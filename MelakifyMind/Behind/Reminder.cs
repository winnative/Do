using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTPersianUtils;
using System.Windows.Controls;
using DNTPersianUtils.Core;

namespace melakify.Entities.Behind
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
        public string IsImportant { get; set; }

        public string DaysDistance
        {
            get
            {
                if (($"{Year:0000}/{Month:00}/{Day:00}".ToGregorianDateTime().Value.Subtract(DateTime.Now).Days + 1) == 0)
                {
                    return "امروز";
                }
                else if (($"{Year:0000}/{Month:00}/{Day:00}".ToGregorianDateTime().Value.Subtract(DateTime.Now).Days + 1) == 1)
                {
                    return "فردا";
                }
                else if (($"{Year:0000}/{Month:00}/{Day:00}".ToGregorianDateTime().Value.Subtract(DateTime.Now).Days + 1) == 2)
                {
                    return "پس فردا";
                }
                else
                {
                    return ($"{Year:0000}/{Month:00}/{Day:00}".ToGregorianDateTime().Value.Subtract(DateTime.Now).Days + 1).ToString() + " روز مانده";
                }
            }
        }

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

        public static void Read(System.Windows.Controls.ListBox listBox)
        {
            List<Reminder> list = new List<Reminder>();

            SQLiteConnection connection = new SQLiteConnection("DataSource=DOs.sqlite;Version=3;");
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM TblReminder", connection);

            connection.Open();
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Reminder reminder = new Reminder();
                reminder.Description = (string)reader["Description"];
                reminder.DaysBefore = (int)reader["DaysBefore"];
                reminder.Day = (int)reader["Day"];
                reminder.Month = (int)reader["Month"];
                reminder.Year = (int)reader["Year"];
                reminder.ShowDay = (int)reader["ShowDay"];
                reminder.ShowMonth = (int)reader["ShowMonth"];
                reminder.ShowYear = (int)reader["ShowYear"];
                reminder.IsImportant = (string)reader["IsImportant"];

                list.Add(reminder);
            }

            listBox.ItemsSource = list;
        }

        public static void Delete(Reminder reminder)
        {

        }
    }
}
