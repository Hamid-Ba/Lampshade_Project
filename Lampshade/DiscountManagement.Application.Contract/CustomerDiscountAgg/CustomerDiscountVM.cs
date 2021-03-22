using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;

namespace DiscountManagement.Application.Contract.CustomerDiscountAgg
{
    public class CreateCustomerDiscountVM
    {
        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public long ProductId { get; set; }

        [Range(0,100,ErrorMessage = ValidateMessage.IsRequired)]
        public int DiscountRate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Reason { get; set; }
    }

    public class EditCustomerDiscountVM : CreateCustomerDiscountVM
    {
        public long Id { get; set; }
    }

    public class DeleteCustomerDiscountVM
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int DiscountRate { get; set; }
    }

    public class AdminCustomerDiscountVM : EditCustomerDiscountVM
    {
        public string ProductName { get; set; }
        public DateTime StartDateGr { get; set; }
        public DateTime EndDateGr { get; set; }
        public string CreationDate { get; set; }
    }

    public class SearchCustomerDiscountVM
    {
        public long ProductId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}

