using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory : EntityBaseModel
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string KeyWords { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }

        public ProductCategory(string name, string description, string keyWords, string picture, string pictureAlt, string pictureTitle, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            KeyWords = keyWords;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            MetaDescription = metaDescription;
            Slug = slug;
        }

        public void Edit(string name, string description, string keyWords, string picture, string pictureAlt, string pictureTitle, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            KeyWords = keyWords;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            MetaDescription = metaDescription;
            Slug = slug;
        }

    }
}
