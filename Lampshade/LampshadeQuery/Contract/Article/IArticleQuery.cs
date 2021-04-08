using System.Collections.Generic;

namespace LampshadeQuery.Contract.Article
{
    public interface IArticleQuery
    {
        IEnumerable<ArticleQueryVM> GetLatestBlogs(int count);
        IEnumerable<ArticleQueryVM> GetArticlesForSideBar(int count);
        ArticleQueryVM GetArticleBy(string slug);
    }
}
