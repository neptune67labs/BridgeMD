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
            ["DANGEROUS_ZONES.md"] = RenderDangerousZones(solution),
            ["important-types.md"] = RenderImportantTypes(solution),
            ["high-relevance-types.md"] = RenderHighRelevanceTypes(solution),
            ["architectural-hotspots.md"] = RenderArchitecturalHotspots(solution),
            ["core-domain-types.md"] = RenderCoreDomainTypes(solution),
            ["IOC_GRAPH.md"] = RenderIocGraph(solution),
            ["composition-roots.md"] = RenderCompositionRoots(solution),
            ["REQUEST_FLOWS.md"] = RenderRequestFlows(solution),
            ["application-flows.md"] = RenderApplicationFlows(solution),
            ["BUSINESS_DOMAIN.md"] = RenderBusinessDomain(solution),
            ["BOUNDED_CONTEXTS.md"] = RenderBoundedContexts(solution),
            ["DOMAIN_RELATIONSHIPS.md"] = RenderDomainRelationships(solution),
            ["USE_CASES.md"] = RenderUseCases(solution),
            ["UBIQUITOUS_LANGUAGE.md"] = RenderUbiquitousLanguage(solution),
            ["ARCHITECTURAL_HOTSPOTS.md"] = RenderArchitecturalHotspotsIntelligence(solution),
            ["LEGACY_ZONES.md"] = RenderLegacyZones(solution),
            ["RISK_AREAS.md"] = RenderRiskAreas(solution)
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
        builder.AppendLine("| Project | Layer | Frameworks | Types | Roles | Patterns |");
        builder.AppendLine("| --- | --- | --- | ---: | --- | --- |");
        foreach (var project in solution.Projects)
        {
            builder.AppendLine($"| `{Escape(project.Name)}` | {project.Layer} | {InlineList(project.TargetFrameworks)} | {project.Types.Count} | {InlineList(project.Types.Select(type => type.ArchitecturalRole.ToString()).Where(role => role != nameof(ArchitecturalRole.Unknown)))} | {InlineList(project.Patterns)} |");
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
            builder.AppendLine("| Type | Role | Layer | Score | Category | Patterns |");
            builder.AppendLine("| --- | --- | --- | ---: | --- | --- |");

            foreach (var type in PrimaryTypes(project.Types).Take(80))
            {
                builder.AppendLine($"| `{Escape(type.FullName)}` | {type.ArchitecturalRole} | {type.Layer} | {type.RelevanceScore} | {type.RelevanceCategory} | {InlineList(type.Patterns)} |");
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
            builder.AppendLine($"| Role | {type.ArchitecturalRole} |");
            builder.AppendLine($"| Layer | {type.Layer} |");
            builder.AppendLine($"| Relevance | {type.RelevanceCategory} / {type.RelevanceScore} |");
            builder.AppendLine($"| Reason | {PlainValue(ScoreReason(type))} |");
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
        builder.AppendLine("| Type | Role | Score | Layer | Why |");
        builder.AppendLine("| --- | --- | ---: | --- | --- |");
        foreach (var type in PrimaryTypes(solution.Projects.SelectMany(project => project.Types)).Take(30))
        {
            builder.AppendLine($"| `{Escape(type.FullName)}` | {type.ArchitecturalRole} | {type.RelevanceScore} | {type.Layer} | {PlainValue(ScoreReason(type))} |");
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
        builder.AppendLine("| Layer | Projects | Key Types | Key Roles | Responsibility |");
        builder.AppendLine("| --- | --- | --- | --- | --- |");
        foreach (var layer in LayerGroups(solution))
        {
            var projects = layer.Select(type => type.ProjectName);
            var keyTypes = PrimaryTypes(layer).Take(8).Select(type => type.Name);
            var roles = layer.Select(type => type.ArchitecturalRole.ToString()).Where(role => role != nameof(ArchitecturalRole.Unknown));
            builder.AppendLine($"| {layer.Key} | {InlineList(projects)} | {InlineList(keyTypes)} | {InlineList(roles)} | {LayerResponsibility(layer.Key)} |");
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

    private static string RenderImportantTypes(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Important Types");
        builder.AppendLine();
        builder.AppendLine("| Type | Role | Layer | Score | Reason |");
        builder.AppendLine("| --- | --- | --- | ---: | --- |");
        foreach (var type in ImportantTypes(solution).Take(120))
        {
            builder.AppendLine($"| `{Escape(type.FullName)}` | {type.ArchitecturalRole} | {type.Layer} | {type.RelevanceScore} | {PlainValue(ScoreReason(type))} |");
        }

        return builder.ToString();
    }

    private static string RenderHighRelevanceTypes(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# High Relevance Types");
        builder.AppendLine();
        foreach (var type in ImportantTypes(solution).Where(type => type.RelevanceCategory == RelevanceCategory.High).Take(80))
        {
            builder.AppendLine($"## {Escape(type.Name)}");
            builder.AppendLine();
            builder.AppendLine($"- Full name: `{Escape(type.FullName)}`");
            builder.AppendLine($"- Role: `{type.ArchitecturalRole}`");
            builder.AppendLine($"- Layer: `{type.Layer}`");
            builder.AppendLine($"- Importance: `{type.RelevanceCategory}` / `{type.RelevanceScore}`");
            builder.AppendLine($"- Reason: {PlainValue(ScoreReason(type))}");
            builder.AppendLine($"- Dependencies: {InlineList(SemanticGraphDependencies(type).Take(8).Select(dependency => dependency.TargetType))}");
            builder.AppendLine();
        }

        return builder.ToString();
    }

    private static string RenderArchitecturalHotspots(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Architectural Hotspots");
        builder.AppendLine();
        builder.AppendLine("| Type | Role | Layer | Signals |");
        builder.AppendLine("| --- | --- | --- | --- |");
        foreach (var type in ImportantTypes(solution)
            .Where(type => type.ArchitecturalRole is ArchitecturalRole.DbContext
                or ArchitecturalRole.Controller
                or ArchitecturalRole.Endpoint
                or ArchitecturalRole.CQRSHandler
                or ArchitecturalRole.Repository
                or ArchitecturalRole.Middleware
                or ArchitecturalRole.Configuration
                or ArchitecturalRole.Decorator)
            .Take(100))
        {
            builder.AppendLine($"| `{Escape(type.FullName)}` | {type.ArchitecturalRole} | {type.Layer} | {PlainValue(ScoreReason(type))} |");
        }

        return builder.ToString();
    }

    private static string RenderCoreDomainTypes(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Core Domain Types");
        builder.AppendLine();
        builder.AppendLine("| Type | Role | Score | Namespace |");
        builder.AppendLine("| --- | --- | ---: | --- |");
        foreach (var type in ImportantTypes(solution)
            .Where(type => type.Layer == ArchitectureLayer.Domain
                || type.ArchitecturalRole is ArchitecturalRole.Entity or ArchitecturalRole.AggregateRoot or ArchitecturalRole.ValueObject)
            .Take(120))
        {
            builder.AppendLine($"| `{Escape(type.FullName)}` | {type.ArchitecturalRole} | {type.RelevanceScore} | `{Escape(type.Namespace)}` |");
        }

        return builder.ToString();
    }

    private static string RenderIocGraph(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# IoC Graph");
        builder.AppendLine();
        builder.AppendLine("| Project | Interface | Implementation | Lifetime | Location |");
        builder.AppendLine("| --- | --- | --- | --- | --- |");

        var registrations = solution.Projects
            .SelectMany(project => project.IoCRegistrations.Select(registration => (project.Name, Registration: registration)))
            .OrderBy(item => item.Name, StringComparer.Ordinal)
            .ThenBy(item => item.Registration.InterfaceType, StringComparer.Ordinal)
            .ToArray();

        if (registrations.Length == 0)
        {
            builder.AppendLine("| none | none | none | none | none |");
        }

        foreach (var item in registrations)
        {
            builder.AppendLine($"| `{Escape(item.Name)}` | `{Escape(item.Registration.InterfaceType)}` | `{Escape(item.Registration.ImplementationType)}` | `{Escape(item.Registration.RegistrationKind)}` | `{Escape(item.Registration.Location)}` |");
        }

        return builder.ToString();
    }

    private static string RenderCompositionRoots(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Composition Roots");
        builder.AppendLine();
        builder.AppendLine("| Project | Location | Registrations |");
        builder.AppendLine("| --- | --- | ---: |");

        var roots = solution.Projects
            .SelectMany(project => project.IoCRegistrations.Select(registration => (project.Name, registration.Location)))
            .GroupBy(item => $"{item.Name}:{item.Location}", StringComparer.Ordinal)
            .OrderBy(group => group.Key, StringComparer.Ordinal)
            .ToArray();

        if (roots.Length == 0)
        {
            builder.AppendLine("| none | none | 0 |");
        }

        foreach (var root in roots)
        {
            var first = root.First();
            builder.AppendLine($"| `{Escape(first.Name)}` | `{Escape(first.Location)}` | {root.Count()} |");
        }

        return builder.ToString();
    }

    private static string RenderRequestFlows(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Request Flows");
        builder.AppendLine();

        var entryPoints = RequestEntryPoints(solution).Take(80).ToArray();
        if (entryPoints.Length == 0)
        {
            builder.AppendLine("- none");
            return builder.ToString();
        }

        foreach (var entryPoint in entryPoints)
        {
            builder.AppendLine($"## {Escape(entryPoint.FullName)}");
            builder.AppendLine();
            builder.AppendLine($"- Entry role: `{entryPoint.ArchitecturalRole}`");
            builder.AppendLine($"- Layer: `{entryPoint.Layer}`");
            builder.AppendLine($"- Flow: {FormatFlow(entryPoint, solution)}");
            builder.AppendLine();
        }

        return builder.ToString();
    }

    private static string RenderApplicationFlows(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Application Flows");
        builder.AppendLine();
        builder.AppendLine("| Entry Point | Flow |");
        builder.AppendLine("| --- | --- |");
        var entryPoints = RequestEntryPoints(solution).Take(80).ToArray();
        if (entryPoints.Length == 0)
        {
            builder.AppendLine("| none | none |");
            return builder.ToString();
        }

        foreach (var entryPoint in entryPoints)
        {
            builder.AppendLine($"| `{Escape(entryPoint.FullName)}` | {FormatFlow(entryPoint, solution)} |");
        }

        return builder.ToString();
    }

    private static string RenderBusinessDomain(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Business Domain");
        builder.AppendLine();
        builder.AppendLine("## What This System Appears To Do");
        builder.AppendLine();
        builder.AppendLine($"- Primary domain language: {InlineList(UbiquitousTerms(solution).Take(12).Select(term => term.Term))}");
        builder.AppendLine($"- Core contexts: {InlineList(BoundedContexts(solution).Take(10).Select(context => context.Name))}");
        builder.AppendLine($"- Core entities: {InlineList(CoreBusinessTypes(solution).Take(12).Select(type => type.Name))}");
        builder.AppendLine();
        builder.AppendLine("## Core Business Entities");
        builder.AppendLine();

        foreach (var type in CoreBusinessTypes(solution).Take(40))
        {
            builder.AppendLine($"## {Escape(type.Name)}");
            builder.AppendLine();
            builder.AppendLine($"- Role: `{type.ArchitecturalRole}`");
            builder.AppendLine($"- Context: `{InferBoundedContext(type)}`");
            builder.AppendLine($"- Namespace: `{Escape(type.Namespace)}`");
            builder.AppendLine($"- Responsibilities: {BusinessResponsibilities(type)}");
            builder.AppendLine($"- Used by: {InlineList(TypesReferencing(solution, type).Take(8).Select(reference => reference.Name))}");
            builder.AppendLine();
        }

        return builder.ToString();
    }

    private static string RenderBoundedContexts(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Bounded Contexts");
        builder.AppendLine();

        foreach (var context in BoundedContexts(solution).Take(30))
        {
            builder.AppendLine($"## {Escape(context.Name)}");
            builder.AppendLine();
            builder.AppendLine($"- Projects: {InlineList(context.Types.Select(type => type.ProjectName))}");
            builder.AppendLine($"- Contains: {InlineList(context.Types.Where(IsDomainType).Take(10).Select(type => type.Name))}");
            builder.AppendLine($"- Services: {InlineList(context.Types.Where(type => type.ArchitecturalRole is ArchitecturalRole.ApplicationService or ArchitecturalRole.DomainService).Take(10).Select(type => type.Name))}");
            builder.AppendLine($"- Entry points: {InlineList(context.Types.Where(type => type.ArchitecturalRole is ArchitecturalRole.Controller or ArchitecturalRole.Endpoint or ArchitecturalRole.CQRSHandler).Take(10).Select(type => type.Name))}");
            builder.AppendLine($"- Dependencies: {InlineList(ContextDependencies(solution, context.Name).Take(10))}");
            builder.AppendLine();
        }

        return builder.ToString();
    }

    private static string RenderDomainRelationships(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Domain Relationships");
        builder.AppendLine();
        builder.AppendLine("| Source | Relationship | Target | Evidence |");
        builder.AppendLine("| --- | --- | --- | --- |");

        var relationships = DomainRelationships(solution).Take(120).ToArray();
        if (relationships.Length == 0)
        {
            builder.AppendLine("| none | none | none | none |");
        }

        foreach (var relationship in relationships)
        {
            builder.AppendLine($"| `{Escape(relationship.Source.Name)}` | {relationship.Kind} | `{Escape(relationship.Target.Name)}` | `{relationship.Evidence}` |");
        }

        builder.AppendLine();
        builder.AppendLine("## Mermaid");
        builder.AppendLine();
        builder.AppendLine("```mermaid");
        builder.AppendLine("graph TD");
        foreach (var relationship in relationships.Take(40))
        {
            builder.AppendLine($"  {MermaidId(relationship.Source.FullName)}[\"{EscapeMermaid(relationship.Source.Name)}\"] --> {MermaidId(relationship.Target.FullName)}[\"{EscapeMermaid(relationship.Target.Name)}\"]");
        }
        builder.AppendLine("```");

        return builder.ToString();
    }

    private static string RenderUseCases(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Use Cases");
        builder.AppendLine();
        builder.AppendLine("| Use Case | Entry | Flow | Entities |");
        builder.AppendLine("| --- | --- | --- | --- |");

        var useCases = RequestEntryPoints(solution)
            .Concat(solution.Projects.SelectMany(project => project.Types).Where(type => type.ArchitecturalRole is ArchitecturalRole.ApplicationService or ArchitecturalRole.CQRSHandler))
            .DistinctBy(type => type.FullName)
            .Where(type => !type.Name.StartsWith("I", StringComparison.Ordinal) || type.ArchitecturalRole == ArchitecturalRole.CQRSHandler)
            .OrderByDescending(type => type.RelevanceScore)
            .ThenBy(type => type.FullName, StringComparer.Ordinal)
            .Take(100)
            .ToArray();

        if (useCases.Length == 0)
        {
            builder.AppendLine("| none | none | none | none |");
        }

        foreach (var useCase in useCases)
        {
            builder.AppendLine($"| `{Escape(HumanizeUseCaseName(useCase.Name))}` | `{Escape(useCase.FullName)}` | {FormatFlow(useCase, solution)} | {InlineList(FlowEntities(useCase, solution).Take(8).Select(type => type.Name))} |");
        }

        return builder.ToString();
    }

    private static string RenderUbiquitousLanguage(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Ubiquitous Language");
        builder.AppendLine();
        builder.AppendLine("| Term | Occurrences | Signals |");
        builder.AppendLine("| --- | ---: | --- |");
        foreach (var term in UbiquitousTerms(solution).Take(80))
        {
            builder.AppendLine($"| `{Escape(term.Term)}` | {term.Count} | {InlineList(term.Signals.Take(8))} |");
        }

        return builder.ToString();
    }

    private static string RenderArchitecturalHotspotsIntelligence(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Architectural Hotspots");
        builder.AppendLine();
        builder.AppendLine("| Type | Risk | Fan-in | Fan-out | Size | Reasons |");
        builder.AppendLine("| --- | ---: | ---: | ---: | ---: | --- |");
        foreach (var hotspot in RiskProfiles(solution).Where(profile => profile.Score >= 35).Take(100))
        {
            builder.AppendLine($"| `{Escape(hotspot.Type.FullName)}` | {hotspot.Score} | {hotspot.FanIn} | {hotspot.FanOut} | {hotspot.Type.SourceLineCount} | {InlineList(hotspot.Reasons)} |");
        }

        return builder.ToString();
    }

    private static string RenderLegacyZones(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Legacy Zones");
        builder.AppendLine();
        builder.AppendLine("| Type | Project | Signals |");
        builder.AppendLine("| --- | --- | --- |");

        var legacy = solution.Projects.SelectMany(project => project.Types)
            .Where(type => LegacySignals(type, solution).Count > 0)
            .OrderByDescending(type => LegacySignals(type, solution).Count)
            .ThenBy(type => type.FullName, StringComparer.Ordinal)
            .Take(100)
            .ToArray();

        if (legacy.Length == 0)
        {
            builder.AppendLine("| none | none | none |");
        }

        foreach (var type in legacy)
        {
            builder.AppendLine($"| `{Escape(type.FullName)}` | `{Escape(type.ProjectName)}` | {InlineList(LegacySignals(type, solution))} |");
        }

        return builder.ToString();
    }

    private static string RenderRiskAreas(SolutionModel solution)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Risk Areas");
        builder.AppendLine();
        builder.AppendLine("| Type | RiskLevel | RiskScore | Reasons |");
        builder.AppendLine("| --- | --- | ---: | --- |");
        foreach (var profile in RiskProfiles(solution).Where(profile => profile.Score >= 25).Take(120))
        {
            builder.AppendLine($"| `{Escape(profile.Type.FullName)}` | {RiskLevel(profile.Score)} | {profile.Score} | {InlineList(profile.Reasons)} |");
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

    private static IEnumerable<TypeModel> ImportantTypes(SolutionModel solution)
    {
        return PrimaryTypes(solution.Projects.SelectMany(project => project.Types))
            .Where(type => type.RelevanceCategory is RelevanceCategory.High or RelevanceCategory.Medium
                || type.ArchitecturalRole is not ArchitecturalRole.Unknown and not ArchitecturalRole.DTO and not ArchitecturalRole.ViewModel)
            .Where(type => type.Layer != ArchitectureLayer.Tests || type.RelevanceScore >= 75)
            .OrderByDescending(type => RoleWeight(type.ArchitecturalRole))
            .ThenBy(type => type.Layer == ArchitectureLayer.Tests)
            .ThenByDescending(type => type.RelevanceScore)
            .ThenBy(type => type.FullName, StringComparer.Ordinal);
    }

    private static IEnumerable<TypeModel> RequestEntryPoints(SolutionModel solution)
    {
        return ImportantTypes(solution)
            .Where(type => type.ArchitecturalRole is ArchitecturalRole.Controller
                or ArchitecturalRole.Endpoint
                or ArchitecturalRole.CQRSHandler
                or ArchitecturalRole.ApplicationService);
    }

    private static int RoleWeight(ArchitecturalRole role)
    {
        return role switch
        {
            ArchitecturalRole.DbContext => 100,
            ArchitecturalRole.Controller or ArchitecturalRole.Endpoint => 95,
            ArchitecturalRole.CQRSHandler => 90,
            ArchitecturalRole.Repository => 85,
            ArchitecturalRole.ApplicationService or ArchitecturalRole.DomainService => 80,
            ArchitecturalRole.Middleware => 75,
            ArchitecturalRole.Configuration => 70,
            ArchitecturalRole.Specification => 65,
            ArchitecturalRole.Entity or ArchitecturalRole.AggregateRoot => 60,
            ArchitecturalRole.Decorator or ArchitecturalRole.Adapter => 55,
            ArchitecturalRole.Mapper => 50,
            _ => 10
        };
    }

    private sealed record BoundedContextModel(string Name, IReadOnlyList<TypeModel> Types);

    private sealed record DomainRelationship(TypeModel Source, TypeModel Target, string Kind, string Evidence);

    private sealed record LanguageTerm(string Term, int Count, IReadOnlyList<string> Signals);

    private sealed record RiskProfile(TypeModel Type, int Score, int FanIn, int FanOut, IReadOnlyList<string> Reasons);

    private static IEnumerable<TypeModel> CoreBusinessTypes(SolutionModel solution)
    {
        return solution.Projects
            .SelectMany(project => project.Types)
            .Where(IsDomainType)
            .OrderByDescending(type => type.ArchitecturalRole is ArchitecturalRole.AggregateRoot)
            .ThenByDescending(type => TypesReferencing(solution, type).Count())
            .ThenByDescending(type => type.RelevanceScore)
            .ThenBy(type => type.FullName, StringComparer.Ordinal);
    }

    private static bool IsDomainType(TypeModel type)
    {
        return type.Layer != ArchitectureLayer.Tests
            && (type.Layer == ArchitectureLayer.Domain
                || type.ArchitecturalRole is ArchitecturalRole.AggregateRoot or ArchitecturalRole.Entity or ArchitecturalRole.ValueObject);
    }

    private static IReadOnlyList<BoundedContextModel> BoundedContexts(SolutionModel solution)
    {
        return solution.Projects
            .SelectMany(project => project.Types)
            .Where(type => type.Layer != ArchitectureLayer.Tests)
            .GroupBy(InferBoundedContext, StringComparer.Ordinal)
            .Where(group => group.Key != "General")
            .Where(group => IsContextNameAllowed(group.Key))
            .Where(group => group.Any(type => IsDomainType(type)
                || type.ArchitecturalRole is ArchitecturalRole.ApplicationService or ArchitecturalRole.DomainService or ArchitecturalRole.CQRSHandler or ArchitecturalRole.Controller or ArchitecturalRole.Endpoint))
            .Select(group => new BoundedContextModel(group.Key, group.OrderByDescending(type => type.RelevanceScore).ThenBy(type => type.FullName, StringComparer.Ordinal).ToArray()))
            .OrderByDescending(context => context.Types.Count(IsDomainType) + context.Types.Count(type => type.ArchitecturalRole is ArchitecturalRole.ApplicationService or ArchitecturalRole.CQRSHandler or ArchitecturalRole.Endpoint))
            .ThenBy(context => context.Name, StringComparer.Ordinal)
            .ToArray();
    }

    private static string InferBoundedContext(TypeModel type)
    {
        var semanticName = $"{type.Namespace}.{type.Name}";
        foreach (var knownContext in KnownBusinessContexts())
        {
            if (semanticName.Contains(knownContext, StringComparison.OrdinalIgnoreCase))
            {
                return knownContext;
            }
        }

        if (type.Namespace.Contains("BasketAggregate", StringComparison.OrdinalIgnoreCase)) return "Basket";
        if (type.Namespace.Contains("OrderAggregate", StringComparison.OrdinalIgnoreCase)) return "Order";
        if (type.Namespace.Contains("BuyerAggregate", StringComparison.OrdinalIgnoreCase)) return "Buyer";

        var candidates = type.Namespace
            .Split('.', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Concat(SplitWords(type.Name))
            .Where(IsBusinessToken)
            .Select(NormalizeBusinessTerm)
            .ToArray();

        var preferred = candidates.FirstOrDefault(token => token is not ("Entities" or "Interfaces" or "Services" or "Data" or "Models" or "View" or "Views" or "Pages" or "Controllers" or "Endpoints"));
        return preferred ?? "General";
    }

    private static IReadOnlyList<string> KnownBusinessContexts()
    {
        return
        [
            "Catalog",
            "Basket",
            "Order",
            "Buyer",
            "Payment",
            "Identity",
            "Account",
            "Authorization",
            "Authentication",
            "Admin",
            "Checkout",
            "Invoice",
            "Billing",
            "Report",
            "Inventory",
            "Schedule",
            "Patient",
            "Clinical",
            "Prescription"
        ];
    }

    private static IEnumerable<string> ContextDependencies(SolutionModel solution, string context)
    {
        var allTypes = solution.Projects.SelectMany(project => project.Types).ToArray();
        var contextTypes = allTypes.Where(type => InferBoundedContext(type) == context).ToArray();
        return contextTypes
            .SelectMany(type => SemanticGraphDependencies(type))
            .Select(dependency => FindTypeByDependency(solution, allTypes, dependency.TargetType, dependency.Kind))
            .Where(type => type is not null)
            .Cast<TypeModel>()
            .Select(InferBoundedContext)
            .Where(targetContext => targetContext != context && targetContext != "General")
            .Distinct(StringComparer.Ordinal)
            .Order(StringComparer.Ordinal);
    }

    private static IEnumerable<TypeModel> TypesReferencing(SolutionModel solution, TypeModel target)
    {
        var targetDefinition = GenericDefinition(target.FullName);
        return solution.Projects.SelectMany(project => project.Types)
            .Where(type => type.Dependencies.Any(dependency =>
                dependency.TargetType.Contains(target.FullName, StringComparison.Ordinal)
                || GenericDefinition(dependency.TargetType).Equals(targetDefinition, StringComparison.Ordinal)
                || dependency.TargetType.EndsWith($".{target.Name}", StringComparison.Ordinal)));
    }

    private static IReadOnlyList<DomainRelationship> DomainRelationships(SolutionModel solution)
    {
        var allTypes = solution.Projects.SelectMany(project => project.Types).ToArray();
        return allTypes
            .Where(IsDomainType)
            .SelectMany(source => SemanticGraphDependencies(source)
                .Select(dependency => (Dependency: dependency, Target: FindTypeByDependency(solution, allTypes, dependency.TargetType, dependency.Kind)))
                .Where(item => item.Target is not null && IsDomainType(item.Target))
                .Select(item => new DomainRelationship(source, item.Target!, RelationshipKind(source, item.Target!, item.Dependency), item.Dependency.Kind.ToString())))
            .DistinctBy(relationship => $"{relationship.Source.FullName}->{relationship.Target.FullName}:{relationship.Kind}")
            .OrderBy(relationship => relationship.Source.Name, StringComparer.Ordinal)
            .ThenBy(relationship => relationship.Target.Name, StringComparer.Ordinal)
            .ToArray();
    }

    private static string RelationshipKind(TypeModel source, TypeModel target, TypeDependencyModel dependency)
    {
        if (dependency.Kind == DependencyKind.DbSet)
        {
            return "persists";
        }

        if (source.ArchitecturalRole == ArchitecturalRole.AggregateRoot && target.ArchitecturalRole is ArchitecturalRole.Entity or ArchitecturalRole.ValueObject)
        {
            return "contains";
        }

        return dependency.Kind is DependencyKind.Property or DependencyKind.Field ? "has" : "uses";
    }

    private static IEnumerable<TypeModel> FlowEntities(TypeModel entryPoint, SolutionModel solution)
    {
        var allTypes = solution.Projects.SelectMany(project => project.Types).ToArray();
        var visited = new HashSet<string>(StringComparer.Ordinal);
        var entities = new List<TypeModel>();
        CollectFlowEntities(entryPoint, solution, allTypes, visited, entities, depth: 0);
        return entities.DistinctBy(type => type.FullName);
    }

    private static void CollectFlowEntities(
        TypeModel current,
        SolutionModel solution,
        IReadOnlyList<TypeModel> allTypes,
        ISet<string> visited,
        ICollection<TypeModel> entities,
        int depth)
    {
        if (depth > 4 || !visited.Add(current.FullName))
        {
            return;
        }

        foreach (var dependency in SemanticGraphDependencies(current))
        {
            var next = FindTypeByDependency(solution, allTypes, dependency.TargetType, dependency.Kind);
            if (next is null)
            {
                continue;
            }

            if (IsDomainType(next))
            {
                entities.Add(next);
            }

            CollectFlowEntities(next, solution, allTypes, visited, entities, depth + 1);
        }
    }

    private static IReadOnlyList<LanguageTerm> UbiquitousTerms(SolutionModel solution)
    {
        var signals = solution.Projects.SelectMany(project => project.Types)
            .SelectMany(type => SplitWords(type.Name)
                .Concat(type.PublicMethods.SelectMany(method => SplitWords(method.Name)))
                .Concat(type.Summary is null ? [] : SplitWords(type.Summary))
                .Concat(type.Namespace.Split('.', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)))
            .Select(NormalizeBusinessTerm)
            .Where(IsBusinessToken)
            .GroupBy(term => term, StringComparer.OrdinalIgnoreCase)
            .Select(group => new LanguageTerm(group.Key, group.Count(), TermSignals(solution, group.Key)))
            .OrderByDescending(term => term.Count)
            .ThenBy(term => term.Term, StringComparer.Ordinal)
            .ToArray();

        return signals;
    }

    private static IReadOnlyList<string> TermSignals(SolutionModel solution, string term)
    {
        return solution.Projects.SelectMany(project => project.Types)
            .Where(type => type.Name.Contains(term, StringComparison.OrdinalIgnoreCase)
                || type.Namespace.Contains(term, StringComparison.OrdinalIgnoreCase)
                || type.PublicMethods.Any(method => method.Name.Contains(term, StringComparison.OrdinalIgnoreCase)))
            .Select(type => type.Name)
            .Distinct(StringComparer.Ordinal)
            .Take(8)
            .ToArray();
    }

    private static IEnumerable<RiskProfile> RiskProfiles(SolutionModel solution)
    {
        var allTypes = solution.Projects.SelectMany(project => project.Types).ToArray();
        foreach (var type in allTypes)
        {
            var fanIn = TypesReferencing(solution, type).Count();
            var fanOut = SemanticGraphDependencies(type).Count();
            var reasons = new List<string>();
            var score = 0;

            if (fanIn >= 10) { score += 30; reasons.Add($"high fan-in {fanIn}"); }
            else if (fanIn >= 4) { score += 15; reasons.Add($"fan-in {fanIn}"); }

            if (fanOut >= 8) { score += 25; reasons.Add($"high fan-out {fanOut}"); }
            else if (fanOut >= 4) { score += 12; reasons.Add($"fan-out {fanOut}"); }

            if (type.PublicMethods.Count >= 20) { score += 20; reasons.Add($"{type.PublicMethods.Count} public methods"); }
            if (type.SourceLineCount >= 500) { score += 25; reasons.Add($"{type.SourceLineCount} LOC"); }
            else if (type.SourceLineCount >= 200) { score += 12; reasons.Add($"{type.SourceLineCount} LOC"); }

            if (type.IsDangerousZone) { score += 20; reasons.Add("dangerous zone"); }
            if (type.ArchitecturalRole is ArchitecturalRole.DbContext or ArchitecturalRole.Middleware or ArchitecturalRole.Controller or ArchitecturalRole.Endpoint) { score += 15; reasons.Add($"critical role {type.ArchitecturalRole}"); }
            if (type.Technologies.Any(technology => technology.Contains("Entity Framework", StringComparison.Ordinal) || technology.Contains("MediatR", StringComparison.Ordinal))) { score += 10; reasons.Add("central technology boundary"); }
            if (LegacySignals(type, solution).Count > 0) { score += 20; reasons.Add("legacy signal"); }
            if (CrossLayerViolation(type, solution) is { } violation) { score += 20; reasons.Add(violation); }

            yield return new RiskProfile(type, Math.Clamp(score, 0, 100), fanIn, fanOut, reasons.Distinct(StringComparer.Ordinal).ToArray());
        }
    }

    private static IReadOnlyList<string> LegacySignals(TypeModel type, SolutionModel solution)
    {
        var text = $"{type.FullName} {type.BaseType} {string.Join(' ', type.Interfaces)} {string.Join(' ', type.Technologies)} {string.Join(' ', type.PublicMethods.Select(method => method.Name))}";
        var project = solution.Projects.FirstOrDefault(project => project.Name == type.ProjectName);
        var dependencies = string.Join(' ', project?.DeclaredDependencies ?? []);
        var signals = new List<string>();
        if (text.Contains("System.Data.Entity", StringComparison.OrdinalIgnoreCase)
            || dependencies.Split(' ', StringSplitOptions.RemoveEmptyEntries).Any(dependency =>
                dependency.Equals("EntityFramework", StringComparison.OrdinalIgnoreCase)
                || dependency.StartsWith("EntityFramework.", StringComparison.OrdinalIgnoreCase)))
        {
            signals.Add("EF6");
        }
        if (dependencies.Contains("Unity", StringComparison.OrdinalIgnoreCase) || text.Contains("UnityContainer", StringComparison.OrdinalIgnoreCase)) signals.Add("Unity IoC");
        if (text.Contains("System.Reflection", StringComparison.OrdinalIgnoreCase)) signals.Add("reflection-heavy");
        if (text.Contains("Thread.Sleep", StringComparison.OrdinalIgnoreCase)) signals.Add("Thread.Sleep");
        if (text.Contains("Obsolete", StringComparison.OrdinalIgnoreCase)) signals.Add("obsolete API");
        if (dependencies.Contains("System.ServiceModel", StringComparison.OrdinalIgnoreCase) || text.Contains("ServiceContract", StringComparison.OrdinalIgnoreCase)) signals.Add("WCF");
        if (dependencies.Contains("Microsoft.AspNet.Mvc", StringComparison.OrdinalIgnoreCase)) signals.Add("old ASP.NET MVC");
        return signals.Distinct(StringComparer.Ordinal).ToArray();
    }

    private static string? CrossLayerViolation(TypeModel type, SolutionModel solution)
    {
        var allTypes = solution.Projects.SelectMany(project => project.Types).ToArray();
        foreach (var dependency in SemanticGraphDependencies(type))
        {
            if (dependency.TargetType.Contains(".Interfaces.", StringComparison.Ordinal))
            {
                continue;
            }

            var target = FindTypeByDependency(solution, allTypes, dependency.TargetType, dependency.Kind);
            if (target is null)
            {
                continue;
            }

            if (type.Layer == ArchitectureLayer.Application && target.Layer == ArchitectureLayer.Infrastructure)
            {
                return "Application -> Infrastructure";
            }

            if (type.Layer == ArchitectureLayer.UI && target.ArchitecturalRole is ArchitecturalRole.Repository or ArchitecturalRole.DbContext)
            {
                return "UI -> persistence";
            }

            if (type.ArchitecturalRole is ArchitecturalRole.Controller or ArchitecturalRole.Endpoint && target.ArchitecturalRole == ArchitecturalRole.DbContext)
            {
                return "entry point -> DbContext";
            }
        }

        return null;
    }

    private static string RiskLevel(int score)
    {
        return score >= 70 ? "HIGH" : score >= 40 ? "MEDIUM" : "LOW";
    }

    private static string BusinessResponsibilities(TypeModel type)
    {
        var signals = new List<string>();
        if (!string.IsNullOrWhiteSpace(type.Summary)) signals.Add(type.Summary!);
        if (type.ArchitecturalRole == ArchitecturalRole.AggregateRoot) signals.Add("aggregate boundary");
        if (type.ArchitecturalRole == ArchitecturalRole.Entity) signals.Add("business state");
        if (type.ArchitecturalRole == ArchitecturalRole.ValueObject) signals.Add("domain value");
        if (type.Patterns.Count > 0) signals.Add(string.Join(", ", type.Patterns));
        return signals.Count == 0 ? "inferred from domain relationships and naming" : string.Join("; ", signals.Take(3));
    }

    private static string HumanizeUseCaseName(string name)
    {
        return string.Join(' ', SplitWords(name)).Replace(" Async", string.Empty, StringComparison.Ordinal).Trim();
    }

    private static IEnumerable<string> SplitWords(string value)
    {
        return System.Text.RegularExpressions.Regex
            .Matches(value.Replace("_", " ", StringComparison.Ordinal), @"[A-Z]?[a-z]+|[A-Z]+(?![a-z])|\d+")
            .Select(match => match.Value)
            .Where(word => word.Length > 1);
    }

    private static string NormalizeBusinessTerm(string term)
    {
        var trimmed = term.Trim();
        if (trimmed.EndsWith("ies", StringComparison.OrdinalIgnoreCase) && trimmed.Length > 4)
        {
            return $"{trimmed[..^3]}y";
        }

        return trimmed.EndsWith('s') && trimmed.Length > 4 ? trimmed[..^1] : trimmed;
    }

    private static bool IsBusinessToken(string token)
    {
        var normalized = NormalizeBusinessTerm(token);
        if (normalized.Length < 3)
        {
            return false;
        }

        if (normalized.EndsWith("Endpoint", StringComparison.OrdinalIgnoreCase)
            || normalized.EndsWith("Request", StringComparison.OrdinalIgnoreCase)
            || normalized.EndsWith("Response", StringComparison.OrdinalIgnoreCase)
            || normalized.EndsWith("ViewModel", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        string[] noise =
        [
            "Microsoft", "System", "Web", "Core", "Data", "Infrastructure", "Application", "ApplicationCore", "Public", "PublicApi", "Api", "Test", "Tests",
            "eShopWeb", "BlazorShared", "BlazorAdmin", "AspNetCore",
            "Service", "Services", "Interface", "Interfaces", "Model", "Models", "View", "Views", "Page", "Pages",
            "Controller", "Endpoint", "Request", "Response", "Async", "Task", "List", "Result", "Base", "Config",
            "Configuration", "Extensions", "Helper", "Helpers", "Return", "With", "Get", "Set", "Create", "Update",
            "Delete", "Unit", "UnitTest", "Ardali", "Ardalis", "Program", "Handler", "Type", "Entity",
            "Configure", "Repository", "Uri", "FunctionalTest", "Logging", "Email", "ViewModel", "Endpoint"
        ];

        return !noise.Any(item => string.Equals(normalized, item, StringComparison.OrdinalIgnoreCase));
    }

    private static bool IsContextNameAllowed(string contextName)
    {
        string[] noise =
        [
            "Configure",
            "Repository",
            "Uri",
            "FunctionalTest",
            "Logging",
            "Email",
            "ViewModel",
            "Entity",
            "Endpoint",
            "AuthEndpoint"
        ];

        return !noise.Any(item => string.Equals(contextName, item, StringComparison.OrdinalIgnoreCase));
    }

    private static string ScoreReason(TypeModel type)
    {
        var reasons = new List<string>();
        if (type.ArchitecturalRole != ArchitecturalRole.Unknown)
        {
            reasons.Add($"role {type.ArchitecturalRole}");
        }

        if (type.Patterns.Count > 0)
        {
            reasons.Add($"patterns {string.Join(", ", type.Patterns.Take(4))}");
        }

        if (type.Technologies.Count > 0)
        {
            reasons.Add($"tech {string.Join(", ", type.Technologies.Take(4))}");
        }

        var dependencyCount = SemanticGraphDependencies(type).Count();
        if (dependencyCount > 0)
        {
            reasons.Add($"{dependencyCount} semantic deps");
        }

        if (type.IsDangerousZone)
        {
            reasons.Add("dangerous zone");
        }

        return reasons.Count == 0 ? "low architectural signal" : string.Join("; ", reasons);
    }

    private static string FormatFlow(TypeModel entryPoint, SolutionModel solution)
    {
        var allTypes = solution.Projects.SelectMany(project => project.Types).ToArray();
        var visited = new HashSet<string>(StringComparer.Ordinal);
        var nodes = new List<string>();
        AppendFlow(entryPoint, solution, allTypes, visited, nodes, depth: 0);
        return string.Join(" -> ", nodes.Distinct(StringComparer.Ordinal));
    }

    private static void AppendFlow(
        TypeModel current,
        SolutionModel solution,
        IReadOnlyList<TypeModel> allTypes,
        ISet<string> visited,
        ICollection<string> nodes,
        int depth)
    {
        if (depth > 4 || !visited.Add(current.FullName))
        {
            return;
        }

        nodes.Add($"{current.ArchitecturalRole}:{current.Name}");

        var nextTypes = SemanticGraphDependencies(current)
            .Select(dependency => FindTypeByDependency(solution, allTypes, dependency.TargetType, dependency.Kind))
            .Where(type => type is not null)
            .Cast<TypeModel>()
            .Where(type => type.ArchitecturalRole is not ArchitecturalRole.DTO and not ArchitecturalRole.ViewModel and not ArchitecturalRole.Unknown)
            .OrderByDescending(type => RoleWeight(type.ArchitecturalRole))
            .ThenByDescending(type => type.RelevanceScore)
            .Take(3)
            .ToArray();

        foreach (var next in nextTypes)
        {
            AppendFlow(next, solution, allTypes, visited, nodes, depth + 1);
        }
    }

    private static TypeModel? FindTypeByDependency(
        SolutionModel solution,
        IEnumerable<TypeModel> allTypes,
        string dependency,
        DependencyKind kind)
    {
        var all = allTypes.ToArray();
        var genericDefinition = GenericDefinition(dependency);
        var direct = FindIocImplementation(solution, all, dependency, genericDefinition)
            ?? all.FirstOrDefault(type => string.Equals(type.FullName, dependency, StringComparison.Ordinal))
            ?? all.FirstOrDefault(type => string.Equals(GenericDefinition(type.FullName), genericDefinition, StringComparison.Ordinal))
            ?? all.FirstOrDefault(type => string.Equals(type.Name, dependency, StringComparison.Ordinal));

        if (direct is not null)
        {
            return direct;
        }

        if (kind == DependencyKind.DbSet)
        {
            var inner = StripGenericWrapper(dependency);
            return all.FirstOrDefault(type => string.Equals(type.FullName, inner, StringComparison.Ordinal))
                ?? all.FirstOrDefault(type => inner.EndsWith($".{type.Name}", StringComparison.Ordinal));
        }

        return all.FirstOrDefault(type => dependency.EndsWith($".{type.Name}", StringComparison.Ordinal) || string.Equals(type.Name, dependency, StringComparison.Ordinal));
    }

    private static TypeModel? FindIocImplementation(
        SolutionModel solution,
        IReadOnlyList<TypeModel> allTypes,
        string dependency,
        string genericDefinition)
    {
        var registration = solution.Projects
            .SelectMany(project => project.IoCRegistrations)
            .FirstOrDefault(candidate =>
                string.Equals(candidate.InterfaceType, dependency, StringComparison.Ordinal)
                || string.Equals(GenericDefinition(candidate.InterfaceType), genericDefinition, StringComparison.Ordinal));

        if (registration is null)
        {
            return null;
        }

        var implementationDefinition = GenericDefinition(registration.ImplementationType);
        return allTypes.FirstOrDefault(type => string.Equals(type.FullName, registration.ImplementationType, StringComparison.Ordinal))
            ?? allTypes.FirstOrDefault(type => string.Equals(GenericDefinition(type.FullName), implementationDefinition, StringComparison.Ordinal));
    }

    private static string StripGenericWrapper(string typeName)
    {
        var start = typeName.IndexOf('<', StringComparison.Ordinal);
        var end = typeName.LastIndexOf('>');
        if (start >= 0 && end > start)
        {
            return typeName[(start + 1)..end].Split(',')[0].Trim();
        }

        return typeName;
    }

    private static string GenericDefinition(string typeName)
    {
        var start = typeName.IndexOf('<', StringComparison.Ordinal);
        if (start < 0)
        {
            return typeName;
        }

        return $"{typeName[..start]}<>";
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
