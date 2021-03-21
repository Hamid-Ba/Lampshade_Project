using System.Collections.Generic;
using System.Linq;
using LampshadeQuery.Contract.Category;
using ShopManagement.Infrastructure.EfCore;

namespace LampshadeQuery.Query
{
    public class CategoryQuery : ICategoryQuery
    {
        private readonly ShopContext _context;

        public CategoryQuery(ShopContext context) => _context = context;

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

    }
}
