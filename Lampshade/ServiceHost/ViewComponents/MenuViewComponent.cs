using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LampshadeQuery;
using LampshadeQuery.Contract.ArticleCategory;
using LampshadeQuery.Contract.Category;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly ICategoryQuery _categoryQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;

        public MenuViewComponent(ICategoryQuery categoryQuery, IArticleCategoryQuery articleCategoryQuery)
        {
            _categoryQuery = categoryQuery;
            _articleCategoryQuery = articleCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var result = new MenuQuery()
            {
                ArticleCategoryQuery = _articleCategoryQuery.GetArticleCategoriesForMenu(),
                CategoryQuery = _categoryQuery.GetAllProductCategoriesForMenu()
            };


            return View(result);
        }
    }
}
