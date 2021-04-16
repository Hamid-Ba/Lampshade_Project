using AccountManagement.Application.Contract.UserAgg;
using DiscountManagement.Infrastructure.EfCore;
using LampshadeQuery.Contract.Cart;
using ShopManagement.Application.Contracts.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LampshadeQuery.Query
{
    public class CalculateCart : ICalculateCart
    {
        private readonly DiscountContext _discountContext;
        private readonly IUserApplication _userApplication;

        public CalculateCart(DiscountContext discountContext, IUserApplication userApplication)
        {
            _discountContext = discountContext;
            _userApplication = userApplication;
        }

        public Cart ComputeCart(string userName, IEnumerable<CartItem> cartItems)
        {
            Cart cart = new();
            int discountRate;
            bool isColleague = _userApplication.IsColleague(userName);

            foreach (var item in cartItems)
            {
                discountRate = 0;

                if (isColleague)
                {
                    if (_discountContext.ColleagueDiscounts.Any(c => c.ProductId == item.Id))
                        discountRate = _discountContext.ColleagueDiscounts.FirstOrDefault(c => c.ProductId == item.Id).DiscountRate;
                }

                else
                {
                    if (_discountContext.CustomerDiscounts.Any(c => c.ProductId == item.Id && DateTime.Now <= c.EndDate))
                        discountRate = _discountContext.CustomerDiscounts.FirstOrDefault(c => c.ProductId == item.Id && DateTime.Now <= c.EndDate).DiscountRate;
                }

                if (discountRate > 0)
                {
                    item.DisocuntRate = discountRate;
                    item.DiscountPrice = (item.TotalPrice * discountRate) / 100;
                }

                item.PayAmount = item.TotalPrice - item.DiscountPrice;
                cart.Add(item);
            }

            return cart;
        }
    }
}
