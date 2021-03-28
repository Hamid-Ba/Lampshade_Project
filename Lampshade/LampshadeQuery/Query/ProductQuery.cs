using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using DiscountManagement.Infrastructure.EfCore;
using InventoryManagement.Infrastructure.EfCore;
using LampshadeQuery.Contract.Category;
using LampshadeQuery.Contract.Product;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EfCore;

namespace LampshadeQuery.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext _context;
        private readonly DiscountContext _discountContext;
        private readonly InventoryContext _inventoryContext;

        public ProductQuery(ShopContext context, DiscountContext discountContext, InventoryContext inventoryContext)
        {
            _context = context;
            _discountContext = discountContext;
            _inventoryContext = inventoryContext;
        }

        public IEnumerable<ProductQueryVM> GetLatestArrival(int count)
        {
            var discount = _discountContext.CustomerDiscounts
                .Where(c => c.StartDate < DateTime.Now && DateTime.Now < c.EndDate)
                .Select(c => new { c.ProductId, c.DiscountRate }).ToList();

            var inventory = _inventoryContext.Inventories.Select(i => new { i.ProductId, i.Price }).ToList();

            var products = _context.Products.Include(p => p.Category)
                .Select(p => new ProductQueryVM()
                {
                    Id = p.Id,
                    CategoryName = p.Category.Name,
                    Name = p.Name,
                    Picture = p.Picture,
                    PictureAlt = p.PictureAlt,
                    PictureTitle = p.PictureTitle,
                    Slug = p.Slug,
                    CategoryId = p.CategoryId,
                    CategorySlug = p.Category.Slug
                }).AsNoTracking().OrderByDescending(p => p.Id).Take(count).ToList();

            foreach (var product in products)
            {
                product.HasDiscount = discount.Exists(d => d.ProductId == product.Id);

                if (!inventory.Exists(p => p.ProductId == product.Id)) continue;

                // ReSharper disable once PossibleNullReferenceException
                var price = inventory.Find(i => i.ProductId == product.Id).Price;

                product.Price = price.ToMoney();

                if (!product.HasDiscount) continue;

                // ReSharper disable once PossibleNullReferenceException
                product.DiscountRate = discount.Find(p => p.ProductId == product.Id).DiscountRate;

                var discountRate = product.DiscountRate;
                var discountMoney = Math.Round(price * discountRate) / 100;

                product.PriceWithDiscount = (price - discountMoney).ToMoney();

            }

            return products;
        }

        public IEnumerable<ProductQueryVM> Search(string search)
        {
            var discount = _discountContext.CustomerDiscounts
                .Where(c => c.StartDate < DateTime.Now && DateTime.Now < c.EndDate)
                .Select(c => new { c.ProductId, c.DiscountRate, c.EndDate }).ToList();

            var inventory = _inventoryContext.Inventories.Select(i => new { i.ProductId, i.Price }).ToList();

            var products = _context.Products.Where(p => p.Name.Contains(search) || p.ShortDescription.Contains(search))
                .Include(p => p.Category)
                .Select(p => new ProductQueryVM()
                {
                    Id = p.Id,
                    CategoryName = p.Category.Name,
                    Name = p.Name,
                    Picture = p.Picture,
                    PictureAlt = p.PictureAlt,
                    PictureTitle = p.PictureTitle,
                    Slug = p.Slug,
                    CategoryId = p.CategoryId,
                    CategorySlug = p.Category.Slug
                }).AsNoTracking().ToList();


            foreach (var product in products)
            {
                product.HasDiscount = discount.Exists(d => d.ProductId == product.Id);

                if (!inventory.Exists(p => p.ProductId == product.Id)) continue;

                // ReSharper disable once PossibleNullReferenceException
                var price = inventory.Find(i => i.ProductId == product.Id).Price;

                product.Price = price.ToMoney();

                if (!product.HasDiscount) continue;

                // ReSharper disable once PossibleNullReferenceException
                product.DiscountRate = discount.Find(p => p.ProductId == product.Id).DiscountRate;

                var discountRate = product.DiscountRate;
                var discountMoney = Math.Round(price * discountRate) / 100;

                product.PriceWithDiscount = (price - discountMoney).ToMoney();
                product.DiscountExpired = discount.Find(d => d.ProductId == product.Id)?.EndDate.ToDiscountFormat();
            }

            return products;
        }
    }
}