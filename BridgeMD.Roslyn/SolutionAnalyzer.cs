using System.Text.RegularExpressions;
using System.Xml.Linq;
using BridgeMD.Core;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;

namespace BridgeMD.Roslyn;

public sealed class SolutionAnalyzer
{
    private static readonly SymbolDisplayFormat FullNameFormat = SymbolDisplayFormat.FullyQualifiedFormat;
    private static readonly SymbolDisplayFormat ShortNameFormat = SymbolDisplayFormat.MinimallyQualifiedFormat;
    private static readonly SemanticDependencyFilter DependencyFilter = new();

    public async Task<SolutionModel> AnalyzeAsync(string solutionPath, CancellationToken cancellationToken = default)
    {
        var fullSolutionPath = Path.GetFullPath(solutionPath);
        if (!File.Exists(fullSolutionPath))
        {
            throw new FileNotFoundException("Solution file not found.", fullSolutionPath);
        }

        EnsureMSBuildRegistered();

        using var workspace = MSBuildWorkspace.Create();
        workspace.WorkspaceFailed += (_, args) =>
        {
            if (args.Diagnostic.Kind == WorkspaceDiagnosticKind.Failure)
            {
                Console.WriteLine($"[Roslyn] {args.Diagnostic.Message}");
            }
        };

        Console.WriteLine($"Loading solution: {fullSolutionPath}");
        var solution = await workspace.OpenSolutionAsync(fullSolutionPath, cancellationToken: cancellationToken);

        var projects = new List<ProjectModel>();
        foreach (var project in solution.Projects.OrderBy(project => project.Name, StringComparer.Ordinal))
        {
            cancellationToken.ThrowIfCancellationRequested();

            Console.WriteLine($"Analyzing project: {project.Name}");
            projects.Add(await AnalyzeProjectAsync(solution, project, cancellationToken));
        }

        return new SolutionModel(
            Path.GetFileNameWithoutExtension(fullSolutionPath),
            fullSolutionPath,
            Path.GetDirectoryName(fullSolutionPath) ?? Directory.GetCurrentDirectory(),
            projects);
    }

    private static async Task<ProjectModel> AnalyzeProjectAsync(
        Solution solution,
        Project project,
        CancellationToken cancellationToken)
    {
        var types = new List<TypeModel>();
        var iocRegistrations = new List<IoCRegistrationModel>();
        var declaredDependencies = ReadDeclaredDependencies(project.FilePath);
        var projectLayer = InferLayer(project.Name, project.Name);

        foreach (var document in project.Documents.Where(document => document.SourceCodeKind == SourceCodeKind.Regular))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var syntaxRoot = await document.GetSyntaxRootAsync(cancellationToken);
            var semanticModel = await document.GetSemanticModelAsync(cancellationToken);
            if (syntaxRoot is null || semanticModel is null)
            {
                continue;
            }

            var declarations = syntaxRoot
                .DescendantNodes()
                .OfType<BaseTypeDeclarationSyntax>()
                .Where(IsSupportedTypeDeclaration);

            foreach (var declaration in declarations)
            {
                if (semanticModel.GetDeclaredSymbol(declaration, cancellationToken) is INamedTypeSymbol symbol)
                {
                    types.Add(CreateTypeModel(project.Name, document.FilePath, symbol, declaration, semanticModel, projectLayer));
                }
            }

            iocRegistrations.AddRange(FindIoCRegistrations(document.FilePath, syntaxRoot, semanticModel));
        }

        var projectReferences = project.ProjectReferences
            .Select(reference =>
            {
                var referencedProject = solution.GetProject(reference.ProjectId);
                return new ProjectReferenceModel(
                    referencedProject?.Name ?? reference.ProjectId.Id.ToString(),
                    referencedProject?.FilePath);
            })
            .OrderBy(reference => reference.Name, StringComparer.Ordinal)
            .ToArray();

        var technologies = DetectProjectTechnologies(declaredDependencies, types, iocRegistrations);

        return new ProjectModel(
            project.Name,
            project.FilePath ?? string.Empty,
            projectLayer,
            ReadTargetFrameworks(project.FilePath),
            projectReferences,
            declaredDependencies,
            technologies,
            iocRegistrations
                .DistinctBy(registration => $"{registration.InterfaceType}->{registration.ImplementationType}:{registration.Location}")
                .OrderBy(registration => registration.InterfaceType, StringComparer.Ordinal)
                .ToArray(),
            types
                .DistinctBy(type => type.FullName)
                .OrderByDescending(type => type.RelevanceScore)
                .ThenBy(type => type.FullName, StringComparer.Ordinal)
                .ToArray());
    }

    private static bool IsSupportedTypeDeclaration(BaseTypeDeclarationSyntax declaration)
    {
        return declaration is ClassDeclarationSyntax
            or InterfaceDeclarationSyntax
            or RecordDeclarationSyntax
            or EnumDeclarationSyntax
            or StructDeclarationSyntax;
    }

    private static TypeModel CreateTypeModel(
        string projectName,
        string? filePath,
        INamedTypeSymbol symbol,
        BaseTypeDeclarationSyntax declaration,
        SemanticModel semanticModel,
        ArchitectureLayer projectLayer)
    {
        var methods = symbol
            .GetMembers()
            .OfType<IMethodSymbol>()
            .Where(method => method.MethodKind == MethodKind.Ordinary)
            .Where(method => method.DeclaredAccessibility == Accessibility.Public)
            .Where(method => method.DeclaringSyntaxReferences.Any(reference => reference.GetSyntax() is MethodDeclarationSyntax))
            .Select(CreateMethodModel)
            .OrderBy(method => method.Name, StringComparer.Ordinal)
            .ToArray();

        var baseType = symbol.TypeKind != TypeKind.Enum && symbol.BaseType is { SpecialType: not SpecialType.System_Object }
            ? CleanName(symbol.BaseType.ToDisplayString(FullNameFormat))
            : null;

        var interfaces = symbol.Interfaces
            .Select(type => CleanName(type.ToDisplayString(FullNameFormat)))
            .Order(StringComparer.Ordinal)
            .ToArray();

        var fullName = CleanName(symbol.ToDisplayString(FullNameFormat));
        var layer = InferLayer(projectName, $"{symbol.ContainingNamespace}.{symbol.Name}");
        if (layer == ArchitectureLayer.Unknown)
        {
            layer = projectLayer;
        }

        var patterns = DetectPatterns(symbol, baseType, interfaces);
        var isGenerated = IsGeneratedCode(filePath, declaration.SyntaxTree.FilePath);
        var isMigration = IsMigration(symbol.Name, symbol.ContainingNamespace?.ToDisplayString(), filePath);
        var summary = ExtractUsefulSummary(symbol);
        var dependencies = FindTypeDependencies(fullName, declaration, semanticModel);
        var technologies = DetectTypeTechnologies(symbol, baseType, interfaces, dependencies, declaration);
        var isDangerousZone = DetectDangerousZone(fullName, filePath, patterns, technologies);
        var role = DetectArchitecturalRole(symbol, declaration, baseType, interfaces, patterns, technologies);
        var relevance = ScoreType(symbol, methods, patterns, technologies, dependencies, role, isGenerated, isMigration, isDangerousZone);

        return new TypeModel(
            symbol.Name,
            fullName,
            GetCodeTypeKind(symbol),
            symbol.ContainingNamespace?.IsGlobalNamespace == false ? symbol.ContainingNamespace.ToDisplayString() : string.Empty,
            projectName,
            filePath,
            layer,
            role,
            baseType,
            interfaces,
            methods,
            patterns,
            technologies,
            dependencies,
            relevance.Category,
            relevance.Score,
            declaration.GetLocation().GetLineSpan().EndLinePosition.Line - declaration.GetLocation().GetLineSpan().StartLinePosition.Line + 1,
            isGenerated,
            isMigration,
            isDangerousZone,
            summary);
    }

    private static MethodModel CreateMethodModel(IMethodSymbol method)
    {
        var parameters = method.Parameters
            .Select(parameter => new ParameterModel(parameter.Name, parameter.Type.ToDisplayString(ShortNameFormat)))
            .ToArray();

        return new MethodModel(
            method.Name,
            method.ReturnType.ToDisplayString(ShortNameFormat),
            parameters,
            method.IsStatic);
    }

    private static CodeTypeKind GetCodeTypeKind(INamedTypeSymbol symbol)
    {
        if (symbol.IsRecord)
        {
            return CodeTypeKind.Record;
        }

        return symbol.TypeKind switch
        {
            TypeKind.Class => CodeTypeKind.Class,
            TypeKind.Interface => CodeTypeKind.Interface,
            TypeKind.Enum => CodeTypeKind.Enum,
            TypeKind.Struct => CodeTypeKind.Struct,
            _ => CodeTypeKind.Class
        };
    }

    private static IReadOnlyList<TypeDependencyModel> FindTypeDependencies(
        string sourceType,
        BaseTypeDeclarationSyntax declaration,
        SemanticModel semanticModel)
    {
        var dependencies = new List<TypeDependencyModel>();

        foreach (var constructor in declaration.DescendantNodes().OfType<ConstructorDeclarationSyntax>())
        {
            foreach (var parameter in constructor.ParameterList.Parameters)
            {
                AddDependency(dependencies, sourceType, semanticModel.GetTypeInfo(parameter.Type!).Type, DependencyKind.ConstructorInjection, constructor.Identifier.Text);
            }
        }

        foreach (var field in declaration.DescendantNodes().OfType<FieldDeclarationSyntax>())
        {
            AddDependency(dependencies, sourceType, semanticModel.GetTypeInfo(field.Declaration.Type).Type, DependencyKind.Field, field.Declaration.Variables.FirstOrDefault()?.Identifier.Text);
        }

        foreach (var property in declaration.DescendantNodes().OfType<PropertyDeclarationSyntax>())
        {
            var kind = property.Type.ToString().Contains("DbSet", StringComparison.Ordinal) ? DependencyKind.DbSet : DependencyKind.Property;
            AddDependency(dependencies, sourceType, semanticModel.GetTypeInfo(property.Type).Type, kind, property.Identifier.Text);
        }

        foreach (var method in declaration.DescendantNodes().OfType<MethodDeclarationSyntax>())
        {
            AddDependency(dependencies, sourceType, semanticModel.GetTypeInfo(method.ReturnType).Type, DependencyKind.ReturnType, method.Identifier.Text);

            foreach (var parameter in method.ParameterList.Parameters)
            {
                AddDependency(dependencies, sourceType, semanticModel.GetTypeInfo(parameter.Type!).Type, DependencyKind.MethodParameter, method.Identifier.Text);
            }
        }

        foreach (var creation in declaration.DescendantNodes().OfType<ObjectCreationExpressionSyntax>())
        {
            AddDependency(dependencies, sourceType, semanticModel.GetTypeInfo(creation.Type).Type, DependencyKind.Instantiation, null);
        }

        return DependencyFilter.Filter(dependencies);
    }

    private static void AddDependency(
        ICollection<TypeDependencyModel> dependencies,
        string sourceType,
        ITypeSymbol? target,
        DependencyKind kind,
        string? memberName)
    {
        if (target is null
            || target.TypeKind == TypeKind.TypeParameter
            || target.TypeKind == TypeKind.Array
            || target.TypeKind == TypeKind.Enum)
        {
            return;
        }

        var targetName = CleanName(target.ToDisplayString(FullNameFormat));
        if (string.IsNullOrWhiteSpace(targetName))
        {
            return;
        }

        dependencies.Add(new TypeDependencyModel(sourceType, targetName, kind, memberName));
    }

    private static IReadOnlyList<IoCRegistrationModel> FindIoCRegistrations(
        string? filePath,
        SyntaxNode syntaxRoot,
        SemanticModel semanticModel)
    {
        var registrations = new List<IoCRegistrationModel>();

        foreach (var invocation in syntaxRoot.DescendantNodes().OfType<InvocationExpressionSyntax>())
        {
            var memberName = (invocation.Expression as MemberAccessExpressionSyntax)?.Name.Identifier.Text;
            if (memberName is not ("RegisterType" or "RegisterInstance" or "Resolve" or "AddScoped" or "AddTransient" or "AddSingleton"))
            {
                continue;
            }

            var typeArguments = (invocation.Expression as MemberAccessExpressionSyntax)?.Name switch
            {
                GenericNameSyntax generic => generic.TypeArgumentList.Arguments,
                _ => default
            };

            var interfaceType = typeArguments.Count > 0
                ? ResolveTypeName(typeArguments[0], semanticModel)
                : ResolveTypeFromArgument(invocation.ArgumentList.Arguments.ElementAtOrDefault(0), semanticModel);
            var implementationType = typeArguments.Count > 1
                ? ResolveTypeName(typeArguments[1], semanticModel)
                : ResolveTypeFromArgument(invocation.ArgumentList.Arguments.ElementAtOrDefault(typeArguments.Count == 1 ? 0 : 1), semanticModel);

            if (implementationType == "unknown")
            {
                implementationType = interfaceType;
            }

            if (interfaceType == "unknown" || IsIoCRegistrationNoise(interfaceType, implementationType))
            {
                continue;
            }

            registrations.Add(new IoCRegistrationModel(
                interfaceType,
                implementationType,
                memberName,
                Path.GetFileName(filePath ?? string.Empty)));
        }

        return registrations;
    }

    private static string ResolveTypeName(TypeSyntax syntax, SemanticModel semanticModel)
    {
        return CleanName((semanticModel.GetTypeInfo(syntax).Type?.ToDisplayString(FullNameFormat) ?? syntax.ToString()));
    }

    private static string ResolveTypeFromArgument(ArgumentSyntax? argument, SemanticModel semanticModel)
    {
        if (argument?.Expression is TypeOfExpressionSyntax typeOfExpression)
        {
            return ResolveTypeName(typeOfExpression.Type, semanticModel);
        }

        if (argument?.Expression is ObjectCreationExpressionSyntax objectCreation)
        {
            return ResolveTypeName(objectCreation.Type, semanticModel);
        }

        return "unknown";
    }

    private static ArchitectureLayer InferLayer(string projectName, string semanticName)
    {
        var value = $"{projectName}.{semanticName}";

        if (ContainsAny(value, ".Tests", "Test.", "Tests.", "Specifications.Tests")) return ArchitectureLayer.Tests;
        if (ContainsAny(value, ".Domain", "Domain.", ".Core.Domain", ".Entities", ".Aggregates")) return ArchitectureLayer.Domain;
        if (projectName.Equals("ApplicationCore", StringComparison.OrdinalIgnoreCase)
            || ContainsAny(value, ".Application.", "Application.", ".UseCases", ".Features", ".Commands", ".Queries", ".Specifications"))
        {
            return ArchitectureLayer.Application;
        }
        if (ContainsAny(value, ".Infrastructure", "Infrastructure.", ".Persistence", ".Data", ".EntityFramework", ".Repositories", ".Roslyn")) return ArchitectureLayer.Infrastructure;
        if (ContainsAny(value, ".Api", ".API", "Api.", "Controllers", ".Endpoints")) return ArchitectureLayer.API;
        if (ContainsAny(value, ".Web", "Web.", ".Mvc", ".Razor", ".Blazor", ".Pages", ".Views", ".Cli")) return ArchitectureLayer.UI;
        if (ContainsAny(value, ".Shared", "Shared.", ".Common", "Common.", ".Abstractions", ".Contracts", ".Core")) return ArchitectureLayer.Shared;
        if (ContainsAny(value, ".Markdown", ".Generation", ".Documentation")) return ArchitectureLayer.Application;

        return ArchitectureLayer.Unknown;
    }

    private static IReadOnlyList<string> DetectPatterns(INamedTypeSymbol symbol, string? baseType, IReadOnlyList<string> interfaces)
    {
        var names = new[] { symbol.Name, baseType ?? string.Empty }
            .Concat(interfaces)
            .ToArray();

        var patterns = new List<string>();
        foreach (var name in names)
        {
            AddIfMatches(name, "UseCase", patterns);
            AddIfMatches(name, "Repository", patterns);
            AddIfMatches(name, "Service", patterns);
            AddIfMatches(name, "Controller", patterns);
            AddIfMatches(name, "DbContext", patterns);
            AddIfMatches(name, "UnitOfWork", patterns);
            AddIfMatches(name, "Specification", patterns);
            AddIfMatches(name, "Handler", patterns);
            AddIfMatches(name, "Dto", patterns);
            AddIfMatches(name, "ViewModel", patterns);
            AddIfMatches(name, "Middleware", patterns);
            AddIfMatches(name, "Analyzer", patterns);
            AddIfMatches(name, "Writer", patterns);
        }

        if (interfaces.Any(name => name.Contains("IRequestHandler", StringComparison.OrdinalIgnoreCase)))
        {
            patterns.Add("CQRS Handler");
        }

        if (interfaces.Any(name => name.Contains("IRequest", StringComparison.OrdinalIgnoreCase)) || symbol.Name.EndsWith("Command", StringComparison.Ordinal))
        {
            patterns.Add("Command");
        }

        if (interfaces.Any(name => name.Contains("IRequest", StringComparison.OrdinalIgnoreCase)) || symbol.Name.EndsWith("Query", StringComparison.Ordinal))
        {
            patterns.Add("Query");
        }

        return patterns
            .Distinct(StringComparer.Ordinal)
            .Order(StringComparer.Ordinal)
            .ToArray();
    }

    private static IReadOnlyList<string> DetectTypeTechnologies(
        INamedTypeSymbol symbol,
        string? baseType,
        IReadOnlyList<string> interfaces,
        IReadOnlyList<TypeDependencyModel> dependencies,
        BaseTypeDeclarationSyntax declaration)
    {
        var signals = new[] { symbol.Name, baseType ?? string.Empty }
            .Concat(interfaces)
            .Concat(dependencies.Select(dependency => dependency.TargetType))
            .ToArray();

        var technologies = new List<string>();
        if (signals.Any(signal => signal.Contains("Microsoft.EntityFrameworkCore", StringComparison.Ordinal))) technologies.Add("Entity Framework Core");
        if (signals.Any(signal => signal.Contains("System.Data.Entity", StringComparison.Ordinal))) technologies.Add("Entity Framework 6");
        if (signals.Any(signal => signal.Contains("DbContext", StringComparison.Ordinal))) technologies.Add("Entity Framework");
        if (signals.Any(signal => signal.Contains("MediatR", StringComparison.Ordinal))) technologies.Add("MediatR");
        if (signals.Any(signal => signal.Contains("IRequest", StringComparison.Ordinal))) technologies.Add("CQRS");
        if (signals.Any(signal => signal.Contains("Controller", StringComparison.Ordinal) || signal.Contains("ControllerBase", StringComparison.Ordinal))) technologies.Add("ASP.NET Controllers");
        if (signals.Any(signal => signal.Contains("Hub", StringComparison.Ordinal))) technologies.Add("SignalR");
        return technologies
            .Distinct(StringComparer.Ordinal)
            .Order(StringComparer.Ordinal)
            .ToArray();
    }

    private static IReadOnlyList<string> DetectProjectTechnologies(
        IReadOnlyList<string> declaredDependencies,
        IReadOnlyList<TypeModel> types,
        IReadOnlyList<IoCRegistrationModel> iocRegistrations)
    {
        var signals = declaredDependencies
            .Concat(types.SelectMany(type => type.Technologies))
            .Concat(types.SelectMany(type => type.Patterns))
            .ToArray();

        var technologies = new List<string>();
        if (signals.Any(signal => signal.Contains("EntityFrameworkCore", StringComparison.OrdinalIgnoreCase) || signal.Contains("Entity Framework Core", StringComparison.OrdinalIgnoreCase))) technologies.Add("Entity Framework Core");
        if (signals.Any(signal => signal.Equals("EntityFramework", StringComparison.OrdinalIgnoreCase) || signal.Contains("EntityFramework.", StringComparison.OrdinalIgnoreCase) || signal.Contains("Entity Framework 6", StringComparison.OrdinalIgnoreCase))) technologies.Add("Entity Framework 6");
        if (signals.Any(signal => signal.Contains("MediatR", StringComparison.OrdinalIgnoreCase))) technologies.Add("MediatR");
        if (signals.Any(signal => signal.Contains("AutoMapper", StringComparison.OrdinalIgnoreCase))) technologies.Add("AutoMapper");
        if (signals.Any(signal => signal.Contains("SignalR", StringComparison.OrdinalIgnoreCase))) technologies.Add("SignalR");
        if (signals.Any(signal => signal.Contains("Microsoft.CodeAnalysis", StringComparison.OrdinalIgnoreCase))) technologies.Add("Roslyn");
        if (signals.Any(signal => signal.Contains("MSBuild", StringComparison.OrdinalIgnoreCase))) technologies.Add("MSBuildWorkspace");
        if (signals.Any(signal => signal.Contains("AspNetCore", StringComparison.OrdinalIgnoreCase))) technologies.Add("ASP.NET Core");
        if (signals.Any(signal => signal.Contains("Microsoft.AspNet.Mvc", StringComparison.OrdinalIgnoreCase))) technologies.Add("ASP.NET MVC");
        if (signals.Any(signal => signal.Contains("Blazor", StringComparison.OrdinalIgnoreCase))) technologies.Add("Blazor");
        if (signals.Any(signal => signal.Contains("Razor", StringComparison.OrdinalIgnoreCase))) technologies.Add("Razor Pages");
        if (signals.Any(signal => signal.Contains("CQRS", StringComparison.OrdinalIgnoreCase) || signal.Contains("Command", StringComparison.OrdinalIgnoreCase) || signal.Contains("Query", StringComparison.OrdinalIgnoreCase))) technologies.Add("CQRS");
        if (declaredDependencies.Any(dependency => dependency.Contains("Unity", StringComparison.OrdinalIgnoreCase)) || iocRegistrations.Count > 0) technologies.Add("Unity IoC");

        return technologies
            .Distinct(StringComparer.Ordinal)
            .Order(StringComparer.Ordinal)
            .ToArray();
    }

    private static ArchitecturalRole DetectArchitecturalRole(
        INamedTypeSymbol symbol,
        BaseTypeDeclarationSyntax declaration,
        string? baseType,
        IReadOnlyList<string> interfaces,
        IReadOnlyList<string> patterns,
        IReadOnlyList<string> technologies)
    {
        var name = symbol.Name;
        var namespaceName = symbol.ContainingNamespace?.ToDisplayString() ?? string.Empty;
        var signals = new[] { name, namespaceName, baseType ?? string.Empty }
            .Concat(interfaces)
            .Concat(patterns)
            .Concat(technologies)
            .ToArray();

        if (signals.Any(signal => signal.EndsWith("Dto", StringComparison.OrdinalIgnoreCase))
            || name.EndsWith("Request", StringComparison.Ordinal)
            || name.EndsWith("Response", StringComparison.Ordinal))
        {
            return ArchitecturalRole.DTO;
        }

        if (signals.Any(signal => signal.Contains("IRequestHandler", StringComparison.OrdinalIgnoreCase))) return ArchitecturalRole.CQRSHandler;
        if (signals.Any(signal => signal.Contains("DbContext", StringComparison.OrdinalIgnoreCase))) return ArchitecturalRole.DbContext;
        if (signals.Any(signal => signal.Contains("ControllerBase", StringComparison.OrdinalIgnoreCase) || signal.EndsWith("Controller", StringComparison.Ordinal))) return ArchitecturalRole.Controller;
        if (name.EndsWith("Endpoint", StringComparison.Ordinal)
            || interfaces.Any(signal => signal.Contains("Endpoint", StringComparison.OrdinalIgnoreCase))
            || (baseType?.Contains("Endpoint", StringComparison.OrdinalIgnoreCase) ?? false))
        {
            return ArchitecturalRole.Endpoint;
        }
        if (signals.Any(signal => signal.Contains("IEntityTypeConfiguration", StringComparison.OrdinalIgnoreCase))) return ArchitecturalRole.Configuration;
        if (signals.Any(signal => signal.Contains("Specification", StringComparison.OrdinalIgnoreCase) || signal.Contains("Spec<", StringComparison.OrdinalIgnoreCase))) return ArchitecturalRole.Specification;
        if (signals.Any(signal => signal.Contains("Repository", StringComparison.OrdinalIgnoreCase))) return ArchitecturalRole.Repository;
        if (signals.Any(signal => signal.Contains("Middleware", StringComparison.OrdinalIgnoreCase))) return ArchitecturalRole.Middleware;
        if (signals.Any(signal => signal.Contains("Profile", StringComparison.OrdinalIgnoreCase) || signal.Contains("IMapper", StringComparison.OrdinalIgnoreCase))) return ArchitecturalRole.Mapper;
        if (signals.Any(signal => signal.Contains("IHostedService", StringComparison.OrdinalIgnoreCase) || signal.EndsWith("HostedService", StringComparison.Ordinal))) return ArchitecturalRole.HostedService;
        if (signals.Any(signal => signal.EndsWith("Decorator", StringComparison.Ordinal))) return ArchitecturalRole.Decorator;
        if (signals.Any(signal => signal.EndsWith("Factory", StringComparison.Ordinal))) return ArchitecturalRole.Factory;
        if (signals.Any(signal => signal.EndsWith("Adapter", StringComparison.Ordinal))) return ArchitecturalRole.Adapter;
        if (signals.Any(signal => signal.EndsWith("ViewModel", StringComparison.OrdinalIgnoreCase))) return ArchitecturalRole.ViewModel;
        if (signals.Any(signal => signal.Contains("Analyzer", StringComparison.OrdinalIgnoreCase))) return ArchitecturalRole.Analyzer;
        if (signals.Any(signal => signal.Contains("Writer", StringComparison.OrdinalIgnoreCase))) return ArchitecturalRole.Writer;
        if (signals.Any(signal => signal.Contains("IRequest", StringComparison.OrdinalIgnoreCase)) && name.EndsWith("Command", StringComparison.Ordinal)) return ArchitecturalRole.Command;
        if (signals.Any(signal => signal.Contains("IRequest", StringComparison.OrdinalIgnoreCase)) || name.EndsWith("Query", StringComparison.Ordinal)) return ArchitecturalRole.Query;
        if (signals.Any(signal => signal.EndsWith("Service", StringComparison.OrdinalIgnoreCase)) && namespaceName.Contains("Domain", StringComparison.OrdinalIgnoreCase)) return ArchitecturalRole.DomainService;
        if (signals.Any(signal => signal.EndsWith("Service", StringComparison.OrdinalIgnoreCase))) return ArchitecturalRole.ApplicationService;
        if (interfaces.Any(interfacename => interfacename.Contains("IAggregateRoot", StringComparison.OrdinalIgnoreCase))) return ArchitecturalRole.AggregateRoot;
        if (namespaceName.Contains("ValueObject", StringComparison.OrdinalIgnoreCase) || name.EndsWith("Value", StringComparison.Ordinal)) return ArchitecturalRole.ValueObject;
        if (namespaceName.Contains("Entities", StringComparison.OrdinalIgnoreCase) && symbol.TypeKind is TypeKind.Class or TypeKind.Struct) return ArchitecturalRole.Entity;

        var hasHttpAttribute = declaration.AttributeLists
            .SelectMany(list => list.Attributes)
            .Select(attribute => attribute.Name.ToString())
            .Any(attributeName => attributeName.StartsWith("Http", StringComparison.OrdinalIgnoreCase)
                || attributeName.Contains("Route", StringComparison.OrdinalIgnoreCase));
        if (hasHttpAttribute)
        {
            return ArchitecturalRole.Endpoint;
        }

        return ArchitecturalRole.Unknown;
    }

    private static (int Score, RelevanceCategory Category) ScoreType(
        INamedTypeSymbol symbol,
        IReadOnlyList<MethodModel> methods,
        IReadOnlyList<string> patterns,
        IReadOnlyList<string> technologies,
        IReadOnlyList<TypeDependencyModel> dependencies,
        ArchitecturalRole role,
        bool isGenerated,
        bool isMigration,
        bool isDangerousZone)
    {
        var score = 10;
        if (symbol.DeclaredAccessibility == Accessibility.Public) score += 8;
        if (methods.Count > 0) score += Math.Min(methods.Count * 2, 16);
        if (dependencies.Count > 0) score += Math.Min(dependencies.Count * 3, 18);
        if (patterns.Any(pattern => pattern is "Service" or "Controller" or "UseCase" or "DbContext" or "Repository" or "UnitOfWork" or "CQRS Handler")) score += 45;
        if (patterns.Any(pattern => pattern is "Command" or "Query" or "Specification")) score += 25;
        if (patterns.Any(pattern => pattern is "Analyzer" or "Writer")) score += 20;
        score += role switch
        {
            ArchitecturalRole.DbContext or ArchitecturalRole.CQRSHandler or ArchitecturalRole.Controller or ArchitecturalRole.Endpoint => 35,
            ArchitecturalRole.Repository or ArchitecturalRole.ApplicationService or ArchitecturalRole.DomainService or ArchitecturalRole.Middleware => 25,
            ArchitecturalRole.Specification or ArchitecturalRole.AggregateRoot or ArchitecturalRole.Configuration or ArchitecturalRole.Decorator => 18,
            ArchitecturalRole.Entity or ArchitecturalRole.Command or ArchitecturalRole.Query or ArchitecturalRole.Mapper => 12,
            ArchitecturalRole.DTO or ArchitecturalRole.ViewModel => -12,
            _ => 0
        };
        if (technologies.Any(technology => technology.Contains("Entity Framework", StringComparison.Ordinal) || technology is "MediatR" or "CQRS" or "Unity IoC")) score += 25;
        if (isDangerousZone) score += 15;
        if (patterns.Any(pattern => pattern is "Dto" or "ViewModel")) score -= 10;
        if (isMigration) score -= 35;
        if (isGenerated) score -= 45;
        if (symbol.TypeKind is TypeKind.Enum) score -= 15;

        score = Math.Clamp(score, 0, 100);
        var category = score >= 65 ? RelevanceCategory.High : score >= 35 ? RelevanceCategory.Medium : RelevanceCategory.Low;
        return (score, category);
    }

    private static bool DetectDangerousZone(
        string fullName,
        string? filePath,
        IReadOnlyList<string> patterns,
        IReadOnlyList<string> technologies)
    {
        var value = $"{fullName} {filePath}";
        return ContainsAny(value, "Migration", "Authentication", "Authorization", "Identity", "Middleware", "Security", "Payment", "Billing")
            || patterns.Any(pattern => pattern is "DbContext" or "Middleware")
            || technologies.Any(technology => technology.Contains("Entity Framework", StringComparison.Ordinal));
    }

    private static bool IsGeneratedCode(string? filePath, string syntaxTreePath)
    {
        var path = filePath ?? syntaxTreePath;
        return ContainsAny(path, ".g.cs", ".g.i.cs", ".designer.cs", ".generated.cs", "/Generated/", "\\Generated\\", "TemporaryGeneratedFile")
            || Path.GetFileName(path).EndsWith(".Designer.cs", StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsMigration(string name, string? namespaceName, string? filePath)
    {
        var value = $"{name} {namespaceName} {filePath}";
        return ContainsAny(value, "Migration", "Migrations", "ModelSnapshot", "Snapshot");
    }

    private static string? ExtractUsefulSummary(INamedTypeSymbol symbol)
    {
        var xml = symbol.GetDocumentationCommentXml();
        if (string.IsNullOrWhiteSpace(xml))
        {
            return null;
        }

        try
        {
            var document = XDocument.Parse($"<root>{xml}</root>");
            var fragments = document.Descendants("summary")
                .Concat(document.Descendants("remarks"))
                .Concat(document.Descendants("param"))
                .Select(element => NormalizeWhitespace(element.Value))
                .Where(text => text.Length >= 12 && !IsLowValueComment(text))
                .Take(3)
                .ToArray();
            var text = string.Join(" ", fragments);
            if (text.Length < 12 || IsLowValueComment(text))
            {
                return null;
            }

            return text.Length > 180 ? $"{text[..177]}..." : text;
        }
        catch
        {
            return null;
        }
    }

    private static bool IsLowValueComment(string text)
    {
        return Regex.IsMatch(text, @"^(gets|sets|gets or sets|initializes|represents)\b", RegexOptions.IgnoreCase)
            || text.Contains("TODO", StringComparison.OrdinalIgnoreCase);
    }

    private static void AddIfMatches(string value, string pattern, ICollection<string> patterns)
    {
        if (value.Contains(pattern, StringComparison.OrdinalIgnoreCase))
        {
            patterns.Add(pattern);
        }
    }

    private static IReadOnlyList<string> ReadTargetFrameworks(string? projectFilePath)
    {
        if (string.IsNullOrWhiteSpace(projectFilePath) || !File.Exists(projectFilePath))
        {
            return [];
        }

        try
        {
            var document = XDocument.Load(projectFilePath);
            var framework = document.Descendants("TargetFramework").FirstOrDefault()?.Value;
            var frameworks = document.Descendants("TargetFrameworks").FirstOrDefault()?.Value;

            return (frameworks ?? framework ?? string.Empty)
                .Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Distinct(StringComparer.Ordinal)
                .Order(StringComparer.Ordinal)
                .ToArray();
        }
        catch
        {
            return [];
        }
    }

    private static IReadOnlyList<string> ReadDeclaredDependencies(string? projectFilePath)
    {
        if (string.IsNullOrWhiteSpace(projectFilePath) || !File.Exists(projectFilePath))
        {
            return [];
        }

        try
        {
            var document = XDocument.Load(projectFilePath);
            var packageReferences = document
                .Descendants("PackageReference")
                .Select(element => element.Attribute("Include")?.Value ?? element.Attribute("Update")?.Value)
                .Where(value => !string.IsNullOrWhiteSpace(value));

            var frameworkReferences = document
                .Descendants("FrameworkReference")
                .Select(element => element.Attribute("Include")?.Value)
                .Where(value => !string.IsNullOrWhiteSpace(value));

            return packageReferences
                .Concat(frameworkReferences)
                .Select(value => value!)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Order(StringComparer.OrdinalIgnoreCase)
                .ToArray();
        }
        catch
        {
            return [];
        }
    }

    private static bool ContainsAny(string value, params string[] candidates)
    {
        return candidates.Any(candidate => value.Contains(candidate, StringComparison.OrdinalIgnoreCase));
    }

    private static bool IsFrameworkType(string typeName)
    {
        return typeName.StartsWith("System.", StringComparison.Ordinal)
            || typeName.StartsWith("Microsoft.", StringComparison.Ordinal)
            || typeName.StartsWith("(", StringComparison.Ordinal)
            || typeName.EndsWith("[]", StringComparison.Ordinal)
            || typeName is "string" or "int" or "bool" or "void" or "object";
    }

    private static bool IsIoCRegistrationNoise(string interfaceType, string implementationType)
    {
        var value = $"{interfaceType} {implementationType}";
        return ContainsAny(value,
            "System.Net.Http.HttpClient",
            "AuthenticationStateProvider",
            "Microsoft.Extensions.",
            "Microsoft.AspNetCore.Components.",
            "Microsoft.AspNetCore.Http.",
            "Microsoft.AspNetCore.Hosting.");
    }

    private static string CleanName(string value)
    {
        return value.Replace("global::", string.Empty, StringComparison.Ordinal);
    }

    private static string NormalizeWhitespace(string value)
    {
        return Regex.Replace(value, @"\s+", " ").Trim();
    }

    private static void EnsureMSBuildRegistered()
    {
        if (MSBuildLocator.IsRegistered)
        {
            return;
        }

        MSBuildLocator.RegisterDefaults();
    }
}
