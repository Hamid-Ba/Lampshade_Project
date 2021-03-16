using System.ComponentModel.DataAnnotations;
using Framework.Application;

namespace ShopManagement.Application.Contracts.ProductCategoryAgg
{
    public class CreateProductCategoryVM
    {
        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string KeyWords { get; set; }
        public string Picture { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string PictureTitle { get; set; }
        public string MetaDescription { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string Slug { get; set; }
    }

    public class EditProductCategoryVM : CreateProductCategoryVM
    {
        public long Id { get; set; }
    }

    public class AdminProductCategoryVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string CreationDate { get; set; }
        public long ProductCount { get; set; }
    }

    public class DeleteProductCategoryVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
