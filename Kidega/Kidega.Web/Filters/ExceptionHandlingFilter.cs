using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Kidega.Web.Filters
{
    public class ExceptionHandlingFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionHandlingFilter> _logger;

        public ExceptionHandlingFilter(ILogger<ExceptionHandlingFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            // Log the exception
            _logger.LogError(context.Exception, "Unhandled exception occurred");

            // Set the result to an error response
            var result = new ObjectResult("An error occurred")
            {
                StatusCode = 500
            };

            context.Result = result;
            context.ExceptionHandled = true;
        }
    }

}
