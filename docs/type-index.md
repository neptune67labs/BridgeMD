# Type Index

## BridgeMD.Roslyn.SolutionAnalyzer

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Analyzer |
| Layer | Infrastructure |
| Relevance | Medium / 46 |
| Reason | role Analyzer; patterns Analyzer; 2 semantic deps |
| Namespace | `BridgeMD.Roslyn` |
| Project | `BridgeMD.Roslyn` |
| Base type | none |
| Interfaces | none |
| Patterns | `Analyzer` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<SolutionModel> AnalyzeAsync(string solutionPath, AnalysisOptions? options, CancellationToken cancellationToken)`

Semantic dependencies:
- none

## BridgeMD.Syntax.SyntaxSolutionAnalyzer

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Analyzer |
| Layer | Unknown |
| Relevance | Medium / 44 |
| Reason | role Analyzer; patterns Analyzer |
| Namespace | `BridgeMD.Syntax` |
| Project | `BridgeMD.Syntax` |
| Base type | none |
| Interfaces | none |
| Patterns | `Analyzer` |
| Technologies | none |
| Summary | none |

Public methods:
- `ProjectModel? AnalyzeProject(string projectPath, AnalysisOptions? options, CancellationToken cancellationToken)`
- `Task<SolutionModel> AnalyzeSolutionAsync(string solutionPath, AnalysisOptions? options, IReadOnlyList<AnalysisDiagnostic>? diagnostics, TimeSpan? elapsed, CancellationToken cancellationToken)`
- `IReadOnlyList<string> DiscoverProjectPaths(string solutionPath, AnalysisOptions? options)`

Semantic dependencies:
- none

## BridgeMD.Markdown.MarkdownDocumentationWriter.RiskProfile

| Field | Value |
| --- | --- |
| Kind | Record |
| Role | Mapper |
| Layer | Application |
| Relevance | Medium / 42 |
| Reason | role Mapper; patterns Writer |
| Namespace | `BridgeMD.Markdown` |
| Project | `BridgeMD.Markdown` |
| Base type | none |
| Interfaces | `System.IEquatable<BridgeMD.Markdown.MarkdownDocumentationWriter.RiskProfile>` |
| Patterns | `Writer` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BridgeMD.Markdown.MarkdownDocumentationWriter

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Writer |
| Layer | Application |
| Relevance | Medium / 40 |
| Reason | role Writer; patterns Writer |
| Namespace | `BridgeMD.Markdown` |
| Project | `BridgeMD.Markdown` |
| Base type | none |
| Interfaces | none |
| Patterns | `Writer` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task WriteAsync(SolutionModel solution, CancellationToken cancellationToken)`

Semantic dependencies:
- none

## BridgeMD.Markdown.MarkdownDocumentationWriter.BoundedContextModel

| Field | Value |
| --- | --- |
| Kind | Record |
| Role | Writer |
| Layer | Application |
| Relevance | Low / 30 |
| Reason | role Writer; patterns Writer |
| Namespace | `BridgeMD.Markdown` |
| Project | `BridgeMD.Markdown` |
| Base type | none |
| Interfaces | `System.IEquatable<BridgeMD.Markdown.MarkdownDocumentationWriter.BoundedContextModel>` |
| Patterns | `Writer` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BridgeMD.Markdown.MarkdownDocumentationWriter.DomainRelationship

| Field | Value |
| --- | --- |
| Kind | Record |
| Role | Writer |
| Layer | Domain |
| Relevance | Low / 30 |
| Reason | role Writer; patterns Writer |
| Namespace | `BridgeMD.Markdown` |
| Project | `BridgeMD.Markdown` |
| Base type | none |
| Interfaces | `System.IEquatable<BridgeMD.Markdown.MarkdownDocumentationWriter.DomainRelationship>` |
| Patterns | `Writer` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BridgeMD.Markdown.MarkdownDocumentationWriter.LanguageTerm

| Field | Value |
| --- | --- |
| Kind | Record |
| Role | Writer |
| Layer | Application |
| Relevance | Low / 30 |
| Reason | role Writer; patterns Writer |
| Namespace | `BridgeMD.Markdown` |
| Project | `BridgeMD.Markdown` |
| Base type | none |
| Interfaces | `System.IEquatable<BridgeMD.Markdown.MarkdownDocumentationWriter.LanguageTerm>` |
| Patterns | `Writer` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BridgeMD.Roslyn.SemanticDependencyFilter

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Infrastructure |
| Relevance | Low / 29 |
| Reason | 3 semantic deps |
| Namespace | `BridgeMD.Roslyn` |
| Project | `BridgeMD.Roslyn` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `IReadOnlyList<TypeDependencyModel> Filter(IEnumerable<TypeDependencyModel> dependencies)`

Semantic dependencies:
- none

## BridgeMD.Roslyn.DependencyDeduplicator

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Infrastructure |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `BridgeMD.Roslyn` |
| Project | `BridgeMD.Roslyn` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `IReadOnlyList<TypeDependencyModel> Deduplicate(IEnumerable<TypeDependencyModel> dependencies)`

Semantic dependencies:
- none

## BridgeMD.Roslyn.FrameworkNoiseFilter

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Infrastructure |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `BridgeMD.Roslyn` |
| Project | `BridgeMD.Roslyn` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `bool IsNoise(string typeName)`

Semantic dependencies:
- none

## BridgeMD.Roslyn.PrimitiveTypeFilter

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Infrastructure |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `BridgeMD.Roslyn` |
| Project | `BridgeMD.Roslyn` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `bool IsPrimitive(string typeName)`

Semantic dependencies:
- none

## BridgeMD.Core.AnalysisDiagnostic

| Field | Value |
| --- | --- |
| Kind | Record |
| Role | Unknown |
| Layer | Shared |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `BridgeMD.Core` |
| Project | `BridgeMD.Core` |
| Base type | none |
| Interfaces | `System.IEquatable<BridgeMD.Core.AnalysisDiagnostic>` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BridgeMD.Core.AnalysisOptions

| Field | Value |
| --- | --- |
| Kind | Record |
| Role | Unknown |
| Layer | Shared |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `BridgeMD.Core` |
| Project | `BridgeMD.Core` |
| Base type | none |
| Interfaces | `System.IEquatable<BridgeMD.Core.AnalysisOptions>` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BridgeMD.Core.AnalysisSummary

| Field | Value |
| --- | --- |
| Kind | Record |
| Role | Unknown |
| Layer | Shared |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `BridgeMD.Core` |
| Project | `BridgeMD.Core` |
| Base type | none |
| Interfaces | `System.IEquatable<BridgeMD.Core.AnalysisSummary>` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BridgeMD.Core.IoCRegistrationModel

| Field | Value |
| --- | --- |
| Kind | Record |
| Role | Unknown |
| Layer | Shared |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `BridgeMD.Core` |
| Project | `BridgeMD.Core` |
| Base type | none |
| Interfaces | `System.IEquatable<BridgeMD.Core.IoCRegistrationModel>` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BridgeMD.Core.MethodModel

| Field | Value |
| --- | --- |
| Kind | Record |
| Role | Unknown |
| Layer | Shared |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `BridgeMD.Core` |
| Project | `BridgeMD.Core` |
| Base type | none |
| Interfaces | `System.IEquatable<BridgeMD.Core.MethodModel>` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BridgeMD.Core.ParameterModel

| Field | Value |
| --- | --- |
| Kind | Record |
| Role | Unknown |
| Layer | Shared |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `BridgeMD.Core` |
| Project | `BridgeMD.Core` |
| Base type | none |
| Interfaces | `System.IEquatable<BridgeMD.Core.ParameterModel>` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BridgeMD.Core.ProjectModel

| Field | Value |
| --- | --- |
| Kind | Record |
| Role | Unknown |
| Layer | Shared |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `BridgeMD.Core` |
| Project | `BridgeMD.Core` |
| Base type | none |
| Interfaces | `System.IEquatable<BridgeMD.Core.ProjectModel>` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BridgeMD.Core.ProjectReferenceModel

| Field | Value |
| --- | --- |
| Kind | Record |
| Role | Unknown |
| Layer | Shared |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `BridgeMD.Core` |
| Project | `BridgeMD.Core` |
| Base type | none |
| Interfaces | `System.IEquatable<BridgeMD.Core.ProjectReferenceModel>` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BridgeMD.Core.SolutionModel

| Field | Value |
| --- | --- |
| Kind | Record |
| Role | Unknown |
| Layer | Shared |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `BridgeMD.Core` |
| Project | `BridgeMD.Core` |
| Base type | none |
| Interfaces | `System.IEquatable<BridgeMD.Core.SolutionModel>` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BridgeMD.Core.TypeDependencyModel

| Field | Value |
| --- | --- |
| Kind | Record |
| Role | Unknown |
| Layer | Shared |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `BridgeMD.Core` |
| Project | `BridgeMD.Core` |
| Base type | none |
| Interfaces | `System.IEquatable<BridgeMD.Core.TypeDependencyModel>` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BridgeMD.Core.TypeModel

| Field | Value |
| --- | --- |
| Kind | Record |
| Role | Unknown |
| Layer | Shared |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `BridgeMD.Core` |
| Project | `BridgeMD.Core` |
| Base type | none |
| Interfaces | `System.IEquatable<BridgeMD.Core.TypeModel>` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BridgeMD.Core.AnalysisDiagnosticSeverity

| Field | Value |
| --- | --- |
| Kind | Enum |
| Role | Unknown |
| Layer | Shared |
| Relevance | Low / 3 |
| Reason | low architectural signal |
| Namespace | `BridgeMD.Core` |
| Project | `BridgeMD.Core` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BridgeMD.Core.ArchitecturalRole

| Field | Value |
| --- | --- |
| Kind | Enum |
| Role | Unknown |
| Layer | Shared |
| Relevance | Low / 3 |
| Reason | low architectural signal |
| Namespace | `BridgeMD.Core` |
| Project | `BridgeMD.Core` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BridgeMD.Core.ArchitectureLayer

| Field | Value |
| --- | --- |
| Kind | Enum |
| Role | Unknown |
| Layer | Shared |
| Relevance | Low / 3 |
| Reason | low architectural signal |
| Namespace | `BridgeMD.Core` |
| Project | `BridgeMD.Core` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BridgeMD.Core.CodeTypeKind

| Field | Value |
| --- | --- |
| Kind | Enum |
| Role | Unknown |
| Layer | Shared |
| Relevance | Low / 3 |
| Reason | low architectural signal |
| Namespace | `BridgeMD.Core` |
| Project | `BridgeMD.Core` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BridgeMD.Core.DependencyKind

| Field | Value |
| --- | --- |
| Kind | Enum |
| Role | Unknown |
| Layer | Shared |
| Relevance | Low / 3 |
| Reason | low architectural signal |
| Namespace | `BridgeMD.Core` |
| Project | `BridgeMD.Core` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BridgeMD.Core.RelevanceCategory

| Field | Value |
| --- | --- |
| Kind | Enum |
| Role | Unknown |
| Layer | Shared |
| Relevance | Low / 3 |
| Reason | low architectural signal |
| Namespace | `BridgeMD.Core` |
| Project | `BridgeMD.Core` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

