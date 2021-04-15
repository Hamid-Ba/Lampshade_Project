using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contracts.OrderAgg;


namespace ServiceHost.Pages
{
    public class CartModel : PageModel
    {
        private const string CookieName = "cart-items";
        public IEnumerable<CartItemVM> CartItems { get; set; }

        public IActionResult OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];

            var cartItems = serializer.Deserialize<List<CartItemVM>>(value);

            if (cartItems.Count > 0)
            {
                cartItems.ForEach(c => c.CalculateTotalPrice());

                CartItems = cartItems;
                return Page();
            }

            return RedirectToPage("Index");
        }

        public IActionResult OnGetRemoveCartItem(long id)
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];

            Response.Cookies.Delete(CookieName);

            var cartItems = serializer.Deserialize<List<CartItemVM>>(value);
            var removedCart = cartItems.Find(c => c.Id == id);

            cartItems.Remove(removedCart);

            var result = serializer.Serialize(cartItems);

            Response.Cookies.Append(CookieName, result, new Microsoft.AspNetCore.Http.CookieOptions { Expires = DateTime.Now.AddDays(2) });

            return RedirectToPage("Cart");
        }
    }
}
