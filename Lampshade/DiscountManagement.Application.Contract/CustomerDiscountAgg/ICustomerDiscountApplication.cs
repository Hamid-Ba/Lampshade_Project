using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;

namespace DiscountManagement.Application.Contract.CustomerDiscountAgg
{
    public interface ICustomerDiscountApplication
    {
        OperationResult Create(CreateCustomerDiscountVM command);
        OperationResult Edit(EditCustomerDiscountVM command);
        OperationResult Delete(DeleteCustomerDiscountVM command);
        IEnumerable<AdminCustomerDiscountVM> GetAllForAdmin(SearchCustomerDiscountVM search);
        EditCustomerDiscountVM GetDetailForEdit(long id);
        DeleteCustomerDiscountVM GetDetailForDelete(long id);
    }
}
