using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;
using ShopManagement.Application.Contracts.ProductAgg;
using ShopManagement.Domain.ProductAgg;

namespace SM.Application.ProductAgg
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository) => _productRepository = productRepository;

        public OperationResult Create(CreateProductVM command)
        {
            OperationResult result = new OperationResult();

            if (_productRepository.IsExist(p => p.Name == command.Name)) return result.Failed(ValidateMessage.IsDuplicatedName);

            var product = new Product(command.Name, command.Code, command.ShortDescription,
                command.Description, command.Picture, command.PictureAlt,
                command.PictureTitle, command.CategoryId, command.Slug.Slugify(), command.Keywords,
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

            var product = _productRepository.Get(command.Id);

            if (product == null) return result.Failed(ValidateMessage.IsExist);

            product.Edit(command.Name, command.Code, command.ShortDescription,
                command.Description, command.Picture, command.PictureAlt,
                command.PictureTitle, command.CategoryId, command.Slug.Slugify(), command.Keywords,
                command.MetaDescription);

            _productRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Delete(DeleteProductVM command)
        {
            OperationResult result = new OperationResult();

            var product = _productRepository.Get(command.Id);

            if (product == null) return result.Failed(ValidateMessage.IsExist);

            product.Delete();
            _productRepository.SaveChanges();

            return result.Succeeded();
        }

        public EditProductVM GetDetailForEdit(long id) => _productRepository.GetDetailForEdit(id);

        public DeleteProductVM GetDetailForDelete(long id) => _productRepository.GetDetailForDelete(id);

        public IEnumerable<AdminProductVM> GetAllForAdmin(SearchProductVM search) => _productRepository.GetAllProductForAdmin(search);

        public List<SearchProductForPictureVM> GetProductModelForSearch() => _productRepository.GetProductModelForSearch();

    }
}