using Emtudio.Systems.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emtudio.Systems.Operations
{
    public class DataUpdater
    {
        static ReminderContext context = new ReminderContext();

        public static void Update(Reminder reminder)
        {
            context.Update(reminder);
            context.SaveChanges();
        }

        public static void Update(int id)
        {
            foreach (var item in context.Reminders)
            {
                if (item.ID == id)
                {
                    context.Reminders.Update(item);
                }
            }
            context.SaveChanges();
        }
    }
}
