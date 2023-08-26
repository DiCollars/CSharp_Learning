using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterTesting.Attributes
{
    public class ResponseHeaderAttribute : ActionFilterAttribute
    {
        private readonly string _name;
        private readonly string _value;

        public ResponseHeaderAttribute(string name, string value) =>
            (_name, _value) = (name, value);

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var val = context.HttpContext.Response.Headers["AttrFiltrOrder"];
            context.HttpContext.Response.Headers["AttrFiltrOrder"] = $"{val} -> {nameof(ResponseHeaderAttribute)}";

            base.OnResultExecuting(context);
        }
    }
}
