using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;
using ShopManagement.Application.Contracts.CommentAgg;
using ShopManagement.Domain.CommentAgg;

namespace SM.Application.CommentAgg
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository) => _commentRepository = commentRepository;

        public OperationResult CreateComment(CreateCommentVM command)
        {
            OperationResult result = new OperationResult();

            var comment = new Comment(command.ProductId, command.Name, command.Email, command.Message);

            _commentRepository.Create(comment);
            _commentRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult DeleteComment(DeleteCommentVM command)
        {
            OperationResult result = new OperationResult();

            var comment = _commentRepository.Get(command.Id);

            if (comment == null) return result.Failed(ValidateMessage.IsExist);

            comment.Delete();
            _commentRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult ConfirmedComment(long id)
        {
            OperationResult result = new OperationResult();

            var comment = _commentRepository.Get(id);

            if (comment == null) return result.Failed(ValidateMessage.IsExist);

            comment.ConfirmedComment();
            _commentRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult DisConfirmedComment(long id)
        {
            OperationResult result = new OperationResult();

            var comment = _commentRepository.Get(id);

            if (comment == null) return result.Failed(ValidateMessage.IsExist);

            comment.DisConfirmedComment();
            _commentRepository.SaveChanges();

            return result.Succeeded();
        }

        public DeleteCommentVM GetDetailForDelete(long id) => _commentRepository.GetDetailForDelete(id);

        public IEnumerable<AdminCommentVM> GetAllForAdmin(SearchCommentVM search) => _commentRepository.GetAllForAdmin(search);
    }
}
