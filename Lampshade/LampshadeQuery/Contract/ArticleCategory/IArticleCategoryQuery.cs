using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LampshadeQuery.Contract.ArticleCategory
{
    public interface IArticleCategoryQuery
    {
        ArticleCategoryQueryVM GetArticleCategory(string slug);
        IEnumerable<ArticleCategoryQueryVM> GetArticleCategoriesForMenu();
        IEnumerable<ArticleCategoryQueryVM> GetArticleCategoriesForSideBar();
    }
}
