using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterTesting.Attributes
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<ExceptionHandlerAttribute> _logger;

        public ExceptionHandlerAttribute()
        {
            var factory = LoggerFactory.Create(builder => {
                builder.AddConsole();
            });

            _logger = factory.CreateLogger<ExceptionHandlerAttribute>();
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception.Message);

            context.HttpContext.Response.StatusCode = 200;

            context.Result = new ContentResult
            {
                Content = ":)"
            };

            context.ExceptionHandled = true;
        }
    }
}
