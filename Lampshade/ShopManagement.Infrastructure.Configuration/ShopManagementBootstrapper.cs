using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application.Contracts.ProductAgg;
using ShopManagement.Application.Contracts.ProductCategoryAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastructure.EfCore;
using ShopManagement.Infrastructure.EfCore.Repository;
using SM.Application.ProductAgg;
using SM.Application.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.Configuration
{
    public class ShopManagementBootstrapper
    {
        public static void Configuration(IServiceCollection service, string connectionString)
        {

            #region ConfigDataBase

            service.AddDbContext<ShopContext>(c => c.UseSqlServer(connectionString));

            #endregion

            service.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            service.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            
            service.AddTransient<IProductRepository,ProductRepository>();
            service.AddTransient<IProductApplication, ProductApplication>();
        }
    }
}
