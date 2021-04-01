using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ShopManagement.Application.Contracts.CommentAgg
{
    public class CreateCommentVM
    {
        public long ProductId { get; set; }

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
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string Name { get; set; }
    }

    public class AdminCommentVM : CreateCommentVM
    {
        public string ProductName { get; set; }
        public string CreationDate { get; set; }
        public bool IsConfirmed { get; set; }
    }

    public class SearchCommentVM
    {
        public long ProductId { get; set; }
        public string Email { get; set; }
    }
}
