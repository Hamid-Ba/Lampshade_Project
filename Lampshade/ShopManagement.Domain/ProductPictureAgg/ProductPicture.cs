using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public class ProductPicture : EntityBaseModel
    {
        public long ProductId { get; private set; }
        public string PictureName { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public Product Product { get; private set; }

        public ProductPicture(long productId, string pictureName, string pictureAlt, string pictureTitle)
        {
            ProductId = productId;
            PictureName = pictureName;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            IsDeleted = false;
        }

        public void Edit(long productId, string pictureName, string pictureAlt, string pictureTitle)
        {
            ProductId = productId;

            if (!string.IsNullOrWhiteSpace(pictureName))
                PictureName = pictureName;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
        }

        public void Delete() => IsDeleted = true;
    }
}
