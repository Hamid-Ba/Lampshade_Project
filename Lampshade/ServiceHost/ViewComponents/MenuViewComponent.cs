using LampshadeQuery;
using LampshadeQuery.Contract.ArticleCategory;
using LampshadeQuery.Contract.Category;
using LampshadeQuery.Contract.Order;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IOrderQuery _orderQuery;
        private readonly ICategoryQuery _categoryQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;

        public MenuViewComponent(IOrderQuery orderQuery, ICategoryQuery categoryQuery, IArticleCategoryQuery articleCategoryQuery)
        {
            _orderQuery = orderQuery;
            _categoryQuery = categoryQuery;
            _articleCategoryQuery = articleCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            IEnumerable<(int, string)> status;
            if (User.Identity.IsAuthenticated) { status = _orderQuery.GetUserOrdersStatusBy(User.Identity.Name); }
            else status = new List<(int, string)>();

            var result = new MenuQuery()
            {
                ArticleCategoryQuery = _articleCategoryQuery.GetArticleCategoriesForMenu(),
                CategoryQuery = _categoryQuery.GetAllProductCategoriesForMenu(),
                UserOrdersStatus = status
            };

            return View(result);
        }
    }
}
