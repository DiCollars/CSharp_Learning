using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterTesting.Filters
{
    public class ResourceFilterOreder : IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var value = context.HttpContext.Response.Headers["Order"];
            context.HttpContext.Response.Headers["Order"] = $"{value} {nameof(ResourceFilterOreder)}";
        }
    }
}
