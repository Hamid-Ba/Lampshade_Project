using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LampshadeQuery.Contract.Product;

namespace ServiceHost.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductQuery _productQuery;

        public IEnumerable<ProductQueryVM> GetLatestArrival { get; set; }

        public IndexModel(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public void OnGet()
        {
            GetLatestArrival = _productQuery.GetLatestArrival(6);
        }
    }
}
