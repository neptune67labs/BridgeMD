# BridgeMD

BridgeMD analyzes .NET solutions with Roslyn and generates compact Markdown context for humans and AI agents.

It is not an XML documentation generator. The MVP focuses on operational and architectural context that can be consumed by Copilot, Codex, Claude, GPT, local agents, and Markdown-based RAG.

## Usage

```bash
dotnet run --project BridgeMD.Cli -- analyze /path/to/MySolution.sln
```

The command writes Markdown files to `/docs` at the root of the analyzed solution.

Recommended first read order for humans and AI agents:

1. `AGENTS.md`
2. `ai-context.md`
3. `architecture.md`
4. `business-domains.md`
5. `hotspots.md`
6. `key-types.md`

Generated markdown is semantic guidance, not source of truth. Always validate assumptions against code.

## Generated Files

BridgeMD intentionally generates a small set of high-signal files:

- `AGENTS.md` - AI/bootstrap entrypoint and navigation map.
- `ai-context.md` - compact architecture, layer, technology, risk and key type summary.
- `architecture.md` - inferred layers, responsibilities and project dependency rules.
- `business-domains.md` - business vocabulary, bounded contexts, core entities and use cases.
- `hotspots.md` - risky, central, fragile or legacy-sensitive areas.
- `key-types.md` - prioritized high-value types for navigation.
- `dependency-graph.md` - semantic dependencies between important types.
- `ioc-graph.md` - dependency injection registrations and runtime wiring.
- `request-flows.md` - inferred request/use-case flows.
- `project-index.md` - project-level navigation.
- `type-index.md` - deeper type-level index. This can be large on enterprise solutions.

## Windows / Enterprise Usage

For a legacy or enterprise solution on Windows:

```powershell
git clone https://github.com/neptune67labs/BridgeMD.git
cd BridgeMD
dotnet build

dotnet run --project .\BridgeMD.Cli -- analyze "D:\Work\MySolution\MySolution.sln" --diagnostics --continue-on-error --project-timeout 60
```

The generated files will be written to:

```text
D:\Work\MySolution\docs
```

If semantic loading fails because of missing SDKs, workloads, NuGet feeds or legacy project types, force syntax-only extraction:

```powershell
dotnet run --project .\BridgeMD.Cli -- analyze "D:\Work\MySolution\MySolution.sln" --no-semantic
```

Syntax-only mode still extracts useful structure: namespaces, types, methods, inheritance text, attributes, project references, basic dependencies and XML summaries.

## Working With Legacy Solutions

BridgeMD is designed to degrade gracefully on mixed or partially broken solutions. Roslyn semantic analysis is preferred, but syntax fallback keeps the tool useful when MSBuild cannot fully load the solution.

For .NET Framework, EF6, UWP, WPF, Windows Forms or older ASP.NET solutions, make sure the machine has the required build tools installed:

- Visual Studio 2022 or Build Tools.
- .NET Framework targeting packs used by the solution.
- UWP workload if the solution contains UWP projects.
- NuGet credentials and `NuGet.config` for private feeds.
- Restored packages when possible.

Useful restore commands before running BridgeMD:

```powershell
nuget restore "D:\Work\MySolution\MySolution.sln"
dotnet restore "D:\Work\MySolution\MySolution.sln" --ignore-failed-sources
```

## CLI Options

Common options:

- `--diagnostics` - prints more environment and workspace diagnostics.
- `--continue-on-error` - continues analysis when projects fail semantically.
- `--project-timeout <seconds>` - prevents long project analysis stalls.
- `--no-semantic` - skips MSBuild/Roslyn semantic loading and uses syntax-only extraction.
- `--semantic-strict` - fails if semantic analysis is unavailable.
- `--exclude-project <glob>` - excludes matching project names or paths.
- `--exclude-folder <glob>` - excludes matching folders.

Advanced options:

- `--msbuild <path>` - explicit MSBuild path override.
- `--vs <version>` - force a Visual Studio/MSBuild instance version.
- `--sdk <path>` - set `DOTNET_ROOT` before MSBuild loading.
- `--solution-filter <pattern>` - include matching project names only.

## Using With GitHub Copilot

After generating `/docs`, open the target solution in your IDE and use the generated files as repository memory.

Recommended prompt pattern:

```text
Read docs/AGENTS.md, docs/ai-context.md and docs/architecture.md first.
Use them as semantic guidance only. Validate every assumption against source code.
```

For risky changes, include:

```text
Also inspect docs/hotspots.md and docs/key-types.md before proposing changes.
```

For domain or feature work, include:

```text
Also inspect docs/business-domains.md and docs/request-flows.md.
```

## More Documentation

See [docs/getting-started.md](docs/getting-started.md) for a guided setup and troubleshooting workflow.

## Local Testing With External Repositories

Clone large test solutions under `/BridgeMD/external-solutions` or `/BridgeMD/sandbox-solutions`. Those folders are ignored by git, so they are safe for experiments without polluting this repository.
