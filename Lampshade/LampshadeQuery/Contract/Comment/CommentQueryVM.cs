using System.Collections.Generic;

namespace LampshadeQuery.Contract.Comment
{
    public class CommentQueryVM
    {
        public long Id { get; set; }
        public long OwnerId { get; set; }
        public long ParentId { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string CreationDate { get; set; }
        public List<CommentQueryVM> Children { get; set; }
    }
}