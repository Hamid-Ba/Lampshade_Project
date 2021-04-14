namespace AccountManagement.Application.Contract.PermissionAgg
{
    public class AdminPermissionVM
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long? ParentId { get; set; }
    }
}
