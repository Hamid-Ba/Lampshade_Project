using AccountManagement.Application.Contract.UserAgg;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;

namespace ServiceHost.Tools
{
    [HtmlTargetElement(Attributes = "Permission")]
    public class PermissionTagHelper : TagHelper
    {
        public int Permission { get; set; }

        private readonly IUserApplication _userApplication;
        private readonly IHttpContextAccessor _contextAccessor;

        public PermissionTagHelper(IUserApplication userApplication, IHttpContextAccessor httpContextAccessor) 
        {
            _userApplication = userApplication;
            _contextAccessor = httpContextAccessor;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                output.SuppressOutput();
                return;
            }

            
            if (!_userApplication.IsUserHasPermissions(Permission,_contextAccessor.HttpContext.User.Identity.Name))
            {
                output.SuppressOutput();
                return;
            }

            base.Process(context, output);
        }
    }
}
