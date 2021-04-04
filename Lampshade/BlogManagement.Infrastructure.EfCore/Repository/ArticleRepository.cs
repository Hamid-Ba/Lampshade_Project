using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using BlogManagement.Application.Contract.ArticleAgg;
using BlogManagement.Domain.ArticleAgg;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EfCore.Repository
{
    public class ArticleRepository : RepositoryBase<long, Article>, IArticleRepository
    {
        private readonly BlogContext _context;

        public ArticleRepository(BlogContext context) : base(context) => _context = context;

        public IEnumerable<AdminArticleVM> GetAllForAdmin(SearchArticleVM search)
        {
            var query = _context.Articles.Include(c => c.ArticleCategory).Select(a => new AdminArticleVM()
            {
                CategoryId = a.CategoryId,
                CategoryName = a.ArticleCategory.Name,
                CreationDate = a.CreationTime.ToFarsi(),
                Id = a.Id,
                PictureName = a.PictureName,
                PublishDate = a.PublishDate.ToFarsi(),
                ShortDescription = a.ShortDescription,
                Title = a.Title
            }).OrderByDescending(a => a.Id).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search.Title)) query = query.Where(a => a.Title.Contains(search.Title));
            if (search.CategoryId > 0) query = query.Where(a => a.CategoryId == search.CategoryId);

            return query.ToList();
        }

        public EditArticleVM GetDetailsForEdit(long id) => _context.Articles.Select(a => new EditArticleVM()
        {
            Title = a.Title,
            ShortDescription = a.ShortDescription,
            PublishDate = a.PublishDate.ToFarsi(),
            Id = a.Id,
            CanonicalUrl = a.CanonicalUrl,
            CategoryId = a.CategoryId,
            Description = a.Description,
            PictureTitle = a.PictureTitle,
            PictureAlt = a.PictureAlt,
            Slug = a.Slug,
            Keywords = a.Keywords,
            MetaDescription = a.MetaDescription
        }).AsNoTracking().FirstOrDefault(a => a.Id == id);
    }
}
