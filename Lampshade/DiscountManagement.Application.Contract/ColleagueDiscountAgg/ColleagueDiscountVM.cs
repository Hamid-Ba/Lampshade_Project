using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contract.ColleagueDiscountAgg
{
    public class CreateColleagueDiscountVM
    {
        public long ProductId { get; set; }
        public int DiscountRate { get; set; }
    }

    public class EditColleagueDiscountVM : CreateColleagueDiscountVM
    {
        public long Id { get; set; }
    }

    public class DeleteColleagueDiscountVM : EditColleagueDiscountVM
    {
        public string ProductName { get; set; }
    }

    public class AdminColleagueDiscountVM : DeleteColleagueDiscountVM
    {
        public string CreationDate { get; set; }
    }

    public class SearchColleagueDiscountVM
    {
        public long ProductId { get; set; }
    }
}
