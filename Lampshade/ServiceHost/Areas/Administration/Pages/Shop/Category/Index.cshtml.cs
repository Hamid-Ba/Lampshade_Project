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
    }
}
