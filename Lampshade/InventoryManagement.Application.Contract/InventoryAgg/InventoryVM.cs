using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contract.InventoryAgg
{
    public class CreateInventoryVM
    {
        public long ProductId { get; set; }
        public double Price { get; set; }
    }

    public class EditInventoryVM : CreateInventoryVM
    {
        public long Id { get; set; }
    }

    public class DeleteInventoryVM : EditInventoryVM
    {
        public string ProductName { get; set; }
    }

    public class AdminInventoryVM : DeleteInventoryVM
    {
        public string CreationDate { get; set; }
        public long CurrentCount { get; set; }
        public bool IsInStock { get; set; }
    }

    public class SearchInventoryVM
    {
        public long ProductId { get; set; }
        public bool IsInStock { get; set; }
    }

    public class IncreaseInventoryVM
    {
        public long InventoryId { get; set; }
        public long Count { get; set; }
        public string Description { get; set; }
    }

    public class DecreaseInventoryVM
    {
        public long ProductId { get; set; }
        public long Count { get; set; }
        public long OrderId { get; set; }
        public string Description { get; set; }
    }

}
