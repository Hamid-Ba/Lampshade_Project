using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;

namespace ShopManagement.Application.Contracts.CommentAgg
{
    public interface ICommentApplication
    {
        OperationResult CreateComment(CreateCommentVM command);
        OperationResult DeleteComment(DeleteCommentVM command);
        OperationResult ConfirmedComment(long id);
        IEnumerable<AdminCommentVM> GetAllForAdmin(SearchCommentVM search);
    }
}
