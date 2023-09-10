using Emtudio.Systems.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emtudio.Systems.Operations
{
    public static class DataDeleter
    {
        static ReminderContext context = new ReminderContext();
        public static void Delete(Reminder reminder)
        {
            context.Reminders.Remove(reminder);
            context.SaveChanges();
        }

        public static void Delete(int id)
        {
            foreach (var item in context.Reminders)
            {
                if (item.ID == id)
                {
                    context.Reminders.Remove(item);
                }
            }
           context.SaveChanges();
        }
    }
}
