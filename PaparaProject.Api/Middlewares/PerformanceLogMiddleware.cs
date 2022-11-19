using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PaparaProject.Api.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class PerformanceLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<PerformanceLogMiddleware> _logger;

        public PerformanceLogMiddleware(RequestDelegate next, ILogger<PerformanceLogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var watch = Stopwatch.StartNew();
            await _next(httpContext);
            watch.Stop();
            if (watch.ElapsedMilliseconds > 500)
                _logger.LogWarning(httpContext.Request.Host + httpContext.Request.Path, watch.ElapsedMilliseconds);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class PerformanceLogMiddlewareExtensions
    {
        public static IApplicationBuilder UsePerformanceLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PerformanceLogMiddleware>();
        }
    }
}
