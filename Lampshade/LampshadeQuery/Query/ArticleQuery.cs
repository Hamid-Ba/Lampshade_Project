using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using BlogManagement.Infrastructure.EfCore;
using Framework.Presentation;
using LampshadeQuery.Contract.Article;
using Microsoft.EntityFrameworkCore;

namespace LampshadeQuery.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _blogContext;

        public ArticleQuery(BlogContext blogContext) => _blogContext = blogContext;

        public IEnumerable<ArticleQueryVM> GetLatestBlogs(int count)
        {
            var query = _blogContext.Articles.Include(c => c.ArticleCategory)
                   .Where(a => a.PublishDate <= DateTime.Now)
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
                   }).OrderByDescending(a => a.Id).AsNoTracking().Take(count).ToList();

            query.ForEach(a => a.PublishMonth = a.PublishDate.ToMonthByDate());
            query.ForEach(a => a.PublishDay = a.PublishDate.ToDayByDate());

            return query;
        }

        public IEnumerable<ArticleQueryVM> GetArticlesForSideBar(int count) => _blogContext.Articles.Select(a =>
            new ArticleQueryVM()
            {
                Id = a.Id,
                Title = a.Title,
                Slug = a.Slug,
                PictureName = a.PictureName,
                CanonicalUrl = a.CanonicalUrl,
                PictureAlt = a.PictureAlt,
                PictureTitle = a.PictureTitle,
                PublishDate = a.PublishDate.ToFarsi()
            });

        public ArticleQueryVM GetArticleBy(string slug) => _blogContext.Articles.Include(c => c.ArticleCategory).Where(a => a.Slug == slug).Select(a => new ArticleQueryVM
        {
            Id = a.Id,
            Title = a.Title,
            Slug = a.Slug,
            ShortDescription = a.ShortDescription,
            CanonicalUrl = a.CanonicalUrl,
            CategoryId = a.CategoryId,
            CategoryName = a.ArticleCategory.Name,
            CategorySlug = a.ArticleCategory.Slug,
            Description = a.Description,
            Keywords = a.Keywords,
            MetaDescription = a.MetaDescription,
            PictureAlt = a.PictureAlt,
            PictureName = a.PictureName,
            PictureTitle = a.PictureTitle,
            PublishDate = a.PublishDate.ToFarsi()
        }).AsNoTracking().FirstOrDefault();

    }
}
