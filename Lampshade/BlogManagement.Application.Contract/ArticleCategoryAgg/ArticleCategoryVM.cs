using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;
using Microsoft.AspNetCore.Http;

namespace BlogManagement.Application.Contract.ArticleCategoryAgg
{
    public class CreateArticleCategoryVM
    {
        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile PictureName { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }

        [Range(1,int.MaxValue,ErrorMessage = ValidateMessage.IsRequired)]
        public int ShowOrder { get; set; }
        
        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string Slug { get;  set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string Keywords { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string MetaDescription { get; set; }
        public string CanonicalUrl { get; set; }
    }

    public class EditArticleCategoryVM : CreateArticleCategoryVM
    {
        public long Id { get; set; }
    }

    public class AdminArticleCategoryVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureName { get; set; }
        public int ShowOrder { get; set; }
        public int ArticleCount { get; set; }
        public string CreationDate { get; set; }
    }

    public class SearchArticleCategoryVM
    {
        public string Name { get; set; }
    }
}
