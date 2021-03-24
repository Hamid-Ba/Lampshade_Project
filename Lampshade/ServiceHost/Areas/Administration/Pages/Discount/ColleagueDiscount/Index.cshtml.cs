using System.Collections.Generic;
using DiscountManagement.Application.Contract.ColleagueDiscountAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; 

using ShopManagement.Application.Contracts.ProductAgg;

namespace ServiceHost.Areas.Administration.Pages.Discount.ColleagueDiscount
{
    public class IndexModel : PageModel
    {
        private readonly IColleagueDiscountApplication _colleagueDiscountApplication;
        private readonly IProductApplication _productApplication;

        public IEnumerable<AdminColleagueDiscountVM> Discounts { get; set; }
        public SearchColleagueDiscountVM Search;

        [ViewData(Key = "Products")]
        public SelectList Products { get; set; }

        public IndexModel(IColleagueDiscountApplication colleagueDiscountApplication, IProductApplication productApplication)
        {
            _colleagueDiscountApplication = colleagueDiscountApplication;
            _productApplication = productApplication;
        }

        public void OnGet(SearchColleagueDiscountVM search)
        {
            Products = new SelectList(_productApplication.GetProductModelForSearch(), "Id", "Name");
            Discounts = _colleagueDiscountApplication.GetAllForAdmin(search);
        }

        public IActionResult OnGetCreate()
        {
            Products = new SelectList(_productApplication.GetProductModelForSearch(), "Id", "Name");
            return Partial("Create", new CreateColleagueDiscountVM());
        }

        public IActionResult OnPostCreate(CreateColleagueDiscountVM command)
        {
            if (!ModelState.IsValid) return RedirectToPage("Index");

            var result = _colleagueDiscountApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            Products = new SelectList(_productApplication.GetProductModelForSearch(), "Id", "Name");
            return Partial("Edit", _colleagueDiscountApplication.GetDetailForEdit(id));
        }

        public IActionResult OnPostEdit(EditColleagueDiscountVM command)
        {
            if (!ModelState.IsValid) return RedirectToPage("Index");

            var result = _colleagueDiscountApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetDelete(long id) => Partial("Delete", _colleagueDiscountApplication.GetDetailForDelete(id));

        public IActionResult OnPostDelete(DeleteColleagueDiscountVM command)
        {
            var result = _colleagueDiscountApplication.Delete(command);
            return new JsonResult(result);
        }
    }
}