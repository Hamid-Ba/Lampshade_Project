using ShopManagement.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.Service
{
    public interface IShopInventoryACL
    {
        bool ReduceFromInventory(IEnumerable<OrderItem> orderItems);
    }
}
