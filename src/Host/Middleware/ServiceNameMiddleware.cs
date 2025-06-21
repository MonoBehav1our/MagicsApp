namespace Host.Middleware;

public class ServiceNameMiddleware(IConfiguration config) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var serviceName = config.GetValue<string>("ServiceName");
        context.Response.Headers.Append("X-SERVICE-NAME", serviceName);
        
        await next(context);
    }
}