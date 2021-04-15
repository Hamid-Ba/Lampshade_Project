using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceHost.Tools;
using ShopManagement.Application.Contracts.ProductAgg;
using ShopManagement.Application.Contracts.ProductCategoryAgg;
using ShopManagement.Infrastructure.Configuration;

namespace ServiceHost.Areas.Administration.Pages.Shop.Product
{
    [PermissionChecker(ShopPermissions.ProductList)]
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _categoryApplication;

        public SearchProductVM Search;

        [ViewData(Key = "Categories")]
        public SelectList Categories { get; set; }

        public IEnumerable<AdminProductVM> Products { get; set; }

        public IndexModel(IProductApplication productApplication, IProductCategoryApplication categoryApplication)
        {
            _productApplication = productApplication;
            _categoryApplication = categoryApplication;
        }

        public void OnGet(SearchProductVM search)
        {
            Categories = new SelectList(_categoryApplication.GetCategoriesForSearchInProduct(), "Id", "Name");
            Products = _productApplication.GetAllForAdmin(search);
        }

        public IActionResult OnGetCreate()
        {
            Categories = new SelectList(_categoryApplication.GetCategoriesForSearchInProduct(), "Id", "Name");
            return Partial("Create", new CreateProductVM());
        }

        public IActionResult OnPostCreate(CreateProductVM command)
        {
            if (!ModelState.IsValid) return RedirectToPage("Index");
            var result = _productApplication.Create(command);
            return new JsonResult(result);
        }


        public IActionResult OnGetEdit(long id)
        {
            Categories = new SelectList(_categoryApplication.GetCategoriesForSearchInProduct(), "Id", "Name");
            var product = _productApplication.GetDetailForEdit(id);
            return Partial("Edit", product);
        }


        public IActionResult OnPostEdit(EditProductVM command)
        {
            if (!ModelState.IsValid) return RedirectToPage("Index");
            var result = _productApplication.Edit(command);
            return new JsonResult(result);
        }


        public IActionResult OnGetDelete(long id)
        {
            var deleteProduct = _productApplication.GetDetailForDelete(id);
            return Partial("Delete", deleteProduct);
        }


        public IActionResult OnPostDelete(DeleteProductVM command)
        {
            var result = _productApplication.Delete(command);
            return new JsonResult(result);
        }
    }
}
