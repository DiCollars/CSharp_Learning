using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterTesting.Filters
{
    public class ExceptionFilterOrder : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var value = context.HttpContext.Response.Headers["Order"];
            context.HttpContext.Response.Headers["Order"] = $"{value} {nameof(ExceptionFilterOrder)}";

            context.Result = new ContentResult
            {
                Content = ":)"
            };

            context.ExceptionHandled = true;
        }
    }
}
