using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.SlideAgg;

namespace ServiceHost.Areas.Administration.Pages.Shop.Slide
{
    public class IndexModel : PageModel
    {
        private readonly ISlideApplication _slideApplication;

        public IEnumerable<AdminSlideVM> Slides { get; set; }

        public IndexModel(ISlideApplication slideApplication) => _slideApplication = slideApplication;

        public void OnGet() => Slides = _slideApplication.GetAllForAdmin();

        public IActionResult OnGetCreate() => Partial("Create", new CreateSlideVM());

        public IActionResult OnPostCreate(CreateSlideVM command)
        {
            if (!ModelState.IsValid) return RedirectToPage("Index");
            var result = _slideApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id) => Partial("Edit", _slideApplication.GetDetailForEdit(id));

        public IActionResult OnPostEdit(EditSlideVM command)
        {
            if (!ModelState.IsValid) return RedirectToPage("Index");
            var result = _slideApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetDelete(long id) => Partial("Delete", _slideApplication.GetDetailForDelete(id));

        public IActionResult OnPostDelete(DeleteSlideVM command)
        {
            var result = _slideApplication.Delete(command);
            return new JsonResult(result);
        }
    }
}
