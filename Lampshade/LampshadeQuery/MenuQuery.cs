using System.Collections.Generic;
using LampshadeQuery.Contract.ArticleCategory;
using LampshadeQuery.Contract.Category;

namespace LampshadeQuery
{
    public class MenuQuery
    {
        public IEnumerable<ArticleCategoryQueryVM> ArticleCategoryQuery { get; set; }
        public IEnumerable<CategoryQueryVM> CategoryQuery { get; set; }
        public IEnumerable<(int, string)> UserOrdersStatus { get; set; }
    }
}
