using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LampshadeQuery.Contract.Category;
using LampshadeQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly ICategoryQuery _categoryQuery;

        public CategoryWithProductsQueryVM CategoryAndProducts { get; set; }
        public CategoryModel(ICategoryQuery categoryQuery) => _categoryQuery = categoryQuery;
        
        public void OnGet(string id)
        {
            CategoryAndProducts = _categoryQuery.GetCategoryAndProductsBy(id);
        }
    }
}
