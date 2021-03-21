using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LampshadeQuery.Contract.Slide
{
    public interface ISlideQuery
    {
        IEnumerable<SlideQueryVM> GetAllSlides();
    }
}
