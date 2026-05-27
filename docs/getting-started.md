# Getting Started

BridgeMD generates AI-oriented semantic memory for .NET solutions. It is intended for humans and AI coding assistants that need to understand a repository quickly.

It does not replace source code. Generated markdown is semantic guidance, not source of truth. Always validate assumptions against code.

## Requirements

- .NET 8 SDK.
- Windows, macOS or Linux for SDK-style projects.
- Windows with Visual Studio or Build Tools for many legacy .NET Framework, UWP, WPF, WinForms or old ASP.NET solutions.
- NuGet access for private feeds when semantic analysis is required.

## Basic Usage

From the BridgeMD repository:

```bash
dotnet build
dotnet run --project BridgeMD.Cli -- analyze /path/to/MySolution.sln
```

On Windows:

```powershell
dotnet build
dotnet run --project .\BridgeMD.Cli -- analyze "D:\Work\MySolution\MySolution.sln"
```

BridgeMD writes markdown to the analyzed solution:

```text
D:\Work\MySolution\docs
```

## Recommended Enterprise Command

For large or legacy solutions, start with diagnostics and graceful degradation:

```powershell
dotnet run --project .\BridgeMD.Cli -- analyze "D:\Work\MySolution\MySolution.sln" --diagnostics --continue-on-error --project-timeout 60
```

This attempts semantic analysis first. If a project fails, BridgeMD tries to keep useful output through syntax extraction.

## If MSBuild Or Roslyn Fails

First restore packages:

```powershell
nuget restore "D:\Work\MySolution\MySolution.sln"
dotnet restore "D:\Work\MySolution\MySolution.sln" --ignore-failed-sources
```

Then retry:

```powershell
dotnet run --project .\BridgeMD.Cli -- analyze "D:\Work\MySolution\MySolution.sln" --diagnostics --continue-on-error --project-timeout 60
```

If the environment is still incomplete, force syntax-only mode:

```powershell
dotnet run --project .\BridgeMD.Cli -- analyze "D:\Work\MySolution\MySolution.sln" --no-semantic
```

Syntax-only mode is useful when:

- private NuGet feeds are unavailable,
- UWP workloads are missing,
- legacy targets cannot be imported,
- old project types cannot be loaded by MSBuildWorkspace,
- the solution is partially broken.

## Legacy Checklist

For .NET Framework 4.x, EF6, UWP, WPF, WinForms or old ASP.NET solutions, verify:

- Visual Studio 2022 or Build Tools is installed.
- Required .NET Framework targeting packs are installed.
- UWP workload is installed if the solution contains UWP projects.
- Private feeds are configured in `NuGet.config`.
- Packages are restored.
- The solution builds or partially loads in Visual Studio.

If not, BridgeMD can still be useful with `--no-semantic`.

## Reading The Output

Start here:

1. `AGENTS.md`
2. `ai-context.md`
3. `architecture.md`
4. `business-domains.md`
5. `hotspots.md`
6. `key-types.md`

Use deeper indexes only when needed:

- `dependency-graph.md`
- `ioc-graph.md`
- `request-flows.md`
- `project-index.md`
- `type-index.md`

`type-index.md` can be large on enterprise repositories. Prefer `key-types.md` for quick navigation.

## Using With GitHub Copilot

After generating docs, open the target solution in your IDE. Ask Copilot to use the generated markdown as orientation.

Suggested prompt:

```text
Use docs/AGENTS.md, docs/ai-context.md and docs/architecture.md as semantic guidance for this repository.
Do not treat generated markdown as source of truth. Validate assumptions against the code.
```

For risky work:

```text
Before changing this area, inspect docs/hotspots.md and docs/key-types.md.
Identify likely impact areas and validate against code.
```

For feature or domain work:

```text
Use docs/business-domains.md and docs/request-flows.md to understand the domain and likely execution flow.
Then inspect the referenced source files.
```

## CLI Options

Common:

- `--diagnostics` - show more MSBuild/Roslyn diagnostics.
- `--continue-on-error` - continue when semantic project analysis fails.
- `--project-timeout <seconds>` - prevent long project analysis stalls.
- `--no-semantic` - force syntax-only analysis.
- `--exclude-project <glob>` - exclude matching projects.
- `--exclude-folder <glob>` - exclude matching folders.

Advanced:

- `--semantic-strict` - fail if semantic analysis is unavailable.
- `--msbuild <path>` - use a specific MSBuild installation.
- `--vs <version>` - force Visual Studio/MSBuild instance version.
- `--sdk <path>` - set a custom SDK path through `DOTNET_ROOT`.
- `--solution-filter <pattern>` - analyze matching project names only.

## Practical Troubleshooting

If BridgeMD fails immediately:

- Run with `--diagnostics`.
- Check Visual Studio Build Tools and targeting packs.
- Restore NuGet packages.
- Try `--no-semantic`.

If one project hangs:

```powershell
dotnet run --project .\BridgeMD.Cli -- analyze "D:\Work\MySolution\MySolution.sln" --project-timeout 60 --continue-on-error
```

If a project type is not useful for semantic context:

```powershell
dotnet run --project .\BridgeMD.Cli -- analyze "D:\Work\MySolution\MySolution.sln" --exclude-project "*Installer*" --exclude-project "*UWP*"
```

If generated docs are too large for Copilot context, start only with:

```text
AGENTS.md
ai-context.md
architecture.md
hotspots.md
key-types.md
```
