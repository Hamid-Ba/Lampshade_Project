using AccountManagement.Application.Contract.UserAgg;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ServiceHost.Tools
{
    public class PermissionCheckerAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private IUserApplication _userApplication;
        private int permissionId;

        public PermissionCheckerAttribute(int permissionId) => this.permissionId = permissionId;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _userApplication = (IUserApplication)context.HttpContext.RequestServices.GetService(typeof(IUserApplication));

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string userName = context.HttpContext.User.Identity.Name;

                if (!_userApplication.IsUserHasPermissions(permissionId, userName)) { context.Result = new RedirectResult("/Account"); }
            }

            else context.Result = new RedirectResult("/Account");
        }
    }
}
