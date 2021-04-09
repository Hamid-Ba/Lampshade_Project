using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LampshadeQuery.Contract.Comment;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class CommentChildrenViewComponent : ViewComponent
    {
        private readonly ICommentQuery _commentQuery;

        public CommentChildrenViewComponent(ICommentQuery commentQuery) => _commentQuery = commentQuery;

        public IViewComponentResult Invoke(long id) => View(_commentQuery.GetChildrenOfComment(id));
    }
}
