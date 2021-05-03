using LampshadeQuery.Contract.Cart;
using LampshadeQuery.Contract.Category;
using LampshadeQuery.Contract.Order;
using LampshadeQuery.Contract.Product;
using LampshadeQuery.Contract.Slide;
using LampshadeQuery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application.Contracts.OrderAgg;
using ShopManagement.Application.Contracts.ProductAgg;
using ShopManagement.Application.Contracts.ProductCategoryAgg;
using ShopManagement.Application.Contracts.ProductPictureAgg;
using ShopManagement.Application.Contracts.SlideAgg;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.Service;
using ShopManagement.Domain.SlideAgg;
using ShopManagement.Infrastructure.EfCore;
using ShopManagement.Infrastructure.EfCore.Repository;
using ShopManagement.Infrastructure.InventoryACL;
using SM.Application.OrderAgg;
using SM.Application.ProductAgg;
using SM.Application.ProductCategoryAgg;
using SM.Application.ProductPictureAgg;
using SM.Application.SlideAgg;

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

            service.AddTransient<IProductRepository, ProductRepository>();
            service.AddTransient<IProductApplication, ProductApplication>();

            service.AddTransient<IProductPictureRepository, ProductPictureRepository>();
            service.AddTransient<IProductPictureApplication, ProductPictureApplication>();

            service.AddTransient<ISlideRepository, SlideRepository>();
            service.AddTransient<ISlideApplication, SlideApplication>();

            service.AddTransient<IOrderRepository, OrderRepository>();
            service.AddTransient<IOrderApplication, OrderApplication>();

            service.AddSingleton<ICartService, CartService>();

            service.AddTransient<IShopInventoryACL, ShopInventoryACL>();

            service.AddTransient<ISlideQuery, SlideQuery>();
            service.AddTransient<ICategoryQuery, CategoryQuery>();
            service.AddTransient<IProductQuery, ProductQuery>();
            service.AddTransient<IOrderQuery, OrderQuery>();
            service.AddTransient<ICalculateCart, CalculateCart>();
            
        }
    }
}
