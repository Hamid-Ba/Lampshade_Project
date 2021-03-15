namespace ShopManagement.Application.Contracts.ProductCategoryAgg
{
    public class CreateProductCategoryVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; }
    }

    public class EditProductCategoryVM : CreateProductCategoryVM
    {
        public long Id { get; set; }
    }

    public class AdminProductCategoryVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string CreationDate { get; set; }
        public long ProductCount { get; set; }
    }
}
