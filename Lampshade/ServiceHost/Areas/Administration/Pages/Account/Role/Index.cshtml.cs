using System.Collections.Generic;
using AccountManagement.Application.Contract.RoleAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Account.Role
{
    public class IndexModel : PageModel
    {
        private readonly IRoleApplication _roleApplication;

        public IEnumerable<AdminRoleVM> Roles { get; set; }

        public IndexModel(IRoleApplication roleApplication) => _roleApplication = roleApplication;

        public void OnGet() => Roles = _roleApplication.GetAllForAdmin();

        public IActionResult OnGetCreate() => Partial("Create", new CreateRoleVM());

        public IActionResult OnPostCreate(CreateRoleVM command)
        {
            if (!ModelState.IsValid) return RedirectToPage("Index");
            var result = _roleApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var role = _roleApplication.GetDetailForEdit(id);
            return Partial("Edit", role);
        }

        public IActionResult OnPostEdit(EditRoleVM command)
        {
            if (!ModelState.IsValid) return RedirectToPage("Index");
            var result = _roleApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetDelete(long id)
        {
            var roleProduct = _roleApplication.GetDetailForDelete(id);
            return Partial("Delete", roleProduct);
        }

        public IActionResult OnPostDelete(DeleteRoleVM command)
        {
            var result = _roleApplication.Delete(command);
            return new JsonResult(result);
        }
    }
}
