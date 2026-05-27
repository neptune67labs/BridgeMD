using System.Text.RegularExpressions;
using System.Xml.Linq;
using BridgeMD.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BridgeMD.Syntax;

public sealed class SyntaxSolutionAnalyzer
{
    private static readonly string[] IgnoredFolders = ["bin", "obj", ".git", ".vs", "node_modules"];

    public Task<SolutionModel> AnalyzeSolutionAsync(
        string solutionPath,
        AnalysisOptions? options = null,
        IReadOnlyList<AnalysisDiagnostic>? diagnostics = null,
        TimeSpan? elapsed = null,
        CancellationToken cancellationToken = default)
    {
        options ??= new AnalysisOptions();
        var fullSolutionPath = Path.GetFullPath(solutionPath);
        var rootPath = Path.GetDirectoryName(fullSolutionPath) ?? Directory.GetCurrentDirectory();
        var projectPaths = DiscoverProjectPaths(fullSolutionPath, options).ToArray();
        var projects = projectPaths
            .Select(projectPath => AnalyzeProject(projectPath, options, cancellationToken))
            .Where(project => project is not null)
            .Cast<ProjectModel>()
            .OrderBy(project => project.Name, StringComparer.Ordinal)
            .ToArray();

        var summary = new AnalysisSummary(
            projectPaths.Length,
            ProjectsAnalyzedSemantically: 0,
            projects.Length,
            projectPaths.Length - projects.Length,
            elapsed ?? TimeSpan.Zero,
            diagnostics ?? []);

        return Task.FromResult(new SolutionModel(
            Path.GetFileNameWithoutExtension(fullSolutionPath),
            fullSolutionPath,
            rootPath,
            projects,
            summary));
    }

    public ProjectModel? AnalyzeProject(string projectPath, AnalysisOptions? options = null, CancellationToken cancellationToken = default)
    {
        options ??= new AnalysisOptions();
        var fullProjectPath = Path.GetFullPath(projectPath);
        if (!File.Exists(fullProjectPath) || IsProjectExcluded(fullProjectPath, options))
        {
            return null;
        }

        var projectName = Path.GetFileNameWithoutExtension(fullProjectPath);
        var projectDir = Path.GetDirectoryName(fullProjectPath) ?? Directory.GetCurrentDirectory();
        var sourceFiles = EnumerateSourceFiles(projectDir, options).ToArray();
        var types = new List<TypeModel>();
        var registrations = new List<IoCRegistrationModel>();

        foreach (var file in sourceFiles)
        {
            cancellationToken.ThrowIfCancellationRequested();
            SyntaxTree tree;
            try
            {
                tree = CSharpSyntaxTree.ParseText(File.ReadAllText(file), path: file, cancellationToken: cancellationToken);
            }
            catch
            {
                continue;
            }

            if (tree.GetRoot(cancellationToken) is not CompilationUnitSyntax root)
            {
                continue;
            }

            registrations.AddRange(FindIoCRegistrations(file, root));
            foreach (var declaration in root.DescendantNodes().OfType<BaseTypeDeclarationSyntax>().Where(IsSupportedTypeDeclaration))
            {
                types.Add(CreateTypeModel(projectName, file, declaration));
            }
        }

        return new ProjectModel(
            projectName,
            fullProjectPath,
            InferLayer(projectName, projectName),
            ReadTargetFrameworks(fullProjectPath),
            ReadProjectReferences(fullProjectPath),
            ReadDeclaredDependencies(fullProjectPath),
            DetectProjectTechnologies(fullProjectPath, types, registrations),
            registrations
                .DistinctBy(registration => $"{registration.InterfaceType}->{registration.ImplementationType}:{registration.Location}")
                .OrderBy(registration => registration.InterfaceType, StringComparer.Ordinal)
                .ToArray(),
            types
                .DistinctBy(type => type.FullName)
                .OrderByDescending(type => type.RelevanceScore)
                .ThenBy(type => type.FullName, StringComparer.Ordinal)
                .ToArray());
    }

    public IReadOnlyList<string> DiscoverProjectPaths(string solutionPath, AnalysisOptions? options = null)
    {
        options ??= new AnalysisOptions();
        var fullSolutionPath = Path.GetFullPath(solutionPath);
        var rootPath = Path.GetDirectoryName(fullSolutionPath) ?? Directory.GetCurrentDirectory();
        var fromSolution = File.ReadLines(fullSolutionPath)
            .Select(line => Regex.Match(line, "\"(?<path>[^\"]+\\.(?:csproj|vbproj|fsproj))\"", RegexOptions.IgnoreCase))
            .Where(match => match.Success)
            .Select(match => match.Groups["path"].Value.Replace('\\', Path.DirectorySeparatorChar))
            .Select(path => Path.GetFullPath(Path.Combine(rootPath, path)))
            .Where(path => path.EndsWith(".csproj", StringComparison.OrdinalIgnoreCase))
            .Where(path => !IsProjectExcluded(path, options))
            .Where(path => string.IsNullOrWhiteSpace(options.SolutionFilter) || GlobMatches(Path.GetFileNameWithoutExtension(path), options.SolutionFilter!))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToArray();

        if (fromSolution.Length > 0)
        {
            return fromSolution;
        }

        return Directory.EnumerateFiles(rootPath, "*.csproj", SearchOption.AllDirectories)
            .Where(path => !IsExcludedFolder(path, options))
            .Where(path => !IsProjectExcluded(path, options))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToArray();
    }

    private static TypeModel CreateTypeModel(string projectName, string filePath, BaseTypeDeclarationSyntax declaration)
    {
        var namespaceName = FindNamespace(declaration);
        var name = declaration switch
        {
            ClassDeclarationSyntax node => node.Identifier.Text,
            InterfaceDeclarationSyntax node => node.Identifier.Text,
            RecordDeclarationSyntax node => node.Identifier.Text,
            StructDeclarationSyntax node => node.Identifier.Text,
            EnumDeclarationSyntax node => node.Identifier.Text,
            _ => declaration.Identifier.Text
        };
        var fullName = string.IsNullOrWhiteSpace(namespaceName) ? name : $"{namespaceName}.{name}";
        var baseTypes = declaration.BaseList?.Types.Select(type => type.Type.ToString()).ToArray() ?? [];
        var baseType = declaration is InterfaceDeclarationSyntax or EnumDeclarationSyntax ? null : baseTypes.FirstOrDefault();
        var interfaces = declaration is InterfaceDeclarationSyntax
            ? baseTypes
            : baseTypes.Skip(baseType is null ? 0 : 1).ToArray();
        var layer = InferLayer(projectName, fullName);
        var patterns = DetectPatterns(name, baseType, interfaces);
        var technologies = DetectTypeTechnologies(name, baseType, interfaces, declaration);
        var role = DetectArchitecturalRole(name, namespaceName, baseType, interfaces, patterns, technologies, declaration);
        var members = declaration is TypeDeclarationSyntax typeDeclaration ? typeDeclaration.Members : [];
        var methods = members
            .OfType<MethodDeclarationSyntax>()
            .Where(method => method.Modifiers.Any(SyntaxKind.PublicKeyword))
            .Select(method => new MethodModel(
                method.Identifier.Text,
                method.ReturnType.ToString(),
                method.ParameterList.Parameters.Select(parameter => new ParameterModel(parameter.Identifier.Text, parameter.Type?.ToString() ?? "unknown")).ToArray(),
                method.Modifiers.Any(SyntaxKind.StaticKeyword)))
            .OrderBy(method => method.Name, StringComparer.Ordinal)
            .ToArray();
        var dependencies = FindTypeDependencies(fullName, declaration);
        var isGenerated = IsGeneratedCode(filePath);
        var isMigration = IsMigration(name, namespaceName, filePath);
        var isDangerous = DetectDangerousZone(fullName, filePath, patterns, technologies);
        var relevance = ScoreType(methods, patterns, technologies, dependencies, role, isGenerated, isMigration, isDangerous);

        return new TypeModel(
            name,
            fullName,
            GetCodeTypeKind(declaration),
            namespaceName,
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
            isDangerous,
            ExtractUsefulSummary(declaration));
    }

    private static IReadOnlyList<TypeDependencyModel> FindTypeDependencies(string sourceType, BaseTypeDeclarationSyntax declaration)
    {
        var dependencies = new List<TypeDependencyModel>();
        foreach (var constructor in declaration.DescendantNodes().OfType<ConstructorDeclarationSyntax>())
        {
            foreach (var parameter in constructor.ParameterList.Parameters)
            {
                AddDependency(dependencies, sourceType, parameter.Type?.ToString(), DependencyKind.ConstructorInjection, constructor.Identifier.Text);
            }
        }

        foreach (var field in declaration.DescendantNodes().OfType<FieldDeclarationSyntax>())
        {
            AddDependency(dependencies, sourceType, field.Declaration.Type.ToString(), DependencyKind.Field, field.Declaration.Variables.FirstOrDefault()?.Identifier.Text);
        }

        foreach (var property in declaration.DescendantNodes().OfType<PropertyDeclarationSyntax>())
        {
            var target = property.Type.ToString();
            AddDependency(dependencies, sourceType, target, target.Contains("DbSet", StringComparison.Ordinal) ? DependencyKind.DbSet : DependencyKind.Property, property.Identifier.Text);
        }

        foreach (var creation in declaration.DescendantNodes().OfType<ObjectCreationExpressionSyntax>())
        {
            AddDependency(dependencies, sourceType, creation.Type.ToString(), DependencyKind.Instantiation, null);
        }

        return dependencies
            .Where(dependency => !IsDependencyNoise(dependency.TargetType))
            .DistinctBy(dependency => $"{dependency.SourceType}->{dependency.TargetType}:{dependency.Kind}:{dependency.MemberName}")
            .OrderBy(dependency => dependency.TargetType, StringComparer.Ordinal)
            .ToArray();
    }

    private static void AddDependency(ICollection<TypeDependencyModel> dependencies, string sourceType, string? targetType, DependencyKind kind, string? memberName)
    {
        if (string.IsNullOrWhiteSpace(targetType) || IsDependencyNoise(targetType))
        {
            return;
        }

        dependencies.Add(new TypeDependencyModel(sourceType, targetType, kind, memberName));
    }

    private static IReadOnlyList<IoCRegistrationModel> FindIoCRegistrations(string filePath, CompilationUnitSyntax root)
    {
        var registrations = new List<IoCRegistrationModel>();
        foreach (var invocation in root.DescendantNodes().OfType<InvocationExpressionSyntax>())
        {
            var memberAccess = invocation.Expression as MemberAccessExpressionSyntax;
            var memberName = memberAccess?.Name.Identifier.Text;
            if (memberName is not ("RegisterType" or "RegisterInstance" or "Resolve" or "AddScoped" or "AddTransient" or "AddSingleton"))
            {
                continue;
            }

            var typeArguments = memberAccess?.Name is GenericNameSyntax generic
                ? generic.TypeArgumentList.Arguments.Select(argument => argument.ToString()).ToArray()
                : [];
            var interfaceType = typeArguments.ElementAtOrDefault(0) ?? ResolveTypeFromArgument(invocation.ArgumentList.Arguments.ElementAtOrDefault(0));
            var implementationType = typeArguments.ElementAtOrDefault(1) ?? ResolveTypeFromArgument(invocation.ArgumentList.Arguments.ElementAtOrDefault(typeArguments.Length == 1 ? 0 : 1));
            if (implementationType == "unknown")
            {
                implementationType = interfaceType;
            }

            if (interfaceType == "unknown" || IsDependencyNoise(interfaceType))
            {
                continue;
            }

            registrations.Add(new IoCRegistrationModel(interfaceType, implementationType, memberName, Path.GetFileName(filePath)));
        }

        return registrations;
    }

    private static string ResolveTypeFromArgument(ArgumentSyntax? argument)
    {
        return argument?.Expression switch
        {
            TypeOfExpressionSyntax typeOfExpression => typeOfExpression.Type.ToString(),
            ObjectCreationExpressionSyntax objectCreation => objectCreation.Type.ToString(),
            _ => "unknown"
        };
    }

    private static IEnumerable<string> EnumerateSourceFiles(string rootPath, AnalysisOptions options)
    {
        return Directory.EnumerateFiles(rootPath, "*.cs", SearchOption.AllDirectories)
            .Where(path => !IsGeneratedCode(path))
            .Where(path => !IsExcludedFolder(path, options));
    }

    private static bool IsExcludedFolder(string path, AnalysisOptions options)
    {
        var segments = path.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        if (segments.Any(segment => IgnoredFolders.Contains(segment, StringComparer.OrdinalIgnoreCase)))
        {
            return true;
        }

        return (options.ExcludedFolders ?? []).Any(pattern => GlobMatches(path, pattern));
    }

    private static bool IsProjectExcluded(string projectPath, AnalysisOptions options)
    {
        var name = Path.GetFileNameWithoutExtension(projectPath);
        return (options.ExcludedProjects ?? []).Any(pattern => GlobMatches(name, pattern) || GlobMatches(projectPath, pattern));
    }

    private static bool GlobMatches(string value, string pattern)
    {
        var regex = "^" + Regex.Escape(pattern).Replace("\\*", ".*", StringComparison.Ordinal).Replace("\\?", ".", StringComparison.Ordinal) + "$";
        return Regex.IsMatch(value, regex, RegexOptions.IgnoreCase);
    }

    private static IReadOnlyList<ProjectReferenceModel> ReadProjectReferences(string? projectPath)
    {
        if (projectPath is null || !File.Exists(projectPath))
        {
            return [];
        }

        try
        {
            var projectDir = Path.GetDirectoryName(projectPath) ?? Directory.GetCurrentDirectory();
            return XDocument.Load(projectPath)
                .Descendants()
                .Where(element => element.Name.LocalName == "ProjectReference")
                .Select(element => element.Attribute("Include")?.Value)
                .Where(include => !string.IsNullOrWhiteSpace(include))
                .Select(include => Path.GetFullPath(Path.Combine(projectDir, include!)))
                .Select(path => new ProjectReferenceModel(Path.GetFileNameWithoutExtension(path), path))
                .OrderBy(reference => reference.Name, StringComparer.Ordinal)
                .ToArray();
        }
        catch
        {
            return [];
        }
    }

    private static IReadOnlyList<string> ReadTargetFrameworks(string? projectPath)
    {
        return ReadProjectValues(projectPath, "TargetFramework")
            .Concat(ReadProjectValues(projectPath, "TargetFrameworks").SelectMany(value => value.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)))
            .Distinct(StringComparer.Ordinal)
            .Order(StringComparer.Ordinal)
            .ToArray();
    }

    private static IReadOnlyList<string> ReadDeclaredDependencies(string? projectPath)
    {
        if (projectPath is null || !File.Exists(projectPath))
        {
            return [];
        }

        try
        {
            return XDocument.Load(projectPath)
                .Descendants()
                .Where(element => element.Name.LocalName == "PackageReference" || element.Name.LocalName == "Reference")
                .Select(element => element.Attribute("Include")?.Value)
                .Where(value => !string.IsNullOrWhiteSpace(value))
                .Select(value => value!.Split(',')[0].Trim())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Order(StringComparer.OrdinalIgnoreCase)
                .ToArray();
        }
        catch
        {
            return [];
        }
    }

    private static IEnumerable<string> ReadProjectValues(string? projectPath, string elementName)
    {
        if (projectPath is null || !File.Exists(projectPath))
        {
            return [];
        }

        try
        {
            return XDocument.Load(projectPath)
                .Descendants()
                .Where(element => element.Name.LocalName == elementName)
                .Select(element => element.Value)
                .Where(value => !string.IsNullOrWhiteSpace(value))
                .ToArray();
        }
        catch
        {
            return [];
        }
    }

    private static string FindNamespace(SyntaxNode declaration)
    {
        return declaration.Ancestors()
            .OfType<BaseNamespaceDeclarationSyntax>()
            .FirstOrDefault()
            ?.Name
            .ToString() ?? string.Empty;
    }

    private static bool IsSupportedTypeDeclaration(BaseTypeDeclarationSyntax declaration)
    {
        return declaration is ClassDeclarationSyntax
            or InterfaceDeclarationSyntax
            or RecordDeclarationSyntax
            or EnumDeclarationSyntax
            or StructDeclarationSyntax;
    }

    private static CodeTypeKind GetCodeTypeKind(BaseTypeDeclarationSyntax declaration)
    {
        return declaration switch
        {
            InterfaceDeclarationSyntax => CodeTypeKind.Interface,
            RecordDeclarationSyntax => CodeTypeKind.Record,
            EnumDeclarationSyntax => CodeTypeKind.Enum,
            StructDeclarationSyntax => CodeTypeKind.Struct,
            _ => CodeTypeKind.Class
        };
    }

    private static ArchitectureLayer InferLayer(string projectName, string semanticName)
    {
        var value = $"{projectName}.{semanticName}";
        if (ContainsAny(value, ".Tests", "Test.", "Tests.")) return ArchitectureLayer.Tests;
        if (ContainsAny(value, ".Domain", "Domain.", ".Core.Domain", ".Entities", ".Aggregates")) return ArchitectureLayer.Domain;
        if (projectName.Equals("ApplicationCore", StringComparison.OrdinalIgnoreCase) || ContainsAny(value, ".Application.", "Application.", ".UseCases", ".Features", ".Commands", ".Queries", ".Specifications")) return ArchitectureLayer.Application;
        if (ContainsAny(value, ".Infrastructure", "Infrastructure.", ".Persistence", ".Data", ".EntityFramework", ".Repositories", ".Roslyn")) return ArchitectureLayer.Infrastructure;
        if (ContainsAny(value, ".Api", ".API", "Api.", "Controllers", ".Endpoints")) return ArchitectureLayer.API;
        if (ContainsAny(value, ".Web", "Web.", ".Mvc", ".Razor", ".Blazor", ".Pages", ".Views", ".Cli")) return ArchitectureLayer.UI;
        if (ContainsAny(value, ".Shared", "Shared.", ".Common", "Common.", ".Abstractions", ".Contracts", ".Core")) return ArchitectureLayer.Shared;
        if (ContainsAny(value, ".Markdown", ".Generation", ".Documentation")) return ArchitectureLayer.Application;
        return ArchitectureLayer.Unknown;
    }

    private static IReadOnlyList<string> DetectPatterns(string name, string? baseType, IReadOnlyList<string> interfaces)
    {
        var signals = new[] { name, baseType ?? string.Empty }.Concat(interfaces).ToArray();
        var patterns = new List<string>();
        foreach (var signal in signals)
        {
            AddIfMatches(signal, "UseCase", patterns);
            AddIfMatches(signal, "Repository", patterns);
            AddIfMatches(signal, "Service", patterns);
            AddIfMatches(signal, "Controller", patterns);
            AddIfMatches(signal, "DbContext", patterns);
            AddIfMatches(signal, "UnitOfWork", patterns);
            AddIfMatches(signal, "Specification", patterns);
            AddIfMatches(signal, "Handler", patterns);
            AddIfMatches(signal, "Dto", patterns);
            AddIfMatches(signal, "ViewModel", patterns);
            AddIfMatches(signal, "Middleware", patterns);
            AddIfMatches(signal, "Analyzer", patterns);
            AddIfMatches(signal, "Writer", patterns);
        }

        if (signals.Any(signal => signal.Contains("IRequestHandler", StringComparison.OrdinalIgnoreCase))) patterns.Add("CQRS Handler");
        if (signals.Any(signal => signal.Contains("IRequest", StringComparison.OrdinalIgnoreCase)) || name.EndsWith("Command", StringComparison.Ordinal)) patterns.Add("Command");
        if (signals.Any(signal => signal.Contains("IRequest", StringComparison.OrdinalIgnoreCase)) || name.EndsWith("Query", StringComparison.Ordinal)) patterns.Add("Query");
        return patterns.Distinct(StringComparer.Ordinal).Order(StringComparer.Ordinal).ToArray();
    }

    private static IReadOnlyList<string> DetectTypeTechnologies(string name, string? baseType, IReadOnlyList<string> interfaces, BaseTypeDeclarationSyntax declaration)
    {
        var signals = new[] { name, baseType ?? string.Empty }
            .Concat(interfaces)
            .Concat(declaration.DescendantNodes().OfType<IdentifierNameSyntax>().Select(identifier => identifier.Identifier.Text))
            .ToArray();
        var technologies = new List<string>();
        if (signals.Any(signal => signal.Contains("EntityFrameworkCore", StringComparison.Ordinal) || signal.Contains("DbContext", StringComparison.Ordinal))) technologies.Add("Entity Framework");
        if (signals.Any(signal => signal.Contains("MediatR", StringComparison.Ordinal) || signal.Contains("IRequest", StringComparison.Ordinal))) technologies.Add("MediatR");
        if (signals.Any(signal => signal.Contains("IRequest", StringComparison.Ordinal))) technologies.Add("CQRS");
        if (signals.Any(signal => signal.Contains("Controller", StringComparison.Ordinal) || signal.Contains("ControllerBase", StringComparison.Ordinal))) technologies.Add("ASP.NET Controllers");
        if (signals.Any(signal => signal.Contains("Hub", StringComparison.Ordinal))) technologies.Add("SignalR");
        return technologies.Distinct(StringComparer.Ordinal).Order(StringComparer.Ordinal).ToArray();
    }

    private static IReadOnlyList<string> DetectProjectTechnologies(string projectPath, IReadOnlyList<TypeModel> types, IReadOnlyList<IoCRegistrationModel> registrations)
    {
        var dependencies = ReadDeclaredDependencies(projectPath);
        var signals = dependencies.Concat(types.SelectMany(type => type.Technologies)).Concat(types.SelectMany(type => type.Patterns)).ToArray();
        var technologies = new List<string>();
        if (signals.Any(signal => signal.Contains("EntityFrameworkCore", StringComparison.OrdinalIgnoreCase))) technologies.Add("Entity Framework Core");
        if (signals.Any(signal => signal.Equals("EntityFramework", StringComparison.OrdinalIgnoreCase) || signal.Contains("EntityFramework.", StringComparison.OrdinalIgnoreCase))) technologies.Add("Entity Framework 6");
        if (signals.Any(signal => signal.Contains("MediatR", StringComparison.OrdinalIgnoreCase))) technologies.Add("MediatR");
        if (signals.Any(signal => signal.Contains("AutoMapper", StringComparison.OrdinalIgnoreCase))) technologies.Add("AutoMapper");
        if (signals.Any(signal => signal.Contains("AspNetCore", StringComparison.OrdinalIgnoreCase))) technologies.Add("ASP.NET Core");
        if (signals.Any(signal => signal.Contains("Microsoft.AspNet.Mvc", StringComparison.OrdinalIgnoreCase))) technologies.Add("ASP.NET MVC");
        if (signals.Any(signal => signal.Contains("Blazor", StringComparison.OrdinalIgnoreCase))) technologies.Add("Blazor");
        if (signals.Any(signal => signal.Contains("Razor", StringComparison.OrdinalIgnoreCase))) technologies.Add("Razor Pages");
        if (signals.Any(signal => signal.Contains("CQRS", StringComparison.OrdinalIgnoreCase) || signal.Contains("Command", StringComparison.OrdinalIgnoreCase) || signal.Contains("Query", StringComparison.OrdinalIgnoreCase))) technologies.Add("CQRS");
        if (dependencies.Any(dependency => dependency.Contains("Unity", StringComparison.OrdinalIgnoreCase)) || registrations.Count > 0) technologies.Add("Unity IoC");
        return technologies.Distinct(StringComparer.Ordinal).Order(StringComparer.Ordinal).ToArray();
    }

    private static ArchitecturalRole DetectArchitecturalRole(
        string name,
        string namespaceName,
        string? baseType,
        IReadOnlyList<string> interfaces,
        IReadOnlyList<string> patterns,
        IReadOnlyList<string> technologies,
        BaseTypeDeclarationSyntax declaration)
    {
        var signals = new[] { name, namespaceName, baseType ?? string.Empty }.Concat(interfaces).Concat(patterns).Concat(technologies).ToArray();
        if (signals.Any(signal => signal.EndsWith("Dto", StringComparison.OrdinalIgnoreCase)) || name.EndsWith("Request", StringComparison.Ordinal) || name.EndsWith("Response", StringComparison.Ordinal)) return ArchitecturalRole.DTO;
        if (signals.Any(signal => signal.Contains("IRequestHandler", StringComparison.OrdinalIgnoreCase))) return ArchitecturalRole.CQRSHandler;
        if (signals.Any(signal => signal.Contains("DbContext", StringComparison.OrdinalIgnoreCase))) return ArchitecturalRole.DbContext;
        if (signals.Any(signal => signal.Contains("ControllerBase", StringComparison.OrdinalIgnoreCase) || signal.EndsWith("Controller", StringComparison.Ordinal))) return ArchitecturalRole.Controller;
        if (name.EndsWith("Endpoint", StringComparison.Ordinal) || interfaces.Any(signal => signal.Contains("Endpoint", StringComparison.OrdinalIgnoreCase)) || (baseType?.Contains("Endpoint", StringComparison.OrdinalIgnoreCase) ?? false)) return ArchitecturalRole.Endpoint;
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
        if (interfaces.Any(interfaceName => interfaceName.Contains("IAggregateRoot", StringComparison.OrdinalIgnoreCase))) return ArchitecturalRole.AggregateRoot;
        if (namespaceName.Contains("ValueObject", StringComparison.OrdinalIgnoreCase) || name.EndsWith("Value", StringComparison.Ordinal)) return ArchitecturalRole.ValueObject;
        if (namespaceName.Contains("Entities", StringComparison.OrdinalIgnoreCase) && declaration is ClassDeclarationSyntax or StructDeclarationSyntax) return ArchitecturalRole.Entity;
        if (declaration.AttributeLists.SelectMany(list => list.Attributes).Select(attribute => attribute.Name.ToString()).Any(attribute => attribute.StartsWith("Http", StringComparison.OrdinalIgnoreCase) || attribute.Contains("Route", StringComparison.OrdinalIgnoreCase))) return ArchitecturalRole.Endpoint;
        return ArchitecturalRole.Unknown;
    }

    private static (int Score, RelevanceCategory Category) ScoreType(
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
        if (methods.Count > 0) score += Math.Min(methods.Count * 2, 16);
        if (dependencies.Count > 0) score += Math.Min(dependencies.Count * 3, 18);
        if (patterns.Any(pattern => pattern is "Service" or "Controller" or "UseCase" or "DbContext" or "Repository" or "UnitOfWork" or "CQRS Handler")) score += 45;
        if (patterns.Any(pattern => pattern is "Command" or "Query" or "Specification")) score += 25;
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
        score = Math.Clamp(score, 0, 100);
        return (score, score >= 65 ? RelevanceCategory.High : score >= 35 ? RelevanceCategory.Medium : RelevanceCategory.Low);
    }

    private static string? ExtractUsefulSummary(BaseTypeDeclarationSyntax declaration)
    {
        var trivia = declaration.GetLeadingTrivia().Select(trivia => trivia.ToFullString()).FirstOrDefault(text => text.Contains("<summary>", StringComparison.OrdinalIgnoreCase));
        if (string.IsNullOrWhiteSpace(trivia))
        {
            return null;
        }

        var summary = Regex.Replace(trivia, @"</?summary>|///", string.Empty, RegexOptions.IgnoreCase).Trim();
        summary = Regex.Replace(summary, @"\s+", " ");
        if (summary.Length < 12 || summary.StartsWith("Gets or sets", StringComparison.OrdinalIgnoreCase))
        {
            return null;
        }

        return summary.Length > 240 ? summary[..240] : summary;
    }

    private static bool DetectDangerousZone(string fullName, string? filePath, IReadOnlyList<string> patterns, IReadOnlyList<string> technologies)
    {
        var value = $"{fullName} {filePath}";
        return ContainsAny(value, "Migration", "Authentication", "Authorization", "Identity", "Middleware", "Security", "Payment", "Billing")
            || patterns.Any(pattern => pattern is "DbContext" or "Middleware")
            || technologies.Any(technology => technology.Contains("Entity Framework", StringComparison.Ordinal));
    }

    private static bool IsGeneratedCode(string path)
    {
        return ContainsAny(path, ".g.cs", ".g.i.cs", ".designer.cs", ".generated.cs", "/Generated/", "\\Generated\\", "TemporaryGeneratedFile")
            || Path.GetFileName(path).EndsWith(".Designer.cs", StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsMigration(string name, string namespaceName, string? filePath)
    {
        var value = $"{name} {namespaceName} {filePath}";
        return ContainsAny(value, "Migration", "Migrations", "ModelSnapshot", "Snapshot");
    }

    private static bool IsDependencyNoise(string value)
    {
        string[] noise = ["string", "int", "bool", "decimal", "double", "float", "Guid", "DateTime", "Task", "IEnumerable", "List", "Dictionary", "CancellationToken", "ILogger", "IConfiguration", "IOptions"];
        return noise.Any(item => value.Equals(item, StringComparison.OrdinalIgnoreCase) || value.StartsWith($"{item}<", StringComparison.OrdinalIgnoreCase));
    }

    private static void AddIfMatches(string value, string pattern, ICollection<string> patterns)
    {
        if (value.Contains(pattern, StringComparison.OrdinalIgnoreCase))
        {
            patterns.Add(pattern);
        }
    }

    private static bool ContainsAny(string value, params string[] candidates)
    {
        return candidates.Any(candidate => value.Contains(candidate, StringComparison.OrdinalIgnoreCase));
    }
}
