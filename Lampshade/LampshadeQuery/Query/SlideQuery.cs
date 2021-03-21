using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LampshadeQuery.Contract.Slide;
using ShopManagement.Infrastructure.EfCore;

namespace LampshadeQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _context;

        public SlideQuery(ShopContext context) => _context = context;

        public IEnumerable<SlideQueryVM> GetAllSlides() => _context.Slides.Select(s => new SlideQueryVM()
        {
            BtnText = s.BtnText,
            Header = s.Header,
            Link = s.Link,
            PictureAlt = s.PictureAlt,
            PictureName = s.PictureName,
            Title = s.Title,
            Text = s.Text,
            PictureTitle = s.PictureTitle
        }).ToList();

    }
}
