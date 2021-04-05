using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;

namespace BlogManagement.Application.Contract.ArticleAgg
{
    public interface IArticleApplication
    {
        OperationResult Create(CreateArticleVM command);
        OperationResult Edit(EditArticleVM command);
        OperationResult Delete(long id);
        IEnumerable<AdminArticleVM> GetAllForAdmin(SearchArticleVM search);
        EditArticleVM GetDetailsForEdit(long id);

    }
}
