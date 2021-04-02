using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.CommentAgg;
using ShopManagement.Application.Contracts.ProductAgg;
using ShopManagement.Application.Contracts.ProductCategoryAgg;

namespace ServiceHost.Areas.Administration.Pages.Shop.Comment
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _productApplication;
        private readonly ICommentApplication _commentApplication;


        public SearchCommentVM Search;

        [ViewData(Key = "Products")]
        public SelectList Products { get; set; }

        public IEnumerable<AdminCommentVM> Comments { get; set; }

        public IndexModel(IProductApplication productApplication, ICommentApplication commentApplication)
        {
            _productApplication = productApplication;
            _commentApplication = commentApplication;
        }

        public void OnGet(SearchCommentVM search)
        {
            Products = new SelectList(_productApplication.GetProductModelForSearch(), "Id", "Name");
            Comments = _commentApplication.GetAllForAdmin(search);
        }

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
