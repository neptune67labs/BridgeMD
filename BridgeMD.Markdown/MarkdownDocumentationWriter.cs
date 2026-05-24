using System.Text;
using BridgeMD.Core;

namespace BridgeMD.Markdown;

public sealed class MarkdownDocumentationWriter
{
    public async Task WriteAsync(SolutionModel solution, CancellationToken cancellationToken = default)
    {
        var docsPath = Path.Combine(solution.RootPath, "docs");
        Directory.CreateDirectory(docsPath);

        var files = new Dictionary<string, string>
        {
            ["solution-overview.md"] = RenderSolutionOverview(solution),
            ["project-index.md"] = RenderProjectIndex(solution),
            ["type-index.md"] = RenderTypeIndex(solution),
            ["AI_CONTEXT.md"] = RenderAiContext(solution),
            ["ARCHITECTURE.md"] = RenderArchitecture(solution),
            ["DEPENDENCY_GRAPH.md"] = RenderDependencyGraph(solution),
            ["CONVENTIONS.md"] = RenderConventions(solution),
            ["DOMAINS.md"] = RenderDomains(solution),
            ["DANGEROUS_ZONES.md"] = RenderDangerousZones(solution)
        };

        foreach (var file in files)
        {
            await File.WriteAllTextAsync(Path.Combine(docsPath, file.Key), file.Value, cancellationToken);
        }
    }

    private static string RenderSolutionOverview(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Solution Overview");
        builder.AppendLine();
        builder.AppendLine("| Field | Value |");
        builder.AppendLine("| --- | --- |");
        builder.AppendLine($"| Solution | `{Escape(solution.Name)}` |");
        builder.AppendLine($"| Projects | {solution.Projects.Count} |");
        builder.AppendLine($"| Types | {solution.TypeCount} |");
        builder.AppendLine($"| Root | `{Escape(solution.RootPath)}` |");
        builder.AppendLine($"| Architecture | {InlineList(InferArchitectures(solution))} |");
        builder.AppendLine($"| Technologies | {InlineList(AllTechnologies(solution))} |");
        builder.AppendLine();

        builder.AppendLine("## Projects");
        builder.AppendLine();
        builder.AppendLine("| Project | Layer | Frameworks | Types | Patterns |");
        builder.AppendLine("| --- | --- | --- | ---: | --- |");
        foreach (var project in solution.Projects)
        {
            builder.AppendLine($"| `{Escape(project.Name)}` | {project.Layer} | {InlineList(project.TargetFrameworks)} | {project.Types.Count} | {InlineList(project.Patterns)} |");
        }

        builder.AppendLine();
        builder.AppendLine("## Project Relations");
        builder.AppendLine();
        builder.AppendLine("| From | To |");
        builder.AppendLine("| --- | --- |");
        foreach (var project in solution.Projects)
        {
            if (project.ProjectReferences.Count == 0)
            {
                builder.AppendLine($"| `{Escape(project.Name)}` | none |");
                continue;
            }

            foreach (var reference in project.ProjectReferences)
            {
                builder.AppendLine($"| `{Escape(project.Name)}` | `{Escape(reference.Name)}` |");
            }
        }

        builder.AppendLine();
        builder.AppendLine("## Main Namespaces");
        builder.AppendLine();
        foreach (var namespaceName in solution.Namespaces.Take(100))
        {
            builder.AppendLine($"- `{Escape(namespaceName)}`");
        }

        return builder.ToString();
    }

    private static string RenderProjectIndex(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Project Index");
        builder.AppendLine();

        foreach (var project in solution.Projects)
        {
            builder.AppendLine($"## {Escape(project.Name)}");
            builder.AppendLine();
            builder.AppendLine($"- Layer: `{project.Layer}`");
            builder.AppendLine($"- Purpose: {InferPurpose(project)}");
            builder.AppendLine($"- Frameworks: {InlineList(project.TargetFrameworks)}");
            builder.AppendLine($"- Project references: {InlineList(project.ProjectReferences.Select(reference => reference.Name))}");
            builder.AppendLine($"- Declared dependencies: {InlineList(project.DeclaredDependencies)}");
            builder.AppendLine($"- Technologies: {InlineList(project.Technologies)}");
            builder.AppendLine($"- Detected patterns: {InlineList(project.Patterns)}");
            builder.AppendLine();
            builder.AppendLine("| Type | Layer | Score | Category | Patterns |");
            builder.AppendLine("| --- | --- | ---: | --- | --- |");

            foreach (var type in PrimaryTypes(project.Types).Take(80))
            {
                builder.AppendLine($"| `{Escape(type.FullName)}` | {type.Layer} | {type.RelevanceScore} | {type.RelevanceCategory} | {InlineList(type.Patterns)} |");
            }

            builder.AppendLine();
        }

        return builder.ToString();
    }

    private static string RenderTypeIndex(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Type Index");
        builder.AppendLine();

        foreach (var type in PrimaryTypes(solution.Projects.SelectMany(project => project.Types)).Take(250))
        {
            builder.AppendLine($"## {Escape(type.FullName)}");
            builder.AppendLine();
            builder.AppendLine("| Field | Value |");
            builder.AppendLine("| --- | --- |");
            builder.AppendLine($"| Kind | {type.Kind} |");
            builder.AppendLine($"| Layer | {type.Layer} |");
            builder.AppendLine($"| Relevance | {type.RelevanceCategory} / {type.RelevanceScore} |");
            builder.AppendLine($"| Namespace | `{Escape(type.Namespace)}` |");
            builder.AppendLine($"| Project | `{Escape(type.ProjectName)}` |");
            builder.AppendLine($"| Base type | {InlineValue(type.BaseType)} |");
            builder.AppendLine($"| Interfaces | {InlineList(type.Interfaces)} |");
            builder.AppendLine($"| Patterns | {InlineList(type.Patterns)} |");
            builder.AppendLine($"| Technologies | {InlineList(type.Technologies)} |");
            builder.AppendLine($"| Summary | {PlainValue(type.Summary)} |");
            builder.AppendLine();
            builder.AppendLine("Public methods:");

            if (type.PublicMethods.Count == 0)
            {
                builder.AppendLine("- none");
            }
            else
            {
                foreach (var method in type.PublicMethods.Take(25))
                {
                    builder.AppendLine($"- `{Escape(FormatMethod(method))}`");
                }
            }

            var dependencies = type.Dependencies
                .Where(dependency => dependency.Kind is DependencyKind.ConstructorInjection or DependencyKind.DbSet or DependencyKind.MediatR)
                .Take(20)
                .ToArray();

            builder.AppendLine();
            builder.AppendLine("Semantic dependencies:");
            if (dependencies.Length == 0)
            {
                builder.AppendLine("- none");
            }
            else
            {
                foreach (var dependency in dependencies)
                {
                    builder.AppendLine($"- `{Escape(dependency.TargetType)}` ({dependency.Kind})");
                }
            }

            builder.AppendLine();
        }

        return builder.ToString();
    }

    private static string RenderAiContext(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# AI Context");
        builder.AppendLine();
        builder.AppendLine("## Arquitectura inferida");
        builder.AppendLine();
        foreach (var architecture in InferArchitectures(solution))
        {
            builder.AppendLine($"- `{Escape(architecture)}`");
        }

        builder.AppendLine();
        builder.AppendLine("## Capas detectadas");
        builder.AppendLine();
        foreach (var layer in LayerGroups(solution))
        {
            builder.AppendLine($"- `{layer.Key}`: {layer.Count()} types; projects {InlineList(layer.Select(type => type.ProjectName))}");
        }

        builder.AppendLine();
        builder.AppendLine("## Convenciones detectadas");
        builder.AppendLine();
        foreach (var convention in DetectConventions(solution))
        {
            builder.AppendLine($"- {convention}");
        }

        builder.AppendLine();
        builder.AppendLine("## Riesgos o zonas delicadas");
        builder.AppendLine();
        var dangerous = DangerousTypes(solution).Take(20).ToArray();
        if (dangerous.Length == 0)
        {
            builder.AppendLine("- none");
        }
        else
        {
            foreach (var type in dangerous)
            {
                builder.AppendLine($"- `{Escape(type.FullName)}`: {InlineList(type.Patterns.Concat(type.Technologies))}");
            }
        }

        builder.AppendLine();
        builder.AppendLine("## Frameworks y tecnologias detectadas");
        builder.AppendLine();
        var technologies = AllTechnologies(solution);
        if (technologies.Count == 0)
        {
            builder.AppendLine("- none");
        }

        foreach (var technology in technologies)
        {
            builder.AppendLine($"- `{Escape(technology)}`");
        }

        builder.AppendLine();
        builder.AppendLine("## Tipos prioritarios para IA");
        builder.AppendLine();
        builder.AppendLine("| Type | Score | Layer | Why |");
        builder.AppendLine("| --- | ---: | --- | --- |");
        foreach (var type in PrimaryTypes(solution.Projects.SelectMany(project => project.Types)).Take(30))
        {
            builder.AppendLine($"| `{Escape(type.FullName)}` | {type.RelevanceScore} | {type.Layer} | {InlineList(type.Patterns.Concat(type.Technologies))} |");
        }

        return builder.ToString();
    }

    private static string RenderArchitecture(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Architecture");
        builder.AppendLine();
        builder.AppendLine("## Layers");
        builder.AppendLine();
        builder.AppendLine("| Layer | Projects | Key Types | Responsibility |");
        builder.AppendLine("| --- | --- | --- | --- |");
        foreach (var layer in LayerGroups(solution))
        {
            var projects = layer.Select(type => type.ProjectName);
            var keyTypes = PrimaryTypes(layer).Take(8).Select(type => type.Name);
            builder.AppendLine($"| {layer.Key} | {InlineList(projects)} | {InlineList(keyTypes)} | {LayerResponsibility(layer.Key)} |");
        }

        builder.AppendLine();
        builder.AppendLine("## Project Dependencies");
        builder.AppendLine();
        builder.AppendLine("| From | To | Inferred Rule |");
        builder.AppendLine("| --- | --- | --- |");
        foreach (var project in solution.Projects)
        {
            foreach (var reference in project.ProjectReferences)
            {
                var target = solution.Projects.FirstOrDefault(candidate => candidate.Name == reference.Name);
                builder.AppendLine($"| `{Escape(project.Name)}` ({project.Layer}) | `{Escape(reference.Name)}` ({target?.Layer.ToString() ?? "Unknown"}) | {InferDependencyRule(project.Layer, target?.Layer ?? ArchitectureLayer.Unknown)} |");
            }
        }

        return builder.ToString();
    }

    private static string RenderDependencyGraph(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Dependency Graph");
        builder.AppendLine();
        builder.AppendLine("## Semantic Dependencies");
        builder.AppendLine();

        var typesWithDependencies = PrimaryTypes(solution.Projects.SelectMany(project => project.Types))
            .Where(type => SemanticGraphDependencies(type).Any())
            .Take(80)
            .ToArray();

        if (typesWithDependencies.Length == 0)
        {
            builder.AppendLine("- none");
            builder.AppendLine();
        }

        foreach (var type in typesWithDependencies)
        {
            builder.AppendLine($"## {Escape(type.FullName)}");
            foreach (var dependency in SemanticGraphDependencies(type).Take(30))
            {
                builder.AppendLine($"- `{Escape(dependency.TargetType)}` ({dependency.Kind}{MemberSuffix(dependency.MemberName)})");
            }

            builder.AppendLine();
        }

        builder.AppendLine("## Mermaid");
        builder.AppendLine();
        builder.AppendLine("```mermaid");
        builder.AppendLine("graph TD");
        foreach (var type in PrimaryTypes(solution.Projects.SelectMany(project => project.Types)).Take(40))
        {
            foreach (var dependency in SemanticGraphDependencies(type).Take(8))
            {
                builder.AppendLine($"  {MermaidId(type.FullName)}[\"{EscapeMermaid(type.Name)}\"] --> {MermaidId(dependency.TargetType)}[\"{EscapeMermaid(ShortTypeName(dependency.TargetType))}\"]");
            }
        }

        builder.AppendLine("```");
        builder.AppendLine();

        builder.AppendLine("## IoC Registrations");
        builder.AppendLine();
        builder.AppendLine("| Project | Interface | Implementation | Kind | Location |");
        builder.AppendLine("| --- | --- | --- | --- | --- |");
        var hasRegistrations = false;
        foreach (var project in solution.Projects)
        {
            foreach (var registration in project.IoCRegistrations)
            {
                hasRegistrations = true;
                builder.AppendLine($"| `{Escape(project.Name)}` | `{Escape(registration.InterfaceType)}` | `{Escape(registration.ImplementationType)}` | {registration.RegistrationKind} | `{Escape(registration.Location)}` |");
            }
        }

        if (!hasRegistrations)
        {
            builder.AppendLine("| none | none | none | none | none |");
        }

        return builder.ToString();
    }

    private static string RenderConventions(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Conventions");
        builder.AppendLine();
        foreach (var convention in DetectConventions(solution))
        {
            builder.AppendLine($"- {convention}");
        }

        return builder.ToString();
    }

    private static string RenderDomains(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Domains");
        builder.AppendLine();
        builder.AppendLine("| Namespace | Types | Primary Types |");
        builder.AppendLine("| --- | ---: | --- |");
        foreach (var group in solution.Projects.SelectMany(project => project.Types)
            .Where(type => !string.IsNullOrWhiteSpace(type.Namespace))
            .GroupBy(type => type.Namespace)
            .OrderByDescending(group => group.Count())
            .ThenBy(group => group.Key, StringComparer.Ordinal)
            .Take(80))
        {
            builder.AppendLine($"| `{Escape(group.Key)}` | {group.Count()} | {InlineList(PrimaryTypes(group).Take(8).Select(type => type.Name))} |");
        }

        return builder.ToString();
    }

    private static string RenderDangerousZones(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Dangerous Zones");
        builder.AppendLine();
        builder.AppendLine("| Type | Project | Layer | Signals |");
        builder.AppendLine("| --- | --- | --- | --- |");
        var dangerousTypes = DangerousTypes(solution).ToArray();
        if (dangerousTypes.Length == 0)
        {
            builder.AppendLine("| none | none | none | none |");
        }

        foreach (var type in dangerousTypes)
        {
            var signals = type.Patterns
                .Concat(type.Technologies)
                .Concat(type.IsMigration ? ["Migration"] : [])
                .Concat(type.IsGenerated ? ["Generated"] : []);
            builder.AppendLine($"| `{Escape(type.FullName)}` | `{Escape(type.ProjectName)}` | {type.Layer} | {InlineList(signals)} |");
        }

        return builder.ToString();
    }

    private static string InferPurpose(ProjectModel project)
    {
        if (project.Types.Count == 0)
        {
            return "No source types detected.";
        }

        if (project.Technologies.Count > 0 || project.Patterns.Count > 0)
        {
            return $"Contains {string.Join(", ", project.Technologies.Concat(project.Patterns).Distinct(StringComparer.Ordinal).Take(8))} code.";
        }

        var dominantNamespaces = project.Types
            .Select(type => type.Namespace)
            .Where(namespaceName => !string.IsNullOrWhiteSpace(namespaceName))
            .GroupBy(namespaceName => namespaceName)
            .OrderByDescending(group => group.Count())
            .ThenBy(group => group.Key, StringComparer.Ordinal)
            .Take(3)
            .Select(group => group.Key)
            .ToArray();

        return dominantNamespaces.Length == 0
            ? "General C# project; purpose inferred from type names."
            : $"General C# project centered around {string.Join(", ", dominantNamespaces)}.";
    }

    private static IReadOnlyList<string> InferArchitectures(SolutionModel solution)
    {
        var layers = solution.Projects.Select(project => project.Layer)
            .Concat(solution.Projects.SelectMany(project => project.Types).Select(type => type.Layer))
            .Distinct()
            .ToArray();
        var technologies = AllTechnologies(solution);
        var patterns = solution.Projects.SelectMany(project => project.Patterns).ToArray();
        var architectures = new List<string>();

        if (layers.Contains(ArchitectureLayer.Domain) && layers.Contains(ArchitectureLayer.Application) && layers.Contains(ArchitectureLayer.Infrastructure))
        {
            architectures.Add("Clean Architecture");
        }

        if (layers.Count(layer => layer is not ArchitectureLayer.Unknown) >= 3)
        {
            architectures.Add("Layered Architecture");
        }

        if (technologies.Contains("CQRS") || patterns.Any(pattern => pattern is "Command" or "Query" or "CQRS Handler"))
        {
            architectures.Add("CQRS");
        }

        if (technologies.Contains("MediatR"))
        {
            architectures.Add("MediatR");
        }

        if (patterns.Contains("Controller") || technologies.Any(technology => technology.Contains("ASP.NET", StringComparison.Ordinal)))
        {
            architectures.Add("MVC/API");
        }

        if (patterns.Contains("Repository"))
        {
            architectures.Add("Repository pattern");
        }

        if (patterns.Contains("UnitOfWork"))
        {
            architectures.Add("Unit of Work");
        }

        if (technologies.Contains("Unity IoC") || solution.Projects.Any(project => project.IoCRegistrations.Count > 0))
        {
            architectures.Add("IoC / DI");
        }

        return architectures.Count == 0 ? ["Unknown"] : architectures.Distinct(StringComparer.Ordinal).Order(StringComparer.Ordinal).ToArray();
    }

    private static IReadOnlyList<string> DetectConventions(SolutionModel solution)
    {
        var types = solution.Projects.SelectMany(project => project.Types).ToArray();
        var conventions = new List<string>();
        AddConvention(types, "Service", "Services terminate in `Service`", conventions);
        AddConvention(types, "Repository", "Repositories terminate in `Repository`", conventions);
        AddConvention(types, "Dto", "DTOs terminate in `Dto`", conventions);
        AddConvention(types, "ViewModel", "View models terminate in `ViewModel`", conventions);
        AddConvention(types, "Controller", "ASP.NET controllers terminate in `Controller`", conventions);
        AddConvention(types, "Specification", "Specifications terminate in `Specification`", conventions);
        AddConvention(types, "Handler", "Handlers terminate in `Handler`", conventions);

        var asyncMethods = types.SelectMany(type => type.PublicMethods).Count(method => method.Name.EndsWith("Async", StringComparison.Ordinal));
        if (asyncMethods > 0)
        {
            conventions.Add($"Async methods use `Async` suffix ({asyncMethods}).");
        }

        return conventions.Count == 0 ? ["No strong naming conventions detected."] : conventions;
    }

    private static void AddConvention(IReadOnlyList<TypeModel> types, string suffix, string text, ICollection<string> conventions)
    {
        var count = types.Count(type => type.Name.EndsWith(suffix, StringComparison.OrdinalIgnoreCase) || type.Patterns.Contains(suffix));
        if (count > 0)
        {
            conventions.Add($"{text} ({count}).");
        }
    }

    private static IEnumerable<IGrouping<ArchitectureLayer, TypeModel>> LayerGroups(SolutionModel solution)
    {
        return solution.Projects
            .SelectMany(project => project.Types)
            .GroupBy(type => type.Layer)
            .OrderBy(group => group.Key == ArchitectureLayer.Unknown)
            .ThenBy(group => group.Key.ToString(), StringComparer.Ordinal);
    }

    private static IEnumerable<TypeModel> PrimaryTypes(IEnumerable<TypeModel> types)
    {
        return types
            .Where(type => !type.IsGenerated && !type.IsMigration)
            .OrderByDescending(type => type.RelevanceScore)
            .ThenBy(type => type.FullName, StringComparer.Ordinal);
    }

    private static IEnumerable<TypeModel> DangerousTypes(SolutionModel solution)
    {
        return solution.Projects
            .SelectMany(project => project.Types)
            .Where(type => type.IsDangerousZone || type.IsMigration || type.IsGenerated)
            .OrderByDescending(type => type.IsDangerousZone)
            .ThenByDescending(type => type.RelevanceScore)
            .ThenBy(type => type.FullName, StringComparer.Ordinal);
    }

    private static IEnumerable<TypeDependencyModel> SemanticGraphDependencies(TypeModel type)
    {
        return type.Dependencies
            .Where(dependency => dependency.Kind is DependencyKind.ConstructorInjection
                or DependencyKind.Field
                or DependencyKind.Property
                or DependencyKind.DbSet
                or DependencyKind.Instantiation)
            .OrderBy(dependency => dependency.TargetType, StringComparer.Ordinal);
    }

    private static IReadOnlyList<string> AllTechnologies(SolutionModel solution)
    {
        return solution.Projects
            .SelectMany(project => project.Technologies)
            .Concat(solution.Projects.SelectMany(project => project.Types).SelectMany(type => type.Technologies))
            .Distinct(StringComparer.Ordinal)
            .Order(StringComparer.Ordinal)
            .ToArray();
    }

    private static string LayerResponsibility(ArchitectureLayer layer)
    {
        return layer switch
        {
            ArchitectureLayer.Domain => "Business concepts, rules, entities, aggregates.",
            ArchitectureLayer.Application => "Use cases, orchestration, commands, queries, services.",
            ArchitectureLayer.Infrastructure => "Persistence, external integrations, IoC, EF, repositories.",
            ArchitectureLayer.API => "HTTP endpoints, controllers, request/response boundary.",
            ArchitectureLayer.UI => "User interface, MVC/Razor/Blazor pages and views.",
            ArchitectureLayer.Shared => "Cross-cutting contracts and reusable primitives.",
            ArchitectureLayer.Tests => "Validation and regression coverage.",
            _ => "Responsibility not inferred."
        };
    }

    private static string InferDependencyRule(ArchitectureLayer from, ArchitectureLayer to)
    {
        if (from == ArchitectureLayer.Application && to is ArchitectureLayer.API or ArchitectureLayer.UI)
        {
            return "suspicious: application depending on presentation";
        }

        if (from == ArchitectureLayer.Domain && to is ArchitectureLayer.Infrastructure or ArchitectureLayer.API or ArchitectureLayer.UI)
        {
            return "suspicious: domain depending outward";
        }

        if (from == ArchitectureLayer.Infrastructure && to is ArchitectureLayer.Domain or ArchitectureLayer.Application)
        {
            return "typical: infrastructure implements lower-level abstractions";
        }

        return "allowed or not enough context";
    }

    private static string FormatMethod(MethodModel method)
    {
        var parameters = string.Join(", ", method.Parameters.Select(parameter => $"{parameter.Type} {parameter.Name}"));
        var modifier = method.IsStatic ? "static " : string.Empty;
        return $"{modifier}{method.ReturnType} {method.Name}({parameters})";
    }

    private static string MemberSuffix(string? memberName)
    {
        return string.IsNullOrWhiteSpace(memberName) ? string.Empty : $", {memberName}";
    }

    private static string ShortTypeName(string fullName)
    {
        var genericTick = fullName.IndexOf('`', StringComparison.Ordinal);
        if (genericTick >= 0)
        {
            fullName = fullName[..genericTick];
        }

        var dot = fullName.LastIndexOf('.');
        return dot < 0 ? fullName : fullName[(dot + 1)..];
    }

    private static string MermaidId(string value)
    {
        var chars = value.Select(character => char.IsLetterOrDigit(character) ? character : '_').ToArray();
        return $"T_{new string(chars)}";
    }

    private static string EscapeMermaid(string value)
    {
        return value.Replace("\"", "\\\"", StringComparison.Ordinal);
    }

    private static string InlineList(IEnumerable<string> values)
    {
        var items = values
            .Where(value => !string.IsNullOrWhiteSpace(value))
            .Distinct(StringComparer.Ordinal)
            .Select(value => $"`{Escape(value)}`")
            .ToArray();

        return items.Length == 0 ? "none" : string.Join(", ", items);
    }

    private static string InlineValue(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? "none" : $"`{Escape(value)}`";
    }

    private static string PlainValue(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? "none" : Escape(value);
    }

    private static string Escape(string value)
    {
        return value.Replace("|", "\\|", StringComparison.Ordinal);
    }
}
