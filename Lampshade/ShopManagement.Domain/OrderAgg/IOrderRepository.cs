using Framework.Domain;
using ShopManagement.Application.Contracts.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.OrderAgg
{
    public interface IOrderRepository : IRepository<long, Order>
    {
        IEnumerable<AdminOrderVM> GetAllForAdmin(SearchOrderVM search);
        IEnumerable<AdminOrderItemVM> GetAllItemsForAdminBy(long orderId);
    }
}
