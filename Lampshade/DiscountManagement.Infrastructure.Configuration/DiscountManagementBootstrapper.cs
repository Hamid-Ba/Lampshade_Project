using System;
using DiscountManagement.Application.Contract.CustomerDiscountAgg;
using DiscountManagement.Application.CustomerDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.EfCore;
using DiscountManagement.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiscountManagement.Infrastructure.Configuration
{
    public class DiscountManagementBootstrapper
    {
        public static void Configuration(IServiceCollection service, string connectionString)
        {
            #region ConfigDataBase

            service.AddDbContext<DiscountContext>(d => d.UseSqlServer(connectionString));

            #endregion


            service.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();
            service.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();
        }
    }
}
