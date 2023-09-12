using melakify.Entities.Behind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Emtudio.Systems.Entities
{
    public class Folder
    {
        public string Date { get; set; }
        public string ReminderCount
        {
            get
            {
                return $"{Reminders.Count} یادآور";
            }
        }

        public SolidColorBrush ImportantColor
        {
            get
            {
                SolidColorBrush brush = new SolidColorBrush();
                int i = 0;
                foreach (var item in Reminders)
                {
                    if (item.IsImportant)
                    {
                        i++;
                    }
                    else
                    {
                        
                    }
                }

                if (i > 0)
                {
                    brush = System.Windows.Media.Brushes.DarkGoldenrod;
                }
                else
                {
                    brush = System.Windows.Media.Brushes.White;
                }

                return brush;
            }
        }

        public string ReminderComment
        {
            get
            {
                return $"تمامی یادآور ها در تاریخ {Date}";
            }
        }

        public string ReminderImportant
        {
            get
            {
                int i = 0;
                bool isIt = false;
                foreach (var item in Reminders)
                {
                    if (item.IsImportant)
                    {
                        isIt = true;
                        i = i + 1;
                    }
                    else
                    {
                        
                    }
                }
                
                if (i > 0)
                {
                    return $"{i} یادآور مهم";
                }
                else
                {
                    return "یادآور مهم ندارد";
                }
            }
        }
        public ICollection<Reminder> Reminders { get; set; }
    }
}
