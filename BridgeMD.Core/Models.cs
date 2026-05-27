namespace BridgeMD.Core;

public sealed record SolutionModel(
    string Name,
    string FilePath,
    string RootPath,
    IReadOnlyList<ProjectModel> Projects,
    AnalysisSummary? AnalysisSummary = null)
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

public sealed record AnalysisOptions(
    bool ForceSyntaxOnly = false,
    bool ContinueOnError = true,
    bool Diagnostics = false,
    bool SemanticStrict = false,
    TimeSpan? ProjectTimeout = null,
    string? MSBuildPath = null,
    string? VisualStudioVersion = null,
    string? SdkPath = null,
    IReadOnlyList<string>? ExcludedProjects = null,
    IReadOnlyList<string>? ExcludedFolders = null,
    string? SolutionFilter = null);

public sealed record AnalysisSummary(
    int ProjectsDiscovered,
    int ProjectsAnalyzedSemantically,
    int ProjectsAnalyzedSyntactically,
    int ProjectsFailed,
    TimeSpan Elapsed,
    IReadOnlyList<AnalysisDiagnostic> Diagnostics)
{
    public double SemanticCoverage => ProjectsDiscovered == 0 ? 0 : (double)ProjectsAnalyzedSemantically / ProjectsDiscovered;

    public double SyntaxFallbackCoverage => ProjectsDiscovered == 0
        ? 0
        : (double)(ProjectsAnalyzedSemantically + ProjectsAnalyzedSyntactically) / ProjectsDiscovered;
}

public sealed record AnalysisDiagnostic(
    AnalysisDiagnosticSeverity Severity,
    string Code,
    string Message,
    string? ProjectName = null,
    string? ProjectPath = null);

public enum AnalysisDiagnosticSeverity
{
    Info,
    Warning,
    Error
}

public sealed record ProjectModel(
    string Name,
    string FilePath,
    ArchitectureLayer Layer,
    IReadOnlyList<string> TargetFrameworks,
    IReadOnlyList<ProjectReferenceModel> ProjectReferences,
    IReadOnlyList<string> DeclaredDependencies,
    IReadOnlyList<string> Technologies,
    IReadOnlyList<IoCRegistrationModel> IoCRegistrations,
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
    string? FilePath,
    ArchitectureLayer Layer,
    ArchitecturalRole ArchitecturalRole,
    string? BaseType,
    IReadOnlyList<string> Interfaces,
    IReadOnlyList<MethodModel> PublicMethods,
    IReadOnlyList<string> Patterns,
    IReadOnlyList<string> Technologies,
    IReadOnlyList<TypeDependencyModel> Dependencies,
    RelevanceCategory RelevanceCategory,
    int RelevanceScore,
    int SourceLineCount,
    bool IsGenerated,
    bool IsMigration,
    bool IsDangerousZone,
    string? Summary);

public sealed record MethodModel(
    string Name,
    string ReturnType,
    IReadOnlyList<ParameterModel> Parameters,
    bool IsStatic);

public sealed record ParameterModel(string Name, string Type);

public sealed record TypeDependencyModel(
    string SourceType,
    string TargetType,
    DependencyKind Kind,
    string? MemberName);

public sealed record IoCRegistrationModel(
    string InterfaceType,
    string ImplementationType,
    string RegistrationKind,
    string Location);

public enum CodeTypeKind
{
    Class,
    Interface,
    Record,
    Enum,
    Struct
}

public enum ArchitectureLayer
{
    Unknown,
    Domain,
    Application,
    Infrastructure,
    UI,
    API,
    Shared,
    Tests
}

public enum ArchitecturalRole
{
    Unknown,
    Controller,
    Endpoint,
    Repository,
    DbContext,
    Entity,
    AggregateRoot,
    ValueObject,
    Specification,
    CQRSHandler,
    Command,
    Query,
    ApplicationService,
    DomainService,
    Middleware,
    DTO,
    ViewModel,
    Configuration,
    Mapper,
    HostedService,
    Factory,
    Adapter,
    Decorator,
    Analyzer,
    Writer
}

public enum RelevanceCategory
{
    Low,
    Medium,
    High
}

public enum DependencyKind
{
    ConstructorInjection,
    Field,
    Property,
    MethodParameter,
    ReturnType,
    DbSet,
    MediatR,
    Instantiation
}
