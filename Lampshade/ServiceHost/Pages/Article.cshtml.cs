using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LampshadeQuery.Contract.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticleModel : PageModel
    {
        private readonly IArticleQuery _articleQuery;

        public ArticleQueryVM Article { get; set; }

        public ArticleModel(IArticleQuery articleQuery) => _articleQuery = articleQuery;

        public void OnGet(string id) => Article = _articleQuery.GetArticleBy(id);

    }
}
