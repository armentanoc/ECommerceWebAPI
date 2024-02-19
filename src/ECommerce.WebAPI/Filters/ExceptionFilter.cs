using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Filters
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {

            int statusCode;

            if (context.Exception is UnauthorizedAccessException)
                statusCode = StatusCodes.Status401Unauthorized;
            else
                statusCode = StatusCodes.Status500InternalServerError;

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
