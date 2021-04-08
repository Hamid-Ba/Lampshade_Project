using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using DiscountManagement.Infrastructure.EfCore;
using InventoryManagement.Infrastructure.EfCore;
using LampshadeQuery.Contract.Category;
using LampshadeQuery.Contract.Product;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.EfCore;

namespace LampshadeQuery.Query
{
    public class CategoryQuery : ICategoryQuery
    {
        private readonly ShopContext _context;
        private readonly DiscountContext _discountContext;
        private readonly InventoryContext _inventoryContext;

        public CategoryQuery(ShopContext context, DiscountContext discountContext, InventoryContext inventoryContext)
        {
            _context = context;
            _discountContext = discountContext;
            _inventoryContext = inventoryContext;
        }

        public IEnumerable<CategoryQueryVM> GetAllCategory() => _context.ProductCategories.Select(c =>
            new CategoryQueryVM()
            {
                Description = c.Description,
                Name = c.Name,
                Picture = c.Picture,
                PictureAlt = c.PictureAlt,
                PictureTitle = c.PictureTitle,
                Slug = c.Slug
            }).ToList();

        public IEnumerable<CategoryWithProductsQueryVM> GetCategoryWithProducts()
        {
            var discount = _discountContext.CustomerDiscounts
                .Where(c => c.StartDate < DateTime.Now && DateTime.Now < c.EndDate)
                .Select(c => new { c.ProductId, c.DiscountRate }).ToList();

            var inventory = _inventoryContext.Inventories.Select(i => new { i.ProductId, i.Price }).ToList();

            var categories = _context.ProductCategories.Include(p => p.Products)
                .ThenInclude(c => c.Category).Select(c => new CategoryWithProductsQueryVM()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Slug = c.Slug,
                    KeyWords = c.KeyWords,
                    MetaDescription = c.MetaDescription,
                    Products = MapProduct(c.Products, 4)
                }).ToList();

            foreach (var category in categories)
            {
                foreach (var product in category.Products)
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
            }

            return categories;
        }

        public IEnumerable<CategoryQueryVM> GetAllProductCategoriesForMenu() => _context.ProductCategories.Select(c =>
            new CategoryQueryVM
            {
                Name = c.Name,
                Slug = c.Slug
            }).ToList();

        public CategoryWithProductsQueryVM GetCategoryAndProductsBy(string slug)
        {
            var discount = _discountContext.CustomerDiscounts
                .Where(c => c.StartDate < DateTime.Now && DateTime.Now < c.EndDate)
                .Select(c => new { c.ProductId, c.DiscountRate, c.EndDate }).ToList();

            var inventory = _inventoryContext.Inventories.Select(i => new { i.ProductId, i.Price }).ToList();

            var category = _context.ProductCategories.Where(c => c.Slug == slug)
                .Include(p => p.Products)
                .ThenInclude(c => c.Category).Select(c => new CategoryWithProductsQueryVM()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Slug = c.Slug,
                    KeyWords = c.KeyWords,
                    MetaDescription = c.MetaDescription,
                    Products = MapProduct(c.Products, c.Products.Count)
                }).AsNoTracking().FirstOrDefault();


            if (category != null)
            {
                foreach (var product in category.Products)
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


            }
            return category;
        }

        private static List<ProductQueryVM> MapProduct(List<Product> Products, int count)
        {
            if (Products == null) throw new ArgumentNullException(nameof(Products));

            return Products.Select(p => new ProductQueryVM()
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
            }).OrderByDescending(p => p.Id).Take(count).ToList();
        }
    }
}
