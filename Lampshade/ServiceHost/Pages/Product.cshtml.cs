using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LampshadeQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.CommentAgg;

namespace ServiceHost.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductQuery _productQuery;
        private readonly ICommentApplication _commentApplication;

        public ProductQueryVM Product { get; set; }

        public ProductModel(IProductQuery productQuery, ICommentApplication commentApplication)
        {
            _productQuery = productQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(string id) => Product = _productQuery.GetDetailsBy(id);

        public IActionResult OnPost(CreateCommentVM command, string slug)
        {
            if (!ModelState.IsValid) return RedirectToPage("Product", new { id = slug });

            var result = _commentApplication.CreateComment(command);

            return RedirectToPage("Product", new { id = slug });  
        }
    }
}
