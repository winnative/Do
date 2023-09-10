using Emtudio.Systems.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emtudio.Systems.Operations
{
    public static class DataSaver
    {
        static ReminderContext context = new ReminderContext();
        public static void Save(Reminder reminder)
        {
            context.Reminders.Add(reminder);
            context.SaveChanges();
        }

        public static void Save(string description, DateTime dateTime, bool isImportant, int daysBefore)
        {
            Reminder reminder = new Reminder() {Description = description, Time = dateTime, IsImportant = isImportant, DaysBefore = daysBefore };

            context.Reminders.Add(reminder);
            context.SaveChanges();
        }
    }
}
