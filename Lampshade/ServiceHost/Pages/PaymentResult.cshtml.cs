using Framework.Application;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class PaymentResultModel : PageModel
    {
        public OperationResult Result { get; set; }

        public void OnGet(OperationResult result) => Result = result;
        
    }
}
