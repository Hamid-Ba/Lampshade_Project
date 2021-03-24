using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountManagement.Application.Contract.ColleagueDiscountAgg;
using Framework.Domain;

namespace DiscountManagement.Domain.ColleagueDiscountAgg
{
    public interface IColleagueDiscountRepository : IRepository<long,ColleagueDiscount>
    {
        EditColleagueDiscountVM GetDetailForEdit(long id);
        DeleteColleagueDiscountVM GetDetailForDelete(long id);
        IEnumerable<AdminColleagueDiscountVM> GetAllForAdmin(SearchColleagueDiscountVM search);
    }
}
