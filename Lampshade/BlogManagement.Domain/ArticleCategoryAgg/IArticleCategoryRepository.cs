using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogManagement.Application.Contract.ArticleCategoryAgg;
using Framework.Domain;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository : IRepository<long, ArticleCategory>
    {
        IEnumerable<AdminArticleCategoryVM> GetAllForAdmin(SearchArticleCategoryVM search);
        EditArticleCategoryVM GetDetailForEdit(long id);
        string GetCategorySlugBy(long id);
    }
}
