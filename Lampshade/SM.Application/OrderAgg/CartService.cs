using ShopManagement.Application.Contracts.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Application.OrderAgg
{
    public class CartService : ICartService
    {
        private Cart cart;

        public Cart GetCart() => cart;

        public void SetCart(Cart cart) => this.cart = cart;

    }
}
