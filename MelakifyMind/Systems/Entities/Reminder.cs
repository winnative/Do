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

        public int DaysDistance
        {
            get
            {
                return Time.Subtract(DateTime.Now).Days;
            }
        }
    }
}
