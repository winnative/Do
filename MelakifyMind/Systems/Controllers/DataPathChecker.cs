using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;
using Emtudio.Systems.Entities;

namespace Emtudio.Systems.Controllers
{
    public static class DataPathChecker
    {
        static ReminderContext context = new ReminderContext();
        public static string Path { get { return @"AppData\base.emlite"; } }
        public async static void PathChecker()
        {
            if (!File.Exists(Path))
            {
                if (!Directory.Exists(@"AppData"))
                {
                    Directory.CreateDirectory(@"AppData");
                }
                SQLiteConnection.CreateFile(Path);
            }
            context.Database.EnsureCreated();
        }
    }
}
