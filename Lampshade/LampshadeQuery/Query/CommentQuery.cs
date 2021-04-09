using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using CommentManagement.Infrastructure.EfCore;
using LampshadeQuery.Contract.Comment;

namespace LampshadeQuery.Query
{
    public class CommentQuery : ICommentQuery
    {
        private readonly CommentContext _commentContext;

        public CommentQuery(CommentContext commentContext) => _commentContext = commentContext;


        public IEnumerable<CommentQueryVM> GetChildrenOfComment(long id) => _commentContext.Comments.Where(c =>
            c.Type == CommentOwnerType.ArticleType && c.IsConfirmed &&
            c.ParentId == id).Select(c => new CommentQueryVM()
            {
                Id = c.Id,
                CreationDate = c.CreationTime.ToFarsi(),
                Message = c.Message,
                Name = c.Name,
                OwnerId = c.OwnerId,
                ParentId = c.ParentId
            }).OrderByDescending(c => c.Id).ToList();

    }
}
