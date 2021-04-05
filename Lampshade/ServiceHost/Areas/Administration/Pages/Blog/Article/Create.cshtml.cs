using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManagement.Application.Contract.ArticleAgg;
using BlogManagement.Application.Contract.ArticleCategoryAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Article
{
    public class CreateModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _categoryApplication;

        public CreateArticleVM Model { get; set; }
        public SelectList Categories { get; set; }

        public CreateModel(IArticleApplication articleApplication, IArticleCategoryApplication categoryApplication)
        {
            _articleApplication = articleApplication;
            _categoryApplication = categoryApplication;
        }

        public void OnGet() => Categories = new SelectList(_categoryApplication.GetAllForSearch(), "Id", "Name");

        public IActionResult OnPost(CreateArticleVM model)
        {
            Categories = new SelectList(_categoryApplication.GetAllForSearch(), "Id", "Name");
            if (!ModelState.IsValid) return Page();

            var result = _articleApplication.Create(model);
            if(result.IsSucceeded) return RedirectToPage("Index");

            return Page();
        }
    }
}
