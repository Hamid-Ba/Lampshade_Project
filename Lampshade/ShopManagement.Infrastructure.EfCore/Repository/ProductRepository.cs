using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductAgg;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {
        private readonly ShopContext _context;
        public ProductRepository(ShopContext context) : base(context) => _context = context;

        public EditProductVM GetDetailForEdit(long id)
        {
            var product = Get(id);

            return new EditProductVM()
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Code = product.Code,
                Description = product.Description,
                Keywords = product.Keywords,
                MetaDescription = product.MetaDescription,
                Name = product.Name,
                Picture = product.Picture,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                Price = product.Price,
                ShortDescription = product.ShortDescription,
                Slug = product.Slug
            };
        }

        public DeleteProductVM GetDetailForDelete(long id)
        {
            var product = Get(id);

            return new DeleteProductVM()
            {
                Id = product.Id,
                Name = product.Name,
                Code = product.Code
            };
        }

        public IEnumerable<AdminProductVM> GetAllProductForAdmin(SearchProductVM search)
        {
            var products = _context.Products.Include(c => c.Category).Select(p => new AdminProductVM()
            {
                Id = p.Id,
                Code = p.Code,
                Name = p.Name,
                Price = p.Price,
                Picture = p.Picture,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                CreationDate = p.CreationTime.ToString(CultureInfo.InvariantCulture)
            });

            if (!string.IsNullOrWhiteSpace(search.Name)) products = products.Where(p => p.Name.Contains(search.Name));

            if (!string.IsNullOrWhiteSpace(search.Code)) products = products.Where(p => p.Code.Contains(search.Code));

            if (search.CategoryId != 0) products = products.Where(p => p.CategoryId == search.CategoryId);

            return products.ToList();
        }

        public List<SearchProductForPictureVM> GetProductForPictureSearch() => _context.Products.
            Select(p => new SearchProductForPictureVM()
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();
    }
}
