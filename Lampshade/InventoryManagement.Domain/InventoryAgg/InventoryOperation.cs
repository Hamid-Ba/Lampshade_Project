using System;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class InventoryOperation
    {
        public long Id { get; private set; }
        public long InventoryId { get; private set; }
        public bool Operation { get; private set; }
        public long Count { get; private set; }
        public long CurrentCount { get; private set; }
        public long OrderId { get; private set; }
        public long OperatorId { get; private set; }
        public DateTime OperationDate { get; private set; }
        public string Description { get; private set; }
        
        public Inventory Inventory { get; private set; }

        public InventoryOperation(long inventoryId, bool operation, long count, long currentCount, long orderId, long operatorId, string description)
        {
            InventoryId = inventoryId;
            Operation = operation;
            Count = count;
            CurrentCount = currentCount;
            OrderId = orderId;
            OperatorId = operatorId;
            OperationDate = DateTime.Now;
            Description = description;
        }
    }
}