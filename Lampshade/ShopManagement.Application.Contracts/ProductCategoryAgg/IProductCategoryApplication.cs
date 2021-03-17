using System.Collections.Generic;
using Framework.Application;

namespace ShopManagement.Application.Contracts.ProductCategoryAgg
{
    public interface IProductCategoryApplication
    {
        IEnumerable<AdminProductCategoryVM> GetAllForAdmin(string searchName);
        EditProductCategoryVM GetDetailBy(long id);
        DeleteProductCategoryVM GetDetailForDelete(long id);
        OperationResult Create(CreateProductCategoryVM command);
        OperationResult Edit(EditProductCategoryVM command);
        OperationResult DeleteCategory(long id);
        List<SearchProdcutCategoryForProductVM> GetCategoriesForSearchInProduct();
    }
}
