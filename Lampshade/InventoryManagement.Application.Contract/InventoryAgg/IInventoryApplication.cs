using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;

namespace InventoryManagement.Application.Contract.InventoryAgg
{
    public interface IInventoryApplication
    {
        OperationResult Create(CreateInventoryVM command);
        OperationResult Edit(EditInventoryVM command);
        OperationResult Delete(DeleteInventoryVM command);
        OperationResult Increase(IncreaseInventoryVM command);
        OperationResult Decrease(DecreaseInventoryVM command);
        OperationResult Decrease(List<DecreaseInventoryVM> commands);
        IEnumerable<AdminInventoryVM> GetAllForAdmin(SearchInventoryVM search);
        EditInventoryVM GetDetailForEdit(long id);
        DeleteInventoryVM GetDetailForDelete(long id);
        IEnumerable<InventoryOperationsVM> GetAllOperations(long inventoryId);
    }
}
