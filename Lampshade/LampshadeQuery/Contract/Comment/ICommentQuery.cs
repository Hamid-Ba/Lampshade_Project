using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LampshadeQuery.Contract.Comment
{
    public interface ICommentQuery
    {
        IEnumerable<CommentQueryVM> GetChildrenOfComment(long id);
    }
}
