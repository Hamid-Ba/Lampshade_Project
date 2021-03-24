using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;
using InventoryManagement.Application.Contract.InventoryAgg;

namespace InventoryManagement.Domain.InventoryAgg
{
    public interface IInventoryRepository : IRepository<long,Inventory>
    {
        IEnumerable<AdminInventoryVM> GetAllForAdmin(SearchInventoryVM search);
        EditInventoryVM GetDetailForEdit(long id);
        DeleteInventoryVM GetDetailForDelete(long id);
        Inventory GetBy(long productId);
    }
}
