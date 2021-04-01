using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;
using ShopManagement.Application.Contracts.CommentAgg;

namespace ShopManagement.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long,Comment>
    {
        DeleteCommentVM GetDetailForDelete(long id);
        IEnumerable<AdminCommentVM> GetAllForAdmin(SearchCommentVM search);
    }
}
