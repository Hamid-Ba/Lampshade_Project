using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Configuration
{
    public static class InventoryPermissions
    {
        public static int InventoryManagement { get; private set; } = 12;
        public static int CreateInventory { get; private set; } = 33;
        public static int EditInventory { get; private set; } = 34;
        public static int Increase { get; private set; } = 35;
        public static int Decrease { get; private set; } = 36;
        public static int InventoryOperations { get; private set; } = 37;
        public static int DeleteInventory { get; private set; } = 38;
    }
}
