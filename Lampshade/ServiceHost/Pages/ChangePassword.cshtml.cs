using AccountManagement.Application.Contract.UserAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ChangePasswordModel : PageModel
    {

        private IUserApplication _userApplication;

        [BindProperty]
        public ChangePasswordVM UserPasswordVM { get; set; }

        [ViewData(Key = "Message")] public string Message { get; set; }

        public ChangePasswordModel(IUserApplication userApplication) => _userApplication = userApplication;

        public void OnGet(long id, string message)
        {
            UserPasswordVM = new ChangePasswordVM
            {
                Id = id
            };
            Message = message;
        }

        public IActionResult OnPostChangePassword()
        {
            if (string.IsNullOrWhiteSpace(UserPasswordVM.NewPassword) || string.IsNullOrWhiteSpace(UserPasswordVM.RePassword))
                return RedirectToPage("ChangePassword", new { UserPasswordVM.Id, message = "تمامی مقادیر را پر کنید" });

            var result = _userApplication.ChangePassword(UserPasswordVM);
            var message = result.Message;

            if (result.IsSucceeded) return RedirectToPage("Account");

            return RedirectToPage("ChangePassword", new { UserPasswordVM.Id, message });
        }
    }
}
