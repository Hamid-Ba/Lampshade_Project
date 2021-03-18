using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductPictureAgg
{
    public class CreateProductPictureVM
    {
        public long ProductId { get; set; }
        public string PictureName { get; set; }
        public string PictureAlt { get; set; }
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
    }

    public class DeleteProductPictureVM
    {
        public long Id { get; set; }
        public string PictureName { get; set; }
        public string ProductName { get; set; }
    }
}
