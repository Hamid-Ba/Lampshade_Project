using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountManagement.Application.Contract.CustomerDiscountAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.ProductAgg;

namespace ServiceHost.Areas.Administration.Pages.Discount.CustomerDiscount
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerDiscountApplication _customerDiscountApplication;
        private readonly IProductApplication _productApplication;

        public IEnumerable<AdminCustomerDiscountVM> Discounts { get; set; }
        public SearchCustomerDiscountVM Search { get; set; }

        [ViewData(Key = "Products")]
        public SelectList Products { get; set; }

        public IndexModel(ICustomerDiscountApplication customerDiscountApplication, IProductApplication productApplication)
        {
            _customerDiscountApplication = customerDiscountApplication;
            _productApplication = productApplication;
        }

        public void OnGet(SearchCustomerDiscountVM search)
        {
            Products = new SelectList(_productApplication.GetProductModelForSearch(), "Id", "Name");
            Discounts = _customerDiscountApplication.GetAllForAdmin(search);
        }

        public IActionResult OnGetCreate()
        {
            Products = new SelectList(_productApplication.GetProductModelForSearch(), "Id", "Name");
            return Partial("Create", new CreateCustomerDiscountVM());
        }

        public IActionResult OnPostCreate(CreateCustomerDiscountVM command)
        {
            if (!ModelState.IsValid) return RedirectToPage("Index");

            var result = _customerDiscountApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            Products = new SelectList(_productApplication.GetProductModelForSearch(), "Id", "Name");
            return Partial("Edit", new EditCustomerDiscountVM());
        }

        public IActionResult OnPostEdit(EditCustomerDiscountVM command)
        {
            if (!ModelState.IsValid) return RedirectToPage("Index");

            var result = _customerDiscountApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetDelete(long id) => Partial("Delete", new DeleteCustomerDiscountVM());

        public IActionResult OnPostDelete(DeleteCustomerDiscountVM command)
        {
            var result = _customerDiscountApplication.Delete(command);
            return new JsonResult(result);
        }
    }
}
