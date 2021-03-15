using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Framework.Infrastructure;
using ShopManagement.Application.Contracts.ProductCategoryAgg;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long,ProductCategory> , IProductCategoryRepository
    {
        private readonly ShopContext _context;

        public ProductCategoryRepository(ShopContext context) : base(context) => _context = context;

        public IEnumerable<AdminProductCategoryVM> GetAllForAdmin(string searchName)
        {
            var categoryList = _context.ProductCategories.Select(c => new AdminProductCategoryVM()
            {
                Id = c.Id,
                Name = c.Name,
                CreationDate = c.CreationTime.ToString(CultureInfo.InvariantCulture),
                Description = c.Description,
                Picture = c.Picture,
                ProductCount = 0
            });

            if (!string.IsNullOrWhiteSpace(searchName)) categoryList = categoryList.Where(c => c.Name.Contains(searchName));

            return categoryList.ToList();
        }

        public EditProductCategoryVM GetDetail(long id)
        {
            var category = Get(id);

            return new EditProductCategoryVM()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                MetaDescription = category.MetaDescription,
                Picture = category.Picture,
                PictureAlt = category.PictureAlt,
                PictureTitle = category.PictureTitle,
                Slug = category.Slug
            };
        }
    }
}