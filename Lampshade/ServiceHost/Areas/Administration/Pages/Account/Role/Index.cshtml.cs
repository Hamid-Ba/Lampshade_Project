using System.Collections.Generic;
using AccountManagement.Application.Contract.PermissionAgg;
using AccountManagement.Application.Contract.RoleAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Account.Role
{
    public class IndexModel : PageModel
    {
        private readonly IRoleApplication _roleApplication;
        private readonly IPermissionApplication _permissionApplication;

        public IEnumerable<AdminRoleVM> Roles { get; set; }

        [ViewData(Key = "Permissions")]
        public SelectList Permissions { get; set; }

        public IndexModel(IRoleApplication roleApplication, IPermissionApplication permissionApplication)
        {
            _roleApplication = roleApplication;
            _permissionApplication = permissionApplication;
            Permissions = new SelectList(_permissionApplication.GetAllForAdmin(), "Id", "Name");
        }

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
    }
}
