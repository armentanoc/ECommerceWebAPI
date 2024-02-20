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
            _logger.LogInformation($"Início da requisição: {context.Request.Path}");

            await _next(context);

            _logger.LogInformation($"Fim da requisição: {context.Request.Path}");
        }
    }
}