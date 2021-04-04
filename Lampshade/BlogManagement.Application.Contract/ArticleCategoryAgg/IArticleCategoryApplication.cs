using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;

namespace BlogManagement.Application.Contract.ArticleCategoryAgg
{
    public interface IArticleCategoryApplication
    {
        OperationResult Create(CreateArticleCategoryVM command);
        OperationResult Edit(EditArticleCategoryVM command);
        IEnumerable<AdminArticleCategoryVM> GetAllForAdmin(SearchArticleCategoryVM search);
        EditArticleCategoryVM GetDetailForEdit(long id);
    }
}
