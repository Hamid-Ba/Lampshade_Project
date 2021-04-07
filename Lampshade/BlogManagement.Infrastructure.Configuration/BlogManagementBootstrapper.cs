using BlogManagement.Application.ArticleAgg;
using BlogManagement.Application.ArticleCategoryAgg;
using BlogManagement.Application.Contract.ArticleAgg;
using BlogManagement.Application.Contract.ArticleCategoryAgg;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infrastructure.EfCore;
using BlogManagement.Infrastructure.EfCore.Repository;
using LampshadeQuery.Contract.Article;
using LampshadeQuery.Contract.ArticleCategory;
using LampshadeQuery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogManagement.Infrastructure.Configuration
{
    public class BlogManagementBootstrapper
    {
        public static void Configuration(IServiceCollection service, string connectionString)
        {
            #region ConfigDbContext

            service.AddDbContext<BlogContext>(c => c.UseSqlServer(connectionString));

            #endregion

            service.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            service.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();

            service.AddTransient<IArticleRepository, ArticleRepository>();
            service.AddTransient<IArticleApplication, ArticleApplication>();

            service.AddTransient<IArticleQuery, ArticleQuery>();
            service.AddTransient<IArticleCategoryQuery, ArticleCategoryQuery>();
        }
    }
}
