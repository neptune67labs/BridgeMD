# Project Index

## BridgeMD.Cli

- Layer: `UI`
- Purpose: No source types detected.
- Frameworks: `net8.0`
- Project references: `BridgeMD.Core`, `BridgeMD.Markdown`, `BridgeMD.Roslyn`
- Declared dependencies: none
- Technologies: none
- Detected patterns: none

| Type | Layer | Score | Category | Patterns |
| --- | --- | ---: | --- | --- |

## BridgeMD.Core

- Layer: `Shared`
- Purpose: General C# project centered around BridgeMD.Core.
- Frameworks: `net8.0`
- Project references: none
- Declared dependencies: none
- Technologies: none
- Detected patterns: none

| Type | Layer | Score | Category | Patterns |
| --- | --- | ---: | --- | --- |
| `BridgeMD.Core.IoCRegistrationModel` | Shared | 18 | Low | none |
| `BridgeMD.Core.MethodModel` | Shared | 18 | Low | none |
| `BridgeMD.Core.ParameterModel` | Shared | 18 | Low | none |
| `BridgeMD.Core.ProjectModel` | Shared | 18 | Low | none |
| `BridgeMD.Core.ProjectReferenceModel` | Shared | 18 | Low | none |
| `BridgeMD.Core.SolutionModel` | Shared | 18 | Low | none |
| `BridgeMD.Core.TypeDependencyModel` | Shared | 18 | Low | none |
| `BridgeMD.Core.TypeModel` | Shared | 18 | Low | none |
| `BridgeMD.Core.ArchitectureLayer` | Shared | 3 | Low | none |
| `BridgeMD.Core.CodeTypeKind` | Shared | 3 | Low | none |
| `BridgeMD.Core.DependencyKind` | Shared | 3 | Low | none |
| `BridgeMD.Core.RelevanceCategory` | Shared | 3 | Low | none |

## BridgeMD.Markdown

- Layer: `Application`
- Purpose: Contains Writer code.
- Frameworks: `net8.0`
- Project references: `BridgeMD.Core`
- Declared dependencies: none
- Technologies: none
- Detected patterns: `Writer`

| Type | Layer | Score | Category | Patterns |
| --- | --- | ---: | --- | --- |
| `BridgeMD.Markdown.MarkdownDocumentationWriter` | Application | 58 | Medium | `Writer` |

## BridgeMD.Roslyn

- Layer: `Infrastructure`
- Purpose: Contains MSBuildWorkspace, Roslyn, Analyzer code.
- Frameworks: `net8.0`
- Project references: `BridgeMD.Core`
- Declared dependencies: `Microsoft.Build`, `Microsoft.Build.Framework`, `Microsoft.Build.Locator`, `Microsoft.Build.Tasks.Core`, `Microsoft.Build.Utilities.Core`, `Microsoft.CodeAnalysis.CSharp.Workspaces`, `Microsoft.CodeAnalysis.Workspaces.MSBuild`, `Microsoft.NET.StringTools`, `NuGet.Frameworks`
- Technologies: `MSBuildWorkspace`, `Roslyn`
- Detected patterns: `Analyzer`

| Type | Layer | Score | Category | Patterns |
| --- | --- | ---: | --- | --- |
| `BridgeMD.Roslyn.SolutionAnalyzer` | Infrastructure | 46 | Medium | `Analyzer` |

