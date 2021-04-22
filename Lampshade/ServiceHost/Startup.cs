using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlogManagement.Infrastructure.Configuration;
using DiscountManagement.Infrastructure.Configuration;
using InventoryManagement.Infrastructure.Configuration;
using ShopManagement.Infrastructure.Configuration;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using AccountManagement.Infrastructure.Configuration;
using CommentManagement.Infrastructure.Configuration;
using Framework.Application.Authentication;
using Framework.Application.Hashing;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Framework.Application.ZarinPal;
using InventoryManagement.Presentation.Api;

namespace ServiceHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            var connectionString = Configuration.GetConnectionString("LampShade");
            ShopManagementBootstrapper.Configuration(services, connectionString);
            DiscountManagementBootstrapper.Configuration(services, connectionString);
            InventoryManagementBootstrapper.Configuration(services, connectionString);
            BlogManagementBootstrapper.Configuration(services, connectionString);
            CommentManagementBootstrapper.Configuration(services, connectionString);
            AccountManagementBootstrapper.Configuration(services, connectionString);

            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IAuthHelper, AuthHelper>();
            services.AddTransient<IZarinPalFactory, ZarinPalFactory>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = "/Account";
                    o.LogoutPath = "/Account/Logout";
                    o.AccessDeniedPath = new PathString("/AccessDenied");
                    o.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
                });

            services.AddRazorPages().
                AddApplicationPart(typeof(InventoryController).Assembly);
               // AddNewtonsoftJson();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
