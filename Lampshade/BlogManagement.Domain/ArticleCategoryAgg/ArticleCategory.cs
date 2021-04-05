using System.Collections.Generic;
using BlogManagement.Domain.ArticleAgg;
using Framework.Domain;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public class ArticleCategory : EntityBaseModel
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string PictureName { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public int ShowOrder { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonicalUrl { get; private set; }

        public List<Article> Articles { get; private set; }

        public ArticleCategory(string name, string description, string pictureName, string pictureAlt, string pictureTitle, int showOrder, string slug, string keywords, string metaDescription, string canonicalUrl)
        {
            Name = name;
            Description = description;
            PictureName = pictureName;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ShowOrder = showOrder;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalUrl = canonicalUrl;
        }

        public void Edit(string name, string description, string pictureName, string pictureAlt, string pictureTitle, int showOrder, string slug, string keywords, string metaDescription, string canonicalUrl)
        {
            Name = name;
            Description = description;

            if (!string.IsNullOrWhiteSpace(pictureName))
                PictureName = pictureName;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ShowOrder = showOrder;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalUrl = canonicalUrl;
        }

        public void Delete() => IsDeleted = true;
    }
}
