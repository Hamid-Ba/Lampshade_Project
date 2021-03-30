using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contracts.ProductPictureAgg
{
    public class CreateProductPictureVM
    {
        [Range(1, long.MaxValue, ErrorMessage = ValidateMessage.IsRequired)]
        public long ProductId { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidateMessage.InvalidFileSize)]
        public IFormFile PictureName { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string PictureTitle { get; set; }
    }

    public class EditProductPictureVM : CreateProductPictureVM
    {
        public long Id { get; set; }
    }

    public class AdminProductPictureVM
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string PictureName { get; set; }
        public string ProductName { get; set; }
        public string CreationDate { get; set; }
    }

    public class DeleteProductPictureVM
    {
        public long Id { get; set; }
        public string PictureName { get; set; }
        public string ProductName { get; set; }
    }


}
