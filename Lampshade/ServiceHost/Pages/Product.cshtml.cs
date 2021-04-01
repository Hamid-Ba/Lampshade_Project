using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LampshadeQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductQuery _productQuery;

        public ProductQueryVM Product { get; set; }

        public ProductModel(IProductQuery productQuery) => _productQuery = productQuery;

        public void OnGet(string id) => Product = _productQuery.GetDetailsBy(id);

    }
}
