using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogManagement.Application.Contract.ArticleAgg;
using Framework.Domain;

namespace BlogManagement.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<long, Article>
    {
        IEnumerable<AdminArticleVM> GetAllForAdmin(SearchArticleVM search);
        EditArticleVM GetDetailsForEdit(long id);
    }
}
