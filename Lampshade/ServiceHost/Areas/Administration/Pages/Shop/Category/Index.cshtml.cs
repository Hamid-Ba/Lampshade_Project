using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategoryAgg;

namespace ServiceHost.Areas.Administration.Pages.Shop.Category
{
    public class IndexModel : PageModel
    {
        private readonly IProductCategoryApplication _categoryApplication;

        [BindProperty]
        public string SearchName { get; set; }

        public IEnumerable<AdminProductCategoryVM> ProductCategories { get; set; }

        public IndexModel(IProductCategoryApplication categoryApplication) => _categoryApplication = categoryApplication;

        public void OnGet(string searchName)
        {
            ProductCategories = _categoryApplication.GetAllForAdmin(searchName);
        }

        public IActionResult OnGetCreate() => Partial("Create",new CreateProductCategoryVM());

        public IActionResult OnPostCreate(CreateProductCategoryVM command)
        {
            if (!ModelState.IsValid) return RedirectToPage("Index");
            var result = _categoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var editCategory = _categoryApplication.GetDetailBy(id);
            return Partial("Edit", editCategory);
        }

        public IActionResult OnPostEdit(EditProductCategoryVM command)
        {
            if (!ModelState.IsValid) return RedirectToPage("Index");
            var result = _categoryApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
