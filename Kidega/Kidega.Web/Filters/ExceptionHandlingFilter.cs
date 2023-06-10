using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Kidega.Web.Filters
{
    public class ExceptionHandlingFilter(ILogger<ExceptionHandlingFilter> logger, LinkGenerator linkGenerator, ITempDataDictionaryFactory tempDataFactory) : IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {
            // Log the exception
            logger.LogError(context.Exception, "Unhandled exception occurred");

            // One option is to show an error page but i would prefer redirecting to home page
            //var result = new ObjectResult("An error occurred")
            //{
            //    StatusCode = 500
            //};

            // Clear the response
            context.Result = new EmptyResult();
            context.ExceptionHandled = true;

            // Redirect to home index page
            var homeIndexUrl = linkGenerator.GetPathByAction("Index", "Home");
            context.HttpContext.Response.Redirect(homeIndexUrl);

            // Add error message to TempData to show it on the home page
            tempDataFactory.GetTempData(context.HttpContext).Add("error", context.Exception.Message);
        }
    }

}
