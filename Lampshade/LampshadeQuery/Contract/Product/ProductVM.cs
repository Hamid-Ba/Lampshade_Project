using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LampshadeQuery.Contract.Comment;

namespace LampshadeQuery.Contract.Product
{
    public class ProductQueryVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public int DiscountRate { get; set; }
        public string Price { get; set; }
        public string PriceWithDiscount { get; set; }
        public bool HasDiscount { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategorySlug { get; set; }
        public string Slug { get; set; }
        public string DiscountExpired { get; set; }
        public string Code { get; set; }
        public bool IsInStock { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public string MetaDescription { get; set; }
        public List<PictureQueryVM> Pictures { get; set; }
        public List<CommentQueryVM> Comments { get; set; }
    }

    public class PictureQueryVM
    {
        public long Id { get; set; }
        public string PictureName { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
    }
}
