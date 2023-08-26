using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterTesting.Filters
{
    public class ResultFilterOrder : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {

        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var value = context.HttpContext.Response.Headers["Order"];
            context.HttpContext.Response.Headers["Order"] = $"{value} {nameof(ResultFilterOrder)}";
        }
    }
}
