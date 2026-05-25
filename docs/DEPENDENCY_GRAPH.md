# Dependency Graph

## Semantic Dependencies

## BridgeMD.Roslyn.SolutionAnalyzer
- `BridgeMD.Roslyn.SemanticDependencyFilter` (Field, DependencyFilter)
- `Microsoft.CodeAnalysis.SymbolDisplayFormat` (Field, FullNameFormat)

## BridgeMD.Roslyn.SemanticDependencyFilter
- `BridgeMD.Roslyn.DependencyDeduplicator` (Field, _deduplicator)
- `BridgeMD.Roslyn.FrameworkNoiseFilter` (Field, _frameworkNoiseFilter)
- `BridgeMD.Roslyn.PrimitiveTypeFilter` (Field, _primitiveTypeFilter)

## Mermaid

```mermaid
graph TD
  T_BridgeMD_Roslyn_SolutionAnalyzer["SolutionAnalyzer"] --> T_BridgeMD_Roslyn_SemanticDependencyFilter["SemanticDependencyFilter"]
  T_BridgeMD_Roslyn_SolutionAnalyzer["SolutionAnalyzer"] --> T_Microsoft_CodeAnalysis_SymbolDisplayFormat["SymbolDisplayFormat"]
  T_BridgeMD_Roslyn_SemanticDependencyFilter["SemanticDependencyFilter"] --> T_BridgeMD_Roslyn_DependencyDeduplicator["DependencyDeduplicator"]
  T_BridgeMD_Roslyn_SemanticDependencyFilter["SemanticDependencyFilter"] --> T_BridgeMD_Roslyn_FrameworkNoiseFilter["FrameworkNoiseFilter"]
  T_BridgeMD_Roslyn_SemanticDependencyFilter["SemanticDependencyFilter"] --> T_BridgeMD_Roslyn_PrimitiveTypeFilter["PrimitiveTypeFilter"]
```

## IoC Registrations

| Project | Interface | Implementation | Kind | Location |
| --- | --- | --- | --- | --- |
| none | none | none | none | none |
