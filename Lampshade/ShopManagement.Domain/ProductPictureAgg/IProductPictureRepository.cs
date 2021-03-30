using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;
using ShopManagement.Application.Contracts.ProductPictureAgg;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository : IRepository<long,ProductPicture>
    {
        List<AdminProductPictureVM> GetAllForAdmin(long productId);
        EditProductPictureVM GetDetailForEdit(long id);
        DeleteProductPictureVM GetDetailForDelete(long id);
        ProductPicture GetWithProductAndCategoryBy(long id);
    }
}
