using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LampshadeQuery.Contract.Article
{
    public interface IArticleQuery
    {
        IEnumerable<ArticleQueryVM> GetLatestBlogs(int count);
        IEnumerable<ArticleQueryVM> GetArticlesForSideBar(int count);
    }
}
