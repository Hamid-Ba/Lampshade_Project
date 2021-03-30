using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;
using ShopManagement.Application.Contracts.ProductPictureAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;

namespace SM.Application.ProductPictureAgg
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;
        private readonly IProductRepository _productRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository, IProductRepository productRepository)
        {
            _productPictureRepository = productPictureRepository;
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProductPictureVM command)
        {
            OperationResult result = new OperationResult();

            //if (_productPictureRepository.IsExist(p =>
            //    p.PictureName == command.PictureName && p.ProductId == p.ProductId))
            //    return result.Failed(ValidateMessage.IsDuplicatedName);

            var product = _productRepository.GetProductWithCategoryBy(command.ProductId);

            var productSlug = product.Slug;
            var categorySlug = product.Category.Slug;

            var folderName = $"{categorySlug}\\{productSlug}";
            var pictureName = Uploader.ImageUploader(command.PictureName, folderName,null!);

            var productPicture = new ProductPicture(command.ProductId, pictureName, command.PictureAlt,
                command.PictureTitle);

            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Edit(EditProductPictureVM command)
        {
            OperationResult result = new OperationResult();

            //if (_productPictureRepository.IsExist(p =>
            //    p.PictureName == command.PictureName && p.ProductId == command.ProductId && p.Id != command.Id))
            //    return result.Failed(ValidateMessage.IsDuplicatedName);

            var productPicture = _productPictureRepository.GetWithProductAndCategoryBy(command.Id);

            if (productPicture == null) return result.Failed(ValidateMessage.IsExist);


            var productSlug = productPicture.Product.Slug;
            var categorySlug = productPicture.Product.Category.Slug;

            var folderName = $"{categorySlug}\\{productSlug}";
            var pictureName = Uploader.ImageUploader(command.PictureName, folderName,productPicture.PictureName);

            productPicture.Edit(command.ProductId, pictureName, command.PictureAlt, command.PictureTitle);
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

        public EditProductPictureVM GetDetailForEdit(long id) => _productPictureRepository.GetDetailForEdit(id);

        public DeleteProductPictureVM GetDetailForDelete(long id) => _productPictureRepository.GetDetailForDelete(id);

    }
}
