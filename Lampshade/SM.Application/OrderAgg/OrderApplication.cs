using Framework.Application;
using Framework.Application.Authentication;
using ShopManagement.Application.Contracts.OrderAgg;
using ShopManagement.Domain.OrderAgg;
using System.Collections.Generic;

namespace SM.Application.OrderAgg
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IAuthHelper _authHelper;
        private readonly IOrderRepository _orderRepository;

        public OrderApplication(IAuthHelper authHelper, IOrderRepository orderRepository)
        {
            _authHelper = authHelper;
            _orderRepository = orderRepository;
        }

        public long PlaceOrder(Cart cart)
        {
            var order = new Order(_authHelper.GetUserId(), cart.TotalPrice, cart.DiscountPrice, cart.PayAmount,cart.Address,cart.MobileNumber,OrderStatus.PreParation, cart.PaymentMethod);

            foreach (var item in cart.CartItems)
            {
                var orderItem = new OrderItem(item.Id, item.UnitPrice, item.DisocuntRate, item.Count);
                order.AddItem(orderItem);
            }

            _orderRepository.Create(order);
            _orderRepository.SaveChanges();

            return order.Id;
        }

        public IEnumerable<AdminOrderVM> GetAllForAdmin(SearchOrderVM search) => _orderRepository.GetAllForAdmin(search);

        public IEnumerable<AdminOrderItemVM> GetAllItemsForAdminBy(long orderId) => _orderRepository.GetAllItemsForAdminBy(orderId);

        public double GetOrderPriceBy(long orderId) => _orderRepository.Get(orderId).PayAmount;
    }
}
