﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AfricanFarmersCommodities.Web.IdentityServices;
using AfricanFarmerCommodities.UnitOfWork.Concretes;
using AfricanFarmerCommodities.Web.Models;
using AfricanFarmersCommodities.AppConfigurations;
using AfricanFarmersCommodities.Domain;
using AfricanFarmersCommodities.Models;
using AfricanFarmersCommodities.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CustomAuthorize;
using AfricanFarmersCommodities.Services.EmailServices.Concretes;
using AfricanFarmersCommodities.Services.EmailServices;
using AfricanFarmersCommodities.Services.EmailServices.Interfaces;
using AfricanFarmerCommodities.Web.IdentityServices;
using AfricanFarmerCommodities.Web.ViewModels;

namespace SimbaToursEastAfrica.Controllers
{
    //Account bespoke controller with bespoke membership and roles with strobg encryption. 
    [EnableCors(PolicyName = "CorsPolicy")]
    public class AccountController : Controller
    {
        private AfricanFarmerCommoditiesUnitOfWork _unitOfWork;
        public readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IMailService _emailService;
        
        public AccountController(IUserService userService, IRoleService roleService, AfricanFarmerCommoditiesUnitOfWork unitOfWork, AppSettingsConfigurations appSettings, IMailService emailService)
        {
            _unitOfWork = unitOfWork;
            _roleService = roleService;
            _userService = userService;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> VerifyLoggedInUser()
        {
            /* if (!string.IsNullOrEmpty(User.Identity.Name))
             {
                 var user = await _userService.FindByNameAsync(User.Identity.Name);

                 return Ok(new { name = user.Email, IsLoggedIn = true, IsAdministrator = _userService.IsUserInRoleAsync(user.Username.ToLower(), "administrator").ConfigureAwait(true).GetAwaiter().GetResult() });
             }
             return Ok(new { IsLoggedIn = false });*/

            var authToken = HttpContext.Request.Headers["authToken"];
            if (!string.IsNullOrEmpty(authToken))
            {
                var user = await _userService.Authenticate(authToken);
                if (!string.IsNullOrEmpty(user.Username))
                {
                    return Ok(new { name = user.Username, IsLoggedIn = true, IsAdministrator = _userService.IsUserInRoleAsync(user.Username.ToLower(), "administrator").ConfigureAwait(true).GetAwaiter().GetResult() });
                }
            }
            return Ok(new { IsLoggedIn = false });
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] AfricanFarmersCommodities.Models.UserDetails userDetails)
        {
            if (userDetails.password != userDetails.repassword)
            {
                ModelState.AddModelError(string.Empty, "Password don't match");
                return BadRequest(new { Error = "Passwords don't match", IsRegistered = false });
            }
            if (string.IsNullOrEmpty(userDetails.mobileNumber))
            {
                ModelState.AddModelError(string.Empty, "Mobile Number Required");
                return BadRequest(new { Error = "Mobile Number Required", IsRegistered = false });
            }
            var newUser = new User
            {
                Username = userDetails.emailAddress,
                Email = userDetails.emailAddress,
                MobileNumber = userDetails.mobileNumber,
                FirstName = userDetails.firstName,
                LastName = userDetails.lastName,
                CreateTime = DateTime.Now,
                IsActive = false,
                IsLockedOut = false
            };

            UserInteractionResults userCreationResult = await _userService.CreateAsync(newUser, userDetails.password);
            if (userCreationResult != UserInteractionResults.Succeeded)
            {
                ModelState.AddModelError(userCreationResult.ToString(), userCreationResult.ToString());
                return Ok(new { IsRegistered = false, ErrorMessage = userCreationResult.ToString() });
            }

            _emailService.SendEmail(new EmailDao
            {
                EmailTo = userDetails.emailAddress,
                EmailSubject = "Welcome to African Farmers Commodities",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                EmailBody = new EmailTemplating().GetEmailTemplate(EmailTemplate.WelcomeMessage).Replace("[[FirstName]]", userDetails.firstName)
            });
            return Ok(new { IsRegistered = true, IsAdministrator = false, Message = UserInteractionResults.Succeeded.ToString() });
        }

        [HttpPost]
        public async Task<IActionResult> UserCredentialsAuthenticate([FromBody] BasicUserToken basicAuthToken)
        {
            var user = await _userService.Authenticate(basicAuthToken.authToken);
            if (user != null && !string.IsNullOrEmpty(user.Username))
            {
                return await Task.FromResult(Ok(new
                {
                    username = user.Username,
                    authToken = basicAuthToken.authToken,
                    emailAddress = user.Username
                }));
            }
            return await Task.FromResult(NotFound(new
            {
                username = string.Empty,
                authToken = string.Empty,
                emailAddress = string.Empty
            }));
        }
        [HttpGet]
        public async Task<LoginResult> Authenticate(string authToken)
        {
            var user = await _userService.Authenticate(authToken);
            if (!string.IsNullOrEmpty(user.Username))
            {
                return new LoginResult { IsLoggedIn = true, IsAdministrator = await _userService.IsUserInRoleAsync(user.Username.ToLower(), "administrator") };
            }
            return new LoginResult { IsLoggedIn = false, IsAdministrator = false };
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AfricanFarmersCommodities.Models.UserDetails userDetails)
        {
            if (!string.IsNullOrEmpty(userDetails.authToken))
            {
                var result = await Authenticate(userDetails.authToken);
                LoginResult res = JsonConvert.DeserializeObject<LoginResult>(JsonConvert.SerializeObject(result));

                if (res.IsLoggedIn)
                {
                    await SignInUserWithClaims(userDetails);
                    return Ok(res);
                }
            }
            var signInResult = await CreateAuthoriseUsingLoginCredentials(userDetails);

            await SignInUserWithClaims(userDetails);

            return signInResult;
        }
        private async Task SignInUserWithClaims(UserDetails userDetails)
        {
            try
            {
                if (userDetails != null && !string.IsNullOrEmpty(userDetails.username))
                {
                    var claims = new List<Claim>();

                    claims.Add(new Claim(ClaimTypes.Email, userDetails.emailAddress));
                    var roleList = _roleService.GetAllUserRolesAsString(userDetails.emailAddress);
                    foreach (var role in roleList)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }

                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties() { IsPersistent = userDetails.keepLoggedIn });
                }
                else
                {
                    throw new Exception("Username cannot be null!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<IActionResult> CreateAuthoriseUsingLoginCredentials(UserDetails userDetails)
        {
            var user = await _userService.FindByEmailAsync(userDetails.emailAddress);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login");

                return BadRequest(new { IsLoggedIn = false, ErrorMessage = "Invalid login" });
            }

            UserInteractionResults result = await _userService.PasswordSignInAsync(user, userDetails.password, isPersistent: userDetails.keepLoggedIn, lockoutOnFailure: false);
            if (result != UserInteractionResults.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid login");
                return BadRequest(new { IsLoggedIn = false, ErrorMessage = "Invalid Login" });
            }
            else if (result == UserInteractionResults.Succeeded)
            {
                var tmpUser = await _userService.FindByNameAsync(user.Username);
                var userRoles = await _roleService.FindByUserNameAsync(tmpUser.Username);
                var authToken = await _userService.AddUserRolesClaimAsync(tmpUser.Username, userRoles,user);
                tmpUser.Token = authToken;
                _unitOfWork.SaveChanges();

                var isAdministrator = await _userService.IsUserInRoleAsync(user.Username.ToLower(), "administrator");
                return Ok(new { AuthToken = authToken, IsLoggedIn = true, IsAdministrator = isAdministrator });
            }

            return Ok(new { IsLoggedIn = false, IsAdministrator = false, Message = "Failed to Login!", Result = result.ToString() });
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string emailAddress)
        {
            var user = await _userService.FindByEmailAsync(emailAddress);
            if (user == null)
                return BadRequest(new { ErrorMessage = "Reset your password through email link" });

            string passwordResetToken = _userService.GeneratePasswordResetTokenAsync(user).ConfigureAwait(true).GetAwaiter().GetResult();
            var passwordResetUrl = Url.Action("ResetPassword", "Account", new ResetPassword { Id = user.UserId.ToString(), Token = passwordResetToken }, Request.Scheme);
            var emailDao = new EmailDao
            {
                EmailTo = user.Email,
                EmailSubject = "You Requested Password Reset for your African Farmers Commodities Site.",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                EmailBody = new EmailTemplating().GetEmailTemplate(EmailTemplate.PasswordResetMessage).Replace("[[FirstName]]", user.FirstName).Replace("[[PasswordResetLink]]", $"Click <a href=\"" + passwordResetUrl + "\">here</a> to reset your password")
            };
            _emailService.SendEmail(emailDao);
            return Ok(new { PasswordResetUrl = passwordResetUrl, passwordResetToken = passwordResetToken, Message = "Reset your password through email link" });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPassword resetPassword)
        {
            User user = await _userService.FindByIdAsync(resetPassword.Id);
            if (user == null)
                throw new InvalidOperationException();

            if (resetPassword.Password != resetPassword.Repassword)
            {
                ModelState.AddModelError(string.Empty, "Passwords do not match");

                return BadRequest(new { ErrorMessage = "Password and retyped Passwords don't match" });
            }

            User userResetPassword = await _userService.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
            if (string.IsNullOrEmpty(userResetPassword.Username))
            {
                ModelState.AddModelError(UserInteractionResults.Failed.ToString(), UserInteractionResults.Failed.ToString());
                return BadRequest(new { ErrorMessage = "Failed to reset Password" });
            }

            _emailService.SendEmail(new EmailDao
            {
                EmailTo = user.Email,
                EmailSubject = "You Requested Password Reset for your African Farmers Commodities Site.",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                EmailBody = new EmailTemplating().GetEmailTemplate(EmailTemplate.PasswordResetMessage).Replace("[[FirstName]]", user.FirstName)
            });
            return Ok(new { Message = "Password reset successfully" });
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            _userService.SignOut(this.User.Identity.Name);
            await this.HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return Ok(new { isLoggedIn = false, Message = "Logged Out", isAdministrator = false });
        }

        [HttpPost]
        [CustomAuthorize.CustomAuthorize(Roles = new string[] { "Administrator" })]
        public async Task<IActionResult> AddUserToRole([FromBody] AfricanFarmersCommodities.Models.UserRole userRole)
        {
            var user = await _userService.FindByEmailAsync(userRole.email);
            var isUserInrole = false;
            if (user != null)
            {
                isUserInrole = await _userService.IsUserInRoleAsync(user.Email.ToLower(), userRole.role.ToLower());
            }
            if (!isUserInrole)
            {
                UserInteractionResults result = await _userService.AddToRoleAsync(user, userRole.role);
                return Json(new { Result = result.ToString() });
            }
            return Ok(new { Message = UserInteractionResults.Failed.ToString() });
        }

        [HttpPost]
        [CustomAuthorize.CustomAuthorize(Roles = new string[] { "Administrator" })]
        public async Task<IActionResult> RemoveUserFromRole([FromBody] AfricanFarmersCommodities.Models.UserRole userRole)
        {
            var user = await _userService.FindByEmailAsync(userRole.email);

            var userInRole = false;
            if (user != null)
            {
                userInRole = await _userService.IsUserInRoleAsync(user.Email.ToLower(), userRole.role.ToLower());
            }
            if (userInRole)
            {
                UserInteractionResults result = await _userService.RemoveFromRolesAsync(user, new string[] { userRole.role });
                return Ok(new { Result = result.ToString() });
            }
            return BadRequest(new { Result = UserInteractionResults.Failed.ToString(), ErrorMessage = "Failed to remove user from Role" });
        }
        [HttpGet]
        [AuthorizeIdentity]
        public IActionResult GetAllRoles()
        {
            try
            {
                IEnumerable<Role> roles = _roleService.GetAllRoles().Result.Select(p => new Role { RoleName = p.RoleName });
                return Ok(roles.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [AuthorizeIdentity]
        public IActionResult GetAllUserRoles(string username)
        {
            try
            {
                if (string.IsNullOrEmpty(username))
                    return NotFound();
                var roles = _roleService.GetAllUserRolesAsString(username);
                return Ok(roles);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [CustomAuthorize.CustomAuthorize(Roles = new string[] { "Administrator" })]
        public async Task<IActionResult> CreateRole([FromBody] AfricanFarmersCommodities.Models.UserRole role)
        {
            try
            {
                var newRole = _roleService.GetAllRoles().Result.FirstOrDefault(p => p.RoleName.ToLower().Equals(role.role.ToLower().Trim()));

                if (newRole == null)
                {
                    UserInteractionResults result = await _roleService.CreateAsync(new AfricanFarmersCommodities.Domain.Role { RoleName = role.role });
                    if (result == UserInteractionResults.Succeeded)
                    {
                        return Ok(new { Message = UserInteractionResults.Succeeded.ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return BadRequest(new { ErrorMessage = UserInteractionResults.Failed.ToString() });
        }
        [HttpPost]
        [CustomAuthorize.CustomAuthorize(Roles = new string[] { "Administrator" })]
        public async Task<IActionResult> DeleteRole([FromBody] AfricanFarmersCommodities.Models.UserRole role)
        {
            try
            {
                var toDeleteRole = _roleService.GetAllRoles().Result.FirstOrDefault(p => p.RoleName.ToLower().Equals(role.role.ToLower().Trim()));

                if (toDeleteRole != null)
                {
                    UserInteractionResults result = await _roleService.DeleteAsync(toDeleteRole);
                    if (result == UserInteractionResults.Succeeded)
                    {
                        return Ok(new { Message = UserInteractionResults.Succeeded.ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return BadRequest(new { ErrorMessage = UserInteractionResults.Failed.ToString() });
        }
    }

}
