using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;
using InventoryManagement.Application.Contract.InventoryAgg;
using InventoryManagement.Domain.InventoryAgg;

namespace InventoryManagement.Application.InventoryAgg
{
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IInventoryRepository _inventoryRepository;
        public InventoryApplication(IInventoryRepository inventoryRepository) => _inventoryRepository = inventoryRepository;

        public OperationResult Create(CreateInventoryVM command)
        {
            OperationResult result = new OperationResult();

            if (_inventoryRepository.IsExist(i => i.ProductId == command.ProductId && i.Price == command.Price))
                return result.Failed(ValidateMessage.IsDuplicated);

            var inventory = new Inventory(command.ProductId, command.Price);

            _inventoryRepository.Create(inventory);
            _inventoryRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Edit(EditInventoryVM command)
        {
            OperationResult result = new OperationResult();

            if (_inventoryRepository.IsExist(i => i.ProductId == command.ProductId && i.Price == command.Price && i.Id != command.Id))
                return result.Failed(ValidateMessage.IsDuplicated);

            var inventory = _inventoryRepository.Get(command.Id);

            if (inventory == null) return result.Failed(ValidateMessage.IsExist);

            inventory.Edit(command.ProductId, command.Price);
            _inventoryRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Delete(DeleteInventoryVM command)
        {
            OperationResult result = new OperationResult();

            var inventory = _inventoryRepository.Get(command.Id);

            if (inventory == null) return result.Failed(ValidateMessage.IsExist);

            inventory.Delete();
            _inventoryRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Increase(IncreaseInventoryVM command)
        {
            OperationResult result = new OperationResult();

            var inventory = _inventoryRepository.Get(command.InventoryId);

            if (inventory == null) return result.Failed(ValidateMessage.IsExist);

            //ToDo OperatorId
            var operatorId = 1;
            inventory.Increase(command.Count, operatorId, command.Description);
            _inventoryRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Decrease(DecreaseInventoryVM command)
        {
            OperationResult result = new OperationResult();

            var inventory = _inventoryRepository.Get(command.Id);

            if (inventory == null) return result.Failed(ValidateMessage.IsExist);

            //ToDo OperatorId
            var operatorId = 1;
            inventory.Decrease(command.Count, operatorId, command.OrderId, command.Description);
            _inventoryRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Decrease(List<DecreaseInventoryVM> commands)
        {
            OperationResult result = new OperationResult();

            //ToDo OperatorId
            var operatorId = 1;

            foreach (var item in commands)
            {
                var inventory = _inventoryRepository.GetBy(item.ProductId);

                if (inventory == null) return result.Failed(ValidateMessage.IsExist);

                inventory.Decrease(item.Count, operatorId, item.OrderId, item.Description);
            }

            _inventoryRepository.SaveChanges();

            return result.Succeeded();
        }

        public IEnumerable<AdminInventoryVM> GetAllForAdmin(SearchInventoryVM search) => _inventoryRepository.GetAllForAdmin(search);

        public EditInventoryVM GetDetailForEdit(long id) => _inventoryRepository.GetDetailForEdit(id);

        public DeleteInventoryVM GetDetailForDelete(long id) => _inventoryRepository.GetDetailForDelete(id);

        public IEnumerable<InventoryOperationsVM> GetAllOperations(long inventoryId) => _inventoryRepository.GetAllOperations(inventoryId);
    }
}