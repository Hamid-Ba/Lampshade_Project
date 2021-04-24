using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Application.Contract.UserAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ForgetPasswordModel : PageModel
    {

        private IUserApplication _userApplication;

        public ForgetPasswordUserVM UserPasswordVM { get; set; }

        [ViewData(Key = "Message")]
        public string Message { get; set; }

        public string MessageColor { get; set; }

        public ForgetPasswordModel(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        public void OnGet(string message, string color)
        {
            Message = message;
            MessageColor = color;
        }

        public IActionResult OnPostForgetPassword(ForgetPasswordUserVM data)
        {
            if (!ModelState.IsValid) return RedirectToPage("ForgetPassword");

            var result = _userApplication.CanChangePassword(data);

            var message = result.Message;

            if (result.IsSucceeded)
            {
                var id = _userApplication.GetUserIdBy(data.Username);
                return RedirectToPage("ChangePassword", new { id });
            }

            return RedirectToPage("ForgetPassword", new { message, color = "danger" });
        }
    }
}
