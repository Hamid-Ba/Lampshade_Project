using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application
{
    public class ValidateMessage
    {
        public const string IsRequired = "این مقدار نمی تواند خالی باشد";
        public const string IsDuplicatedName = "این نام وجود دارد";
        public const string IsDuplicated = "این رکورد وجود دارد";
        public const string IsExist = "این رکورد در سرور وجود ندارد";
        public const string InvalidFileSize = "تصویر انتخاب شده بیشتر از حجم مجاز می باشد!";
    }
}
