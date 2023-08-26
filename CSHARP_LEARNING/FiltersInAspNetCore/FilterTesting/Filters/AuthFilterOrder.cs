using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterTesting.Filters
{
    public class AuthFilterOrder : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            context.HttpContext.Response.Headers["Order"] = nameof(AuthFilterOrder);
        }
    }
}
