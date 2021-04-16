using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.OrderAgg
{
    public class Cart
    {
        public double TotalPrice { get; set; }
        public double DiscountPrice { get; set; }
        public double PayAmount { get; set; }

        public List<CartItem> CartItems { get; set; }

        public Cart() => CartItems = new List<CartItem>();
        
        public void Add(CartItem item)
        {
            CartItems.Add(item);

            TotalPrice += item.TotalPrice;
            DiscountPrice += item.DiscountPrice;
            PayAmount += item.PayAmount;
        }
    }
}
