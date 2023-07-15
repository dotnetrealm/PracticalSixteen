namespace PracticalSixteen.Middlewares;
public class RequestLoggingMiddleware
{
    readonly RequestDelegate _next;
    readonly ILogger<RequestLoggingMiddleware> _logger;
    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    /// Middleware method which invoked automatically.
    /// </summary>
    public async Task InvokeAsync(HttpContext context)
    {
        //Log request information
        _logger.LogInformation("Request {method} {url} => {statusCode} [{timestamp}]",
            context.Request?.Method,
            context.Request?.Path.Value,
            context.Response?.StatusCode,
            DateTime.Now);

        //Move to next middleware in pipeline
        await _next(context);
        
        //Log response information
        _logger.LogInformation("Request served successfully [{timestamp}]", DateTime.Now);
    }
}

//Create IApplicationBuilder extension method
public static class RequestLoggingMiddlewareExtensions
{
    /// <summary>
    /// Log information about each HTTP request and response.
    /// </summary>
    public static IApplicationBuilder UseRequestLoggingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestLoggingMiddleware>();
    }

}
