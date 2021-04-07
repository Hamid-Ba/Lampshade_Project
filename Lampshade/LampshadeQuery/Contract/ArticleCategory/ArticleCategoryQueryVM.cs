using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LampshadeQuery.Contract.Article;

namespace LampshadeQuery.Contract.ArticleCategory
{
    public class ArticleCategoryQueryVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureName { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public int ShowOrder { get; set; }
        public string Slug { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }
        public string CanonicalUrl { get; set; }
        public int ArticlesCount { get; set; }
        public List<ArticleQueryVM> Articles { get; set; }
    }
}
