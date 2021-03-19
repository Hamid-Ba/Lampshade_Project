using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;

namespace ShopManagement.Application.Contracts.SlideAgg
{
    public interface ISlideApplication
    {
        OperationResult Create(CreateSlideVM command);
        OperationResult Edit(EditSlideVM command);
        OperationResult Delete(DeleteSlideVM command);
        List<AdminSlideVM> GetAllForAdmin();
        EditSlideVM GetDetailForEdit(long id);
        DeleteSlideVM GetDetailForDelete(long id);
    }
}
