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

        foreach (var document in project.Documents.Where(document => document.SourceCodeKind == SourceCodeKind.Regular))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var syntaxRoot = await document.GetSyntaxRootAsync(cancellationToken);
            if (syntaxRoot is null)
            {
                continue;
            }

            var semanticModel = await document.GetSemanticModelAsync(cancellationToken);
            if (semanticModel is null)
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
                    types.Add(CreateTypeModel(project.Name, symbol));
                }
            }
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

        return new ProjectModel(
            project.Name,
            project.FilePath ?? string.Empty,
            ReadTargetFrameworks(project.FilePath),
            projectReferences,
            ReadDeclaredDependencies(project.FilePath),
            types
                .DistinctBy(type => type.FullName)
                .OrderBy(type => type.FullName, StringComparer.Ordinal)
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

    private static TypeModel CreateTypeModel(string projectName, INamedTypeSymbol symbol)
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
            ? symbol.BaseType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat).Replace("global::", string.Empty, StringComparison.Ordinal)
            : null;

        var interfaces = symbol.Interfaces
            .Select(type => type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat).Replace("global::", string.Empty, StringComparison.Ordinal))
            .Order(StringComparer.Ordinal)
            .ToArray();

        var fullName = symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)
            .Replace("global::", string.Empty, StringComparison.Ordinal);

        var patterns = DetectPatterns(symbol, baseType, interfaces);

        return new TypeModel(
            symbol.Name,
            fullName,
            GetCodeTypeKind(symbol),
            symbol.ContainingNamespace?.IsGlobalNamespace == false ? symbol.ContainingNamespace.ToDisplayString() : string.Empty,
            projectName,
            baseType,
            interfaces,
            methods,
            patterns);
    }

    private static MethodModel CreateMethodModel(IMethodSymbol method)
    {
        var parameters = method.Parameters
            .Select(parameter => new ParameterModel(
                parameter.Name,
                parameter.Type.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat)))
            .ToArray();

        return new MethodModel(
            method.Name,
            method.ReturnType.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat),
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

    private static IReadOnlyList<string> DetectPatterns(
        INamedTypeSymbol symbol,
        string? baseType,
        IReadOnlyList<string> interfaces)
    {
        var names = new[]
        {
            symbol.Name,
            baseType ?? string.Empty
        }.Concat(interfaces);

        var patterns = new List<string>();
        foreach (var name in names)
        {
            AddIfMatches(name, "UseCase", patterns);
            AddIfMatches(name, "Repository", patterns);
            AddIfMatches(name, "Service", patterns);
            AddIfMatches(name, "Controller", patterns);
            AddIfMatches(name, "DbContext", patterns);
        }

        return patterns
            .Distinct(StringComparer.Ordinal)
            .Order(StringComparer.Ordinal)
            .ToArray();
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

    private static void EnsureMSBuildRegistered()
    {
        if (MSBuildLocator.IsRegistered)
        {
            return;
        }

        MSBuildLocator.RegisterDefaults();
    }
}
