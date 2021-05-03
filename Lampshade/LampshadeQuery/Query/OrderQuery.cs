using AccountManagement.Infrastructure.EfCore;
using Framework.Application;
using LampshadeQuery.Contract.Order;
using ShopManagement.Infrastructure.EfCore;
using System.Collections.Generic;
using System.Linq;

namespace LampshadeQuery.Query
{
    public class OrderQuery : IOrderQuery
    {
        private readonly ShopContext _shopContext;
        private readonly AccountContext _accountContext;

        public OrderQuery(ShopContext shopContext, AccountContext accountContext)
        {
            _shopContext = shopContext;
            _accountContext = accountContext;
        }

        public IEnumerable<(int, string)> GetUserOrdersStatusBy(string userName)
        {
            var userId = _accountContext.Users.FirstOrDefault(u => u.Username.ToLower() == userName.ToLower()).Id;
            var ordersStatus = _shopContext.Orders.Where(o => o.UserId == userId).Select(o => new { o.Status }).ToList();

            List<(int, string)> result = new List<(int, string)>();

            foreach (var status in ordersStatus)
            {
                switch (status.Status)
                {
                    case OrderStatus.Transaction:
                        result.Add(new(20, "در حال پردازش"));
                        break;

                    case OrderStatus.PreParation:
                        result.Add(new(40, "درحال آماده سازی"));
                        break;

                    case OrderStatus.Dispatching:
                        result.Add(new(60, "خروج از مرکز پردازش"));
                        break;

                    case OrderStatus.AgentDelivary:
                        result.Add(new(80, "تحویل مامور پست"));
                        break;

                    case OrderStatus.CustomerDelivary:
                        result.Add(new(100, "تحویل مرسوله به مشتری"));
                        break;
                }
            }

            return result;
        }
    }
}
