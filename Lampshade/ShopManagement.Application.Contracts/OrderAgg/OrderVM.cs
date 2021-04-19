using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.OrderAgg
{

    public class DeleteOrderVM
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Fullname { get; set; }
        public double TotalPrice { get; set; }
    }

    public class AdminOrderVM
    {
        public long Id { get; set; }
        public long UserId { get;  set; }
        public string Fullname { get;  set; }
        public double TotalPrice { get;  set; }
        public double DiscountPrice { get;  set; }
        public double PayAmount { get;  set; }
        public long RefId { get;  set; }
        public string IssueTrackingNo { get;  set; }
        public bool IsPayed { get;  set; }
        public int Status { get; set; }
        public string StatusTitle { get;  set; }
        public int PaymentMethodId { get;  set; }
        public string PaymentMethod { get;  set; }
        public string CreationDate { get; set; }
    }

    public class SearchOrderVM
    {
        public long UserId { get; set; }
        public int Status { get; set; }
    }

    public class AdminOrderItemVM
    {
        public long ProductId { get;  set; }
        public string ProductName { get; set; }
        public double UnitPrice { get;  set; }
        public int DiscountRate { get;  set; }
        public int Count { get;  set; }
    }

    
}
