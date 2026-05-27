using BridgeMD.Core;
using BridgeMD.Markdown;
using BridgeMD.Roslyn;

if (args.Length is 0 || args[0] is "-h" or "--help")
{
    PrintUsage();
    return 0;
}

if (!string.Equals(args[0], "analyze", StringComparison.OrdinalIgnoreCase))
{
    Console.Error.WriteLine($"Unknown command: {args[0]}");
    PrintUsage();
    return 1;
}

if (args.Length < 2)
{
    Console.Error.WriteLine("Missing solution path.");
    PrintUsage();
    return 1;
}

try
{
    var options = ParseOptions(args.Skip(2).ToArray());
    var analyzer = new SolutionAnalyzer();
    var writer = new MarkdownDocumentationWriter();

    var solution = await RunWithSpinnerAsync("Analyzing solution", () => analyzer.AnalyzeAsync(args[1], options));

    await RunWithSpinnerActionAsync("Writing markdown", () => writer.WriteAsync(solution));

    Console.WriteLine($"Done. Markdown generated at: {Path.Combine(solution.RootPath, "docs")}");
    PrintSummary(solution.AnalysisSummary);
    return 0;
}
catch (Exception ex)
{
    Console.Error.WriteLine($"BridgeMD failed: {ex.Message}");
    return 1;
}

static async Task<T> RunWithSpinnerAsync<T>(string message, Func<Task<T>> operation)
{
    if (Console.IsErrorRedirected)
    {
        Console.WriteLine($"[BridgeMD] {message}");
        return await operation();
    }

    using var cancellation = new CancellationTokenSource();
    var startedAt = DateTimeOffset.UtcNow;
    var spinner = SpinAsync(message, startedAt, cancellation.Token);

    try
    {
        var result = await operation();
        cancellation.Cancel();
        await IgnoreCancellationAsync(spinner);
        Console.WriteLine($"[OK] {message} ({DateTimeOffset.UtcNow - startedAt:hh\\:mm\\:ss})");
        return result;
    }
    catch
    {
        cancellation.Cancel();
        await IgnoreCancellationAsync(spinner);
        Console.Error.WriteLine($"[FAIL] {message} ({DateTimeOffset.UtcNow - startedAt:hh\\:mm\\:ss})");
        throw;
    }
}

static async Task RunWithSpinnerActionAsync(string message, Func<Task> operation)
{
    await RunWithSpinnerAsync(message, async () =>
    {
        await operation();
        return true;
    });
}

static async Task SpinAsync(string message, DateTimeOffset startedAt, CancellationToken cancellationToken)
{
    char[] frames = ['|', '/', '-', '\\'];
    var index = 0;
    while (!cancellationToken.IsCancellationRequested)
    {
        var elapsed = DateTimeOffset.UtcNow - startedAt;
        Console.Error.WriteLine($"[{frames[index++ % frames.Length]}] {message} elapsed {elapsed:hh\\:mm\\:ss}");
        try
        {
            await Task.Delay(1000, cancellationToken);
        }
        catch (OperationCanceledException)
        {
            break;
        }
    }
}

static async Task IgnoreCancellationAsync(Task task)
{
    try
    {
        await task;
    }
    catch (OperationCanceledException)
    {
    }
}

static AnalysisOptions ParseOptions(IReadOnlyList<string> args)
{
    var excludedProjects = new List<string>();
    var excludedFolders = new List<string>();
    var forceSyntaxOnly = false;
    var continueOnError = true;
    var diagnostics = false;
    var semanticStrict = false;
    TimeSpan? projectTimeout = null;
    string? msbuildPath = null;
    string? vsVersion = null;
    string? sdkPath = null;
    string? solutionFilter = null;

    for (var index = 0; index < args.Count; index++)
    {
        var arg = args[index];
        switch (arg)
        {
            case "--no-semantic":
                forceSyntaxOnly = true;
                break;
            case "--continue-on-error":
                continueOnError = true;
                break;
            case "--diagnostics":
                diagnostics = true;
                break;
            case "--semantic-strict":
                semanticStrict = true;
                continueOnError = false;
                break;
            case "--msbuild":
                msbuildPath = ReadValue(args, ref index, arg);
                break;
            case "--vs":
                vsVersion = ReadValue(args, ref index, arg);
                break;
            case "--sdk":
                sdkPath = ReadValue(args, ref index, arg);
                break;
            case "--project-timeout":
                if (!int.TryParse(ReadValue(args, ref index, arg), out var seconds) || seconds <= 0)
                {
                    throw new ArgumentException("--project-timeout must be a positive number of seconds.");
                }

                projectTimeout = TimeSpan.FromSeconds(seconds);
                break;
            case "--exclude-project":
                excludedProjects.Add(ReadValue(args, ref index, arg));
                break;
            case "--exclude-folder":
                excludedFolders.Add(ReadValue(args, ref index, arg));
                break;
            case "--solution-filter":
                solutionFilter = ReadValue(args, ref index, arg);
                break;
            default:
                throw new ArgumentException($"Unknown option: {arg}");
        }
    }

    return new AnalysisOptions(
        forceSyntaxOnly,
        continueOnError,
        diagnostics,
        semanticStrict,
        projectTimeout,
        msbuildPath,
        vsVersion,
        sdkPath,
        excludedProjects,
        excludedFolders,
        solutionFilter);
}

static string ReadValue(IReadOnlyList<string> args, ref int index, string option)
{
    if (index + 1 >= args.Count)
    {
        throw new ArgumentException($"{option} requires a value.");
    }

    index++;
    return args[index];
}

static void PrintSummary(AnalysisSummary? summary)
{
    if (summary is null)
    {
        return;
    }

    Console.WriteLine();
    Console.WriteLine("=================================================");
    Console.WriteLine("BridgeMD Analysis Summary");
    Console.WriteLine("=================================================");
    Console.WriteLine($"Projects discovered: {summary.ProjectsDiscovered}");
    Console.WriteLine($"Projects analyzed semantically: {summary.ProjectsAnalyzedSemantically}");
    Console.WriteLine($"Projects analyzed syntactically only: {summary.ProjectsAnalyzedSyntactically}");
    Console.WriteLine($"Projects failed completely: {summary.ProjectsFailed}");
    Console.WriteLine();
    Console.WriteLine($"Semantic coverage: {summary.SemanticCoverage:P0}");
    Console.WriteLine($"Syntax fallback coverage: {summary.SyntaxFallbackCoverage:P0}");

    var warnings = summary.Diagnostics
        .Where(diagnostic => diagnostic.Severity is AnalysisDiagnosticSeverity.Warning or AnalysisDiagnosticSeverity.Error)
        .ToArray();
    if (warnings.Length > 0)
    {
        Console.WriteLine();
        Console.WriteLine("Warnings:");
        foreach (var warning in warnings.Take(20))
        {
            var project = string.IsNullOrWhiteSpace(warning.ProjectName) ? string.Empty : $" [{warning.ProjectName}]";
            Console.WriteLine($"- {warning.Code}{project}: {warning.Message}");
        }
    }

    Console.WriteLine();
    Console.WriteLine($"Elapsed time: {summary.Elapsed:hh\\:mm\\:ss}");
}

static void PrintUsage()
{
    Console.WriteLine("BridgeMD");
    Console.WriteLine();
    Console.WriteLine("Usage:");
    Console.WriteLine("  BridgeMD analyze <path-to-solution.sln> [options]");
    Console.WriteLine();
    Console.WriteLine("Options:");
    Console.WriteLine("  --msbuild <path>             Explicit MSBuild path override");
    Console.WriteLine("  --vs <version>               Force Visual Studio/MSBuild instance version");
    Console.WriteLine("  --sdk <path>                 Set DOTNET_ROOT before loading MSBuild");
    Console.WriteLine("  --no-semantic                Force syntax-only analysis");
    Console.WriteLine("  --continue-on-error          Continue with syntax fallback when semantic analysis fails");
    Console.WriteLine("  --diagnostics                Enable verbose environment diagnostics");
    Console.WriteLine("  --project-timeout <seconds>  Downgrade a project to syntax mode after timeout");
    Console.WriteLine("  --exclude-project <glob>     Exclude matching project names or paths");
    Console.WriteLine("  --exclude-folder <glob>      Exclude matching folders");
    Console.WriteLine("  --solution-filter <pattern>  Include matching project names only");
    Console.WriteLine("  --semantic-strict            Fail if semantic analysis is unavailable");
}
