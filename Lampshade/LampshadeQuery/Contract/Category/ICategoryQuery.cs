using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LampshadeQuery.Contract.Category
{
    public interface ICategoryQuery
    {
        IEnumerable<CategoryQueryVM> GetAllCategory();
        IEnumerable<CategoryWithProductsQueryVM> GetCategoryWithProducts();
        CategoryWithProductsQueryVM GetCategoryAndProductsBy(string slug);
    }
}
