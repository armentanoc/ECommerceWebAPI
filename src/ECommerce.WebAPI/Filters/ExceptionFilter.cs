using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Filters
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger; 

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            int statusCode;

            if (context.Exception is UnauthorizedAccessException)
                statusCode = StatusCodes.Status401Unauthorized;
            else
                statusCode = StatusCodes.Status500InternalServerError;

            _logger.LogError(context.Exception, "Error caught in exception filter.");

            var objectResponse = new
            {
                Error = new
                {
                    message = context.Exception.Message,
                    statusCode = statusCode
                }
            };

            context.Result = new ObjectResult(objectResponse)
            {
                StatusCode = statusCode
            };

            await Task.CompletedTask;
        }
    }
}
