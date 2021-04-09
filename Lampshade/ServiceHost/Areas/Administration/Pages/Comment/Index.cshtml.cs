using System.Collections.Generic;
using CommentManagement.Application.Contract.CommentAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductAgg;

namespace ServiceHost.Areas.Administration.Pages.Comment
{
    public class IndexModel : PageModel
    {
        private readonly ICommentApplication _commentApplication;

        public SearchCommentVM Search;

        public IEnumerable<AdminCommentVM> Comments { get; set; }

        public IndexModel(ICommentApplication commentApplication) => _commentApplication = commentApplication;

        public void OnGet(SearchCommentVM search) => Comments = _commentApplication.GetAllForAdmin(search);

        public IActionResult OnGetDelete(long id)
        {
            var deleteComment = _commentApplication.GetDetailForDelete(id);
            return Partial("Delete", deleteComment);
        }

        public IActionResult OnPostDelete(DeleteCommentVM command)
        {
            var result = _commentApplication.DeleteComment(command);
            return new JsonResult(result);
        }


        public IActionResult OnGetConfirmed(long id)
        {
            _commentApplication.ConfirmedComment(id);
            return RedirectToPage("Index");
        }

        public IActionResult OnGetDisConfirmed(long id)
        {
            _commentApplication.DisConfirmedComment(id);
            return RedirectToPage("Index");
        }

    }
}
