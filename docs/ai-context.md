# AI Context

## Inferred Architecture

- `Clean Architecture`
- `Layered Architecture`

## Detected Layers

- `Application`: 4 types; projects `BridgeMD.Markdown`
- `Domain`: 1 types; projects `BridgeMD.Markdown`
- `Infrastructure`: 5 types; projects `BridgeMD.Roslyn`
- `Shared`: 13 types; projects `BridgeMD.Core`

## Detected Conventions

- Async methods use `Async` suffix (2).

## Risk Areas

- none

## Detected Frameworks And Technologies

- `MSBuildWorkspace`
- `Roslyn`

## Priority Types For AI

| Type | Role | Score | Layer | Why |
| --- | --- | ---: | --- | --- |
| `BridgeMD.Roslyn.SolutionAnalyzer` | Analyzer | 46 | Infrastructure | role Analyzer; patterns Analyzer; 2 semantic deps |
| `BridgeMD.Markdown.MarkdownDocumentationWriter.RiskProfile` | Mapper | 42 | Application | role Mapper; patterns Writer |
| `BridgeMD.Markdown.MarkdownDocumentationWriter` | Writer | 40 | Application | role Writer; patterns Writer |
| `BridgeMD.Markdown.MarkdownDocumentationWriter.BoundedContextModel` | Writer | 30 | Application | role Writer; patterns Writer |
| `BridgeMD.Markdown.MarkdownDocumentationWriter.DomainRelationship` | Writer | 30 | Domain | role Writer; patterns Writer |
| `BridgeMD.Markdown.MarkdownDocumentationWriter.LanguageTerm` | Writer | 30 | Application | role Writer; patterns Writer |
| `BridgeMD.Roslyn.SemanticDependencyFilter` | Unknown | 29 | Infrastructure | 3 semantic deps |
| `BridgeMD.Roslyn.DependencyDeduplicator` | Unknown | 20 | Infrastructure | low architectural signal |
| `BridgeMD.Roslyn.FrameworkNoiseFilter` | Unknown | 20 | Infrastructure | low architectural signal |
| `BridgeMD.Roslyn.PrimitiveTypeFilter` | Unknown | 20 | Infrastructure | low architectural signal |
| `BridgeMD.Core.IoCRegistrationModel` | Unknown | 18 | Shared | low architectural signal |
| `BridgeMD.Core.MethodModel` | Unknown | 18 | Shared | low architectural signal |
| `BridgeMD.Core.ParameterModel` | Unknown | 18 | Shared | low architectural signal |
| `BridgeMD.Core.ProjectModel` | Unknown | 18 | Shared | low architectural signal |
| `BridgeMD.Core.ProjectReferenceModel` | Unknown | 18 | Shared | low architectural signal |
| `BridgeMD.Core.SolutionModel` | Unknown | 18 | Shared | low architectural signal |
| `BridgeMD.Core.TypeDependencyModel` | Unknown | 18 | Shared | low architectural signal |
| `BridgeMD.Core.TypeModel` | Unknown | 18 | Shared | low architectural signal |
| `BridgeMD.Core.ArchitecturalRole` | Unknown | 3 | Shared | low architectural signal |
| `BridgeMD.Core.ArchitectureLayer` | Unknown | 3 | Shared | low architectural signal |
| `BridgeMD.Core.CodeTypeKind` | Unknown | 3 | Shared | low architectural signal |
| `BridgeMD.Core.DependencyKind` | Unknown | 3 | Shared | low architectural signal |
| `BridgeMD.Core.RelevanceCategory` | Unknown | 3 | Shared | low architectural signal |
