using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;
using Microsoft.AspNetCore.Http;

namespace BlogManagement.Application.Contract.ArticleAgg
{
    public class CreateArticleVM
    {
        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string Title { get; set; }

        [Range(1,int.MaxValue,ErrorMessage = ValidateMessage.IsRequired)]
        public long CategoryId { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        [MaxFileSize(3 * 1024 *1024,ErrorMessage = ValidateMessage.InvalidFileSize)]
        public IFormFile PictureName { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string PictureTitle { get; set; }
        public string PublishDate { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string Description { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string Slug { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string Keywords { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string MetaDescription { get; set; }
        public string CanonicalUrl { get; set; }
    }

    public class EditArticleVM : CreateArticleVM
    {
        public long Id { get; set; }
    }

    public class AdminArticleVM
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string PictureName { get; set; }
        public string PublishDate { get; set; }
        public string ShortDescription { get; set; }
        public string CreationDate { get; set; }
    }

    public class SearchArticleVM
    {
        public string Title { get; set; }
        public long CategoryId { get; set; }
    }
}
