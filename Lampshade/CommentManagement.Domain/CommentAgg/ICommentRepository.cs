using System.Collections.Generic;
using CommentManagement.Application.Contract.CommentAgg;
using Framework.Domain;

namespace CommentManagement.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long,Comment>
    {
        DeleteCommentVM GetDetailForDelete(long id);
        IEnumerable<AdminCommentVM> GetAllForAdmin(SearchCommentVM search);
    }
}
