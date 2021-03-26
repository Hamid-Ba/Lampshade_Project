using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory : EntityBaseModel
    {
        public long ProductId { get; private set; }
        public double Price { get; private set; }
        public bool IsInStock { get; private set; }

        public List<InventoryOperation> InventoryOperations { get; private set; }

        public Inventory(long productId, double price)
        {
            ProductId = productId;
            Price = price;
            IsInStock = false;
        }

        public void Edit(long productId, double price)
        {
            ProductId = productId;
            Price = price;
        }

        public void Delete() => IsDeleted = true;

        public long CalculateStock()
        {
            var plus = InventoryOperations.Where(o => o.Operation).Sum(o => o.Count);
            var minus = InventoryOperations.Where(o => !o.Operation).Sum(o => o.Count);

            return plus - minus;
        }

        public void Increase(long count, long operatorId, string description)
        {
            var currentCount = CalculateStock() + count;

            var operation = new InventoryOperation(Id, true, count, currentCount, 0, operatorId,
                description);
            InventoryOperations.Add(operation);

            IsInStock = currentCount > 0;
        }

        public void Decrease(long count, long operatorId, long orderId, string description)
        {
            var currentCount = CalculateStock() - count;

            var operation = new InventoryOperation(Id, false, count, currentCount, orderId, operatorId,
                description);
            InventoryOperations.Add(operation);

            IsInStock = currentCount > 0;

        }
    }
}
