using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LampshadeQuery.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class ArticleCategorySideBarViewComponent : ViewComponent
    {
        private readonly IArticleCategoryQuery _categoryQuery;

        public ArticleCategorySideBarViewComponent(IArticleCategoryQuery categoryQuery) => _categoryQuery = categoryQuery;

        public IViewComponentResult Invoke() => View(_categoryQuery.GetArticleCategoriesForSideBar());

    }
}
