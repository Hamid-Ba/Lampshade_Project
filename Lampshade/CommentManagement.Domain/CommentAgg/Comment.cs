using System.Collections.Generic;
using Framework.Domain;

namespace CommentManagement.Domain.CommentAgg
{
    public class Comment : EntityBaseModel
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public bool IsConfirmed { get; private set; }
        public int Type { get; private set; }
        public long OwnerId { get; private set; }
        public string OwnerName { get; private set; }

        public long ParentId { get; private set; }
        public Comment Parent { get; private set; }
        public List<Comment> Children { get; private set; }


        public Comment(string name, string email, string message, int type, long ownerId,string ownerName, long parentId)
        {
            Name = name;
            Email = email;
            Message = message;
            Type = type;
            OwnerId = ownerId;
            OwnerName = ownerName;
            ParentId = parentId;
            IsConfirmed= false;
        }

        public void ConfirmedComment() => IsConfirmed = true;
        public void DisConfirmedComment() => IsConfirmed = false;
        public void Delete() => IsDeleted = true;
    }
}
