using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using AuthenticationProperties = Microsoft.AspNetCore.Authentication.AuthenticationProperties;

namespace Framework.Application.Authentication
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public long GetUserId() => long.Parse(_contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);

        public bool IsAuthenticated() =>  _contextAccessor.HttpContext.User.Identity != null && _contextAccessor.HttpContext.User.Identity.IsAuthenticated;

        public void Signin(AuthViewModel account)
        {
            var claims = new List<Claim>
            {
                new Claim("UserId", account.Id.ToString()),
                new Claim("Fullname", account.Fullname),
              //  new Claim(ClaimTypes.Role, account.RoleId.ToString()),
                new Claim(ClaimTypes.Name, account.Username), // Or Use ClaimTypes.NameIdentifier
              //  new Claim("Mobile", account.Mobile)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = account.KeepMe
            };

            _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        }

        public void SignOut()
        {
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}