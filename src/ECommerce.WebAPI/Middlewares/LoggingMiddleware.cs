using System.Diagnostics;

namespace ECommerce.WebAPI.Middlewares
{
    internal class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var requestDetails = $"{context.Request.Method} {context.Request.Path}";

            _logger.LogInformation($"Início da requisição: {requestDetails}");

            var stopwatch = Stopwatch.StartNew();

            await _next(context);

            stopwatch.Stop();
            
            _logger.LogInformation($"Fim da Requisição: {requestDetails} - Status: {context.Response.StatusCode} - Elapsed Time: {stopwatch.ElapsedMilliseconds}ms");
            
        }
    }
}