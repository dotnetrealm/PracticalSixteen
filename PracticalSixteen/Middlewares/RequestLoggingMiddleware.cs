namespace PracticalSixteen.Middlewares;
public class RequestLoggingMiddleware
{
    readonly RequestDelegate _next;
    readonly ILogger _logger;
    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        //print request information
        _logger.LogInformation("Request {method} {url} => {statusCode} [{timestamp}]",
            context.Request?.Method,
            context.Request?.Path.Value,
            context.Response?.StatusCode,
            DateTime.Now);

        await _next(context);

        //print response information
        _logger.LogInformation("Request served successfully [{timestamp}]", DateTime.Now);
    }
}

//Bind extension method
public static class RequestLoggingMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestLoggingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestLoggingMiddleware>();
    }

}
