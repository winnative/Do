using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace melakify.Automation.Behind
{
    public static class AutoBack
    {
        public static class DateTime
        {
            public static int GetMonth(System.DateTime time)
            {
                return new PersianCalendar().GetMonth(time);
            }

            public static int GetYear(System.DateTime time)
            {
                return new PersianCalendar().GetYear(time);
            }

            public static int GetDay(System.DateTime time)
            {
                return new PersianCalendar().GetDayOfMonth(time);
            }

            public static class Convert
            {
                public static (string name, int number)[] MonthConnection = { ("فروردین", 1), ("اردیبهشت", 2), ("خرداد", 3), ("تیر", 4), ("مرداد", 5), ("شهریور", 6), ("مهر", 7), ("آبان", 8), ("آذر", 9), ("دی", 10), ("بهمن", 11), ("اسفند", 12) };
                public static string ToMonthName(int monthNumber)
                {
                    return MonthConnection.OrderBy(x => x.number).Where(x => x.number == monthNumber).Select(x => x.name).First();
                }

                public static int ToMonthNumber(string monthName)
                {
                    return MonthConnection.OrderBy(x => x.name).Where(x => x.name == monthName).Select(x => x.number).First();
                }
            }
        }
    }
}
