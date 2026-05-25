# Architecture

## Layers

| Layer | Projects | Key Types | Key Roles | Responsibility |
| --- | --- | --- | --- | --- |
| Application | `BridgeMD.Markdown` | `RiskProfile`, `MarkdownDocumentationWriter`, `BoundedContextModel`, `LanguageTerm` | `Mapper`, `Writer` | Use cases, orchestration, commands, queries, services. |
| Domain | `BridgeMD.Markdown` | `DomainRelationship` | `Writer` | Business concepts, rules, entities, aggregates. |
| Infrastructure | `BridgeMD.Roslyn` | `SolutionAnalyzer`, `SemanticDependencyFilter`, `DependencyDeduplicator`, `FrameworkNoiseFilter`, `PrimitiveTypeFilter` | `Analyzer` | Persistence, external integrations, IoC, EF, repositories. |
| Shared | `BridgeMD.Core` | `IoCRegistrationModel`, `MethodModel`, `ParameterModel`, `ProjectModel`, `ProjectReferenceModel`, `SolutionModel`, `TypeDependencyModel`, `TypeModel` | none | Cross-cutting contracts and reusable primitives. |

## Project Dependencies

| From | To | Inferred Rule |
| --- | --- | --- |
| `BridgeMD.Cli` (UI) | `BridgeMD.Core` (Shared) | allowed or not enough context |
| `BridgeMD.Cli` (UI) | `BridgeMD.Markdown` (Application) | allowed or not enough context |
| `BridgeMD.Cli` (UI) | `BridgeMD.Roslyn` (Infrastructure) | allowed or not enough context |
| `BridgeMD.Markdown` (Application) | `BridgeMD.Core` (Shared) | allowed or not enough context |
| `BridgeMD.Roslyn` (Infrastructure) | `BridgeMD.Core` (Shared) | allowed or not enough context |
