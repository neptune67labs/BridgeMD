# Solution Overview

| Field | Value |
| --- | --- |
| Solution | `BridgeMD` |
| Projects | 4 |
| Types | 14 |
| Root | `/Users/francisco/Projects/BridgeMD` |
| Architecture | `Layered Architecture` |
| Technologies | `MSBuildWorkspace`, `Roslyn` |

## Projects

| Project | Layer | Frameworks | Types | Patterns |
| --- | --- | --- | ---: | --- |
| `BridgeMD.Cli` | UI | `net8.0` | 0 | none |
| `BridgeMD.Core` | Shared | `net8.0` | 12 | none |
| `BridgeMD.Markdown` | Application | `net8.0` | 1 | `Writer` |
| `BridgeMD.Roslyn` | Infrastructure | `net8.0` | 1 | `Analyzer` |

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
