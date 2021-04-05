using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogManagement.Domain.ArticleCategoryAgg;
using Framework.Domain;

namespace BlogManagement.Domain.ArticleAgg
{
    public class Article : EntityBaseModel
    {
        public string Title { get; private set; }
        public long CategoryId { get; private set; }
        public string PictureName { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public DateTime PublishDate { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonicalUrl { get; private set; }

        public ArticleCategory ArticleCategory { get; private set; }

        public Article(string title, long categoryId, string pictureName, string pictureAlt, string pictureTitle, DateTime publishDate, string shortDescription, string description, string slug, string keywords, string metaDescription, string canonicalUrl)
        {
            Title = title;
            CategoryId = categoryId;
            PictureName = pictureName;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            PublishDate = publishDate;
            ShortDescription = shortDescription;
            Description = description;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalUrl = canonicalUrl;
        }

        public void Edit(string title, long categoryId, string pictureName, string pictureAlt, string pictureTitle, DateTime publishDate, string shortDescription, string description, string slug, string keywords, string metaDescription, string canonicalUrl)
        {
            Title = title;
            CategoryId = categoryId;

            if (!string.IsNullOrWhiteSpace(pictureName))
                PictureName = pictureName;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            PublishDate = publishDate;
            ShortDescription = shortDescription;
            Description = description;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalUrl = canonicalUrl;
        }

        public void Delete() => IsDeleted = true;
    }
}
