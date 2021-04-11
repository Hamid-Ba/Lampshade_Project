using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentManagement.Application.CommentAgg;
using CommentManagement.Application.Contract.CommentAgg;
using CommentManagement.Domain.CommentAgg;
using CommentManagement.Infrastructure.EfCore;
using CommentManagement.Infrastructure.EfCore.Repository;
using LampshadeQuery.Contract.Comment;
using LampshadeQuery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CommentManagement.Infrastructure.Configuration
{
    public class CommentManagementBootstrapper
    {
        public static void Configuration(IServiceCollection service, string connectionString)
        {
            #region ConfigDbContext

            service.AddDbContext<CommentContext>(c => c.UseSqlServer(connectionString));

            #endregion

            service.AddTransient<ICommentRepository, CommentRepository>();
            service.AddTransient<ICommentApplication, CommentApplication>();

            service.AddTransient<ICommentQuery, CommentQuery>();
        }
    }
}
