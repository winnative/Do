using melakify.UI.BackDrop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using melakify.Entities.Behind;
using System.IO;
using System.Globalization;
using MelakifyMind.Properties;
using MelakifyMind;
using melakify.Automation.UI;
using System.Data.SQLite;
using System.Net;
using System.Drawing;
using System.Windows.Forms;

namespace melakify.Do
{
    /// <summary>
    /// Interaction logic for ToastWindow.xaml
    /// </summary>
    public partial class ToastWindow : Window
    {
        Storyboard storyToastClose = new Storyboard();
        List<Reminder> reminders = new List<Reminder>();
        PersianCalendar persian = new PersianCalendar();
        SQLiteConnection connection = new SQLiteConnection(@"DataSource = C:\melakify\+Do\DOs.sqlite; Version = 3;");
        SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS TblReminder (Description varchar(50), DaysBefore int, Day int, Month int, Year int, ShowDay int, ShowMonth int, ShowYear int, IsImportant varchar(4), IsChecked boolean)");
        SQLiteDataReader reader;
        DateTime time = DateTime.Now;

        public double CloseLeft { get; set; } = SystemParameters.PrimaryScreenWidth + 100;

        public const string Path = @"C:\melakify\+Do\DOs.sqlite";
        public ToastWindow()
        {
            InitializeComponent();
            if (!Settings.Default.FirstReminder)
            {
                MainWindow win = new MainWindow();
                win.Show();
                Close();
            }
        }

        private void StoryToastClose_Completed(object? sender, EventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!Directory.Exists(@"C:\melakify\+Do"))
                {
                    Directory.CreateDirectory(@"C:\melakify\+Do");
                }

                Topmost = true;
                DataContext = this;
                storyToastClose = (Storyboard)Resources["storyClose"];
                storyToastClose.Completed += StoryToastClose_Completed;


                try
                {
                    command.Connection = connection;
                    if (File.Exists(Path))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        command.CommandText = "SELECT * FROM TblReminder";
                        connection.Open();
                        reader = command.ExecuteReader();

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

                            reminders.Add(reminder);
                        }
                        connection.Close();

                        var result = from remind in reminders
                                     where remind.ShowDay == new PersianCalendar().GetDayOfMonth(DateTime.Now)
                                     where remind.ShowMonth == new PersianCalendar().GetMonth(DateTime.Now)
                                     where remind.ShowYear == new PersianCalendar().GetYear(DateTime.Now)
                                     select remind;

                        if (result.Count() > 0)
                        {
                            textBlockDescription.Text = result.ToList()[0].Description.ToString();
                            textBlockDaysDistance.Text = result.ToList()[0].DaysDistance.ToString();
                            buttonDismiss.Visibility = Visibility.Visible;
                            buttonSnooze.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            textBlockDescription.Text = "سلام. برای امروز یادآوری ندارید.";
                            buttonSnooze.Visibility = Visibility.Collapsed;
                            buttonDismiss.Visibility = Visibility.Visible;
                        }
                        
                    }
                    else
                    {
                        SQLiteConnection.CreateFile(Path);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                        textBlockDescription.Text = "با سلام. یادآوری در حافظه برنامه وجود ندارد!";
                    }
                }
                finally
                {
                    connection.Close();
                }

                Left = SystemParameters.PrimaryScreenWidth - Width;
                Top = SystemParameters.PrimaryScreenHeight - Height - 64;
                

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            storyToastClose.Begin();
        }

        private void buttonCloseNow_Click(object sender, RoutedEventArgs e)
        {
            Topmost = false;
            MainWindow win = new MainWindow();
            win.Show();
            storyToastClose.Begin();
        }

        private void buttonDismiss_Click(object sender, RoutedEventArgs e)
        {
            storyToastClose.Begin();
        }
    }
}
