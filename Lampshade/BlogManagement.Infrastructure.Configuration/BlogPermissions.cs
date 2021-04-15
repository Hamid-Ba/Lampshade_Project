namespace BlogManagement.Infrastructure.Configuration
{
    public static class BlogPermissions
    {
        public static int BlogManagement { get; private set; } = 15;
        public static int ArticleList { get; private set; } = 50;
        public static int CreateArticle { get; private set; } = 51;
        public static int EditArticle { get; private set; } = 52;
        public static int DeleteArticle { get; private set; } = 53;
        public static int CategoryList { get; private set; } = 54;
        public static int CreateCategory { get; private set; } = 55;
        public static int EditCategory { get; private set; } = 56;
        public static int DeleteCategory { get; private set; } = 57;
    }
}
