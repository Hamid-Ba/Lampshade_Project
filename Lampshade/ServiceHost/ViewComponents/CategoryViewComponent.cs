using LampshadeQuery.Contract.Category;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryQuery _query;

        public CategoryViewComponent(ICategoryQuery query) => _query = query;

        public IViewComponentResult Invoke() => View(_query.GetAllCategory());
    }
}
