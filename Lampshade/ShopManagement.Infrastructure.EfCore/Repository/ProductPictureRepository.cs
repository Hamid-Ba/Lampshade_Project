using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductPictureAgg;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class ProductPictureRepository : RepositoryBase<long, ProductPicture>, IProductPictureRepository
    {
        private readonly ShopContext _context;

        public ProductPictureRepository(ShopContext context) : base(context) => _context = context;

        public List<AdminProductPictureVM> GetAllForAdmin(long productId)
        {
            var productPictures = _context.ProductPictures.Include(p => p.Product).Select(p => new AdminProductPictureVM()
            {
                Id = p.Id,
                PictureName = p.PictureName,
                ProductId = p.ProductId,
                ProductName = p.Product.Name,
                CreationDate = p.CreationTime.ToFarsi()
            });

            if (productId != 0) productPictures = productPictures.Where(p => p.ProductId == productId);

            return productPictures.ToList();
        }

        public EditProductPictureVM GetDetailForEdit(long id) => _context.ProductPictures.Where(p => p.Id == id).Select(p =>
            new EditProductPictureVM()
            {
                Id = p.Id,
                ProductId = p.ProductId,
                PictureName = p.PictureName,
                PictureAlt = p.PictureAlt,
                PictureTitle = p.PictureTitle
            }).FirstOrDefault();

        public DeleteProductPictureVM GetDetailForDelete(long id) => _context.ProductPictures.Where(p => p.Id == id).Include(p => p.Product)
            .Select(p =>
                new DeleteProductPictureVM()
                {
                    Id = p.Id,
                    PictureName = p.PictureName,
                    ProductName = p.Product.Name
                }).FirstOrDefault();
    }
}
