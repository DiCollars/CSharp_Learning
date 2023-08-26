using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterTesting.Filters
{
    public class KeyApplierActionFilter : IActionFilter
    {
        private readonly ILogger<KeyApplierActionFilter> _logger;

        public KeyApplierActionFilter(ILogger<KeyApplierActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var certigicate = context.HttpContext.Response.Headers["Certificate"];
            _logger.LogInformation($"Certificate: {certigicate}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("API_KEY", "TestApiKey");
        }
    }
}
