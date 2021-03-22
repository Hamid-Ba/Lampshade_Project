using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountManagement.Application.Contract.CustomerDiscountAgg;
using Framework.Domain;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public interface ICustomerDiscountRepository : IRepository<long,CustomerDiscount>
    {
        IEnumerable<AdminCustomerDiscountVM> GetAllForAdmin(SearchCustomerDiscountVM search);
        EditCustomerDiscountVM GetDetailForEdit(long id);
        DeleteCustomerDiscountVM GetDetailForDelete(long id);
    }
}
