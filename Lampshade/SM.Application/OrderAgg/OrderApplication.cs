using Framework.Application;
using Framework.Application.Authentication;
using Microsoft.Extensions.Configuration;
using ShopManagement.Application.Contracts.OrderAgg;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.Service;
using System.Collections.Generic;

namespace SM.Application.OrderAgg
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IAuthHelper _authHelper;
        private readonly IConfiguration _configuration;
        private readonly IOrderRepository _orderRepository;
        private readonly IShopInventoryACL _shopInventoryACL;

        public OrderApplication(IAuthHelper authHelper,IConfiguration configuration, IOrderRepository orderRepository,IShopInventoryACL shopInventoryACL)
        {
            _authHelper = authHelper;
            _configuration = configuration;
            _orderRepository = orderRepository;
            _shopInventoryACL = shopInventoryACL;
        }

        public long PlaceOrder(Cart cart)
        {
            var order = new Order(_authHelper.GetUserId(), cart.TotalPrice, cart.DiscountPrice, cart.PayAmount,cart.Address,cart.MobileNumber,OrderStatus.Transaction, cart.PaymentMethod);

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

        public string PaymentSuccedded(long orderId, long refId)
        {
            var order = _orderRepository.Get(orderId);

            if(order != null)
            {
                order.PaymentSuccedded(refId);
                
                var issueTrackingNo = CodeGenerator.Generate(_configuration.GetSection("Symbol").Value);
                order.SetIssueTrackingNo(issueTrackingNo);
                order.SetOrderStatus(OrderStatus.PreParation);

                if(!_shopInventoryACL.ReduceFromInventory(order.OrderItems)) return "";

                _orderRepository.SaveChanges();

                return issueTrackingNo;
            }

            return "";
        }
    }
}
