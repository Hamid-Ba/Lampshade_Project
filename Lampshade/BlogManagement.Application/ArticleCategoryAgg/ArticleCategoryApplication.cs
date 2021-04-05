using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogManagement.Application.Contract.ArticleCategoryAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using Framework.Application;

namespace BlogManagement.Application.ArticleCategoryAgg
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository) => _articleCategoryRepository = articleCategoryRepository;

        public OperationResult Create(CreateArticleCategoryVM command)
        {
            OperationResult result = new OperationResult();

            if (_articleCategoryRepository.IsExist(c => c.Name == command.Name))
                return result.Failed(ValidateMessage.IsDuplicatedName);

            var slug = command.Slug.Slugify();
            var pictureName = Uploader.ImageUploader(command.PictureName, slug, null!);

            var category = new ArticleCategory(command.Name, command.Description, pictureName, command.PictureAlt,
                command.PictureTitle, command.ShowOrder,
                slug, command.Keywords, command.MetaDescription, command.CanonicalUrl);

            _articleCategoryRepository.Create(category);
            _articleCategoryRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Edit(EditArticleCategoryVM command)
        {
            OperationResult result = new OperationResult();

            var category = _articleCategoryRepository.Get(command.Id);
            if (category == null) return result.Failed(ValidateMessage.IsExist);

            if (_articleCategoryRepository.IsExist(c => c.Name == command.Name && c.Id != command.Id))
                return result.Failed(ValidateMessage.IsDuplicated);

            var slug = command.Slug.Slugify();
            var pictureName = Uploader.ImageUploader(command.PictureName, slug, category.PictureName);

            category.Edit(command.Name, command.Description, pictureName, command.PictureAlt,
                command.PictureTitle, command.ShowOrder,
                slug, command.Keywords, command.MetaDescription, command.CanonicalUrl);
            _articleCategoryRepository.SaveChanges();

            return result.Succeeded();
        }

        public OperationResult Delete(long id)
        {
            OperationResult result = new OperationResult();

            var category = _articleCategoryRepository.Get(id);
            if (category == null) return result.Failed(ValidateMessage.IsExist);

            var slug = category.Slug;

            category.Delete();

            Uploader.DirectoryRemover(slug);

            _articleCategoryRepository.SaveChanges();

            return result.Succeeded();
        }

        public IEnumerable<AdminArticleCategoryVM> GetAllForAdmin(SearchArticleCategoryVM search) => _articleCategoryRepository.GetAllForAdmin(search);
        public IEnumerable<SearchArticleCategoryVM> GetAllForSearch() => _articleCategoryRepository.GetAllForSearch();
        public EditArticleCategoryVM GetDetailForEdit(long id) => _articleCategoryRepository.GetDetailForEdit(id);
    }
}
