using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.EfCore;
using InventoryManagement.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Infrastructure.Configuration
{
    public class InventoryManagementBootstrapper
    {
        public static void Configuration(IServiceCollection service, string connectionString)
        {
            #region ConfigureDataBase
            
            service.AddDbContext<InventoryContext>(d => d.UseSqlServer(connectionString));
            
            #endregion

            service.AddTransient<IInventoryRepository, InventoryRepository>();
        }
    }
}
