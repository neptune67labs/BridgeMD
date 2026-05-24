# AI Context

## Arquitectura inferida

- `Layered Architecture`

## Capas detectadas

- `Application`: 1 types; projects `BridgeMD.Markdown`
- `Infrastructure`: 1 types; projects `BridgeMD.Roslyn`
- `Shared`: 12 types; projects `BridgeMD.Core`

## Convenciones detectadas

- Async methods use `Async` suffix (2).

## Riesgos o zonas delicadas

- none

## Frameworks y tecnologias detectadas

- `MSBuildWorkspace`
- `Roslyn`

## Tipos prioritarios para IA

| Type | Score | Layer | Why |
| --- | ---: | --- | --- |
| `BridgeMD.Markdown.MarkdownDocumentationWriter` | 58 | Application | `Writer` |
| `BridgeMD.Roslyn.SolutionAnalyzer` | 46 | Infrastructure | `Analyzer` |
| `BridgeMD.Core.IoCRegistrationModel` | 18 | Shared | none |
| `BridgeMD.Core.MethodModel` | 18 | Shared | none |
| `BridgeMD.Core.ParameterModel` | 18 | Shared | none |
| `BridgeMD.Core.ProjectModel` | 18 | Shared | none |
| `BridgeMD.Core.ProjectReferenceModel` | 18 | Shared | none |
| `BridgeMD.Core.SolutionModel` | 18 | Shared | none |
| `BridgeMD.Core.TypeDependencyModel` | 18 | Shared | none |
| `BridgeMD.Core.TypeModel` | 18 | Shared | none |
| `BridgeMD.Core.ArchitectureLayer` | 3 | Shared | none |
| `BridgeMD.Core.CodeTypeKind` | 3 | Shared | none |
| `BridgeMD.Core.DependencyKind` | 3 | Shared | none |
| `BridgeMD.Core.RelevanceCategory` | 3 | Shared | none |
