﻿using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using Framework.Infrastructure;
using InventoryManagement.Application.Contract.InventoryAgg;
using InventoryManagement.Domain.InventoryAgg;
using ShopManagement.Infrastructure.EfCore;

namespace InventoryManagement.Infrastructure.EfCore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Inventory>, IInventoryRepository
    {
        private readonly InventoryContext _context;
        private readonly ShopContext _shopContext;

        public InventoryRepository(InventoryContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public IEnumerable<AdminInventoryVM> GetAllForAdmin(SearchInventoryVM search)
        {
            var products = _shopContext.Products.Select(p => new { p.Id, p.Name }).ToList();

            var query = _context.Inventories.Select(v => new AdminInventoryVM()
            {
                Id = v.Id,
                ProductId = v.ProductId,
                CreationDate = v.CreationTime.ToFarsi(),
                Price = v.Price,
                IsInStock = v.IsInStock,
                CurrentCount = v.CalculateStock()
            });

            if (search.ProductId > 0) query = query.Where(v => v.ProductId == search.ProductId);
            if (search.IsInStock) query = query.Where(v => !v.IsInStock);

            var inventories = query.ToList();

            inventories.ForEach(v => v.ProductName = products.FirstOrDefault(p => p.Id == v.ProductId)?.Name);

            return inventories;
        }

        public EditInventoryVM GetDetailForEdit(long id) => _context.Inventories.Select(v =>
            new EditInventoryVM()
            {
                Id = v.Id,
                Price = v.Price,
                ProductId = v.ProductId
            }).FirstOrDefault(v => v.Id == id);

        public DeleteInventoryVM GetDetailForDelete(long id)
        {
            var products = _shopContext.Products.Select(p => new { p.Id, p.Name }).ToList();

            var inventory = _context.Inventories.Select(v => new DeleteInventoryVM()
            {
                Id = v.Id,
                Price = v.Price,
                ProductId = v.ProductId
            }).FirstOrDefault(v => v.Id == id);

            if (inventory == null) return null;


            inventory.ProductName = products.FirstOrDefault(p => p.Id == inventory.ProductId)?.Name;
            return inventory;
        }

        public Inventory GetBy(long productId) => _context.Inventories.FirstOrDefault(i => i.ProductId == productId);
    }
}