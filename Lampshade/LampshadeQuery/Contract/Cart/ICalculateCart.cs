using ShopManagement.Application.Contracts.OrderAgg;
using System.Collections.Generic;

namespace LampshadeQuery.Contract.Cart
{
    public interface ICalculateCart
    {
        ShopManagement.Application.Contracts.OrderAgg.Cart ComputeCart(string userName,IEnumerable<CartItem> cartItems);
    }
}
