using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LampshadeQuery.Contract.Product;

namespace LampshadeQuery.Contract.Category
{
    public class CategoryQueryVM
    {
        public string Name { get;  set; }
        public string Description { get;  set; }
        public string Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public string Slug { get;  set; }
    }

    public class CategoryWithProductsQueryVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<ProductQueryVM> Products { get; set; }
    }
}
