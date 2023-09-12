using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emtudio.Systems.Entities
{
    public partial class Reminder
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public bool IsImportant { get; set; }
        public int DaysBefore { get; set; }

        public string DaysDistance
        {
            get
            {
                if (Time.Date == DateTime.Now.Date)
                {
                    return "امروز";
                }
                else if (Time.Date < DateTime.Now.Date)
                {
                    return "گذشته";
                }
                else if (Time.Date == DateTime.Now.Date.AddDays(1))
                {
                    return "فردا";
                }
                else if (Time.Date == DateTime.Now.Date.AddDays(2))
                {
                    return "پس فردا";
                }
                else
                {
                    return $"{Time.Subtract(DateTime.Now).Days} روز دیگر";
                }
            }
        }

        public System.Windows.Media.SolidColorBrush ImportantColor
        {
            get
            {
                if (IsImportant)
                {
                    return System.Windows.Media.Brushes.DarkGoldenrod;
                }
                else
                {
                    return System.Windows.Media.Brushes.DarkGray;
                }
            }
        }
    }
}
