using System.Collections.Generic;
using BlogManagement.Application.Contract.ArticleAgg;
using BlogManagement.Application.Contract.ArticleCategoryAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Article
{
    public class IndexModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _categoryApplication;

        public IEnumerable<AdminArticleVM> Articles { get; set; }
        public SearchArticleVM Search { get; set; }

        [ViewData(Key = "Categories")]
        public SelectList Categories { get; set; }

        public IndexModel(IArticleApplication articleApplication, IArticleCategoryApplication categoryApplication)
        {
            _articleApplication = articleApplication;
            _categoryApplication = categoryApplication;
        }

        public void OnGet(SearchArticleVM search)
        {
            Categories = new SelectList(_categoryApplication.GetAllForSearch(), "Id", "Name");
            Articles = _articleApplication.GetAllForAdmin(search);
        }

        public IActionResult OnGetDelete(long id)
        {
            _articleApplication.Delete(id);
            return RedirectToPage("Index");
        }
    }
}
