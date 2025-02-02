using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Dotnet.Homeworks.MainProject.Middlewares;

public class RequestTimingMiddleware
{
    private readonly RequestDelegate _next;
    private static readonly Meter Meter = new("Dotnet.Homeworks.Metrics");
    private static readonly Histogram<double> RequestDuration = 
        Meter.CreateHistogram<double>("request_duration_ms", "ms", "Время обработки HTTP-запроса");

    public RequestTimingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        try
        {
            await _next(context);
        }
        finally
        {
            stopwatch.Stop();
            RequestDuration.Record(stopwatch.ElapsedMilliseconds,
                new KeyValuePair<string, object>("method", context.Request.Method)!,
                new KeyValuePair<string, object>("path", context.Request.Path)!
            );
        }
    }
}