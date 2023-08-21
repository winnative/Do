using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using melakify.Entities.Behind;
using System.Globalization;
using Newtonsoft.Json;

namespace melakify.Behind.ML
{
    public class ML2
    {
        List<Reminder> reminders = new List<Reminder>();
        public enum Command
        {
            Read,
            Delete,
            Create,
            Update,
            Abort
        }

        public string UserText { get; set; }
        public List<(string text,string rule)> mind= new List<(string text,string rule)> ();
        
        public ML2(string userText)
        {
            this.UserText = userText;
            Remembering();
        }

        public ML2()
        {
            Remembering();
        }

        void Remembering()
        {
            reminders = JsonConvert.DeserializeObject<List<Reminder>>(File.ReadAllText("DOs.json"));

            string[] text = File.ReadAllLines("MLData.txt");

            for (int i = 0; i < text.Length; i++)
            {
                string tex = text[i].Trim().Split(',', StringSplitOptions.RemoveEmptyEntries)[0];
                string rul = text[i].Trim().Split(',', StringSplitOptions.RemoveEmptyEntries)[1];

                mind.Add((tex, rul));
            }
        }

        Command GetCommand(string userText)
        {
            string[] words = userText.TrimEnd('.').Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<string> shareWords = new List<string>();
            Command command = Command.Abort;

            for(int i = 0; i < words.Length; i++)
            {
                for(int j = 0; j < mind.Count; j++)
                {
                    if (words[i] == mind[j].text)
                    {
                        shareWords.Add(mind[j].rule);
                    }
                }
            }

            if (shareWords.Contains("vrb"))
            {
                if (shareWords.Contains("c"))
                {
                    command = Command.Create;
                }
                else if(shareWords.Contains("d"))
                {
                    command = Command.Delete;
                }
                else if (shareWords.Contains("s"))
                {
                    command = Command.Read;
                }
                else if (shareWords.Contains("u"))
                {
                    command = Command.Update;
                }
            }
            else if (shareWords.Contains("ipr"))
            {

            }

            return command;
        }

        string GetDescription(string userText)
        {
            string description = "";
            if (userText.Contains("\""))
            {
                description = userText.Substring(userText.IndexOf("\"") + 1, (userText.LastIndexOf("\"") - userText.IndexOf("\"")));
                description = description.Trim('"');

                return description;
            }
            else if (userText.Contains("'"))
            {
                description = userText.Substring(userText.IndexOf("\'") + 1, (userText.LastIndexOf("\'") - userText.IndexOf("\'")));
                description = description.Trim('\'');

                return description;
            }
            else
            {
                return "لطفا توضیحات را داخل کوتیشن یا دابل کوتیشن وارد کنید.";
            }
        }

        public Reminder ReturnPredict(string userText)
        {
            Command command = GetCommand(userText);
            string description = "";
            Reminder reminder = new Reminder();

            if (command == Command.Create)
            {
                description = GetDescription(userText);
            }
            else if (command == Command.Update)
            {

            }
            else if (command == Command.Read)
            {

            }
            else if (command == Command.Delete)
            {

            }
            else if (command == Command.Abort)
            {

            }
            else
            {
                 
            }

            return reminder;
        }

        int CreateReminder(string description, int daysBefore, int day, int month, int year)
        {
            Reminder newReminder = new Reminder();
            newReminder.Description = description;
            newReminder.DaysBefore = daysBefore;
            newReminder.Day = day;
            newReminder.Month = month;
            newReminder.Year = year;

            if ((newReminder.Day - newReminder.DaysBefore) < 1)
            {
                if (newReminder.Month == 1)
                {
                    if (new PersianCalendar().IsLeapYear(newReminder.Year - 1))
                    {
                        newReminder.ShowDay = 29 + (newReminder.Day - newReminder.DaysBefore);
                    }
                    else
                    {
                        newReminder.ShowDay = 30 + (newReminder.Day - newReminder.DaysBefore);
                    }
                    newReminder.ShowYear = newReminder.Year - 1;
                    newReminder.ShowMonth = 12;
                }
                else if (newReminder.Month > 1 && newReminder.Month <= 6)
                {
                    newReminder.ShowDay = 31 + (newReminder.Day - newReminder.DaysBefore);
                    newReminder.ShowMonth = newReminder.Month - 1;
                    newReminder.ShowYear = newReminder.Year;
                }
                else if (newReminder.Month > 6 && newReminder.Month <= 12)
                {
                    newReminder.ShowDay = 30 + (newReminder.Day - newReminder.DaysBefore);
                    newReminder.ShowMonth = newReminder.Month - 1;
                    newReminder.ShowYear = newReminder.Year;
                }
            }
            else
            {
                newReminder.ShowYear = newReminder.Year;
                newReminder.ShowMonth = newReminder.Month;
                newReminder.ShowDay = newReminder.Day - newReminder.DaysBefore;
            }

            try
            {
                reminders.Add(newReminder);
                File.WriteAllText("DOs.json", JsonConvert.SerializeObject(reminders));
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
