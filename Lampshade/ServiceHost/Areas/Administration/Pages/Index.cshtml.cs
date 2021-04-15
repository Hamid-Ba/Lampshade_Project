using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceHost.Tools;

namespace ServiceHost.Areas.Administration.Pages
{
    [PermissionChecker(6)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
