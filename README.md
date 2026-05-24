# BridgeMD

BridgeMD analyzes .NET solutions with Roslyn and generates compact Markdown context for humans and AI agents.

It is not an XML documentation generator. The MVP focuses on operational and architectural context that can be consumed by Copilot, Codex, Claude, GPT, local agents, and Markdown-based RAG.

## Usage

```bash
dotnet run --project BridgeMD.Cli -- analyze /path/to/MySolution.sln
```

The command writes these files to `/docs` at the root of the analyzed solution:

- `solution-overview.md`
- `project-index.md`
- `type-index.md`

## Local Testing With External Repositories

Clone large test solutions under `/Users/francisco/Projects/BridgeMD/external-solutions` or `/Users/francisco/Projects/BridgeMD/sandbox-solutions`. Those folders are ignored by git, so they are safe for experiments without polluting this repository.
