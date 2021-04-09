using System.Collections.Generic;
using CommentManagement.Application.Contract.CommentAgg;
using CommentManagement.Domain.CommentAgg;
using Framework.Application;

namespace CommentManagement.Application.CommentAgg
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository) => _commentRepository = commentRepository;

        public OperationResult CreateComment(CreateCommentVM command)
        {
            OperationResult result = new OperationResult();

            var comment = new Comment(command.Name, command.Email, command.Message, command.Type, command.OwnerId,
                command.OwnerName, command.ParentId);

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
