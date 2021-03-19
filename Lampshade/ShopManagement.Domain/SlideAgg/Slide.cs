using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain;

namespace ShopManagement.Domain.SlideAgg
{
    public class Slide : EntityBaseModel
    {
        public string PictureName { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Header { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public string BtnText { get; private set; }

        public Slide(string pictureName, string pictureAlt, string pictureTitle, string header, string title, string text, string btnText)
        {
            PictureName = pictureName;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Header = header;
            Title = title;
            Text = text;
            BtnText = btnText;
        }

        public void Edit(string pictureName, string pictureAlt, string pictureTitle, string header, string title, string text, string btnText)
        {
            PictureName = pictureName;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Header = header;
            Title = title;
            Text = text;
            BtnText = btnText;
        }

        public void Delete() => IsDeleted = true;

    }
}
