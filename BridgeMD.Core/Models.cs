namespace BridgeMD.Core;

public sealed record SolutionModel(
    string Name,
    string FilePath,
    string RootPath,
    IReadOnlyList<ProjectModel> Projects)
{
    public int TypeCount => Projects.Sum(project => project.Types.Count);

    public IReadOnlyList<string> Namespaces => Projects
        .SelectMany(project => project.Types)
        .Select(type => type.Namespace)
        .Where(namespaceName => !string.IsNullOrWhiteSpace(namespaceName))
        .Distinct(StringComparer.Ordinal)
        .Order(StringComparer.Ordinal)
        .ToArray();
}

public sealed record ProjectModel(
    string Name,
    string FilePath,
    IReadOnlyList<string> TargetFrameworks,
    IReadOnlyList<ProjectReferenceModel> ProjectReferences,
    IReadOnlyList<string> DeclaredDependencies,
    IReadOnlyList<TypeModel> Types)
{
    public IReadOnlyList<string> Patterns => Types
        .SelectMany(type => type.Patterns)
        .Distinct(StringComparer.Ordinal)
        .Order(StringComparer.Ordinal)
        .ToArray();
}

public sealed record ProjectReferenceModel(string Name, string? FilePath);

public sealed record TypeModel(
    string Name,
    string FullName,
    CodeTypeKind Kind,
    string Namespace,
    string ProjectName,
    string? BaseType,
    IReadOnlyList<string> Interfaces,
    IReadOnlyList<MethodModel> PublicMethods,
    IReadOnlyList<string> Patterns);

public sealed record MethodModel(
    string Name,
    string ReturnType,
    IReadOnlyList<ParameterModel> Parameters,
    bool IsStatic);

public sealed record ParameterModel(string Name, string Type);

public enum CodeTypeKind
{
    Class,
    Interface,
    Record,
    Enum,
    Struct
}
