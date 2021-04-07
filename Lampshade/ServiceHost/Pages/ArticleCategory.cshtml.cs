using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LampshadeQuery.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticleCategoryModel : PageModel
    {
        private readonly IArticleCategoryQuery _categoryQuery;

        public ArticleCategoryQueryVM Category { get; set; }

        public ArticleCategoryModel(IArticleCategoryQuery categoryQuery) => _categoryQuery = categoryQuery;

        public void OnGet(string id) => Category = _categoryQuery.GetArticleCategory(id);

    }
}
