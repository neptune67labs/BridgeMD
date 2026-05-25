using BridgeMD.Core;

namespace BridgeMD.Roslyn;

public sealed class SemanticDependencyFilter
{
    private readonly PrimitiveTypeFilter _primitiveTypeFilter = new();
    private readonly FrameworkNoiseFilter _frameworkNoiseFilter = new();
    private readonly DependencyDeduplicator _deduplicator = new();

    public IReadOnlyList<TypeDependencyModel> Filter(IEnumerable<TypeDependencyModel> dependencies)
    {
        return _deduplicator.Deduplicate(dependencies
            .Where(dependency => !_primitiveTypeFilter.IsPrimitive(dependency.TargetType))
            .Where(dependency => !_frameworkNoiseFilter.IsNoise(dependency.TargetType))
            .Where(dependency => dependency.Kind is not DependencyKind.MethodParameter and not DependencyKind.ReturnType)
            .OrderBy(dependency => dependency.TargetType, StringComparer.Ordinal));
    }
}

public sealed class PrimitiveTypeFilter
{
    private static readonly string[] PrimitiveNames =
    [
        "bool",
        "byte",
        "char",
        "decimal",
        "double",
        "float",
        "int",
        "long",
        "object",
        "sbyte",
        "short",
        "string",
        "uint",
        "ulong",
        "ushort",
        "void",
        "System.Boolean",
        "System.Byte",
        "System.Char",
        "System.DateOnly",
        "System.DateTime",
        "System.DateTimeOffset",
        "System.Decimal",
        "System.Double",
        "System.Guid",
        "System.Int16",
        "System.Int32",
        "System.Int64",
        "System.Object",
        "System.Single",
        "System.String",
        "System.TimeOnly",
        "System.TimeSpan",
        "System.Uri"
    ];

    public bool IsPrimitive(string typeName)
    {
        var normalized = Normalize(typeName);
        return PrimitiveNames.Any(primitive =>
            string.Equals(normalized, primitive, StringComparison.Ordinal)
            || normalized.StartsWith($"{primitive}?", StringComparison.Ordinal)
            || normalized.StartsWith($"{primitive}<", StringComparison.Ordinal));
    }

    private static string Normalize(string typeName)
    {
        return typeName.Trim().TrimEnd('?');
    }
}

public sealed class FrameworkNoiseFilter
{
    private static readonly string[] ExactNoise =
    [
        "CancellationToken",
        "System.Threading.CancellationToken",
        "IActionResult",
        "ActionResult",
        "Task",
        "ValueTask",
        "IMapper",
        "ITestOutputHelper",
        "System.Net.Http.HttpClient",
        "System.Text.Encodings.Web.UrlEncoder",
        "System.Timers.Timer"
    ];

    private static readonly string[] PrefixNoise =
    [
        "System.Collections.Generic.IEnumerable<",
        "System.Collections.Generic.IReadOnlyCollection<",
        "System.Collections.Generic.IReadOnlyList<",
        "System.Collections.Generic.ICollection<",
        "System.Collections.Generic.IList<",
        "System.Collections.Generic.List<",
        "System.Collections.Generic.Dictionary<",
        "System.Threading.Tasks.Task<",
        "System.Threading.Tasks.ValueTask<",
        "Microsoft.Extensions.Logging.ILogger",
        "Microsoft.Extensions.Options.IOptions",
        "Microsoft.Extensions.Options.IOptionsMonitor",
        "Microsoft.Extensions.Options.IOptionsSnapshot",
        "Microsoft.Extensions.Configuration.IConfiguration",
        "Microsoft.AspNetCore.Http.HttpContext",
        "Microsoft.AspNetCore.Http.IHttpContextAccessor",
        "Microsoft.AspNetCore.Hosting.IWebHostEnvironment",
        "Microsoft.Extensions.Hosting.IHostEnvironment",
        "Microsoft.JSInterop.IJSRuntime",
        "Microsoft.AspNetCore.Http.RequestDelegate",
        "Microsoft.AspNetCore.Identity.UserManager<",
        "Microsoft.AspNetCore.Identity.SignInManager<",
        "Microsoft.AspNetCore.Authentication.AuthenticationScheme",
        "Microsoft.Extensions.Caching.Memory.IMemoryCache",
        "AutoMapper.IMapper"
    ];

    private static readonly string[] ShortNoisePrefixes =
    [
        "ILogger",
        "IOptions",
        "IOptionsMonitor",
        "IOptionsSnapshot",
        "IConfiguration",
        "UserManager<",
        "SignInManager<",
        "IEnumerable<",
        "IReadOnlyCollection<",
        "IReadOnlyList<",
        "ICollection<",
        "IList<",
        "List<",
        "Dictionary<",
        "Task<",
        "ValueTask<",
        "ActionResult<"
    ];

    public bool IsNoise(string typeName)
    {
        var normalized = typeName.Trim();
        if (ExactNoise.Any(noise => string.Equals(normalized, noise, StringComparison.Ordinal)))
        {
            return true;
        }

        return PrefixNoise.Any(noise => normalized.StartsWith(noise, StringComparison.Ordinal))
            || ShortNoisePrefixes.Any(noise => normalized.StartsWith(noise, StringComparison.Ordinal));
    }
}

public sealed class DependencyDeduplicator
{
    public IReadOnlyList<TypeDependencyModel> Deduplicate(IEnumerable<TypeDependencyModel> dependencies)
    {
        return dependencies
            .GroupBy(dependency => NormalizeTarget(dependency.TargetType), StringComparer.Ordinal)
            .Select(group => group.OrderBy(dependency => Rank(dependency.Kind)).ThenBy(dependency => dependency.MemberName, StringComparer.Ordinal).First())
            .OrderBy(dependency => dependency.TargetType, StringComparer.Ordinal)
            .ToArray();
    }

    private static int Rank(DependencyKind kind)
    {
        return kind switch
        {
            DependencyKind.ConstructorInjection => 0,
            DependencyKind.DbSet => 1,
            DependencyKind.Instantiation => 2,
            DependencyKind.Property => 3,
            DependencyKind.Field => 4,
            _ => 9
        };
    }

    private static string NormalizeTarget(string targetType)
    {
        return targetType
            .Replace("System.Collections.Generic.IEnumerable<", string.Empty, StringComparison.Ordinal)
            .Replace("System.Collections.Generic.IReadOnlyList<", string.Empty, StringComparison.Ordinal)
            .Replace("System.Collections.Generic.List<", string.Empty, StringComparison.Ordinal)
            .TrimEnd('>');
    }
}
