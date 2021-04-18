using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.OrderAgg
{
    public interface ICartService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}
