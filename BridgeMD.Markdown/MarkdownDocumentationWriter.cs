using System.Text;
using BridgeMD.Core;

namespace BridgeMD.Markdown;

public sealed class MarkdownDocumentationWriter
{
    public async Task WriteAsync(SolutionModel solution, CancellationToken cancellationToken = default)
    {
        var docsPath = Path.Combine(solution.RootPath, "docs");
        Directory.CreateDirectory(docsPath);

        await File.WriteAllTextAsync(
            Path.Combine(docsPath, "solution-overview.md"),
            RenderSolutionOverview(solution),
            cancellationToken);

        await File.WriteAllTextAsync(
            Path.Combine(docsPath, "project-index.md"),
            RenderProjectIndex(solution),
            cancellationToken);

        await File.WriteAllTextAsync(
            Path.Combine(docsPath, "type-index.md"),
            RenderTypeIndex(solution),
            cancellationToken);
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
        builder.AppendLine();

        builder.AppendLine("## Projects");
        builder.AppendLine();
        builder.AppendLine("| Project | Frameworks | Types | Patterns |");
        builder.AppendLine("| --- | --- | ---: | --- |");
        foreach (var project in solution.Projects)
        {
            builder.AppendLine($"| `{Escape(project.Name)}` | {InlineList(project.TargetFrameworks)} | {project.Types.Count} | {InlineList(project.Patterns)} |");
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
            builder.AppendLine($"- Purpose: {InferPurpose(project)}");
            builder.AppendLine($"- Frameworks: {InlineList(project.TargetFrameworks)}");
            builder.AppendLine($"- Project references: {InlineList(project.ProjectReferences.Select(reference => reference.Name))}");
            builder.AppendLine($"- Declared dependencies: {InlineList(project.DeclaredDependencies)}");
            builder.AppendLine($"- Detected patterns: {InlineList(project.Patterns)}");
            builder.AppendLine();
            builder.AppendLine("| Type | Kind | Namespace | Patterns |");
            builder.AppendLine("| --- | --- | --- | --- |");

            foreach (var type in project.Types.Take(80))
            {
                builder.AppendLine($"| `{Escape(type.Name)}` | {type.Kind} | `{Escape(type.Namespace)}` | {InlineList(type.Patterns)} |");
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

        foreach (var type in solution.Projects.SelectMany(project => project.Types).OrderBy(type => type.FullName, StringComparer.Ordinal))
        {
            builder.AppendLine($"## {Escape(type.FullName)}");
            builder.AppendLine();
            builder.AppendLine("| Field | Value |");
            builder.AppendLine("| --- | --- |");
            builder.AppendLine($"| Kind | {type.Kind} |");
            builder.AppendLine($"| Namespace | `{Escape(type.Namespace)}` |");
            builder.AppendLine($"| Project | `{Escape(type.ProjectName)}` |");
            builder.AppendLine($"| Base type | {InlineValue(type.BaseType)} |");
            builder.AppendLine($"| Interfaces | {InlineList(type.Interfaces)} |");
            builder.AppendLine($"| Patterns | {InlineList(type.Patterns)} |");
            builder.AppendLine();
            builder.AppendLine("Public methods:");

            if (type.PublicMethods.Count == 0)
            {
                builder.AppendLine("- none");
            }
            else
            {
                foreach (var method in type.PublicMethods)
                {
                    builder.AppendLine($"- `{Escape(FormatMethod(method))}`");
                }
            }

            builder.AppendLine();
        }

        return builder.ToString();
    }

    private static string InferPurpose(ProjectModel project)
    {
        if (project.Types.Count == 0)
        {
            return "No source types detected.";
        }

        if (project.Patterns.Count > 0)
        {
            return $"Contains {string.Join(", ", project.Patterns)} oriented code.";
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

    private static string FormatMethod(MethodModel method)
    {
        var parameters = string.Join(", ", method.Parameters.Select(parameter => $"{parameter.Type} {parameter.Name}"));
        var modifier = method.IsStatic ? "static " : string.Empty;
        return $"{modifier}{method.ReturnType} {method.Name}({parameters})";
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

    private static string Escape(string value)
    {
        return value.Replace("|", "\\|", StringComparison.Ordinal);
    }
}
