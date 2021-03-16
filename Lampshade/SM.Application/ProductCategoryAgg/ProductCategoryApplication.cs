using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;
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

            var productCategory = new ProductCategory(command.Name, command.Description, command.KeyWords, command.Picture,
                command.PictureAlt, command.PictureTitle, command.MetaDescription,
                command.Slug.Slugify());

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

        public OperationResult Edit(EditProductCategoryVM command)
        {
            OperationResult operation = new OperationResult();

            if (_productCategoryRepository.IsExist(c => c.Name == command.Name && c.Id != command.Id))
                return operation.Failed("نام گروه تکراری است!");

            var productCategory = _productCategoryRepository.Get(command.Id);

            productCategory.Edit(command.Name, command.Description, command.KeyWords, command.Picture
                , command.PictureAlt, command.PictureTitle, command.MetaDescription, command.Slug.Slugify());

            _productCategoryRepository.SaveChanges();

            return operation.Succeeded();
        }

        public IEnumerable<AdminProductCategoryVM> GetAllForAdmin(string searchName) => _productCategoryRepository.GetAllForAdmin(searchName);

        public EditProductCategoryVM GetDetailBy(long id) => _productCategoryRepository.GetDetail(id);

        public DeleteProductCategoryVM GetDetailForDelete(long id) => _productCategoryRepository.GetDetailForDelete(id);
    }
}
