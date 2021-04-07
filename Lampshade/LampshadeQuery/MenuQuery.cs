using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LampshadeQuery.Contract.ArticleCategory;
using LampshadeQuery.Contract.Category;

namespace LampshadeQuery
{
    public class MenuQuery
    {
        public IEnumerable<ArticleCategoryQueryVM> ArticleCategoryQuery { get; set; }
        public IEnumerable<CategoryQueryVM> CategoryQuery { get; set; }
    }
}
