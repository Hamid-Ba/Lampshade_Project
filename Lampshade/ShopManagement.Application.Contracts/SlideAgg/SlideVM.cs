using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.SlideAgg
{
    public class CreateSlideVM
    {
        public string PictureName { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
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
    }

    public class DeleteSlideVM
    {
        public long Id { get; set; }
        public string Header { get; set; }
    }
}
