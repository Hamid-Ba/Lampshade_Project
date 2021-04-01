using System.Collections.Generic;
using Framework.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.CommentAgg
{
    public class Comment : EntityBaseModel
    {
        public long ProductId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public bool IsConfirmed { get; private set; }
        public Product Product { get; private set; }

        public Comment(long productId, string name, string email, string message)
        {
            ProductId = productId;
            Name = name;
            Email = email;
            Message = message;
            IsConfirmed = false;
        }

        public void ConfirmedComment() => IsConfirmed = true;

        public void Delete() => IsDeleted = true;
    }
}
