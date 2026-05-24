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
    var analyzer = new SolutionAnalyzer();
    var writer = new MarkdownDocumentationWriter();

    var solution = await analyzer.AnalyzeAsync(args[1]);
    await writer.WriteAsync(solution);

    Console.WriteLine($"Done. Markdown generated at: {Path.Combine(solution.RootPath, "docs")}");
    return 0;
}
catch (Exception ex)
{
    Console.Error.WriteLine($"BridgeMD failed: {ex.Message}");
    return 1;
}

static void PrintUsage()
{
    Console.WriteLine("BridgeMD");
    Console.WriteLine();
    Console.WriteLine("Usage:");
    Console.WriteLine("  BridgeMD analyze <path-to-solution.sln>");
}
