using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Unic.Core.TokenAuthorization;
using Microsoft.Extensions.Caching.Memory;
using Unic.Domain.Entities;

namespace Unic.Demo.Utils
{
    public class AuthorizeUserAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// - This method disables the standard authorization and only validates the application-specific claims.
        /// - This method is by no-means secure and should not be used in real environments.
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            string? userId = user.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                context.Result = new ForbidResult();
                return;
            }

            string? userRole = user.Claims.FirstOrDefault(c => c.Type == "userRole")?.Value;
            if (string.IsNullOrEmpty(userRole))
            {
                context.Result = new ForbidResult();
                return;
            }

            AuthorizationContext authorizationContext = context.HttpContext.RequestServices.GetService<AuthorizationContext>();

            authorizationContext.UserId = int.Parse(userId);
            authorizationContext.UserRole = userRole;
        }
    }
}
