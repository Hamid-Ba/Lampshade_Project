using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommentManagement.Application.Contract.CommentAgg;
using LampshadeQuery;
using LampshadeQuery.Contract.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticleModel : PageModel
    {
        private readonly IArticleQuery _articleQuery;
        private readonly ICommentApplication _commentApplication;

        public ArticleQueryVM Article { get; set; }

        public string Message { get; set; }
        public string MessageColor { get; set; }

        public ArticleModel(IArticleQuery articleQuery, ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(string id, string message, string messageColor)
        {
            Article = _articleQuery.GetArticleBy(id);
            Message = message;
            MessageColor = messageColor;
        }

        public IActionResult OnPost(CreateCommentVM comment, string slug)
        {
            comment.Type = CommentOwnerType.ArticleType;

            if (!ModelState.IsValid) return RedirectToPage("Article", new { id = slug, message = "همه اطلاعات را وارد نمائید!", messageColor = "danger" });
            
            var result = _commentApplication.CreateComment(comment);

            return RedirectToPage("Article", new { id = slug, message = "نظر شما با موفقیت ثبت شد!", messageColor = "success" });
        }

    }
}
