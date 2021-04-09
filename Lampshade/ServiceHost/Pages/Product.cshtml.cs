using CommentManagement.Application.Contract.CommentAgg;
using LampshadeQuery;
using LampshadeQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductQuery _productQuery;
        private readonly ICommentApplication _commentApplication;

        public ProductQueryVM Product { get; set; }

        public string Message { get; set; }
        public string MessageColor { get; set; }

        public ProductModel(IProductQuery productQuery, ICommentApplication commentApplication)
        {
            _productQuery = productQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(string id, string message, string messageColor)
        {
            Product = _productQuery.GetDetailsBy(id);
            Message = message;
            MessageColor = messageColor;
        }

        public IActionResult OnPost(CreateCommentVM command, string slug)
        {
            command.Type = CommentOwnerType.ProductType;
            if (!ModelState.IsValid) return RedirectToPage("Product", new { id = slug, message = "همه اطلاعات را وارد نمائید!", messageColor = "danger" });

            var result = _commentApplication.CreateComment(command);

            return RedirectToPage("Product", new { id = slug, message = "نظر شما با موفقیت ثبت شد!", messageColor = "success" });
        }
    }
}
