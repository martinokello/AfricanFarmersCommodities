using AfricanFarmersCommodities.Web.IdentityServices;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.Web.Http.Filters;

namespace AfricanFarmersCommodities.Web.IdentityServices
{
    public class AuthorizeIdentity : FilterAttribute, Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter
    {
        UserService _userService;
        public AuthorizeIdentity()
        {
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _userService = context.HttpContext.RequestServices.GetService(typeof(IUserService)) as UserService;

            var authToken = context.HttpContext.Request.Headers["authToken"];

            if (!string.IsNullOrEmpty(authToken))
            {
                var userClaims = _userService.GetUserClaimsFromToken(authToken);
                if (userClaims.Where(c => c.Key.ToLower().Equals("email")).Any())
                {
                    return;
                }
                context.Result = new Microsoft.AspNetCore.Mvc.JsonResult(new { Message = "Forbidden", StatusCode = "403" });
            }
            else
            {
                context.Result = new Microsoft.AspNetCore.Mvc.JsonResult(new { Message = "Forbidden", StatusCode = "403" });
            }
        }
    }
}
