# Business Domains

| Signal | Value |
| --- | --- |
| Primary language | `BridgeMD`, `Markdown`, `Roslyn`, `Analysi`, `Dependency`, `Project`, `Solution`, `Analyze`, `Analyzer`, `Diagnostic`, `Kind`, `Noise` |
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
| `BridgeMD` | 28 | `AnalysisDiagnostic`, `AnalysisOptions`, `AnalysisSummary`, `IoCRegistrationModel`, `MethodModel`, `ParameterModel` |
| `Markdown` | 6 | `RiskProfile`, `MarkdownDocumentationWriter`, `BoundedContextModel`, `DomainRelationship`, `LanguageTerm` |
| `Roslyn` | 5 | `SolutionAnalyzer`, `SemanticDependencyFilter`, `DependencyDeduplicator`, `FrameworkNoiseFilter`, `PrimitiveTypeFilter` |
| `Analysi` | 4 | `AnalysisDiagnostic`, `AnalysisOptions`, `AnalysisSummary`, `AnalysisDiagnosticSeverity` |
| `Dependency` | 4 | `TypeDependencyModel`, `DependencyKind`, `SemanticDependencyFilter`, `DependencyDeduplicator` |
| `Project` | 4 | `ProjectModel`, `ProjectReferenceModel`, `SyntaxSolutionAnalyzer` |
| `Solution` | 4 | `SolutionModel`, `SolutionAnalyzer`, `SyntaxSolutionAnalyzer` |
| `Analyze` | 3 | `SolutionAnalyzer`, `SyntaxSolutionAnalyzer` |
| `Analyzer` | 2 | `SolutionAnalyzer`, `SyntaxSolutionAnalyzer` |
| `Diagnostic` | 2 | `AnalysisDiagnostic`, `AnalysisDiagnosticSeverity` |
| `Kind` | 2 | `CodeTypeKind`, `DependencyKind` |
| `Noise` | 2 | `FrameworkNoiseFilter` |
| `Primitive` | 2 | `PrimitiveTypeFilter` |
| `Syntax` | 2 | `SyntaxSolutionAnalyzer` |
| `Architectural` | 1 | `ArchitecturalRole` |
| `Architecture` | 1 | `ArchitectureLayer` |
| `Bounded` | 1 | `BoundedContextModel` |
| `Category` | 1 | `RelevanceCategory` |
| `Code` | 1 | `CodeTypeKind` |
| `Deduplicate` | 1 | `DependencyDeduplicator` |
| `Deduplicator` | 1 | `DependencyDeduplicator` |
| `Discover` | 1 | `SyntaxSolutionAnalyzer` |
| `Documentation` | 1 | `MarkdownDocumentationWriter` |
| `Domain` | 1 | `DomainRelationship` |
| `Framework` | 1 | `FrameworkNoiseFilter` |
| `Language` | 1 | `LanguageTerm` |
| `Layer` | 1 | `ArchitectureLayer` |
| `Method` | 1 | `MethodModel` |
| `Option` | 1 | `AnalysisOptions` |
| `Parameter` | 1 | `ParameterModel` |
| `Path` | 1 | `SyntaxSolutionAnalyzer` |
| `Profile` | 1 | `RiskProfile` |
| `Reference` | 1 | `ProjectReferenceModel` |
| `Registration` | 1 | `IoCRegistrationModel` |
| `Relationship` | 1 | `DomainRelationship` |
| `Relevance` | 1 | `RelevanceCategory` |
| `Risk` | 1 | `RiskProfile` |
| `Role` | 1 | `ArchitecturalRole` |
| `Semantic` | 1 | `SemanticDependencyFilter` |
| `Severity` | 1 | `AnalysisDiagnosticSeverity` |
