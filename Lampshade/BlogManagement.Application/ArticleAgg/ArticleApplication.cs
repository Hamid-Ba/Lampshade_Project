using System.Collections.Generic;
using _0_Framework.Application;
using BlogManagement.Application.Contract.ArticleAgg;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using Framework.Application;

namespace BlogManagement.Application.ArticleAgg
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleCategoryRepository _categoryRepository;

        public ArticleApplication(IArticleRepository articleRepository, IArticleCategoryRepository categoryRepository)
        {
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
        }

        public OperationResult Create(CreateArticleVM command)
        {
            OperationResult result = new OperationResult();

            if (_articleRepository.IsExist(a => a.Title == command.Title))
                return result.Failed(ValidateMessage.IsDuplicatedName);

            var slug = command.Slug.Slugify();
            var categorySlug = _categoryRepository.GetCategorySlugBy(command.CategoryId);
            var path = $"{categorySlug}/{slug}";
            var pictureName = Uploader.ImageUploader(command.PictureName, path, null!);

            var article = new Article(command.Title, command.CategoryId, pictureName, command.PictureAlt,
                command.PictureTitle, command.PublishDate.ToGeorgianDateTime(), command.ShortDescription,
                command.Description, slug, command.Keywords, command.MetaDescription, command.CanonicalUrl);

            _articleRepository.Create(article);
            _articleRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Edit(EditArticleVM command)
        {
            OperationResult result = new OperationResult();

            var article = _articleRepository.Get(command.Id);
            if (article == null) return result.Failed(ValidateMessage.IsExist);

            if (_articleRepository.IsExist(a => a.Title == command.Title && a.Id != command.Id))
                return result.Failed(ValidateMessage.IsDuplicated);

            var slug = command.Slug.Slugify();
            var categorySlug = _categoryRepository.GetCategorySlugBy(command.CategoryId);
            var path = $"{categorySlug}/{slug}";
            var pictureName = Uploader.ImageUploader(command.PictureName, path, article.PictureName);

            article.Edit(command.Title, command.CategoryId, pictureName, command.PictureAlt,
                command.PictureTitle, command.PublishDate.ToGeorgianDateTime(), command.ShortDescription,
                command.Description, slug, command.Keywords, command.MetaDescription, command.CanonicalUrl);
            _articleRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Delete(long id)
        {
            OperationResult result = new OperationResult();

            var article = _articleRepository.Get(id);
            if (article == null) return result.Failed(ValidateMessage.IsExist);

            var slug = article.Slug;
            var categorySlug = _categoryRepository.GetCategorySlugBy(article.CategoryId);
            var folderName = $"{categorySlug}\\{slug}";

            article.Delete();
            Uploader.DirectoryRemover(folderName);

            _articleRepository.SaveChanges();
            return result.Succeeded();
        }

        public IEnumerable<AdminArticleVM> GetAllForAdmin(SearchArticleVM search) => _articleRepository.GetAllForAdmin(search);

        public EditArticleVM GetDetailsForEdit(long id) => _articleRepository.GetDetailsForEdit(id);
    }
}
