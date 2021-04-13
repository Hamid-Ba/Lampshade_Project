using System.ComponentModel.DataAnnotations;
using AccountManagement.Application.Contract.UserAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class AccountModel : PageModel
    {
        private readonly IUserApplication _userApplication;

        [ViewData(Key = "Message")] public string Message { get; set; }
        [ViewData(Key = "MessageColor")] public string MessageColor { get; set; }
        public bool IsKeep { get; set; }

        public AccountModel(IUserApplication userApplication) => _userApplication = userApplication;

        public void OnGet()
        {
        }

        public IActionResult OnPostLogin(LoginVM command, bool isKeep)
        {
            MessageColor = "danger";
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "تمامی مقادیر را پر کنید";
                return Page();
            }

            var result = _userApplication.Login(command, isKeep);

            if (!result.IsSucceeded)
            {
                ViewData["Message"] = result.Message;
                return Page();
            }

            return RedirectToPage("Index");
        }

        public IActionResult OnGetLogout()
        {
            _userApplication.Logout();
            return RedirectToPage("Account");
        }

        public IActionResult OnPostRegister(CreateUserVM command, string rePassword)
        {
            MessageColor = "danger";
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "تمامی مقادیر را پر کنید";
                return Page();
            }

            if (command.Password != rePassword)
            {
                ViewData["Message"] = "رمزهای عبور مطابقت ندارند!";
                return Page();
            }

            var result = _userApplication.Create(command);

            if (!result.IsSucceeded)
            {
                ViewData["Message"] = result.Message;
                return Page();
            }

            MessageColor = "success";
            ViewData["Message"] = "ثبت نام شما با موفقیت انجام پذیرفت!";

            return Page();
        }
    }
}
