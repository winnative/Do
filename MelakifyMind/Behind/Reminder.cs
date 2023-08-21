using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Windows.Media.Devices;

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

        public static void Read(ListBox listBox)
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
