using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTPersianUtils;
using System.Windows.Controls;
using DNTPersianUtils.Core;
using System.Windows.Media;

namespace melakify.Entities.Behind
{
    public class Reminder
    {
        public string Description { get; set; }
        public int DaysBefore { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int ShowDay { get; set; }
        public int ShowMonth { get; set; }
        public int ShowYear { get; set; }
        public string IsImportant { get; set; }

        public SolidColorBrush ImportantColor
        {
            get
            {
                if (IsImportant == "مهم")
                {
                    return System.Windows.Media.Brushes.DarkGoldenrod;
                }
                else
                {
                    return System.Windows.Media.Brushes.DarkGray;
                }
            }
        }

        public string DateFolder
        {
            get
            {
                return $"{Year:0000}/{Month:00}/{Day:00}";
            }
        }

        public string GregorianDateFolder
        {
            get
            {
                return $"{Year:0000}/{Month:00}/{Day:00}".ToGregorianDateTime().Value.ToShortDateString();
            }
        }

        public string DaysDistance
        {
            get
            {
                if ((Day == new PersianCalendar().GetDayOfMonth(DateTime.Now)) && (Month == new PersianCalendar().GetMonth(DateTime.Now)) && (Year == new PersianCalendar().GetYear(DateTime.Now)))
                {
                    return "امروز";
                }
                else if (($"{Year:0000}/{Month:00}/{Day:00}".ToGregorianDateTime().Value.Subtract(DateTime.Now).Days + 1) == 1)
                {
                    return "فردا";
                }
                else if (($"{Year:0000}/{Month:00}/{Day:00}".ToGregorianDateTime().Value.Subtract(DateTime.Now).Days + 1) == 2)
                {
                    return "پس فردا";
                }
                else if (($"{Year:0000}/{Month:00}/{Day:00}".ToGregorianDateTime().Value.Subtract(DateTime.Now).Days + 1) <= 0)
                {
                    return "گذشته";
                }
                else
                {
                    return ($"{Year:0000}/{Month:00}/{Day:00}".ToGregorianDateTime().Value.Subtract(DateTime.Now).Days + 1).ToString() + " روز دیگر";
                }
            }
        }

        public string Matter
        {
            get
            {
                if (IsImportant == "مهم")
                {
                    return "دارای یادآور مهم";
                }
                else
                {
                    return "یادآور مهم ندارد";
                }
            }
        }
    }
}
