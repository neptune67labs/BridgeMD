# Business Domains

| Signal | Value |
| --- | --- |
| Primary language | `BridgeMD`, `Markdown`, `Roslyn`, `Dependency`, `Kind`, `Noise`, `Primitive`, `Project`, `Solution`, `Analyze`, `Analyzer`, `Architectural` |
| Bounded contexts | `BridgeMD` |
| Core entities | `DomainRelationship` |

## Core Business Entities

| Entity | Role | Context | Used By | Responsibility Signal |
| --- | --- | --- | --- | --- |
| `BridgeMD.Markdown.MarkdownDocumentationWriter.DomainRelationship` | Writer | `BridgeMD` | none | Writer |

## Bounded Contexts

| Context | Contains | Services | Entry Points | Dependencies |
| --- | --- | --- | --- | --- |
| `BridgeMD` | `DomainRelationship` | none | none | none |

## Use Cases

| Use Case | Entry | Flow | Entities |
| --- | --- | --- | --- |
| none | none | none | none |

## Domain Relationships

| Source | Relationship | Target | Evidence |
| --- | --- | --- | --- |
| none | none | none | none |

## Ubiquitous Language

| Term | Occurrences | Signals |
| --- | ---: | --- |
| `BridgeMD` | 23 | `IoCRegistrationModel`, `MethodModel`, `ParameterModel`, `ProjectModel`, `ProjectReferenceModel`, `SolutionModel` |
| `Markdown` | 6 | `RiskProfile`, `MarkdownDocumentationWriter`, `BoundedContextModel`, `DomainRelationship`, `LanguageTerm` |
| `Roslyn` | 5 | `SolutionAnalyzer`, `SemanticDependencyFilter`, `DependencyDeduplicator`, `FrameworkNoiseFilter`, `PrimitiveTypeFilter` |
| `Dependency` | 4 | `TypeDependencyModel`, `DependencyKind`, `SemanticDependencyFilter`, `DependencyDeduplicator` |
| `Kind` | 2 | `CodeTypeKind`, `DependencyKind` |
| `Noise` | 2 | `FrameworkNoiseFilter` |
| `Primitive` | 2 | `PrimitiveTypeFilter` |
| `Project` | 2 | `ProjectModel`, `ProjectReferenceModel` |
| `Solution` | 2 | `SolutionModel`, `SolutionAnalyzer` |
| `Analyze` | 1 | `SolutionAnalyzer` |
| `Analyzer` | 1 | `SolutionAnalyzer` |
| `Architectural` | 1 | `ArchitecturalRole` |
| `Architecture` | 1 | `ArchitectureLayer` |
| `Bounded` | 1 | `BoundedContextModel` |
| `Category` | 1 | `RelevanceCategory` |
| `Code` | 1 | `CodeTypeKind` |
| `Deduplicate` | 1 | `DependencyDeduplicator` |
| `Deduplicator` | 1 | `DependencyDeduplicator` |
| `Documentation` | 1 | `MarkdownDocumentationWriter` |
| `Domain` | 1 | `DomainRelationship` |
| `Framework` | 1 | `FrameworkNoiseFilter` |
| `Language` | 1 | `LanguageTerm` |
| `Layer` | 1 | `ArchitectureLayer` |
| `Method` | 1 | `MethodModel` |
| `Parameter` | 1 | `ParameterModel` |
| `Profile` | 1 | `RiskProfile` |
| `Reference` | 1 | `ProjectReferenceModel` |
| `Registration` | 1 | `IoCRegistrationModel` |
| `Relationship` | 1 | `DomainRelationship` |
| `Relevance` | 1 | `RelevanceCategory` |
| `Risk` | 1 | `RiskProfile` |
| `Role` | 1 | `ArchitecturalRole` |
| `Semantic` | 1 | `SemanticDependencyFilter` |
| `Term` | 1 | `ParameterModel`, `LanguageTerm` |
| `Write` | 1 | `MarkdownDocumentationWriter` |
| `Writer` | 1 | `MarkdownDocumentationWriter` |
