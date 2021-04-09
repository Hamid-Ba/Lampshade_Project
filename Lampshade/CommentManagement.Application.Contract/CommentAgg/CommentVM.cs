using System.ComponentModel.DataAnnotations;
using Framework.Application;

namespace CommentManagement.Application.Contract.CommentAgg
{
    public class CreateCommentVM
    {
        public long OwnerId { get; set; }
        public string OwnerName { get; set; }
        public int Type { get; set; }
        public long ParentId { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        [EmailAddress(ErrorMessage = "ایمیل نامعتبر هست !")]
        public string Email { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string Message { get; set; }
    }

    public class DeleteCommentVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class AdminCommentVM : CreateCommentVM
    {
        public long Id { get; set; }
        public string OwnerName { get; set; }
        public string CreationDate { get; set; }
        public bool IsConfirmed { get; set; }
    }

    public class SearchCommentVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
