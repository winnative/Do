using Emtudio.Systems.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emtudio.Systems.Operations
{
    public static class DataReader
    {
        static ReminderContext context = new ReminderContext();
        public static IList<Reminder> GetReminders()
        {
            return context.Reminders.ToList();
        }

        public static IList<int> GetIDs()
        {
            IList<int> ids = new List<int>();
            foreach (var item in context.Reminders)
            {
                ids.Add(item.ID);
            }
            return ids;
        }

        public static IList<string> GetDescriptions()
        {
            IList<string> descriptions = new List<string>();
            foreach (var item in context.Reminders)
            {
                descriptions.Add(item.Description);
            }
            return descriptions;
        }
    }
}
