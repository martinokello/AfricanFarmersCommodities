using AfricanFarmerCommodities.UnitOfWork.Concretes;
using AfricanFarmerCommodities.UnitOfWork.Interfaces;
using AfricanFarmersCommodities.Web.IdentityServices;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace CustomAuthorize
{
    public class CustomAuthorize : FilterAttribute, Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter
    {
        public string[] Roles { get; set; }
        UserService _userService;
        public CustomAuthorize(params string[] Roles)
        {
            this.Roles = Roles;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _userService = context.HttpContext.RequestServices.GetService(typeof(IUserService)) as UserService ;

            var authToken = context.HttpContext.Request.Headers["authToken"];
            if (!string.IsNullOrEmpty(authToken))
            {
                var userClaims = _userService.GetUserClaimsFromToken(authToken);

                Array.ForEach(Roles, role =>
                {
                    if (userClaims.Where(c => c.Key.ToLower() == "role" && c.Value.ToString().ToLower().Contains(role.ToLower())).Any())
                    {
                        return;
                    }
                    context.Result = new Microsoft.AspNetCore.Mvc.JsonResult(new { Message = "Forbidden", StatusCode = "403" });

                });
            }
            else 
            {
                context.Result = new Microsoft.AspNetCore.Mvc.JsonResult(new { Message = "Forbidden", StatusCode = "403" });
            }
        }
    }
}
