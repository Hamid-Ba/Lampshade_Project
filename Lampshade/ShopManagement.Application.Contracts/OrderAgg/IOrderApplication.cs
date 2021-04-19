using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.OrderAgg
{
    public interface IOrderApplication
    {
        long PlaceOrder(Cart cart);
        string PaymentSuccedded(long orderId, long refId);
        string CreateCashOrderOperation(long orderId);
        OperationResult MakePaymentSuccedded(long orderId);
        OperationResult Delete(DeleteOrderVM command);
        OperationResult ChangeStatus(ChangeStatusOrderVM command);
        DeleteOrderVM GetDetailForDelete(long orderId);
        ChangeStatusOrderVM GetDetailForChangeStatus(long orderId);
        DetailCustomerOrderVM GetDetailOfOrderCustomer(long orderId);
        IEnumerable<AdminOrderVM> GetAllForAdmin(SearchOrderVM search);
        IEnumerable<AdminOrderItemVM> GetAllItemsForAdminBy(long orderId);
        double GetOrderPriceBy(long orderId);
    }
}
