# Project Index

## BridgeMD.Cli

- Layer: `UI`
- Purpose: No source types detected.
- Frameworks: `net8.0`
- Project references: `BridgeMD.Core`, `BridgeMD.Markdown`, `BridgeMD.Roslyn`
- Declared dependencies: none
- Technologies: none
- Detected patterns: none

| Type | Role | Layer | Score | Category | Patterns |
| --- | --- | --- | ---: | --- | --- |

## BridgeMD.Core

- Layer: `Shared`
- Purpose: General C# project centered around BridgeMD.Core.
- Frameworks: `net8.0`
- Project references: none
- Declared dependencies: none
- Technologies: none
- Detected patterns: none

| Type | Role | Layer | Score | Category | Patterns |
| --- | --- | --- | ---: | --- | --- |
| `BridgeMD.Core.IoCRegistrationModel` | Unknown | Shared | 18 | Low | none |
| `BridgeMD.Core.MethodModel` | Unknown | Shared | 18 | Low | none |
| `BridgeMD.Core.ParameterModel` | Unknown | Shared | 18 | Low | none |
| `BridgeMD.Core.ProjectModel` | Unknown | Shared | 18 | Low | none |
| `BridgeMD.Core.ProjectReferenceModel` | Unknown | Shared | 18 | Low | none |
| `BridgeMD.Core.SolutionModel` | Unknown | Shared | 18 | Low | none |
| `BridgeMD.Core.TypeDependencyModel` | Unknown | Shared | 18 | Low | none |
| `BridgeMD.Core.TypeModel` | Unknown | Shared | 18 | Low | none |
| `BridgeMD.Core.ArchitecturalRole` | Unknown | Shared | 3 | Low | none |
| `BridgeMD.Core.ArchitectureLayer` | Unknown | Shared | 3 | Low | none |
| `BridgeMD.Core.CodeTypeKind` | Unknown | Shared | 3 | Low | none |
| `BridgeMD.Core.DependencyKind` | Unknown | Shared | 3 | Low | none |
| `BridgeMD.Core.RelevanceCategory` | Unknown | Shared | 3 | Low | none |

## BridgeMD.Markdown

- Layer: `Application`
- Purpose: Contains Writer code.
- Frameworks: `net8.0`
- Project references: `BridgeMD.Core`
- Declared dependencies: none
- Technologies: none
- Detected patterns: `Writer`

| Type | Role | Layer | Score | Category | Patterns |
| --- | --- | --- | ---: | --- | --- |
| `BridgeMD.Markdown.MarkdownDocumentationWriter.RiskProfile` | Mapper | Application | 42 | Medium | `Writer` |
| `BridgeMD.Markdown.MarkdownDocumentationWriter` | Writer | Application | 40 | Medium | `Writer` |
| `BridgeMD.Markdown.MarkdownDocumentationWriter.BoundedContextModel` | Writer | Application | 30 | Low | `Writer` |
| `BridgeMD.Markdown.MarkdownDocumentationWriter.DomainRelationship` | Writer | Domain | 30 | Low | `Writer` |
| `BridgeMD.Markdown.MarkdownDocumentationWriter.LanguageTerm` | Writer | Application | 30 | Low | `Writer` |

## BridgeMD.Roslyn

- Layer: `Infrastructure`
- Purpose: Contains MSBuildWorkspace, Roslyn, Analyzer code.
- Frameworks: `net8.0`
- Project references: `BridgeMD.Core`
- Declared dependencies: `Microsoft.Build`, `Microsoft.Build.Framework`, `Microsoft.Build.Locator`, `Microsoft.Build.Tasks.Core`, `Microsoft.Build.Utilities.Core`, `Microsoft.CodeAnalysis.CSharp.Workspaces`, `Microsoft.CodeAnalysis.Workspaces.MSBuild`, `Microsoft.NET.StringTools`, `NuGet.Frameworks`
- Technologies: `MSBuildWorkspace`, `Roslyn`
- Detected patterns: `Analyzer`

| Type | Role | Layer | Score | Category | Patterns |
| --- | --- | --- | ---: | --- | --- |
| `BridgeMD.Roslyn.SolutionAnalyzer` | Analyzer | Infrastructure | 46 | Medium | `Analyzer` |
| `BridgeMD.Roslyn.SemanticDependencyFilter` | Unknown | Infrastructure | 29 | Low | none |
| `BridgeMD.Roslyn.DependencyDeduplicator` | Unknown | Infrastructure | 20 | Low | none |
| `BridgeMD.Roslyn.FrameworkNoiseFilter` | Unknown | Infrastructure | 20 | Low | none |
| `BridgeMD.Roslyn.PrimitiveTypeFilter` | Unknown | Infrastructure | 20 | Low | none |

