using System.Collections.Generic;
using System.Linq;
using Framework.Application;
using Framework.Application.ZarinPal;
using LampshadeQuery.Contract.Cart;
using LampshadeQuery.Contract.Product;
using LampshadeQuery.Contract.User;
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

        private readonly IUserQuery _userQuery;
        private readonly ICartService _cartService;
        private readonly IProductQuery _productQuery;
        private readonly ICalculateCart _calculateCart;
        private readonly IZarinPalFactory _zarinPalFactory;
        private readonly IOrderApplication _orderApplication;

        public Cart Cart { get; set; }

        [BindProperty]
        public string Message { get; set; }

        public CheckoutModel(IUserQuery userQuery, ICartService cartService, IProductQuery productQuery, ICalculateCart calculateCart, IZarinPalFactory zarinPalFactory, IOrderApplication orderApplication)
        {
            _userQuery = userQuery;
            _cartService = cartService;
            _productQuery = productQuery;
            _calculateCart = calculateCart;
            _zarinPalFactory = zarinPalFactory;
            _orderApplication = orderApplication;
        }

        public IActionResult OnGet(string message)
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];

            var cartItems = _productQuery.CheckIsInStock(serializer.Deserialize<List<CartItem>>(value));

            if (cartItems.Any(i => !i.IsInStock)) return RedirectToPage("Cart");

            foreach (var item in cartItems) item.CalculateTotalPrice();

            Cart = _calculateCart.ComputeCart(User.Identity.Name, cartItems);
            _cartService.SetCart(Cart);

            Message = message;

            return Page();
        }

        public IActionResult OnPostPay(int paymentMethod,string address,string phoneNumber)
        {
            if (string.IsNullOrEmpty(address) || string.IsNullOrEmpty(phoneNumber))
            {
                long number;
                if (string.IsNullOrEmpty(address)) Message = "آدرس خود را مشخص نمایید";
                if (string.IsNullOrEmpty(phoneNumber) || !phoneNumber.StartsWith("09") || !long.TryParse(phoneNumber,out number) || phoneNumber.Length != 11) Message = "شماره موبایل خود را وارد نمایید";
                return RedirectToPage("Checkout",new { message = Message });
            }

            Cart = _cartService.GetCart();

            if (Cart.CartItems.Any(c => !c.IsInStock)) return RedirectToPage("Cart");
            Cart.SetPaymentMethod(paymentMethod);
            Cart.Address = address;
            Cart.MobileNumber = phoneNumber;

            var user = _userQuery.GetUserBy(User.Identity.Name);
            var orderId = _orderApplication.PlaceOrder(Cart);

            if (paymentMethod == PaymentMethod.Online)
            {
                var paymentResponse = _zarinPalFactory.CreatePaymentRequest(Cart.PayAmount.ToString(), user.Mobile, user.Email, "خرید محصول", orderId);
                return Redirect(
                    $"https://{_zarinPalFactory.Prefix}.zarinpal.com/pg/StartPay/{paymentResponse.Authority}");
            }

            OperationResult result = new OperationResult();
            result.Succeeded("سفارش شما ثبت گردید ، جهت ارسال محصول ، همکاران ما با شما تماس خواهند گرفت!");

            return RedirectToPage("PaymentResult", result);
        }

        public IActionResult OnGetCallBack([FromQuery] string authority, [FromQuery] string status,
            [FromQuery] long oId)
        {
            var verificationResponse = _zarinPalFactory.CreateVerificationRequest(authority, _orderApplication.GetOrderPriceBy(oId).ToString());

            if (verificationResponse.Status == 100 && status.ToLower() == "ok")
            {
                var issueTrackingNo = _orderApplication.PaymentSuccedded(oId, verificationResponse.RefID);
                Response.Cookies.Delete(CookieName);
            }

            return null;
        }
    }
}
