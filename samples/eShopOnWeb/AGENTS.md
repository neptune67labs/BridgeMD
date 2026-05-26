# AGENTS

Generated markdown is semantic guidance, not source of truth. Always validate assumptions against code.

## Start Here
- `ai-context.md`: fastest overview of architecture, layers, technologies, risks and key types.
- `architecture.md`: layer responsibilities, project dependencies and inferred architectural rules.
- `business-domains.md`: domain vocabulary, bounded contexts, core entities and use cases.
- `hotspots.md`: high-risk, high-centrality, legacy or fragile areas.

## Architecture Investigation
- Read `architecture.md` first.
- Use `dependency-graph.md` for semantic type dependencies.
- Use `ioc-graph.md` to understand runtime registrations and composition roots.

## Domain Investigation
- Read `business-domains.md` for business concepts, contexts and relationships.
- Use `key-types.md` to jump to high-value entities, services, handlers, controllers and repositories.
- Use `request-flows.md` when tracing feature behavior from entry points.

## Risky Areas
- Read `hotspots.md` before changing persistence, authentication, middleware, controllers, legacy infrastructure or central services.
- Validate risky changes with focused tests and direct code inspection.

## Navigation Map
- Tier 1 core memory: `ai-context.md`, `architecture.md`, `business-domains.md`, `hotspots.md`.
- Tier 2 navigation: `dependency-graph.md`, `ioc-graph.md`, `request-flows.md`, `key-types.md`, `project-index.md`, `type-index.md`.
- Prefer Tier 1 for orientation and Tier 2 only when deeper evidence is needed.
