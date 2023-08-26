using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterTesting.Filters
{
    public class ActionFilterOrder : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var value = context.HttpContext.Response.Headers["Order"];
            context.HttpContext.Response.Headers["Order"] = $"{value} {nameof(ActionFilterOrder)}";
        }
    }
}
