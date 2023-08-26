using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterTesting.Filters
{
    public class KeyCheckerAsyncActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await next();

            if (context.HttpContext.Response.Headers["API_KEY"] != "TestApiKey")
            {
                context.HttpContext.Response.StatusCode = 400;
            }

            context.HttpContext.Response.Headers["Certificate"] = Guid.NewGuid().ToString();
        }
    }
}
