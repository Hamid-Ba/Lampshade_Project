using System.Collections.Generic;
using Framework.Application;
using ShopManagement.Application.Contracts.ProductAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;

namespace SM.Application.ProductAgg
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _categoryRepository;

        public ProductApplication(IProductRepository productRepository, IProductCategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public OperationResult Create(CreateProductVM command)
        {
            OperationResult result = new OperationResult();

            if (_productRepository.IsExist(p => p.Name == command.Name)) return result.Failed(ValidateMessage.IsDuplicatedName);

            var slug = command.Slug.Slugify();
            var categorySlug = _categoryRepository.GetCategorySlugBy(command.CategoryId);
            var folderName = $"{categorySlug}//{slug}";

            var pictureName = Uploader.ImageUploader(command.Picture, folderName,null!);

            var product = new Product(command.Name, command.Code, command.ShortDescription,
                command.Description, pictureName, command.PictureAlt,
                command.PictureTitle, command.CategoryId, slug, command.Keywords,
                command.MetaDescription);

            _productRepository.Create(product);
            _productRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Edit(EditProductVM command)
        {
            OperationResult result = new OperationResult();

            if (_productRepository.IsExist(p => p.Name == command.Name && p.Id != command.Id))
                return result.Failed(ValidateMessage.IsDuplicatedName);

            var product = _productRepository.GetProductWithCategoryBy(command.Id);

            if (product == null) return result.Failed(ValidateMessage.IsExist);

            var slug = command.Slug.Slugify();
            var categorySlug = _categoryRepository.GetCategorySlugBy(command.CategoryId);
            var folderName = $"{categorySlug}//{slug}";

            var pictureName = Uploader.ImageUploader(command.Picture, folderName,product.Picture);

            product.Edit(command.Name, command.Code, command.ShortDescription,
                command.Description, pictureName, command.PictureAlt,
                command.PictureTitle, command.CategoryId, slug, command.Keywords,
                command.MetaDescription);

            _productRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Delete(DeleteProductVM command)
        {
            OperationResult result = new OperationResult();

            var product = _productRepository.GetProductWithCategoryBy(command.Id);

            if (product == null) return result.Failed(ValidateMessage.IsExist);

            product.Delete();

            var slug = product.Slug;
            var categorySlug = product.Category.Slug;
            var folderName = $"{categorySlug}\\{slug}";
            Uploader.DirectoryRemover(folderName);

            _productRepository.SaveChanges();

            return result.Succeeded();
        }

        public EditProductVM GetDetailForEdit(long id) => _productRepository.GetDetailForEdit(id);

        public DeleteProductVM GetDetailForDelete(long id) => _productRepository.GetDetailForDelete(id);

        public IEnumerable<AdminProductVM> GetAllForAdmin(SearchProductVM search) => _productRepository.GetAllProductForAdmin(search);

        public List<SearchProductForPictureVM> GetProductModelForSearch() => _productRepository.GetProductModelForSearch();

    }
}