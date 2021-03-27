using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;

namespace ShopManagement.Application.Contracts.ProductAgg
{
    public class CreateProductVM
    {
        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string Name { get;  set; }
        public string Code { get;  set; }
        public string ShortDescription { get;  set; }
        public string Description { get;  set; }
        public string Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }

        [Range(1, double.MaxValue, ErrorMessage = ValidateMessage.IsRequired)]
        public long CategoryId { get;  set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string Slug { get;  set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string Keywords { get;  set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string MetaDescription { get;  set; }
    }

    public class EditProductVM : CreateProductVM
    {
        public long Id { get; set; }
    }

    public class AdminProductVM
    {
        public long Id { get; set; }
        public string Name { get;  set; }
        public string Code { get;  set; }
        public string Picture { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CreationDate { get; set; }
    }

    public class SearchProductVM
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public long CategoryId { get; set; }
    }

    public class DeleteProductVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class SearchProductForPictureVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
