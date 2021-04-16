using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LampshadeQuery.Contract.Cart;
using LampshadeQuery.Contract.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contracts.OrderAgg;

namespace ServiceHost.Pages
{
    [Authorize]
    public class CheckoutModel : PageModel
    {
        private const string CookieName = "cart-items";

        private readonly IProductQuery _productQuery;
        private readonly ICalculateCart _calculateCart;

        public Cart Cart { get; set; }

        public CheckoutModel(IProductQuery productQuery, ICalculateCart calculateCart)
        {
            _productQuery = productQuery;
            _calculateCart = calculateCart;
        }

        public IActionResult OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];

            var cartItems = _productQuery.CheckIsInStock(serializer.Deserialize<List<CartItem>>(value));

            if (cartItems.Any(i => !i.IsInStock)) return RedirectToPage("Cart");

            Cart = _calculateCart.ComputeCart(User.Identity.Name, cartItems);

            return Page();
        }
    }
}
