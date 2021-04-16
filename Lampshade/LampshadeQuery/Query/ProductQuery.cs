using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using CommentManagement.Infrastructure.EfCore;
using DiscountManagement.Infrastructure.EfCore;
using InventoryManagement.Infrastructure.EfCore;
using LampshadeQuery.Contract.Comment;
using LampshadeQuery.Contract.Product;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.OrderAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Infrastructure.EfCore;

namespace LampshadeQuery.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext _context;
        private readonly DiscountContext _discountContext;
        private readonly InventoryContext _inventoryContext;
        private readonly CommentContext _commentContext;

        public ProductQuery(ShopContext context, DiscountContext discountContext, InventoryContext inventoryContext, CommentContext commentContext)
        {
            _context = context;
            _discountContext = discountContext;
            _inventoryContext = inventoryContext;
            _commentContext = commentContext;
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

        public ProductQueryVM GetDetailsBy(string slug)
        {
            var discount = _discountContext.CustomerDiscounts
                .Where(c => c.StartDate < DateTime.Now && DateTime.Now < c.EndDate)
                .Select(c => new { c.ProductId, c.DiscountRate, c.EndDate }).ToList();

            var inventory = _inventoryContext.Inventories.Select(i => new { i.ProductId, i.Price, i.IsInStock }).ToList();


            var product = _context.Products.Where(p => p.Slug == slug)
                .Include(p => p.Category).Include(p => p.ProductPictures)
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
                    CategorySlug = p.Category.Slug,
                    Code = p.Code,
                    Description = p.Description,
                    MetaDescription = p.MetaDescription,
                    ShortDescription = p.ShortDescription,
                    Tags = p.Slug,
                    Pictures = MapPictures(p.ProductPictures),
                }).AsNoTracking().FirstOrDefault();

            var comments = _commentContext.Comments.Where(c => c.Type == CommentOwnerType.ProductType && c.OwnerId == product.Id && c.IsConfirmed)
                .Select(c => new CommentQueryVM()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Message = c.Message,
                    CreationDate = c.CreationTime.ToFarsi(),
                    OwnerId = c.OwnerId
                }).OrderByDescending(c => c.Id).ToList();

            if (product == null) return new ProductQueryVM();



            product.Comments = MapComments(comments);

            product.HasDiscount = discount.Exists(d => d.ProductId == product.Id);

            if (!inventory.Exists(p => p.ProductId == product.Id)) return product;

            // ReSharper disable once PossibleNullReferenceException
            var price = inventory.Find(i => i.ProductId == product.Id).Price;

            // ReSharper disable once PossibleNullReferenceException
            product.IsInStock = inventory.Find(i => i.ProductId == product.Id).IsInStock;

            product.Price = price.ToMoney();
            product.DoublePrice = price;

            if (!product.HasDiscount) return product;

            // ReSharper disable once PossibleNullReferenceException
            product.DiscountRate = discount.Find(p => p.ProductId == product.Id).DiscountRate;

            var discountRate = product.DiscountRate;
            var discountMoney = Math.Round(price * discountRate) / 100;

            product.PriceWithDiscount = (price - discountMoney).ToMoney();
            product.DiscountExpired = discount.Find(d => d.ProductId == product.Id)?.EndDate.ToDiscountFormat();

            return product;
        }

        private static List<CommentQueryVM> MapComments(List<CommentQueryVM> comments)
        {
            if (comments == null) throw new ArgumentNullException(nameof(comments));

            return comments.Select(c => new CommentQueryVM()
            {
                Id = c.Id,
                Message = c.Message,
                Name = c.Name,
                CreationDate = c.CreationDate,
                OwnerId = c.OwnerId
            }).OrderByDescending(c => c.Id).ToList();
        }

        private static List<PictureQueryVM> MapPictures(List<ProductPicture> productPictures)
        {
            if (productPictures == null) throw new ArgumentNullException(nameof(productPictures));
            return productPictures.Select(p => new PictureQueryVM()
            {
                Id = p.Id,
                PictureAlt = p.PictureAlt,
                PictureName = p.PictureName,
                PictureTitle = p.PictureTitle
            }).ToList();
        }

        public IEnumerable<CartItem> CheckIsInStock(IEnumerable<CartItem> cartItems)
        {
            var inventory = _inventoryContext.Inventories.ToList();

            foreach (var item in cartItems.Where(cart => inventory.Any(i => i.ProductId == cart.Id && i.IsInStock)))
            {
                var itemInventory = inventory.FirstOrDefault(i => i.ProductId == item.Id);
                item.IsInStock = itemInventory.CalculateStock() >= item.Count;
            }

            return cartItems;
        }
    }
}