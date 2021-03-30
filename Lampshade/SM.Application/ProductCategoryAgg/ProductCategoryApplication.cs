using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Framework.Application;
using ShopManagement.Application.Contracts.ProductCategoryAgg;

namespace SM.Application.ProductCategoryAgg
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository) => _productCategoryRepository = productCategoryRepository;

        public OperationResult Create(CreateProductCategoryVM command)
        {
            OperationResult operation = new OperationResult();

            if (_productCategoryRepository.IsExist(c => c.Name == command.Name))
                return operation.Failed("نام گروه تکراری است!");

            var slug = command.Slug.Slugify();
            var folderName = slug;

            var pictureName = Uploader.ImageUploader(command.Picture, folderName);

            var productCategory = new ProductCategory(command.Name, command.Description, command.KeyWords, pictureName,
                command.PictureAlt, command.PictureTitle, command.MetaDescription,
                slug);

            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SaveChanges();

            return operation.Succeeded();
        }

        public OperationResult DeleteCategory(long id)
        {
            OperationResult result = new OperationResult();

            var category = _productCategoryRepository.Get(id);

            if (category == null || category.IsDeleted) return result.Failed();

            category.Delete();
            _productCategoryRepository.SaveChanges();
            return result.Succeeded("حذف با موفقیت انجام شد");
        }

        public List<SearchProdcutCategoryForProductVM> GetCategoriesForSearchInProduct() => _productCategoryRepository.GetCategoriesForSearchInProduct();

        public OperationResult Edit(EditProductCategoryVM command)
        {
            OperationResult operation = new OperationResult();

            if (_productCategoryRepository.IsExist(c => c.Name == command.Name && c.Id != command.Id))
                return operation.Failed("نام گروه تکراری است!");

            var productCategory = _productCategoryRepository.Get(command.Id);

            var slug = command.Slug.Slugify();
            var folderName = slug;

            var pictureName = Uploader.ImageUploader(command.Picture, folderName);

            productCategory.Edit(command.Name, command.Description, command.KeyWords, pictureName
                , command.PictureAlt, command.PictureTitle, command.MetaDescription, slug);

            _productCategoryRepository.SaveChanges();

            return operation.Succeeded();
        }

        public IEnumerable<AdminProductCategoryVM> GetAllForAdmin(string searchName) => _productCategoryRepository.GetAllForAdmin(searchName);

        public EditProductCategoryVM GetDetailBy(long id) => _productCategoryRepository.GetDetail(id);

        public DeleteProductCategoryVM GetDetailForDelete(long id) => _productCategoryRepository.GetDetailForDelete(id);
    }
}
