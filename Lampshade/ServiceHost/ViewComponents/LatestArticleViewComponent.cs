using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LampshadeQuery.Contract.Article;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class LatestArticleViewComponent : ViewComponent
    {
        private readonly IArticleQuery _articleQuery;

        public LatestArticleViewComponent(IArticleQuery articleQuery) => _articleQuery = articleQuery;


        public IViewComponentResult Invoke() => View(_articleQuery.GetLatestBlogs(5));
    }
}
