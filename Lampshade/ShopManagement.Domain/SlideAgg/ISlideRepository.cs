using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;
using ShopManagement.Application.Contracts.SlideAgg;

namespace ShopManagement.Domain.SlideAgg
{
    public interface ISlideRepository : IRepository<long,Slide>
    {
        List<AdminSlideVM> GetAllForAdmin();
        EditSlideVM GetDetailForEdit(long id);
        DeleteSlideVM GetDetailForDelete(long id);
    }
}
