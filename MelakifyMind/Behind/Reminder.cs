using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelakifyMind.Behind
{
    public class Reminder
    {
        public string Description { get; set; }
        public int DaysBefore { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public bool IsChecked { get; set; }
        public int ShowDay { get; set; }
        public int ShowMonth { get; set; }
        public int ShowYear { get; set; }

        public Reminder() { }
        public Reminder(string description, int daysBefore, int day, int month, int year, bool isChecked)
        {
            Description = description;
            DaysBefore = daysBefore;
            Day = day;
            Month = month;
            Year = year;
            IsChecked = isChecked;
        }
    }
}
