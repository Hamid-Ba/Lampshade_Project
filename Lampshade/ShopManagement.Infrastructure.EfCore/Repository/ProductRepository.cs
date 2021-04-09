using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
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
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
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
                Picture = p.Picture,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                CreationDate = p.CreationTime.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(search.Name)) products = products.Where(p => p.Name.Contains(search.Name));

            if (!string.IsNullOrWhiteSpace(search.Code)) products = products.Where(p => p.Code.Contains(search.Code));

            if (search.CategoryId != 0) products = products.Where(p => p.CategoryId == search.CategoryId);

            return products.ToList();
        }

        public List<SearchProductForPictureVM> GetProductModelForSearch() => _context.Products.
            Select(p => new SearchProductForPictureVM()
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

        public Product GetProductWithCategoryBy(long id) => _context.Products.Include(c => c.Category).FirstOrDefault(p => p.Id == id);
    }
}
