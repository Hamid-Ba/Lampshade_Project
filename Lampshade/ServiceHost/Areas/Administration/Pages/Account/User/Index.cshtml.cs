using System.Collections.Generic;
using AccountManagement.Application.Contract.RoleAgg;
using AccountManagement.Application.Contract.UserAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.ProductAgg;
using ShopManagement.Application.Contracts.ProductCategoryAgg;

namespace ServiceHost.Areas.Administration.Pages.Account.User
{
    public class IndexModel : PageModel
    {
        private readonly IUserApplication _userApplication;
        private readonly IRoleApplication _roleApplication;


        public SearchUserVM Search;

        [ViewData(Key = "Roles")]
        public SelectList Roles { get; set; }

        public IEnumerable<AdminUserVM> Users { get; set; }

        public IndexModel(IUserApplication userApplication, IRoleApplication roleApplication)
        {
            _userApplication = userApplication;
            _roleApplication = roleApplication;
            Roles = new SelectList(_roleApplication.GetAllForAdmin(), "Id", "Name");
        }

        public void OnGet(SearchUserVM search) => Users = _userApplication.GetAllForAdmin(search);

        public IActionResult OnGetCreate() => Partial("Create", new CreateUserVM());

        public IActionResult OnPostCreate(CreateUserVM command)
        {
            if (!ModelState.IsValid) return RedirectToPage("Index");
            var result = _userApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var user = _userApplication.GetDetailForEdit(id);
            return Partial("Edit", user);
        }

        public IActionResult OnPostEdit(EditUserVM command)
        {
            if (!ModelState.IsValid) return RedirectToPage("Index");
            var result = _userApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetDelete(long id)
        {
            var user = _userApplication.GetDetailForDelete(id);
            return Partial("Delete", user);
        }

        public IActionResult OnPostDelete(DeleteUserVM command)
        {
            var result = _userApplication.Delete(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetChangePassword(long id) => Partial("ChangePassword", new ChangePasswordVM() { Id = id });

        public IActionResult OnPostChangePassword(ChangePasswordVM command)
        {
            var result = _userApplication.ChangePassword(command);
            return new JsonResult(result);
        }

    }
}
