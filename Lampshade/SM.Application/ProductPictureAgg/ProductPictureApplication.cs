using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;
using ShopManagement.Application.Contracts.ProductPictureAgg;
using ShopManagement.Domain.ProductPictureAgg;

namespace SM.Application.ProductPictureAgg
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository) => _productPictureRepository = productPictureRepository;

        public OperationResult Create(CreateProductPictureVM command)
        {
            OperationResult result = new OperationResult();

            if (_productPictureRepository.IsExist(p =>
                p.PictureName == command.PictureName && p.ProductId == p.ProductId))
                return result.Failed(ValidateMessage.IsDuplicatedName);

            var productPicture = new ProductPicture(command.ProductId, command.PictureName, command.PictureAlt,
                command.PictureTitle);

            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Edit(EditProductPictureVM command)
        {
            OperationResult result = new OperationResult();

            if (_productPictureRepository.IsExist(p =>
                p.PictureName == command.PictureName && p.ProductId == command.ProductId && p.Id != command.Id))
                return result.Failed(ValidateMessage.IsDuplicatedName);

            var productPicture = _productPictureRepository.Get(command.Id);

            if (productPicture == null) return result.Failed(ValidateMessage.IsExist);

            productPicture.Edit(command.ProductId, command.PictureName, command.PictureAlt, command.PictureTitle);
            _productPictureRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Delete(DeleteProductPictureVM command)
        {
            OperationResult result = new OperationResult();

            var productPicture = _productPictureRepository.Get(command.Id);
            if (productPicture == null) return result.Failed(ValidateMessage.IsExist);

            productPicture.Delete();
            _productPictureRepository.SaveChanges();

            return result.Succeeded();
        }

        public List<AdminProductPictureVM> GetAllForAdmin(long productId) => _productPictureRepository.GetAllForAdmin(productId);
    }
}
