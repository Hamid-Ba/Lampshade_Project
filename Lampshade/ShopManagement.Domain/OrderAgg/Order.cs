using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.OrderAgg
{
    public class Order : EntityBaseModel
    {
        public long UserId { get; private set; }
        public double TotalPrice { get; private set; }
        public double DiscountPrice { get; private set; }
        public double PayAmount { get; private set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public long RefId { get; private set; }
        public string IssueTrackingNo { get; private set; }
        public bool IsPayed { get; private set; }
        public int Status { get; private set; }
        public int PaymentMethod { get; private set; }

        public List<OrderItem> OrderItems { get; private set; }

        public Order(long userId, double totalPrice, double discountPrice, double payAmount,string address,string mobileNumber, int status, int paymentMethod)
        {
            UserId = userId;
            TotalPrice = totalPrice;
            DiscountPrice = discountPrice;
            PayAmount = payAmount;
            Address = address;
            MobileNumber = mobileNumber;
            IsPayed = false;
            Status = status;
            PaymentMethod = paymentMethod;
            OrderItems = new List<OrderItem>();
        }

        public void PaymentSuccedded(long refId)
        {
            if (refId > 0) RefId = refId;
            IsPayed = true;
        }

        public void SetIssueTrackingNo(string issueTrackingNo) => IssueTrackingNo = issueTrackingNo;

        public void SetOrderStatus(int status) => Status = status;

        public void AddItem(OrderItem item) => OrderItems.Add(item);
    }
}
