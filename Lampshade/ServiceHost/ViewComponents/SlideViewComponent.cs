using LampshadeQuery.Contract.Slide;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class SlideViewComponent : ViewComponent
    {
        private readonly ISlideQuery _query;

        public SlideViewComponent(ISlideQuery query) => _query = query;

        public IViewComponentResult Invoke() => View(_query.GetAllSlides());

    }
}
