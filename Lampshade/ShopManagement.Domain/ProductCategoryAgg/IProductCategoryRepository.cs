using ShopManagement.Application.Contracts.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Framework.Domain;


namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IRepository<long,ProductCategory>
    {
        IEnumerable<AdminProductCategoryVM> GetAllForAdmin(string searchName);
        EditProductCategoryVM GetDetail(long id);
        DeleteProductCategoryVM GetDetailForDelete(long id);
    }
}
