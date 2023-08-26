using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterTesting.Attributes
{
    public class ResultHeaderAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers["IsFine"] = "true";
        }
    }
}
