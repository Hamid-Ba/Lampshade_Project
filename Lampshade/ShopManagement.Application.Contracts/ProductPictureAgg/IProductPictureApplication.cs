using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;

namespace ShopManagement.Application.Contracts.ProductPictureAgg
{
    public interface IProductPictureApplication
    {
        OperationResult Create(CreateProductPictureVM command);
        OperationResult Edit(EditProductPictureVM command);
        OperationResult Delete(DeleteProductPictureVM command);
        List<AdminProductPictureVM> GetAllForAdmin(long productId);
    }
}
