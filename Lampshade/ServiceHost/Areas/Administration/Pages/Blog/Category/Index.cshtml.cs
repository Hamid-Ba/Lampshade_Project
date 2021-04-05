using System.Collections.Generic;
using BlogManagement.Application.Contract.ArticleCategoryAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategoryAgg;

namespace ServiceHost.Areas.Administration.Pages.Blog.Category
{
    public class IndexModel : PageModel
    {
        private readonly IArticleCategoryApplication _categoryApplication;

        public SearchArticleCategoryVM Search { get; set; }

        public IEnumerable<AdminArticleCategoryVM> Categories { get; set; }

        public IndexModel(IArticleCategoryApplication categoryApplication) => _categoryApplication = categoryApplication;

        public void OnGet(SearchArticleCategoryVM search) => Categories = _categoryApplication.GetAllForAdmin(search);

        public IActionResult OnGetCreate() => Partial("Create", new CreateArticleCategoryVM());

        public IActionResult OnPostCreate(CreateArticleCategoryVM command)
        {
            if (!ModelState.IsValid) return RedirectToPage("Index");
            var result = _categoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var editCategory = _categoryApplication.GetDetailForEdit(id);
            return Partial("Edit", editCategory);
        }

        public IActionResult OnPostEdit(EditArticleCategoryVM command)
        {
            if (!ModelState.IsValid) return RedirectToPage("Index");
            var result = _categoryApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetDelete(long id)
        {
            var result = _categoryApplication.Delete(id);
            return RedirectToPage("Index");
        }
    }
}
