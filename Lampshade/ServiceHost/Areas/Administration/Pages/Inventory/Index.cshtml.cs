using System.Collections.Generic;
using DiscountManagement.Application.Contract.CustomerDiscountAgg;
using InventoryManagement.Application.Contract.InventoryAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.ProductAgg;

namespace ServiceHost.Areas.Administration.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        private readonly IInventoryApplication _inventoryApplication;
        private readonly IProductApplication _productApplication;

        public IEnumerable<AdminInventoryVM> Inventories { get; set; }
        public SearchInventoryVM Search { get; set; }

        [ViewData(Key = "Products")]
        public SelectList Products { get; set; }

        public IndexModel(IInventoryApplication inventoryApplication, IProductApplication productApplication)
        {
            _inventoryApplication = inventoryApplication;
            _productApplication = productApplication;
        }

        public void OnGet(SearchInventoryVM search)
        {
            Products = new SelectList(_productApplication.GetProductModelForSearch(), "Id", "Name");
            Inventories = _inventoryApplication.GetAllForAdmin(search);
        }

        public IActionResult OnGetCreate()
        {
            Products = new SelectList(_productApplication.GetProductModelForSearch(), "Id", "Name");
            return Partial("Create", new CreateInventoryVM());
        }

        public IActionResult OnPostCreate(CreateInventoryVM command)
        {
            if (!ModelState.IsValid) return RedirectToPage("Index");

            var result = _inventoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            Products = new SelectList(_productApplication.GetProductModelForSearch(), "Id", "Name");
            return Partial("Edit", _inventoryApplication.GetDetailForEdit(id));
        }

        public IActionResult OnPostEdit(EditInventoryVM command)
        {
            if (!ModelState.IsValid) return RedirectToPage("Index");

            var result = _inventoryApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetDelete(long id) => Partial("Delete", _inventoryApplication.GetDetailForDelete(id));

        public IActionResult OnPostDelete(DeleteInventoryVM command)
        {
            var result = _inventoryApplication.Delete(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetIncrease(long id)
        {
            var model = new IncreaseInventoryVM()
            {
                InventoryId = id,
            };
            return Partial("Increase", model);
        }

        public IActionResult OnPostIncrease(IncreaseInventoryVM command)
        {
            var result = _inventoryApplication.Increase(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetDecrease(long id)
        {
            var model = new DecreaseInventoryVM()
            {
                Id = id
            };
            return Partial("Decrease", model);
        }

        public IActionResult OnPostDecrease(DecreaseInventoryVM command)
        {
            var result = _inventoryApplication.Decrease(command);
            return new JsonResult(result);
        }
        
    }
}
