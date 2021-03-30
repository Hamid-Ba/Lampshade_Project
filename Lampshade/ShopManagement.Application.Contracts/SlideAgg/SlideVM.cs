using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contracts.SlideAgg
{
    public class CreateSlideVM
    {
        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public IFormFile PictureName { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = ValidateMessage.IsRequired)]
        public string Link { get; set; }

        public string Header { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string BtnText { get; set; }
    }

    public class EditSlideVM : CreateSlideVM
    {
        public long Id { get; set; }
    }

    public class AdminSlideVM
    {
        public long Id { get; set; }
        public string PictureName { get; set; }
        public string Header { get; set; }
        public string Title { get; set; }
        public string CreationDate { get; set; }
    }

    public class DeleteSlideVM
    {
        public long Id { get; set; }
        public string Header { get; set; }
    }
}
