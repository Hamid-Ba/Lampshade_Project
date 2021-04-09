using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using BlogManagement.Infrastructure.EfCore;
using CommentManagement.Domain.CommentAgg;
using CommentManagement.Infrastructure.EfCore;
using Framework.Presentation;
using LampshadeQuery.Contract.Article;
using LampshadeQuery.Contract.Comment;
using Microsoft.EntityFrameworkCore;

namespace LampshadeQuery.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _blogContext;
        private readonly CommentContext _commentContext;

        public ArticleQuery(BlogContext blogContext, CommentContext commentContext)
        {
            _blogContext = blogContext;
            _commentContext = commentContext;
        }

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

        public ArticleQueryVM GetArticleBy(string slug)
        {
            var article = _blogContext.Articles.Include(c => c.ArticleCategory).Where(a => a.Slug == slug).Select(a =>
                new ArticleQueryVM
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

            if (article == null) return null;

            var comments = _commentContext.Comments.Include(c => c.Children).ThenInclude(c => c.Parent)
                .Where(c => c.Type == CommentOwnerType.ArticleType && c.ParentId == 0 && c.IsConfirmed && c.OwnerId == article.Id).Select(
                    c => new CommentQueryVM()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        CreationDate = c.CreationTime.ToFarsi(),
                        Message = c.Message,
                        OwnerId = c.OwnerId,
                        Children = MapChildren(c.Children)
                    }).OrderByDescending(c => c.Id).AsNoTracking().ToList();

            article.Comments = MapComments(comments);

            return article;
        }

        private static List<CommentQueryVM> MapChildren(List<Comment> children)
        {
            if (children == null) throw new ArgumentNullException(nameof(children));

            return children.Select(c => new CommentQueryVM()
            {
                Id = c.Id,
                Name = c.Name,
                CreationDate = c.CreationTime.ToFarsi(),
                Message = c.Message,
                OwnerId = c.OwnerId,
                ParentId = c.ParentId,
            }).ToList();
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
                OwnerId = c.OwnerId,
                ParentId = c.ParentId,
                Children = c.Children
            }).OrderByDescending(c => c.Id).ToList();
        }
    }
}
