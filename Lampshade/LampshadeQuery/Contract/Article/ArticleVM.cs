using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LampshadeQuery.Contract.Comment;

namespace LampshadeQuery.Contract.Article
{
    public class ArticleQueryVM
    {
        public long Id { get; set; }
        public string Title { get;  set; }
        public long CategoryId { get;  set; }
        public string CategoryName { get; set; }
        public string PictureName { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public string PublishDate { get;  set; }
        public string PublishMonth { get; set; }
        public string PublishDay { get; set; }
        public string ShortDescription { get;  set; }
        public string Description { get;  set; }
        public string Slug { get;  set; }
        public string CategorySlug { get; set; }
        public string Keywords { get;  set; }
        public string MetaDescription { get;  set; }
        public string CanonicalUrl { get;  set; }
        public List<CommentQueryVM> Comments { get; set; }
    }
}
