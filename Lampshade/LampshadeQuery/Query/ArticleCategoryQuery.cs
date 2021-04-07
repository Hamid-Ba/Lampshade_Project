using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Infrastructure.EfCore;
using LampshadeQuery.Contract.Article;
using LampshadeQuery.Contract.ArticleCategory;
using Microsoft.EntityFrameworkCore;

namespace LampshadeQuery.Query
{
    public class ArticleCategoryQuery : IArticleCategoryQuery
    {
        private readonly BlogContext _blogContext;

        public ArticleCategoryQuery(BlogContext blogContext) => _blogContext = blogContext;

        public ArticleCategoryQueryVM GetArticleCategory(string slug) => _blogContext.ArticleCategories.Include(a => a.Articles)
            .ThenInclude(c => c.ArticleCategory).Select(c =>
            new ArticleCategoryQueryVM()
            {
                Name = c.Name,
                Slug = c.Slug,
                CanonicalUrl = c.CanonicalUrl,
                Description = c.Description,
                Keywords = c.Keywords,
                MetaDescription = c.MetaDescription,
                PictureAlt = c.PictureAlt,
                PictureName = c.PictureName,
                PictureTitle = c.PictureTitle,
                ShowOrder = c.ShowOrder,
                Articles = MapArticles(c.Articles)
            }).AsNoTracking().FirstOrDefault(c => c.Slug == slug);

        public IEnumerable<ArticleCategoryQueryVM> GetArticleCategoriesForMenu() =>
            _blogContext.ArticleCategories.Select(c => new ArticleCategoryQueryVM()
            {
                Name = c.Name,
                Slug = c.Slug
            });

        public IEnumerable<ArticleCategoryQueryVM> GetArticleCategoriesForSideBar() => _blogContext.ArticleCategories
            .Select(c => new ArticleCategoryQueryVM()
            {
                Name = c.Name,
                ArticlesCount = c.Articles.Count,
                Slug = c.Slug
            }).ToList();

        private static List<ArticleQueryVM> MapArticles(List<Article> articles)
        {
            if (articles == null) throw new ArgumentNullException(nameof(articles));

            return articles.Where(a => a.PublishDate <= DateTime.Now)
                .Select(a => new ArticleQueryVM()
                {
                    Id = a.Id,
                    CategoryId = a.CategoryId,
                    CategoryName = a.ArticleCategory.Name,
                    CanonicalUrl = a.CanonicalUrl,
                    PictureName = a.PictureName,
                    PictureAlt = a.PictureAlt,
                    PictureTitle = a.PictureTitle,
                    CategorySlug = a.ArticleCategory.Slug,
                    PublishDate = a.PublishDate.ToFarsi(),
                    ShortDescription = a.ShortDescription,
                    Slug = a.Slug,
                    Title = a.Title,
                }).OrderByDescending(a => a.Id).ToList();
        }

    }
}
