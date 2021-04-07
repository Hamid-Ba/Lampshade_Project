using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Presentation
{
    public static class DateFormat
    {
        public static string ToDayByDate(this string date) => date.Substring(8);

        public static string ToMonthByDate(this string date)
        {
            var month = int.Parse(date.Substring(5, 2));

            return month switch
            {
                1 => "فروردین",
                2 => "اردیبهشت",
                3 => "خرداد",
                4 => "تیر",
                5 => "مرداد",
                6 => "شهریور",
                7 => "مهر",
                8 => "آبان",
                9 => "آذر",
                10 => "دی",
                11 => "بهمن",
                12 => "اسفند",
                _ => ""
            };
        }
    }

    public enum Month
    {
        Far = 1,
        Ord,
        Kho,
        Tir,
        Mor,
        Sha,
        Mehr,
        Aban,
        Azar,
        Dey,
        Bahman,
        Esfand
    }
}
