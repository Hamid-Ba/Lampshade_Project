using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;
using ShopManagement.Application.Contracts.ProductAgg;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository : IRepository<long,Product>
    {
        EditProductVM GetDetailForEdit(long id);
        DeleteProductVM GetDetailForDelete(long id);
        IEnumerable<AdminProductVM> GetAllProductForAdmin(SearchProductVM search);
        List<SearchProductForPictureVM> GetProductModelForSearch();
        Product GetProductWithCategoryBy(long id);
    }
}
