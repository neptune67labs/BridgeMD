# Solution Overview

| Field | Value |
| --- | --- |
| Solution | `BridgeMD` |
| Projects | 4 |
| Types | 23 |
| Root | `/Users/francisco/Projects/BridgeMD` |
| Architecture | `Clean Architecture`, `Layered Architecture` |
| Technologies | `MSBuildWorkspace`, `Roslyn` |

## Projects

| Project | Layer | Frameworks | Types | Roles | Patterns |
| --- | --- | --- | ---: | --- | --- |
| `BridgeMD.Cli` | UI | `net8.0` | 0 | none | none |
| `BridgeMD.Core` | Shared | `net8.0` | 13 | none | none |
| `BridgeMD.Markdown` | Application | `net8.0` | 5 | `Mapper`, `Writer` | `Writer` |
| `BridgeMD.Roslyn` | Infrastructure | `net8.0` | 5 | `Analyzer` | `Analyzer` |

## Project Relations

| From | To |
| --- | --- |
| `BridgeMD.Cli` | `BridgeMD.Core` |
| `BridgeMD.Cli` | `BridgeMD.Markdown` |
| `BridgeMD.Cli` | `BridgeMD.Roslyn` |
| `BridgeMD.Core` | none |
| `BridgeMD.Markdown` | `BridgeMD.Core` |
| `BridgeMD.Roslyn` | `BridgeMD.Core` |

## Main Namespaces

- `BridgeMD.Core`
- `BridgeMD.Markdown`
- `BridgeMD.Roslyn`
