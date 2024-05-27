using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Kinopoisk.Helpers;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class JWTAuthorizeAttribute : Attribute, IAuthorizationFilter {
    public void OnAuthorization(AuthorizationFilterContext context) {
        var user = (UserModel?)context.HttpContext.Items["User"];
        if (user == null) {
            context.Result = new JsonResult(
                new { message = "Unauthorized" }
            ){ StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}