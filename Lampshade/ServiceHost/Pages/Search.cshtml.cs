using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LampshadeQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class SearchModel : PageModel
    {
        private readonly IProductQuery _productQuery;

        public IEnumerable<ProductQueryVM> Result { get; set; }
        public string Search { get; set; }

        public SearchModel(IProductQuery productQuery) => _productQuery = productQuery;

        public void OnGet(string search)
        {
            Search = search;
            Result = _productQuery.Search(search);
        }
    }
}
