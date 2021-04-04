using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using BlogManagement.Application.Contract.ArticleCategoryAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EfCore.Repository
{
    public class ArticleCategoryRepository : RepositoryBase<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly BlogContext _context;

        public ArticleCategoryRepository(BlogContext context) : base(context) => _context = context;


        public IEnumerable<AdminArticleCategoryVM> GetAllForAdmin(SearchArticleCategoryVM search)
        {
            var query = _context.ArticleCategories.Select(c => new AdminArticleCategoryVM()
            {
                ArticleCount = 0,
                CreationDate = c.CreationTime.ToFarsi(),
                Description = c.Description,
                Id = c.Id,
                Name = c.Name,
                PictureName = c.PictureName,
                ShowOrder = c.ShowOrder
            }).OrderByDescending(o => o.Id).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search.Name)) query = query.Where(c => c.Name.Contains(search.Name));

            return query.ToList();
        }

        public EditArticleCategoryVM GetDetailForEdit(long id) => _context.ArticleCategories.Select(c =>
            new EditArticleCategoryVM()
            {
                CanonicalUrl = c.CanonicalUrl,
                Description = c.Description,
                Id = c.Id,
                Keywords = c.Keywords,
                MetaDescription = c.MetaDescription,
                Name = c.Name,
                Slug = c.Slug,
                PictureAlt = c.PictureAlt,
                PictureTitle = c.PictureTitle,
                ShowOrder = c.ShowOrder
            }).AsNoTracking().FirstOrDefault(c => c.Id == id);

        public string GetCategorySlugBy(long id) => _context.ArticleCategories.FirstOrDefault(c => c.Id == id)?.Slug;

    }
}
