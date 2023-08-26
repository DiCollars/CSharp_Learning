using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterTesting.Attributes
{
    public class GlobalActionFilter : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var val = context.HttpContext.Response.Headers["AttrFiltrOrder"];
            context.HttpContext.Response.Headers["AttrFiltrOrder"] = $"{val} -> {nameof(GlobalActionFilter)}";


            base.OnResultExecuting(context);
        }
    }
}
