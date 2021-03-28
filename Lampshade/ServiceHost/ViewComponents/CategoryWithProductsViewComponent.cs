using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LampshadeQuery.Contract.Category;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class CategoryWithProductsViewComponent :ViewComponent
    {
        private readonly ICategoryQuery _categoryQuery;

        public CategoryWithProductsViewComponent(ICategoryQuery categoryQuery) => _categoryQuery = categoryQuery;

        public IViewComponentResult Invoke() => View(_categoryQuery.GetCategoryWithProducts());

    }
}
