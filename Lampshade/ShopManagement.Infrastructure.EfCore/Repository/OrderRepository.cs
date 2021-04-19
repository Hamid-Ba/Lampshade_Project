using _0_Framework.Application;
using AccountManagement.Infrastructure.EfCore;
using Framework.Application;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.OrderAgg;
using ShopManagement.Domain.OrderAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class OrderRepository : RepositoryBase<long, Order>, IOrderRepository
    {
        private readonly ShopContext _shopContext;
        private readonly AccountContext _accountContext;

        public OrderRepository(ShopContext shopContext, AccountContext accountContext) : base(shopContext)
        {
            _shopContext = shopContext;
            _accountContext = accountContext;
        }

        public IEnumerable<AdminOrderVM> GetAllForAdmin(SearchOrderVM search)
        {
            var users = _accountContext.Users.Select(u => new { u.Id, u.Fullname }).ToList();

            var query = _shopContext.Orders.Select(o => new AdminOrderVM
            {
                Id = o.Id,
                DiscountPrice = o.DiscountPrice,
                IsPayed = o.IsPayed,
                IssueTrackingNo = o.IssueTrackingNo,
                PayAmount = o.PayAmount,
                RefId = o.RefId,
                TotalPrice = o.TotalPrice,
                UserId = o.UserId,
                Status = o.Status,
                PaymentMethodId = o.PaymentMethod,
                CreationDate = o.CreationTime.ToFarsi()
            }).OrderByDescending(o => o.Id).AsNoTracking();

            if (search.UserId > 0) query = query.Where(o => o.UserId == search.UserId);
            if (search.Status > 0) query = query.Where(o => o.Status == search.Status);

            var orders = query.ToList();

            orders.ForEach(o => o.PaymentMethod = o.PaymentMethodId == PaymentMethod.Online ? "پرداخت اینترنتی" : "پرداخت نقدی");
            orders.ForEach(o => o.Fullname = users.FirstOrDefault(u => u.Id == o.Id)?.Fullname);

            foreach (var order in orders)
            {
                switch (order.Status)
                {
                    case OrderStatus.Transaction:
                        order.StatusTitle = "در حال انجام تراکنش";
                        break;
                    case OrderStatus.PreParation:
                        order.StatusTitle = "آماده سازی";
                        break;
                    case OrderStatus.Dispatching:
                        order.StatusTitle = "در حال ارسال";
                        break;
                    case OrderStatus.AgentDelivary:
                        order.StatusTitle = "تحویل پست";
                        break;
                    case OrderStatus.CustomerDelivary:
                        order.StatusTitle = "تحویل داده شد";
                        break;
                }
            }

            return orders;
        }

        public IEnumerable<AdminOrderItemVM> GetAllItemsForAdminBy(long orderId)
        {
            var products = _shopContext.Products.Select(p => new { p.Id, p.Name }).ToList();

            var order = _shopContext.Find<Order>(orderId);

            var items = order.OrderItems.Select(o => new AdminOrderItemVM
            {
                ProductId = o.ProductId,
                Count = o.Count,
                DiscountRate = o.DiscountRate,
                UnitPrice = o.UnitPrice
            }).ToList();

            items.ForEach(o => o.ProductName = products.FirstOrDefault(p => p.Id == o.ProductId)?.Name);

            return items;
        }

        public DeleteOrderVM GetDetailForDelete(long orderId)
        {
            var users = _accountContext.Users.Select(u => new { u.Id, u.Fullname }).ToList();

            var result = _shopContext.Orders.Select(o => new DeleteOrderVM
            {
                Id = o.Id,
                TotalPrice = o.TotalPrice,
                UserId = o.UserId
            }).AsNoTracking().FirstOrDefault(o => o.Id == orderId);

            result.Fullname = users.FirstOrDefault(u => u.Id == result.UserId)?.Fullname;

            return result;
        }
    }
}
