using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.ProductAgg;
using ShopManagement.Application.Contracts.ProductPictureAgg;

namespace ServiceHost.Areas.Administration.Pages.Shop.Picture
{
    public class IndexModel : PageModel
    {
        private readonly IProductPictureApplication _productPictureApplication;
        private readonly IProductApplication _productApplication;

        public long ProductSearchId { get; set; }

        [ViewData(Key = "Products")]
        public SelectList Products { get; set; }

        public IEnumerable<AdminProductPictureVM> Pictures { get; set; }

        public IndexModel(IProductPictureApplication productPictureApplication, IProductApplication productApplication)
        {
            _productPictureApplication = productPictureApplication;
            _productApplication = productApplication;
        }

        public void OnGet(long productSearchId)
        {
            Products = new SelectList(_productApplication.GetProductForPictureSearch(), "Id", "Name");
            Pictures = _productPictureApplication.GetAllForAdmin(productSearchId);
        }

        public IActionResult OnGetCreate()
        {
            Products = new SelectList(_productApplication.GetProductForPictureSearch(), "Id", "Name");
            return Partial("Create", new CreateProductPictureVM());
        }

        public IActionResult OnPostCreate(CreateProductPictureVM command)
        {
            if (!ModelState.IsValid) return RedirectToPage("Index");
            var result = _productPictureApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            Products = new SelectList(_productApplication.GetProductForPictureSearch(), "Id", "Name");
            var picture = _productPictureApplication.GetDetailForEdit(id);
            return Partial("Edit", picture);
        }

        public IActionResult OnPostEdit(EditProductPictureVM command)
        {
            if (!ModelState.IsValid) return RedirectToPage("Index");
            var result = _productPictureApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetDelete(long id)
        {
            var deletePicture = _productPictureApplication.GetDetailForDelete(id);
            return Partial("Delete", deletePicture);
        }

        public IActionResult OnPostDelete(DeleteProductPictureVM command)
        {
            var result = _productPictureApplication.Delete(command);
            return new JsonResult(result);
        }
    }
}
