using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;

namespace DiscountManagement.Application.Contract.ColleagueDiscountAgg
{
    public interface IColleagueDiscountApplication
    {
        OperationResult Create(CreateColleagueDiscountVM command);
        OperationResult Edit(EditColleagueDiscountVM command);
        OperationResult Delete(DeleteColleagueDiscountVM command);
        EditColleagueDiscountVM GetDetailForEdit(long id);
        DeleteColleagueDiscountVM GetDetailForDelete(long id);
        IEnumerable<AdminColleagueDiscountVM> GetAllForAdmin(SearchColleagueDiscountVM search);
    }
}
