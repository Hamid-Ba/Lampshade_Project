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
    public class EditModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _categoryApplication;

        public EditArticleVM Model { get; set; }
        public SelectList Categories { get; set; }

        public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication categoryApplication)
        {
            _articleApplication = articleApplication;
            _categoryApplication = categoryApplication;
        }

        public IActionResult OnGet(long id)
        {
            Categories = new SelectList(_categoryApplication.GetAllForSearch(), "Id", "Name");
            Model = _articleApplication.GetDetailsForEdit(id);

            if (Model == null) return RedirectToPage("Index");

            return Page();
        }

        public IActionResult OnPost(EditArticleVM model)
        {
            Categories = new SelectList(_categoryApplication.GetAllForSearch(), "Id", "Name");
            if (!ModelState.IsValid) return Page();

            var result = _articleApplication.Edit(model);

            if (result.IsSucceeded) return RedirectToPage("Index");

            return Page();
        }
    }
}
