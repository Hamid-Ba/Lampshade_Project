using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;

namespace ShopManagement.Application.Contracts.ProductAgg
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProductVM command);
        OperationResult Edit(EditProductVM command);
        OperationResult Delete(DeleteProductVM command);
        EditProductVM GetDetailForEdit(long id);
        DeleteProductVM GetDetailForDelete(long id);
        IEnumerable<AdminProductVM> GetAllForAdmin(SearchProductVM search);
        List<SearchProductForPictureVM> GetProductModelForSearch();

    }
}
