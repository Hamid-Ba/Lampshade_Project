using System.Collections.Generic;
using Framework.Application;

namespace CommentManagement.Application.Contract.CommentAgg
{
    public interface ICommentApplication
    {
        OperationResult CreateComment(CreateCommentVM command);
        OperationResult DeleteComment(DeleteCommentVM command);
        OperationResult ConfirmedComment(long id);
        OperationResult DisConfirmedComment(long id);
        DeleteCommentVM GetDetailForDelete(long id);
        IEnumerable<AdminCommentVM> GetAllForAdmin(SearchCommentVM search);
    }
}
