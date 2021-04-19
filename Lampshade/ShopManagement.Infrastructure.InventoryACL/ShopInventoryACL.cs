using InventoryManagement.Application.Contract.InventoryAgg;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.InventoryACL
{
    public class ShopInventoryACL : IShopInventoryACL
    {
        private readonly IInventoryApplication _inventoryApplication;

        public ShopInventoryACL(IInventoryApplication inventoryApplication) => _inventoryApplication = inventoryApplication;

        public bool ReduceFromInventory(IEnumerable<OrderItem> orderItems)
        {
            var commands = orderItems.Select(o => new DecreaseInventoryVM
            {
                ProductId = o.ProductId,
                Count = o.Count,
                OrderId = o.OrderId,
                Description = "خرید محصول"
            }).ToList();

           return _inventoryApplication.Decrease(commands).IsSucceeded;
        }
    }
}
