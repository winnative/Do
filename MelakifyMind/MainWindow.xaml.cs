using melakify.Automation.UI;
using melakify.Entities.Behind;
using melakify.UI.BackDrop;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using melakify.Do;
using melakify.Automation.UI;
using melakify.Behind.ML;
using System.Collections;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
using System.Globalization;
using static melakify.Behind.ML.ML2;
using System.Data.SQLite;
using System.Reflection.PortableExecutable;
using melakify.Automation.Behind;
using MelakifyMind.Properties;
using DNTPersianUtils.Core;
using Microsoft.Win32;
using MelakifyMind.Behind;
using System.Linq.Expressions;

namespace melakify.Do
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SolidColorBrush selectedPalette { get; set; }
        public void ShowMessage(string message, string title, string primaryText = "باشه")
        {
            borderMessage.Visibility = Visibility.Visible;
            borderMessageBack.Visibility = Visibility.Visible;

            textBlockMessageTitle.Text = title;
            textBlockMessageComment.Text = message;
            buttonMessageOK.Content = primaryText;

            storyMessageDialogOpen.Begin();
        }

        public void RefreshCalendarDays()
        {
            for (int i = 0; i < 42; i++)
            {
                ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i]).IsEnabled = false;
                ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i]).Content = "";
            }

            DateTime? time = $"{YearNumber}/{MonthNumber}/{1}".ToGregorianDateTime();
            int firstWeekDay = AutoBack.DateTime.Convert.ToNumberWeekDay(time.Value.DayOfWeek.ToString());

            switch (firstWeekDay)
            {
                case 1:
                    if (MonthNumber >= 1 && MonthNumber <= 6)
                    {
                        for (int i = 0; i < 31; i++)
                        {
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i]).Content = i + 1;
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i]).IsEnabled = true;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 30; i++)
                        {
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i]).Content = i + 1;
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i]).IsEnabled = true;
                        }
                    }
                    break;
                case 2:
                    if (MonthNumber >= 1 && MonthNumber <= 6)
                    {
                        for (int i = 0; i < 31; i++)
                        {
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 1]).Content = i + 1;
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 1]).IsEnabled = true;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 30; i++)
                        {
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 1]).Content = i + 1;
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 1]).IsEnabled = true;
                        }
                    }
                    break;
                case 3:
                    if (MonthNumber >= 1 && MonthNumber <= 6)
                    {
                        for (int i = 0; i < 31; i++)
                        {
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 2]).Content = i + 1;
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 2]).IsEnabled = true;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 30; i++)
                        {
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 2]).Content = i + 1;
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 2]).IsEnabled = true;
                        }
                    }
                    break;
                case 4:
                    if (MonthNumber >= 1 && MonthNumber <= 6)
                    {
                        for (int i = 0; i < 31; i++)
                        {
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 3]).Content = i + 1;
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 3]).IsEnabled = true;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 30; i++)
                        {
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 3]).Content = i + 1;
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 3]).IsEnabled = true;
                        }
                    }
                    break;
                case 5:
                    if (MonthNumber >= 1 && MonthNumber <= 6)
                    {
                        for (int i = 0; i < 31; i++)
                        {
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 4]).Content = i + 1;
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 4]).IsEnabled = true;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 30; i++)
                        {
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 4]).Content = i + 1;
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 4]).IsEnabled = true;
                        }
                    }
                    break;
                case 6:
                    if (MonthNumber >= 1 && MonthNumber <= 6)
                    {
                        for (int i = 0; i < 31; i++)
                        {
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 5]).Content = i + 1;
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 5]).IsEnabled = true;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 30; i++)
                        {
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 5]).Content = i + 1;
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 5]).IsEnabled = true;
                        }
                    }
                    break;
                case 7:
                    if (MonthNumber >= 1 && MonthNumber <= 6)
                    {
                        for (int i = 0; i < 31; i++)
                        {
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 6]).Content = i + 1;
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 6]).IsEnabled = true;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 30; i++)
                        {
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 6]).Content = i + 1;
                            ((System.Windows.Controls.Button)gridDaysOfCalendar.Children[i + 6]).IsEnabled = true;
                        }
                    }
                    break;
            }
        }

        public int GetLastDayOfWeek()
        {
            int dayOfWeek = DateTime.Now.GetPersianWeekDayNumber();
            int result = new PersianCalendar().GetDayOfMonth(DateTime.Now) + (7 - dayOfWeek);
            return result;
        }

        public int GetFirstDayOfWeek()
        {
            int dayOfWeek = DateTime.Now.GetPersianWeekDayNumber();
            int result = new PersianCalendar().GetDayOfMonth(DateTime.Now) - (dayOfWeek - 1);
            return result;
        }

        public void Refresh()
        {
            try
            {
                command.Connection = connection;
                if (File.Exists(Path))
                {
                    command.CommandText = "CREATE TABLE IF NOT EXISTS TblReminder (Description varchar(50), DaysBefore int, Day int, Month int, Year int, ShowDay int, ShowMonth int, ShowYear int, IsImportant varchar(4))";
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    command.CommandText = "SELECT * FROM TblReminder";
                    connection.Open();
                    reader = command.ExecuteReader();
                    reminders.Clear();
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
                    reader.Close();
                    connection.Close();
                }
                else
                {
                    SQLiteConnection.CreateFile(Path);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch
            {
                
            }
            finally
            {
                connection.Close();
            }

            if (reminders.Count > 0)
            {
                gridTimes.Visibility = Visibility.Visible;
                textBlockNoReminder.Visibility = Visibility.Collapsed;
                imageNoReminder.Visibility = Visibility.Collapsed;
                textBlockNoReminderComment.Visibility = Visibility.Collapsed;

                var all = from a in reminders
                          select a;

                var fewDays = from f in reminders
                              where $"{f.Year:0000}/{f.Month:00}/{f.Day:00}".ToGregorianDateTime().Value.Subtract(DateTime.Now).Days >= 1 && $"{f.Year:0000}/{f.Month:00}/{f.Day:00}".ToGregorianDateTime().Value.Subtract(DateTime.Now).Days <= 3
                              where f.Month == new PersianCalendar().GetMonth(DateTime.Now)
                              where f.Year == new PersianCalendar().GetYear(DateTime.Now)
                              where $"{f.Year:0000}/{f.Month:00}/{f.Day:00}".ToGregorianDateTime().Value.Subtract(DateTime.Now).Days >= 0
                              select f;

                var week = from w in reminders
                           where (w.Day <= GetLastDayOfWeek()) && (w.Day >= GetFirstDayOfWeek())
                           where w.Month == new PersianCalendar().GetMonth(DateTime.Now)
                           where w.Year == new PersianCalendar().GetYear(DateTime.Now)
                           where $"{w.Year:0000}/{w.Month:00}/{w.Day:00}".ToGregorianDateTime().Value.Subtract(DateTime.Now).Days >= 0
                           select w;

                var month = from m in reminders
                            where m.Month == new PersianCalendar().GetMonth(DateTime.Now)
                            where m.Year == new PersianCalendar().GetYear(DateTime.Now)
                            where $"{m.Year:0000}/{m.Month:00}/{m.Day:00}".ToGregorianDateTime().Value.Subtract(DateTime.Now).Days >= 0
                            select m;

                var pin = from p in reminders
                          where p.IsImportant == "مهم"
                          select p;

                var expired = from exp in reminders
                              where $"{exp.Year:0000}/{exp.Month:00}/{exp.Day:00}".ToGregorianDateTime().Value.Subtract(DateTime.Now).Days < 0
                              select exp;

                var dateShortcut = (from ds in reminders
                                    where $"{ds.Year:0000}/{ds.Month:00}/{ds.Day:00}".ToGregorianDateTime().Value.Subtract(DateTime.Now).Days >= 0
                                    group ds by ds.DateFolder into folder
                                    select new { Reminders = folder, Title = folder.Key.ToString() }).ToList();

                if (dateShortcut.Count() > 0)
                {
                    folders.Clear();
                    listBoxTimeLine.Visibility = Visibility.Visible;
                    foreach(var d in dateShortcut)
                    {
                        foreach(var f in d.Reminders)
                        {
                            folders.Add(new Folder() { Date = d.Title, Reminders = d.Reminders.ToList() });
                        }
                    }

                    folders = folders.DistinctBy(d => d.Date).ToList();

                    listBoxTimeLine.ItemsSource = folders;
                }
                else
                {
                    listBoxTimeLine.Visibility = Visibility.Collapsed;
                }

                listBoxAllReminder.ItemsSource = all;
                
                if (month.Count() > 0)
                {
                    buttonThisMonth.Visibility = Visibility.Visible;
                    listBoxThisMonth.ItemsSource = month;
                }
                else
                {
                    buttonThisMonth.Visibility = Visibility.Collapsed;
                    listBoxThisMonth.Visibility = Visibility.Collapsed;

                    listBoxAllReminder.Visibility = Visibility.Visible;
                    buttonAllReminder.IsEnabled = false;
                    buttonThisMonth.IsEnabled = true;
                    buttonThisWeek.IsEnabled = true;
                    buttonExpiredReminder.IsEnabled = true;
                    buttonPinReminder.IsEnabled = true;
                    textBlockFilterTitle.Text = "همه یادآور ها";
                }

                if (week.Count() > 0)
                {
                    buttonThisWeek.Visibility = Visibility.Visible;
                    listBoxThisWeek.ItemsSource = week;
                }
                else
                {
                    buttonThisWeek.Visibility = Visibility.Collapsed;
                    listBoxThisWeek.Visibility = Visibility.Collapsed;

                    listBoxAllReminder.Visibility = Visibility.Visible;
                    buttonAllReminder.IsEnabled = false;
                    buttonThisMonth.IsEnabled = true;
                    buttonThisWeek.IsEnabled = true;
                    buttonExpiredReminder.IsEnabled = true;
                    buttonPinReminder.IsEnabled = true;
                    textBlockFilterTitle.Text = "همه یادآور ها";
                }

                if (expired.Count() > 0)
                {
                    buttonExpiredReminder.Visibility = Visibility.Visible;
                    listBoxExpiredReminder.ItemsSource = expired;
                }
                else
                {
                    buttonExpiredReminder.Visibility = Visibility.Collapsed;
                    listBoxExpiredReminder.Visibility = Visibility.Collapsed;

                    listBoxAllReminder.Visibility = Visibility.Visible;
                    buttonAllReminder.IsEnabled = false;
                    buttonThisMonth.IsEnabled = true;
                    buttonThisWeek.IsEnabled = true;
                    buttonExpiredReminder.IsEnabled = true;
                    buttonPinReminder.IsEnabled = true;
                    textBlockFilterTitle.Text = "همه یادآور ها";
                }

                if (pin.Count() > 0)
                {
                    buttonPinReminder.Visibility = Visibility.Visible;
                    listBoxPins.ItemsSource = pin;
                }
                else
                {
                    buttonPinReminder.Visibility = Visibility.Collapsed;
                    listBoxPins.Visibility = Visibility.Collapsed;

                    listBoxAllReminder.Visibility = Visibility.Visible;
                    buttonAllReminder.IsEnabled = false;
                    buttonThisMonth.IsEnabled = true;
                    buttonThisWeek.IsEnabled = true;
                    buttonExpiredReminder.IsEnabled = true;
                    buttonPinReminder.IsEnabled = true;
                    textBlockFilterTitle.Text = "همه یادآور ها";
                }
            }
            else
            {
                gridTimes.Visibility = Visibility.Collapsed;
                textBlockNoReminder.Visibility = Visibility.Visible;
                imageNoReminder.Visibility = Visibility.Visible;
                textBlockNoReminderComment.Visibility = Visibility.Visible;
                buttonThisWeek.Visibility = Visibility.Collapsed;
                buttonThisMonth.Visibility = Visibility.Collapsed;
                buttonExpiredReminder.Visibility = Visibility.Collapsed;
                buttonPinReminder.Visibility = Visibility.Collapsed;
                listBoxTimeLine.Visibility = Visibility.Collapsed;
            }

            if (Settings.Default.FolderWatch)
            {
                storyListOpenWithFolder.Begin();
            }
            else
            {
                storyListOpen.Begin();
            }
        }

        public void RecalculateYears()
        {
            int currentYear = new PersianCalendar().GetYear(DateTime.Now);

            for (int i = 0; i < 11; i++)
            {
                ((System.Windows.Controls.Button)wrapPanelCalendarYear.Children[i]).Content = (currentYear + i).ToString();
            }
        }

        public enum FlyoutIcon
        {
            Info,
            Error,
            Successful
        }

        public const string Path = @"C:\emtudio\+Do\base.sqlite";
        public object ListSelected = null;
        SQLiteConnection connection = new SQLiteConnection($"DataSource={Path}; Version=3;");
        SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS TblReminder (Description varchar(50), DaysBefore int, Day int, Month int, Year int, ShowDay int, ShowMonth int, ShowYear int, IsImportant varchar(4))");
        SQLiteDataReader reader;
        List<(string monthName, int monthNumber)> MonthConnection = new List<(string monthName, int monthNumber)>();
        Storyboard storyBoardExpandAI = new Storyboard();
        Storyboard storyBoardExpandAIClose = new Storyboard();
        Storyboard storyPreviewOpen = new Storyboard();
        Storyboard storyPreviewClose = new Storyboard();
        Storyboard storyAIOpen = new Storyboard();
        Storyboard storyAIClose = new Storyboard();
        Storyboard storyMessageOpen = new Storyboard();
        Storyboard storyMessageClose = new Storyboard();
        Storyboard storyContentOpen = new Storyboard();
        Storyboard storyContentClose = new Storyboard();
        Storyboard storySettingsOpen = new Storyboard();
        Storyboard storySettingsClose = new Storyboard();
        Storyboard storyMessageScreenClose = new Storyboard();
        Storyboard storyMessageScreen = new Storyboard();
        Storyboard storyMessageForceClose = new Storyboard();
        Storyboard storyAddOpen = new Storyboard();
        Storyboard storyAddClose = new Storyboard();
        Storyboard storyOnStartupEnable = new Storyboard();
        Storyboard storyOnStartupDisable = new Storyboard();
        Storyboard storyReminderFirstEnable = new Storyboard();
        Storyboard storyReminderFirstDisable = new Storyboard();
        Storyboard storyBackupEnable = new Storyboard();
        Storyboard storyBackupDisable = new Storyboard();
        Storyboard storyAllowTransEnable = new Storyboard();
        Storyboard storyAllowTransDisable = new Storyboard();
        Storyboard storyMessageDialogOpen = new Storyboard();
        Storyboard storyMessageDialogClose = new Storyboard();
        Storyboard storySettingsPerformanceOpen = new Storyboard();
        Storyboard storySettingsPerformanceClose = new Storyboard();
        Storyboard storySettingsUserOpen = new Storyboard();
        Storyboard storySettingsUserClose = new Storyboard();
        Storyboard storySettingsPersonalizeOpen = new Storyboard();
        Storyboard storySettingsPersonalizeClose = new Storyboard();
        Storyboard storySettingsDatabaseOpen = new Storyboard();
        Storyboard storySettingsDatabaseClose = new Storyboard();
        Storyboard storySettingsOptionsOpen = new Storyboard();
        Storyboard storySettingsOptionsClose = new Storyboard();
        Storyboard storyListOpenWithFolder = new Storyboard();
        Storyboard storyListCloseWithFolder = new Storyboard();
        Storyboard storyListOpen = new Storyboard();
        Storyboard storyListClose = new Storyboard();
        Storyboard storyListFolderOpen = new Storyboard();
        Storyboard storyListFolderClose = new Storyboard();
        Reminder newReminder = new Reminder();
        Reminder selectedReminder = new Reminder();
        List<Reminder> reminders = new List<Reminder>();
        List<Folder> folders = new List<Folder>();
        PersianCalendar persian = new PersianCalendar();
        public string DescriptionPreview { get; set; }
        public int DaysBefore { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public bool Acceptable { get; set; } = false;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            
            storyBoardExpandAI = (Storyboard)this.Resources["storyExpandAI"];
            storyBoardExpandAIClose = (Storyboard)this.Resources["storyExpandAIClose"];
            storyPreviewOpen = (Storyboard)this.Resources["storyPreviewOpen"];
            storyPreviewClose = (Storyboard)this.Resources["storyPreviewClose"];
            storyAIClose = (Storyboard)this.Resources["storyAIClose"];
            storyAIOpen = (Storyboard)this.Resources["storyAIOpen"];
            storyMessageOpen = (Storyboard)this.Resources["storyMessageOpen"];
            storyMessageClose = (Storyboard)this.Resources["storyMessageClose"];
            storyMessageForceClose = (Storyboard)this.Resources["storyMessageForceClose"];
            storyContentOpen = (Storyboard)this.Resources["storyContentOpen"];
            storyContentClose = (Storyboard)this.Resources["storyContentClose"];
            storySettingsOpen = (Storyboard)this.Resources["storySettingsOpen"];
            storySettingsClose = (Storyboard)this.Resources["storySettingsClose"];
            storyMessageScreenClose = (Storyboard)Resources["storyMessageScreenClose"];
            storyMessageScreen = (Storyboard)Resources["storyMessageScreen"];
            storyAddOpen = (Storyboard)Resources["storyAddOpen"];
            storyAddClose = (Storyboard)Resources["storyAddClose"];
            storyOnStartupEnable = (Storyboard)Resources["storyOnStartupEnable"];
            storyOnStartupDisable = (Storyboard)Resources["storyOnStartupDisable"];
            storyReminderFirstEnable = (Storyboard)Resources["storyReminderFirstEnable"];
            storyReminderFirstDisable = (Storyboard)Resources["storyReminderFirstDisable"];
            storyBackupEnable = (Storyboard)Resources["storyBackupEnable"];
            storyBackupDisable = (Storyboard)Resources["storyBackupDisable"];
            storyAllowTransEnable = (Storyboard)Resources["storyAllowTransEnable"];
            storyAllowTransDisable = (Storyboard)Resources["storyAllowTransDisable"];
            storyMessageDialogClose = (Storyboard)Resources["storyMessageDialogClose"];
            storyMessageDialogOpen = (Storyboard)Resources["storyMessageDialogOpen"];
            storySettingsOptionsOpen = (Storyboard)Resources["storySettingsOptionsOpen"];
            storySettingsOptionsClose = (Storyboard)Resources["storySettingsOptionsClose"];
            storySettingsPerformanceOpen = (Storyboard)Resources["storySettingsPerformanceOpen"];
            storySettingsPerformanceClose = (Storyboard)Resources["storySettingsPerformanceClose"];
            storySettingsUserOpen = (Storyboard)Resources["storySettingsUserOpen"];
            storySettingsUserClose = (Storyboard)Resources["storySettingsUserClose"];
            storySettingsPersonalizeOpen = (Storyboard)Resources["storySettingsPersonalizeOpen"];
            storySettingsPersonalizeClose = (Storyboard)Resources["storySettingsPersonalizeClose"];
            storySettingsDatabaseOpen = (Storyboard)Resources["storySettingsDatabaseOpen"];
            storySettingsDatabaseClose = (Storyboard)Resources["storySettingsDatabaseClose"];
            storyListOpenWithFolder = (Storyboard)Resources["storyListOpenWithFolder"];
            storyListCloseWithFolder = (Storyboard)Resources["storyListCloseWithFolder"];
            storyListOpen = (Storyboard)Resources["storyListOpen"];
            storyListClose = (Storyboard)Resources["storyListClose"];
            storyListFolderOpen = (Storyboard)Resources["storyListFolderOpen"];
            storyListFolderClose = (Storyboard)Resources["storyListFolderClose"];
            storyPreviewClose.Completed += StoryPreviewClose_Completed;
            storyMessageClose.Completed += StoryMessageClose_Completed;
            storyMessageOpen.Completed += StoryMessageOpen_Completed;
            storyMessageForceClose.Completed += StoryMessageForceClose_Completed;
            storyContentClose.Completed += StoryContentClose_Completed;
            storySettingsClose.Completed += StorySettingsClose_Completed;
            storyBoardExpandAIClose.Completed += StoryBoardExpandAIClose_Completed;
            storyAddClose.Completed += StoryAddClose_Completed;
            storyMessageDialogClose.Completed += StoryMessageDialogClose_Completed;
            storySettingsOptionsClose.Completed += StorySettingsOptionsClose_Completed;
            storySettingsPerformanceClose.Completed += StorySettingsPerformanceClose_Completed;
            storySettingsUserClose.Completed += StorySettingsUserClose_Completed;
            storySettingsPersonalizeClose.Completed += StorySettingsPersonalizeClose_Completed;
            storySettingsDatabaseClose.Completed += StorySettingsDatabaseClose_Completed;

        }

        private void StorySettingsDatabaseClose_Completed(object? sender, EventArgs e)
        {
            gridSettingsDatabase.Visibility = Visibility.Collapsed;
            gridSettingsOptions.Visibility = Visibility.Visible;
            storySettingsOptionsOpen.Begin();
        }

        private void StorySettingsPersonalizeClose_Completed(object? sender, EventArgs e)
        {
            gridSettingsPersonalize.Visibility = Visibility.Collapsed;
            gridSettingsOptions.Visibility = Visibility.Visible;
            storySettingsOptionsOpen.Begin();
        }

        private void StorySettingsUserClose_Completed(object? sender, EventArgs e)
        {
            gridSettingsUser.Visibility = Visibility.Collapsed;
            gridSettingsOptions.Visibility = Visibility.Visible;
            storySettingsOptionsOpen.Begin();
        }

        private void StorySettingsPerformanceClose_Completed(object? sender, EventArgs e)
        {
            gridSettingsPerformance.Visibility = Visibility.Collapsed;
            gridSettingsOptions.Visibility = Visibility.Visible;
            storySettingsOptionsOpen.Begin();
        }

        System.Windows.Controls.Button buttonSelectedCatagorySettings;

        private void StorySettingsOptionsClose_Completed(object? sender, EventArgs e)
        {
            gridSettingsOptions.Visibility = Visibility.Collapsed;

            if (buttonSelectedCatagorySettings == buttonSettingsPerformance)
            {
                gridSettingsPerformance.Visibility = Visibility.Visible;
                storySettingsPerformanceOpen.Begin();
            }
            else if (buttonSelectedCatagorySettings == buttonSettingsDatabase)
            {
                gridSettingsDatabase.Visibility = Visibility.Visible;
                storySettingsDatabaseOpen.Begin();
            }
            else if (buttonSelectedCatagorySettings == buttonSettingsPersonalize)
            {
                gridSettingsPersonalize.Visibility = Visibility.Visible;
                storySettingsPersonalizeOpen.Begin();
            }
            else if (buttonSelectedCatagorySettings == buttonSettingsUser)
            {
                gridSettingsUser.Visibility = Visibility.Visible;
                storySettingsUserOpen.Begin();
            }
        }

        private void StoryMessageDialogClose_Completed(object? sender, EventArgs e)
        {
            borderMessage.Visibility = Visibility.Collapsed;
            borderMessageBack.Visibility = Visibility.Collapsed;
        }

        private void StoryAddClose_Completed(object? sender, EventArgs e)
        {
            borderAddReminder.Visibility = Visibility.Collapsed;
        }

        private void StoryBoardExpandAIClose_Completed(object? sender, EventArgs e)
        {
            storyMessageScreen.Begin();

            if (Acceptable)
            {
                ShowFlyout("موعد مقرر شده با موفقیت تنظیم شد.", FlyoutIcon.Successful);
                Acceptable = false;
            }
        }

        private void StorySettingsClose_Completed(object? sender, EventArgs e)
        {
            gridSettings.Visibility = Visibility.Collapsed;
            gridContent.Visibility = Visibility.Visible;
            storyContentOpen.Begin();
        }

        private void StoryContentClose_Completed(object? sender, EventArgs e)
        {
            gridContent.Visibility = Visibility.Collapsed;
            gridSettings.Visibility = Visibility.Visible;
            storySettingsOpen.Begin();
        }

        private void StoryMessageForceClose_Completed(object? sender, EventArgs e)
        {
            borderMessageAI.Visibility = Visibility.Collapsed;
        }

        private void StoryMessageOpen_Completed(object? sender, EventArgs e)
        {
            storyMessageClose.Begin();
        }

        private void ShowFlyout(string message, FlyoutIcon icon)
        {
            textBlockMessageAI.Text = message;

            if (icon == FlyoutIcon.Info)
            {
                imageMessageInfo.Visibility = Visibility.Visible;
                imageMessageSuccess.Visibility = Visibility.Collapsed;
                imageMessageError.Visibility = Visibility.Collapsed;
            }
            else if (icon == FlyoutIcon.Error)
            {
                imageMessageInfo.Visibility = Visibility.Collapsed;
                imageMessageSuccess.Visibility = Visibility.Collapsed;
                imageMessageError.Visibility = Visibility.Visible;
            }
            else if (icon == FlyoutIcon.Successful)
            {
                imageMessageInfo.Visibility = Visibility.Collapsed;
                imageMessageSuccess.Visibility = Visibility.Visible;
                imageMessageError.Visibility = Visibility.Collapsed;
            }

            borderMessageAI.Visibility = Visibility.Visible;
            storyMessageClose.Stop();
            storyMessageOpen.Begin();
        }

        private void StoryMessageClose_Completed(object? sender, EventArgs e)
        {
            borderMessageAI.Visibility = Visibility.Collapsed;
        }

        private void StoryBoardExpandAI_Completed(object? sender, EventArgs e)
        {
        }

        private void StoryPreviewClose_Completed(object? sender, EventArgs e)
        {
            storyBoardExpandAIClose.Begin();
            storyAIOpen.Begin();
        }

        private void windowRoot_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxColorPalette.Text = Settings.Default.ColorName;

            if ((System.Environment.OSVersion.Version.Major == 10) && (Environment.OSVersion.Version.Build >= 22621))
            {
                if (Settings.Default.IsTranslucent)
                {
                    if (Settings.Default.TranslucentMode == "میکا")
                    {
                        BackDrop.UseNewMica(this);
                        borderBack.Visibility = Visibility.Collapsed;
                        comboBoxChooseBackDrop.Text = "میکا";
                    }
                    else if (Settings.Default.TranslucentMode == "اکلیل")
                    {
                        BackDrop.UseAcrylic(this);
                        borderBack.Visibility = Visibility.Visible;
                        borderBack.Background = new SolidColorBrush(new System.Windows.Media.Color() { A = 160, R = 255, B = 255, G = 255 });
                        comboBoxChooseBackDrop.Text = "اکلیل";
                    }

                    windowChrome.UseAeroCaptionButtons = true;
                    buttonClose.Visibility = Visibility.Collapsed;
                    buttonMinimize.Visibility = Visibility.Collapsed;
                    buttonMaximize.Visibility = Visibility.Collapsed;
                    comboBoxColorPalette.IsEnabled = false;
                    Background = System.Windows.Media.Brushes.Transparent;
                }
                else
                {
                    BackDrop.Disable(this);
                    comboBoxChooseBackDrop.Visibility = Visibility.Collapsed;
                    windowChrome.UseAeroCaptionButtons = false;
                    buttonClose.Visibility = Visibility.Visible;
                    buttonMinimize.Visibility = Visibility.Visible;
                    buttonMaximize.Visibility = Visibility.Visible;
                    comboBoxColorPalette.IsEnabled = true;
                    System.Windows.Media.Color backColor = new System.Windows.Media.Color();
                    borderBack.Visibility = Visibility.Collapsed;
                    Background = Settings.Default.ColorBackground;
                }
            }
            else
            {
                borderAllowTrans.Visibility = Visibility.Collapsed;
                borderBack.Visibility = Visibility.Collapsed;
                windowChrome.UseAeroCaptionButtons = false;
            }

            MonthConnection.Add(("فروردین", 1));
            MonthConnection.Add(("اردیبهشت", 2));
            MonthConnection.Add(("خرداد", 3));
            MonthConnection.Add(("تیر", 4));
            MonthConnection.Add(("مرداد", 5));
            MonthConnection.Add(("شهریور", 6));
            MonthConnection.Add(("مهر", 7));
            MonthConnection.Add(("آبان", 8));
            MonthConnection.Add(("آذر", 9));
            MonthConnection.Add(("دی", 10));
            MonthConnection.Add(("بهمن", 11));
            MonthConnection.Add(("اسفند", 12));

            Refresh();

            Storyboard openAI = (Storyboard)Resources["storyMessageScreen"];
            openAI.Begin();

            if (Settings.Default.OnStartup)
            {
                storyOnStartupEnable.Begin();
            }
            else
            {
                storyOnStartupDisable.Begin();
            }

            if (Settings.Default.FirstReminder)
            {
                storyReminderFirstEnable.Begin();
            }
            else
            {
                storyReminderFirstDisable.Begin();
            }

            if (Settings.Default.AutoBackup)
            {
                storyBackupEnable.Begin();
            }
            else
            {
                storyBackupDisable.Begin();
            }

            if (Settings.Default.IsTranslucent)
            {
                storyAllowTransEnable.Begin();
            }
            else
            {
                storyAllowTransDisable.Begin();
            }

            RecalculateYears();
        }

        private void borderDragMove_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        
        private void buttonNotAcceptPreview_Click(object sender, RoutedEventArgs e)
        {
            newReminder = new Reminder();
            storyPreviewClose.Begin();
        }

        private void buttonPreviewAccept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                reminders.Add(newReminder);
                File.WriteAllText(Path, JsonConvert.SerializeObject(reminders));
                Acceptable = true;
                storyPreviewClose.Begin();
            }
            catch
            {
                ShowFlyout("یک مشکل در تنظیم موعد وجود دارد، ولی نگران نباشید این تقصیر شما نیست!", FlyoutIcon.Error);
            }
        }

        private void buttonSettings_Click(object sender, RoutedEventArgs e)
        {
            storyContentClose.Begin();
            borderSearch.Visibility = Visibility.Collapsed;

            imageBetweenNevigation.Visibility = Visibility.Visible;
            textBlockNevigationBackDrop.Visibility = Visibility.Visible;
            textBlockNavigationHome.IsEnabled = true;
            textBlockNevigationBackDrop.Text = "تنظیمات";
            textBlockNavigationHome.Opacity = 0.64;
            textBlockNevigationBackDrop.Opacity = 1;
        }

        private void buttonMessageAIClose_Click(object sender, RoutedEventArgs e)
        {
            storyMessageClose.Stop();
            storyMessageForceClose.Begin();
        }

        private void buttonBackToHome_Click(object sender, RoutedEventArgs e)
        {
            if (gridSettings.Visibility == Visibility.Visible)
            {
                storySettingsClose.Begin();
                borderSearch.Visibility = Visibility.Visible;

                textBlockNavigationHome.Opacity = 1;
                textBlockNavigationHome.IsEnabled = false;
                imageBetweenNevigation.Visibility = Visibility.Collapsed;
                textBlockNevigationBackDrop.Visibility = Visibility.Collapsed;

                imageBetweenNevigation2.Visibility = Visibility.Collapsed;
                textBlockNevigationSubBackDrop.Visibility = Visibility.Collapsed;
                textBlockNevigationBackDrop.IsEnabled = false;

                if (buttonSelectedCatagorySettings == buttonSettingsDatabase)
                {
                    storySettingsDatabaseClose.Begin();
                }
                else if (buttonSelectedCatagorySettings == buttonSettingsPerformance)
                {
                    storySettingsPerformanceClose.Begin();
                }
                else if (buttonSelectedCatagorySettings == buttonSettingsPersonalize)
                {
                    storySettingsPersonalizeClose.Begin();
                }
                else if (buttonSelectedCatagorySettings == buttonSettingsUser)
                {
                    storySettingsUserClose.Begin();
                }
                textBlockNavigationHome.Opacity = 1;
                textBlockNevigationBackDrop.Opacity = 1;
                listBoxTimeLineReminders.Visibility = Visibility.Collapsed;
                gridTimes.Visibility = Visibility.Visible;
                listBoxTimeLine.Visibility = Visibility.Visible;
            }
            else
            {
                textBlockNevigationBackDrop.Visibility = Visibility.Collapsed;
                imageBetweenNevigation.Visibility = Visibility.Collapsed;
                textBlockNavigationHome.Opacity = 1;
                textBlockNevigationBackDrop.Opacity = 1;
                textBlockNavigationHome.IsEnabled = false;
                listBoxTimeLineReminders.Visibility = Visibility.Collapsed;
                gridTimes.Visibility = Visibility.Visible;
                listBoxTimeLine.Visibility = Visibility.Visible;
            }
        }

        private void borderMessageAI_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            storyMessageClose.Pause();
        }

        private void borderMessageAI_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            storyMessageClose.Resume();
        }

        private void buttonGenerateBack_Click(object sender, RoutedEventArgs e)
        {
            storyPreviewClose.Begin();
        }

        public DateTime time { get; set; } = DateTime.Now;
        private void buttonAddDaysBefore_Click(object sender, RoutedEventArgs e)
        {
            int num = Convert.ToInt32(textBoxDaysBefore.Text);
            num++;
            textBoxDaysBefore.Text = num.ToString();

            if (num > 1)
            {
                buttonRemoveDaysBefore.IsEnabled = true;
            }
        }

        private void buttonRemoveDaysBefore_Click(object sender, RoutedEventArgs e)
        {
            int num = Convert.ToInt32(textBoxDaysBefore.Text);
            
            if (num > 1)
            {
                num--;

                if (num <= 1)
                {
                    buttonRemoveDaysBefore.IsEnabled = false;
                }
            }
            else
            {
                num = 1;
                buttonRemoveDaysBefore.IsEnabled = false;
            }

            textBoxDaysBefore.Text = num.ToString();
        }

        private void buttonAddReminderKey_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxDescription.Text != "")
            {
                if ((Convert.ToInt32(textBoxDateTime.Text.Split('/')[2]) <= 31 && Convert.ToInt32(textBoxDateTime.Text.Split('/')[1]) <= 6) || (Convert.ToInt32(textBoxDateTime.Text.Split('/')[2]) <= 30 && Convert.ToInt32(textBoxDateTime.Text.Split('/')[1]) >= 7))
                {
                        string[] date = textBoxDateTime.Text.Split('/');

                        int showDay = 0;
                        int showMonth = 0;
                        int showYear = 0;

                        int day = 0;
                        int month = 0;
                        int year = 0;
                        int daysBefore = 0;
                        string isImportant = "";

                        day = Convert.ToInt32(date[2]);
                        month = Convert.ToInt32(date[1]);
                        year = Convert.ToInt32(date[0]);
                        daysBefore = Convert.ToInt32(textBoxDaysBefore.Text);

                        if (buttonAddReminderKey.Content == "ویرایش کردن")
                        {
                            command.CommandText = "UPDATE TblReminder SET Description=@Description, DaysBefore=@DaysBefore, Day=@Day, Month=@Month, Year=@Year, ShowDay=@ShowDay, ShowMonth=@ShowMonth, ShowYear=@ShowYear, IsImportant=@IsImportant WHERE Description=@Desc AND DaysBefore=@OldBefore AND Day=@OldDay AND Month=@OldMonth AND Year=@OldYear";
                        }
                        else if (buttonAddReminderKey.Content == "اضافه کردن")
                        {
                            command.CommandText = "INSERT INTO TblReminder VALUES (@Description, @DaysBefore, @Day, @Month, @Year, @ShowDay, @ShowMonth, @ShowYear, @IsImportant)";
                        }

                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@Description", textBoxDescription.Text);
                        command.Parameters.AddWithValue("@DaysBefore", daysBefore);
                        command.Parameters.AddWithValue("@Day", day);
                        command.Parameters.AddWithValue("@Month", month);
                        command.Parameters.AddWithValue("@Year", year);
                        command.Parameters.AddWithValue("@Desc", selectedReminder.Description);
                        command.Parameters.AddWithValue("@OldBefore", selectedReminder.DaysBefore);
                        command.Parameters.AddWithValue("@OldDay", selectedReminder.Day);
                        command.Parameters.AddWithValue("@OldMonth", selectedReminder.Month);
                        command.Parameters.AddWithValue("@OldYear", selectedReminder.Year);

                        if ((day - daysBefore) < 1)
                        {
                            if (month == 1)
                            {
                                if (new PersianCalendar().IsLeapYear(year - 1))
                                {
                                    showDay = 29 + (day - daysBefore);
                                }
                                else
                                {
                                    showDay = 30 + (day - daysBefore);
                                }
                                showYear = year - 1;
                                showMonth = 12;
                            }
                            else if (month > 1 && month <= 6)
                            {
                                showDay = 31 + (day - daysBefore);
                                showMonth = month - 1;
                                showYear = year;
                            }
                            else if (month > 6 && month <= 12)
                            {
                                showDay = 30 + (day - daysBefore);
                                showMonth = month - 1;
                                showYear = year;
                            }
                        }
                        else
                        {
                            showYear = year;
                            showMonth = month;
                            showDay = day - daysBefore;
                        }

                        command.Parameters.AddWithValue("@ShowDay", showDay);
                        command.Parameters.AddWithValue("@ShowMonth", showMonth);
                        command.Parameters.AddWithValue("@ShowYear", showYear);

                        if (imageNotImportant.Visibility == Visibility.Visible)
                        {
                            isImportant = "";
                        }
                        else if (imageImportant.Visibility == Visibility.Visible)
                        {
                            isImportant = "مهم";
                        }

                        command.Parameters.AddWithValue("@IsImportant", isImportant);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        storyAddClose.Begin();
                        borderSmoke.Visibility = Visibility.Collapsed;

                        Reminder reminder = new Reminder();
                        reminder.Description = textBoxDescription.Text;
                        reminder.Day = day;
                        reminder.Month = month;
                        reminder.Year = year;
                        reminder.DaysBefore = daysBefore;
                        reminder.ShowYear = showYear;
                        reminder.ShowMonth = showMonth;
                        reminder.ShowDay = showDay;
                        reminder.IsImportant = isImportant;

                        reminders.Add(reminder);

                        Refresh();
                    }
                    finally
                    {
                        connection.Close();
                    }

                    if (Settings.Default.AutoBackup)
                    {
                        if (Settings.Default.BackupPath != "None")
                        {
                            File.Copy(Path, Settings.Default.BackupPath + @"base.sqlite", true);
                        }
                    }                    
                }
                else
                {
                    ShowMessage("تاریخی که وارد کرده اید از لحاظ منطقی صحیح نمی باشد.", "تاریخ صحیح نیست!");
                }
            }
            else
            {
                ShowMessage("لطفا توضیحی برای یادآور وارد کنید.", "درباره یادآور توضیح دهید!");
            }
        }

        private void textBoxDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            melakify.Automation.UI.Automation.PlaceHolderAI((System.Windows.Controls.TextBox)sender, "توضیحات مربوط به یادآور");

            if (((System.Windows.Controls.TextBox)sender).Text != "")
            {
                buttonAddReminderKey.IsEnabled = true;
            }
            else
            {
                buttonAddReminderKey.IsEnabled = false;
            }
        }

        private void buttonAddReminder_Click(object sender, RoutedEventArgs e)
        {
            DateTime firstTime = DateTime.Now;
            textBoxDaysBefore.Text = "1";
            firstTime.AddDays(Convert.ToInt32(textBoxDaysBefore.Text));
            textBoxDateTime.Text = string.Format($"{new PersianCalendar().GetYear(firstTime):0000}/{new PersianCalendar().GetMonth(firstTime):00}/{new PersianCalendar().GetDayOfMonth(firstTime):00}");
            buttonAddReminderKey.Content = "اضافه کردن";
            textBoxDescription.Text = "";
            imageImportant.Visibility = Visibility.Collapsed;
            imageNotImportant.Visibility = Visibility.Visible;
            buttonAddReminderDelete.Visibility = Visibility.Collapsed;
            borderAddReminder.Visibility = Visibility.Visible;
            borderSmoke.Visibility = Visibility.Visible;
            storyAddOpen.Begin();
        }

        private void buttonAddReminderClose_Click(object sender, RoutedEventArgs e)
        {
            storyAddClose.Begin();
            borderSmoke.Visibility = Visibility.Collapsed;
        }

        private void buttonIsImportant_Click(object sender, RoutedEventArgs e)
        {
            buttonAddReminderKey.IsEnabled = true;
            if (imageNotImportant.Visibility == Visibility.Visible)
            {
                imageImportant.Visibility = Visibility.Visible;
                imageNotImportant.Visibility = Visibility.Collapsed;
            }
            else if (imageImportant.Visibility == Visibility.Visible)
            {
                imageNotImportant.Visibility = Visibility.Visible;
                imageImportant.Visibility = Visibility.Collapsed;
            }
        }

        private void EditLists_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ListSelected = sender;
        }

        private void buttonAddReminderDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                command.CommandText = "DELETE FROM TblReminder WHERE Description=@Description AND DaysBefore=@DaysBefore AND Day=@Day AND Month=@Month AND Year=@Year";
                command.Parameters.AddWithValue("@Description", textBoxDescription.Text);
                command.Parameters.AddWithValue("@DaysBefore", Convert.ToInt32(textBoxDaysBefore.Text));
                command.Parameters.AddWithValue("@Day", Convert.ToInt32(textBoxDateTime.Text.Split('/')[2]));
                command.Parameters.AddWithValue("@Month", Convert.ToInt32(textBoxDateTime.Text.Split('/')[1]));
                command.Parameters.AddWithValue("@Year", Convert.ToInt32(textBoxDateTime.Text.Split('/')[0]));

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                storyAddClose.Begin();
                borderSmoke.Visibility = Visibility.Collapsed;

                reminders.Remove(selectedReminder);
                Refresh();

                textBlockNevigationBackDrop.Visibility = Visibility.Collapsed;
                imageBetweenNevigation.Visibility = Visibility.Collapsed;
                textBlockNavigationHome.Opacity = 1;
                textBlockNevigationBackDrop.Opacity = 1;
                textBlockNavigationHome.IsEnabled = false;
                listBoxTimeLineReminders.Visibility = Visibility.Collapsed;
                gridTimes.Visibility = Visibility.Visible;
                listBoxTimeLine.Visibility = Visibility.Visible;
            }
            catch
            {
                System.Windows.MessageBox.Show("Hell");
            }
            finally
            {
                connection.Close();
            }
        }

        private void windowRoot_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Settings.Default.AutoBackup)
            {
                if (Settings.Default.BackupPath != "None")
                {
                    File.Copy(Path, Settings.Default.BackupPath + @"\base.sqlite", true);
                }
            }
        }

        private void menuItemDeleteList_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void borderCalendarBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            borderCalendar.Visibility = Visibility.Collapsed;
            borderCalendarBack.Visibility = Visibility.Collapsed;
        }

        private void buttonCalendar_Click(object sender, RoutedEventArgs e)
        {
            borderCalendar.Visibility = Visibility.Visible;
            borderCalendarBack.Visibility = Visibility.Visible;

            MonthNumber = Convert.ToInt32(textBoxDateTime.Text.Split('/')[1].ToString());
            YearNumber = Convert.ToInt32(textBoxDateTime.Text.Split('/')[0].ToString());
            MonthName = AutoBack.DateTime.Convert.ToMonthName(MonthNumber);

            textBlockCalendarMonthYear.Text = $"{MonthName} {YearNumber}";

            if (MonthNumber == new PersianCalendar().GetMonth(DateTime.Now) && YearNumber == new PersianCalendar().GetYear(DateTime.Now))
            {
                buttonBackCalendar.IsEnabled = false;
                buttonForwardCalendar.IsEnabled = true;
            }
            else if (MonthNumber == 12)
            {
                buttonBackCalendar.IsEnabled = true;
                buttonForwardCalendar.IsEnabled = false;
            }
            else if (MonthNumber == 1)
            {
                buttonBackCalendar.IsEnabled = false;
                buttonForwardCalendar.IsEnabled = true;
            }
            else
            {
                buttonBackCalendar.IsEnabled = true;
                buttonForwardCalendar.IsEnabled = true;
            }

            RefreshCalendarDays();
        }

        public int MonthNumber { get; set; } = new PersianCalendar().GetMonth(DateTime.Now);
        public string MonthName { get; set; } = AutoBack.DateTime.Convert.ToMonthName(new PersianCalendar().GetMonth(DateTime.Now));
        public int YearNumber { get; set; } = new PersianCalendar().GetYear(DateTime.Now);

        private void buttonBackCalendar_Click(object sender, RoutedEventArgs e)
        {
            if (YearNumber > new PersianCalendar().GetYear(DateTime.Now))
            {
                if (MonthNumber > 1)
                {
                    buttonBackCalendar.IsEnabled = true;
                    MonthName = AutoBack.DateTime.Convert.ToMonthName(MonthNumber -= 1);
                    textBlockCalendarMonthYear.Text = $"{MonthName} {YearNumber}";

                    if (MonthNumber > 1)
                    {
                        buttonBackCalendar.IsEnabled = true;
                    }
                    else
                    {
                        buttonBackCalendar.IsEnabled = false;
                    }

                    if (MonthNumber < 12)
                    {
                        buttonForwardCalendar.IsEnabled = true;
                    }
                    else
                    {
                        buttonForwardCalendar.IsEnabled = false;
                    }
                }
                else
                {
                    buttonBackCalendar.IsEnabled = false;
                }
            }
            else if (YearNumber == new PersianCalendar().GetYear(DateTime.Now))
            {
                if (MonthNumber > new PersianCalendar().GetMonth(DateTime.Now))
                {
                    buttonBackCalendar.IsEnabled = true;
                    MonthName = AutoBack.DateTime.Convert.ToMonthName(MonthNumber -= 1);
                    textBlockCalendarMonthYear.Text = $"{MonthName} {YearNumber}";

                    if (MonthNumber > new PersianCalendar().GetMonth(DateTime.Now))
                    {
                        buttonBackCalendar.IsEnabled = true;
                    }
                    else
                    {
                        buttonBackCalendar.IsEnabled = false;
                    }

                    if (MonthNumber < 12)
                    {
                        buttonForwardCalendar.IsEnabled = true;
                    }
                    else
                    {
                        buttonForwardCalendar.IsEnabled = false;
                    }
                }
                else
                {
                    buttonBackCalendar.IsEnabled = false;
                }
            }

            RefreshCalendarDays();
        }

        private void buttonForwardCalendar_Click(object sender, RoutedEventArgs e)
        {
            if (MonthNumber < 12)
            {
                buttonForwardCalendar.IsEnabled = true;
                MonthName = AutoBack.DateTime.Convert.ToMonthName(MonthNumber += 1);
                textBlockCalendarMonthYear.Text = $"{MonthName} {YearNumber}";

                if (MonthNumber < 12)
                {
                    buttonForwardCalendar.IsEnabled = true;
                }
                else
                {
                    buttonForwardCalendar.IsEnabled = false;
                }

                if (MonthNumber > 1)
                {
                    buttonBackCalendar.IsEnabled = true;
                }
                else
                {
                    buttonBackCalendar.IsEnabled = false;
                }
            }
            else
            {
                buttonForwardCalendar.IsEnabled = false;
            }

            RefreshCalendarDays();
        }

        private void textBoxDescription_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (textBoxDescription.Text != "")
                {
                    if ((Convert.ToInt32(textBoxDateTime.Text.Split('/')[2]) <= 31 && Convert.ToInt32(textBoxDateTime.Text.Split('/')[1]) <= 6) || (Convert.ToInt32(textBoxDateTime.Text.Split('/')[2]) <= 30 && Convert.ToInt32(textBoxDateTime.Text.Split('/')[1]) >= 7))
                    {
                        string[] date = textBoxDateTime.Text.Split('/');

                        int showDay = 0;
                        int showMonth = 0;
                        int showYear = 0;

                        int day = 0;
                        int month = 0;
                        int year = 0;
                        int daysBefore = 0;
                        string isImportant = "";

                        day = Convert.ToInt32(date[2]);
                        month = Convert.ToInt32(date[1]);
                        year = Convert.ToInt32(date[0]);
                        daysBefore = Convert.ToInt32(textBoxDaysBefore.Text);

                        if (buttonAddReminderKey.Content == "ویرایش کردن")
                        {
                            command.CommandText = "UPDATE TblReminder SET Description=@Description, DaysBefore=@DaysBefore, Day=@Day, Month=@Month, Year=@Year, ShowDay=@ShowDay, ShowMonth=@ShowMonth, ShowYear=@ShowYear, IsImportant=@IsImportant WHERE Description=@Desc AND DaysBefore=@OldBefore AND Day=@OldDay AND Month=@OldMonth AND Year=@OldYear";
                        }
                        else if (buttonAddReminderKey.Content == "اضافه کردن")
                        {
                            command.CommandText = "INSERT INTO TblReminder VALUES (@Description, @DaysBefore, @Day, @Month, @Year, @ShowDay, @ShowMonth, @ShowYear, @IsImportant)";
                        }

                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@Description", textBoxDescription.Text);
                        command.Parameters.AddWithValue("@DaysBefore", daysBefore);
                        command.Parameters.AddWithValue("@Day", day);
                        command.Parameters.AddWithValue("@Month", month);
                        command.Parameters.AddWithValue("@Year", year);
                        command.Parameters.AddWithValue("@Desc", selectedReminder.Description);
                        command.Parameters.AddWithValue("@OldBefore", selectedReminder.DaysBefore);
                        command.Parameters.AddWithValue("@OldDay", selectedReminder.Day);
                        command.Parameters.AddWithValue("@OldMonth", selectedReminder.Month);
                        command.Parameters.AddWithValue("@OldYear", selectedReminder.Year);

                        if ((day - daysBefore) < 1)
                        {
                            if (month == 1)
                            {
                                if (new PersianCalendar().IsLeapYear(year - 1))
                                {
                                    showDay = 29 + (day - daysBefore);
                                }
                                else
                                {
                                    showDay = 30 + (day - daysBefore);
                                }
                                showYear = year - 1;
                                showMonth = 12;
                            }
                            else if (month > 1 && month <= 6)
                            {
                                showDay = 31 + (day - daysBefore);
                                showMonth = month - 1;
                                showYear = year;
                            }
                            else if (month > 6 && month <= 12)
                            {
                                showDay = 30 + (day - daysBefore);
                                showMonth = month - 1;
                                showYear = year;
                            }
                        }
                        else
                        {
                            showYear = year;
                            showMonth = month;
                            showDay = day - daysBefore;
                        }

                        command.Parameters.AddWithValue("@ShowDay", showDay);
                        command.Parameters.AddWithValue("@ShowMonth", showMonth);
                        command.Parameters.AddWithValue("@ShowYear", showYear);

                        if (imageNotImportant.Visibility == Visibility.Visible)
                        {
                            isImportant = "";
                        }
                        else if (imageImportant.Visibility == Visibility.Visible)
                        {
                            isImportant = "مهم";
                        }

                        command.Parameters.AddWithValue("@IsImportant", isImportant);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                            storyAddClose.Begin();
                            borderSmoke.Visibility = Visibility.Collapsed;

                            Reminder reminder = new Reminder();
                            reminder.Description = textBoxDescription.Text;
                            reminder.Day = day;
                            reminder.Month = month;
                            reminder.Year = year;
                            reminder.DaysBefore = daysBefore;
                            reminder.ShowYear = showYear;
                            reminder.ShowMonth = showMonth;
                            reminder.ShowDay = showDay;
                            reminder.IsImportant = isImportant;

                            reminders.Add(reminder);

                            Refresh();
                        }
                        finally
                        {
                            connection.Close();
                        }

                        if (Settings.Default.AutoBackup)
                        {
                            if (Settings.Default.BackupPath != "None")
                            {
                                File.Copy(Path, Settings.Default.BackupPath + @"base.sqlite", true);
                            }
                        }
                    }
                    else
                    {
                        ShowMessage("تاریخی که وارد کرده اید از لحاظ منطقی صحیح نمی باشد.", "تاریخ صحیح نیست!");
                    }
                }
            }
        }

        private void YearCalendarButton_Click(object sender, RoutedEventArgs e)
        {
            int year = Convert.ToInt32(((System.Windows.Controls.Button)sender).Content.ToString());
            YearNumber = year;

            if (YearNumber > new PersianCalendar().GetYear(DateTime.Now))
            {
                MonthNumber = 1;
            }
            else if (YearNumber == new PersianCalendar().GetYear(DateTime.Now))
            {
                MonthNumber = new PersianCalendar().GetMonth(DateTime.Now);
            }

            MonthName = AutoBack.DateTime.Convert.ToMonthName(MonthNumber);

            textBlockCalendarMonthYear.Text = $"{MonthName} {YearNumber}";

            RefreshCalendarDays();

            gridCalendarMainBar.Visibility = Visibility.Visible;
            gridCalendarMainDays.Visibility = Visibility.Visible;
            gridCalendarYear.Visibility = Visibility.Collapsed;

            buttonForwardCalendar.IsEnabled = true;
            buttonBackCalendar.IsEnabled = false;
        }

        private void buttonCalendarMonthYear_Click(object sender, RoutedEventArgs e)
        {
            gridCalendarYear.Visibility = Visibility.Visible;
            gridCalendarMainBar.Visibility = Visibility.Collapsed;
            gridCalendarMainDays.Visibility = Visibility.Collapsed;
        }

        private void textBlockSettingsTitle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (gridSettings.Visibility == Visibility.Visible)
            {
                storySettingsClose.Begin();
                borderSearch.Visibility = Visibility.Visible;

                textBlockNavigationHome.Opacity = 1;
                textBlockNavigationHome.IsEnabled = false;
                imageBetweenNevigation.Visibility = Visibility.Collapsed;
                textBlockNevigationBackDrop.Visibility = Visibility.Collapsed;

                imageBetweenNevigation2.Visibility = Visibility.Collapsed;
                textBlockNevigationSubBackDrop.Visibility = Visibility.Collapsed;
                textBlockNevigationBackDrop.IsEnabled = false;

                if (buttonSelectedCatagorySettings == buttonSettingsDatabase)
                {
                    storySettingsDatabaseClose.Begin();
                }
                else if (buttonSelectedCatagorySettings == buttonSettingsPerformance)
                {
                    storySettingsPerformanceClose.Begin();
                }
                else if (buttonSelectedCatagorySettings == buttonSettingsPersonalize)
                {
                    storySettingsPersonalizeClose.Begin();
                }
                else if (buttonSelectedCatagorySettings == buttonSettingsUser)
                {
                    storySettingsUserClose.Begin();
                }
                textBlockNavigationHome.Opacity = 1;
                textBlockNevigationBackDrop.Opacity = 1;
                listBoxTimeLineReminders.Visibility = Visibility.Collapsed;
                gridTimes.Visibility = Visibility.Visible;
            }
            else
            {
                textBlockNevigationBackDrop.Visibility = Visibility.Collapsed;
                imageBetweenNevigation.Visibility = Visibility.Collapsed;
                textBlockNavigationHome.Opacity = 1;
                textBlockNevigationBackDrop.Opacity = 1;
                textBlockNavigationHome.IsEnabled = false;
                listBoxTimeLineReminders.Visibility = Visibility.Collapsed;
                gridTimes.Visibility = Visibility.Visible;
                listBoxTimeLine.Visibility = Visibility.Visible;
            }
            Refresh();
            listBoxAllReminder.Visibility = Visibility.Visible;
            listBoxThisWeek.Visibility = Visibility.Collapsed;
            listBoxThisMonth.Visibility = Visibility.Collapsed;
            listBoxExpiredReminder.Visibility = Visibility.Collapsed;
            listBoxPins.Visibility = Visibility.Collapsed;
        }

        
        private void borderOnStartupActivator_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Settings.Default.OnStartup)
            {
                storyOnStartupDisable.Begin();
                Settings.Default.OnStartup = false;

                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                key.DeleteValue("PlusDoOnStartup", false);
            }
            else
            {
                storyOnStartupEnable.Begin();
                Settings.Default.OnStartup = true;

                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                key.SetValue("PlusDoOnStartup", System.IO.Path.GetFullPath(@"emtudio +Do.exe"));

                storyReminderFirstEnable.Begin();
                Settings.Default.FirstReminder = true;
                
                
            }
            Settings.Default.Save();
        }

        private void borderReminderFirstActivator_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Settings.Default.FirstReminder)
            {
                storyReminderFirstDisable.Begin();
                storyOnStartupDisable.Begin();
                Settings.Default.FirstReminder = false;

                Settings.Default.OnStartup = false;

                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                key.DeleteValue("PlusDoOnStartup", false);
            }
            else
            {
                storyReminderFirstEnable.Begin();
                Settings.Default.FirstReminder = true;
            }
            Settings.Default.Save();
        }

        private void buttonCalendarDays_Click(object sender, RoutedEventArgs e)
        {
            int year, month, day = 0;

            day = Convert.ToInt32(((System.Windows.Controls.Button)sender).Content);
            month = Convert.ToInt32(AutoBack.DateTime.Convert.ToMonthNumber(textBlockCalendarMonthYear.Text.Split(' ')[0]));
            year = Convert.ToInt32(textBlockCalendarMonthYear.Text.Split(' ')[1]);

            textBoxDateTime.Text = $"{year:0000}/{month:00}/{day:00}";

            borderCalendarBack.Visibility = Visibility.Collapsed;
            borderCalendar.Visibility = Visibility.Collapsed;
            buttonAddReminderKey.IsEnabled = true;
        }

        private void buttonMessageOK_Click(object sender, RoutedEventArgs e)
        {
            storyMessageDialogClose.Begin();
        }

        private void buttonMMS_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void listBoxItemUIMain_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            selectedReminder = (Reminder)((System.Windows.Controls.ListBox)ListSelected).SelectedItem;
            try
            {
                textBoxDescription.Text = selectedReminder.Description;
                textBoxDaysBefore.Text = selectedReminder.DaysBefore.ToString();
                textBoxDateTime.Text = string.Format($"{selectedReminder.Year:0000}/{selectedReminder.Month:00}/{selectedReminder.Day:00}");

                if (selectedReminder.IsImportant == "")
                {
                    imageImportant.Visibility = Visibility.Collapsed;
                    imageNotImportant.Visibility = Visibility.Visible;
                }
                else
                {
                    imageImportant.Visibility = Visibility.Visible;
                    imageNotImportant.Visibility = Visibility.Collapsed;
                }

                buttonAddReminderKey.Content = "ویرایش کردن";
                buttonAddReminderKey.IsEnabled = false;
                buttonAddReminderDelete.Visibility = Visibility.Visible;
                borderSmoke.Visibility = Visibility.Visible;
                borderAddReminder.Visibility = Visibility.Visible;
                storyAddOpen.Begin();
            }
            catch
            {

            }
        }

        private void textBoxDaysBefore_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(textBoxDaysBefore.Text) < 1)
            {
                textBoxDaysBefore.Text = "1";
            }
        }

        private void borderBackupActivator_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Settings.Default.AutoBackup)
            {
                storyBackupDisable.Begin();
                Settings.Default.AutoBackup = false;
            }
            else
            {
                if (Settings.Default.BackupPath != "None")
                {
                    storyBackupEnable.Begin();
                    Settings.Default.AutoBackup = true;
                }
                else
                {
                    storyBackupDisable.Begin();
                    Settings.Default.AutoBackup = false;
                    ShowMessage("شما می بایست یک مسیر را برای ذخیره فایل پشتیبان وارد کنید.", "مسیر ذخیره پشتیبان تعیین نشده!");
                }
            }
            Settings.Default.Save();
        }

        private void buttonSelectBackupPath_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Settings.Default.BackupPath = dialog.SelectedPath;
                Settings.Default.Save();
            }
        }

        private void buttonReturnBackup_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "SQLite files|*.sqlite";
            ofd.Title = "وارد کردن فایل پشتیبانی...";
            if (ofd.ShowDialog() == true)
            {
                File.Copy(ofd.FileName, Path, true);
            }
        }

        private void borderAllowTransActivator_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Settings.Default.IsTranslucent)
            {
                storyAllowTransDisable.Begin();
                Settings.Default.IsTranslucent = false;
                BackDrop.Disable(this);
                comboBoxChooseBackDrop.Visibility = Visibility.Collapsed;
                windowChrome.UseAeroCaptionButtons = false;
                buttonClose.Visibility = Visibility.Visible;
                buttonMaximize.Visibility = Visibility.Visible;
                buttonMinimize.Visibility = Visibility.Visible;
                System.Windows.Media.Color color = new System.Windows.Media.Color();
                System.Windows.Media.Color backColor = new System.Windows.Media.Color();
                comboBoxColorPalette.IsEnabled = true;
                borderBack.Visibility = Visibility.Collapsed;
                Background = Settings.Default.ColorBackground;
            }
            else
            {
                storyAllowTransEnable.Begin();
                Settings.Default.IsTranslucent = true;
                Background = System.Windows.Media.Brushes.Transparent;
                windowChrome.UseAeroCaptionButtons = true;
                buttonClose.Visibility = Visibility.Collapsed;
                buttonMinimize.Visibility = Visibility.Collapsed;
                buttonMaximize.Visibility = Visibility.Collapsed;
                comboBoxChooseBackDrop.Visibility = Visibility.Visible;
                comboBoxChooseBackDrop.Text = Settings.Default.TranslucentMode;
                comboBoxColorPalette.IsEnabled = false;

                if (Settings.Default.TranslucentMode == "اکلیل")
                {
                    borderBack.Visibility = Visibility.Visible;
                    borderBack.Background = new SolidColorBrush(new System.Windows.Media.Color() { A = 160, R = 255, B = 255, G = 255 });
                    BackDrop.UseAcrylic(this);
                }
                else if (Settings.Default.TranslucentMode == "میکا")
                {
                    borderBack.Visibility = Visibility.Collapsed;
                    BackDrop.UseNewMica(this);
                }
            }
            Settings.Default.Save();
        }

        private void buttonSettingsPerformance_Click(object sender, RoutedEventArgs e)
        {
            buttonSelectedCatagorySettings = sender as System.Windows.Controls.Button;
            storySettingsOptionsClose.Begin();
            imageBetweenNevigation2.Visibility = Visibility.Visible;
            textBlockNevigationSubBackDrop.Text = "عملکرد برنامه";
            textBlockNevigationSubBackDrop.Visibility = Visibility.Visible;
            textBlockNevigationBackDrop.IsEnabled = true;
            textBlockNevigationBackDrop.Opacity = 0.64;
        }

        private void buttonSettingsUser_Click(object sender, RoutedEventArgs e)
        {
            buttonSelectedCatagorySettings = sender as System.Windows.Controls.Button;
            storySettingsOptionsClose.Begin();
            imageBetweenNevigation2.Visibility = Visibility.Visible;
            textBlockNevigationSubBackDrop.Text = "حساب شما";
            textBlockNevigationSubBackDrop.Visibility = Visibility.Visible;
            textBlockNevigationBackDrop.IsEnabled = true;
            textBlockNevigationBackDrop.Opacity = 0.64;
        }

        private void buttonSettingsPersonalize_Click(object sender, RoutedEventArgs e)
        {
            buttonSelectedCatagorySettings = sender as System.Windows.Controls.Button;
            storySettingsOptionsClose.Begin();
            imageBetweenNevigation2.Visibility = Visibility.Visible;
            textBlockNevigationSubBackDrop.Text = "شخصی سازی";
            textBlockNevigationSubBackDrop.Visibility = Visibility.Visible;
            textBlockNevigationBackDrop.IsEnabled = true;
            textBlockNevigationBackDrop.Opacity = 0.64;
        }

        private void buttonSettingsDatabase_Click(object sender, RoutedEventArgs e)
        {
            buttonSelectedCatagorySettings = sender as System.Windows.Controls.Button;
            storySettingsOptionsClose.Begin();
            imageBetweenNevigation2.Visibility = Visibility.Visible;
            textBlockNevigationSubBackDrop.Text = "پایگاه داده";
            textBlockNevigationSubBackDrop.Visibility = Visibility.Visible;
            textBlockNevigationBackDrop.IsEnabled = true;
            textBlockNevigationBackDrop.Opacity = 0.64;
        }

        private void textBlockNevigationBackDrop_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            imageBetweenNevigation2.Visibility = Visibility.Collapsed;
            textBlockNevigationSubBackDrop.Visibility = Visibility.Collapsed;
            textBlockNevigationBackDrop.IsEnabled = false;

            if (buttonSelectedCatagorySettings == buttonSettingsDatabase)
            {
                storySettingsDatabaseClose.Begin();
            }
            else if (buttonSelectedCatagorySettings == buttonSettingsPerformance)
            {
                storySettingsPerformanceClose.Begin();
            }
            else if (buttonSelectedCatagorySettings == buttonSettingsPersonalize)
            {
                storySettingsPersonalizeClose.Begin();
            }
            else if (buttonSelectedCatagorySettings == buttonSettingsUser)
            {
                storySettingsUserClose.Begin();
            }
        }

        private void textBlockNavigationHome_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            textBlockNavigationHome.Opacity = 1;
        }

        private void textBlockNavigationHome_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (textBlockNevigationBackDrop.IsVisible)
            {
                textBlockNavigationHome.Opacity = 0.64;
            }
            else
            {
                textBlockNavigationHome.Opacity = 1;
            }
        }

        private void textBlockNavigationHome_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            textBlockNavigationHome.Opacity = 0.48;
        }

        private void textBlockNevigationBackDrop_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            textBlockNevigationBackDrop.Opacity = 1;
        }

        private void textBlockNevigationBackDrop_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (textBlockNevigationSubBackDrop.IsVisible)
            {
                textBlockNevigationBackDrop.Opacity = 0.64;
            }
            else
            {
                textBlockNevigationBackDrop.Opacity = 1;
            }
        }

        private void textBlockNevigationBackDrop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            textBlockNevigationBackDrop.Opacity = 0.48;
        }

        private void comboBoxChooseBackDrop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBoxItem item = (ComboBoxItem)comboBoxChooseBackDrop.SelectedItem;
                if (item.Content.ToString() == "میکا")
                {
                    BackDrop.UseNewMica(this);
                    borderBack.Visibility = Visibility.Collapsed;
                    Settings.Default.TranslucentMode = "میکا";
                }
                else if (item.Content.ToString() == "اکلیل")
                {
                    BackDrop.UseAcrylic(this);
                    borderBack.Visibility = Visibility.Visible;
                    Settings.Default.TranslucentMode = "اکلیل";
                }
                Settings.Default.Save();
            }
            catch
            {

            }
        }

        private void comboBoxColorPalette_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)comboBoxColorPalette.SelectedItem;

            if (item.Content.ToString() == "نارنجی")
            {
                Settings.Default.ColorBackground = new SolidColorBrush(new System.Windows.Media.Color() { A = 255, R = 236, G = 211, B = 203 });
                Settings.Default.ColorPalette = System.Windows.Media.Brushes.Orange;
                Settings.Default.ColorName = "Orange";
            }
            else if (item.Content.ToString() == "سبز")
            {
                Settings.Default.ColorBackground = new SolidColorBrush(new System.Windows.Media.Color() { A = 255, R = 211, G = 223, B = 208 });
                Settings.Default.ColorPalette = System.Windows.Media.Brushes.Green;
                Settings.Default.ColorName = "Green";
            }
            else if (item.Content.ToString() == "آبی")
            {
                Settings.Default.ColorBackground = new SolidColorBrush(new System.Windows.Media.Color() { A = 255, R = 207, G = 220, B = 235 });
                Settings.Default.ColorPalette = System.Windows.Media.Brushes.Blue;
                Settings.Default.ColorName = "Blue";
            }
            Settings.Default.Save();
            Background = Settings.Default.ColorBackground;
            selectedPalette = Settings.Default.ColorPalette;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown(0);
        }

        private void buttonMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                gridRoot.Margin = new Thickness(0);
            }
            else if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
                gridRoot.Margin = new Thickness(8);
            }
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void listBoxItemUIMain_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            Folder folder = (Folder)listBoxTimeLine.SelectedItem;

            listBoxTimeLineReminders.Visibility = Visibility.Visible;
            gridTimes.Visibility = Visibility.Collapsed;
            listBoxTimeLine.Visibility = Visibility.Collapsed;
            imageBetweenNevigation.Visibility = Visibility.Visible;
            storyListFolderOpen.Begin();
            textBlockNavigationHome.Opacity = 0.64;
            textBlockNavigationHome.IsEnabled = true;
            textBlockNevigationBackDrop.Visibility = Visibility.Visible;
            textBlockNevigationBackDrop.IsEnabled = false;
            textBlockNevigationBackDrop.Text = $"{folder.Date}";

            listBoxTimeLineReminders.ItemsSource = folder.Reminders;
        }

        private void listBoxItemUIMain_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            selectedReminder = (Reminder)((System.Windows.Controls.ListBox)listBoxTimeLineReminders).SelectedItem;
            try
            {
                textBoxDescription.Text = selectedReminder.Description;
                textBoxDaysBefore.Text = selectedReminder.DaysBefore.ToString();
                textBoxDateTime.Text = string.Format($"{selectedReminder.Year:0000}/{selectedReminder.Month:00}/{selectedReminder.Day:00}");

                if (selectedReminder.IsImportant == "")
                {
                    imageImportant.Visibility = Visibility.Collapsed;
                    imageNotImportant.Visibility = Visibility.Visible;
                }
                else
                {
                    imageImportant.Visibility = Visibility.Visible;
                    imageNotImportant.Visibility = Visibility.Collapsed;
                }

                buttonAddReminderKey.Content = "ویرایش کردن";
                buttonAddReminderKey.IsEnabled = false;
                buttonAddReminderDelete.Visibility = Visibility.Visible;
                borderSmoke.Visibility = Visibility.Visible;
                borderAddReminder.Visibility = Visibility.Visible;
                storyAddOpen.Begin();
            }
            catch
            {

            }
        }

        private void buttonAllReminder_Click(object sender, RoutedEventArgs e)
        {
            buttonAllReminder.IsEnabled = false;
            buttonThisMonth.IsEnabled = true;
            buttonThisWeek.IsEnabled = true;
            buttonExpiredReminder.IsEnabled = true;
            buttonPinReminder.IsEnabled = true;
            listBoxAllReminder.Visibility = Visibility.Visible;
            listBoxExpiredReminder.Visibility = Visibility.Collapsed;
            listBoxThisMonth.Visibility = Visibility.Collapsed;
            listBoxThisWeek.Visibility = Visibility.Collapsed;
            listBoxPins.Visibility = Visibility.Collapsed;
            textBlockFilterTitle.Text = "همه یادآور ها";
            
            if (Settings.Default.FolderWatch)
            {
                storyListOpenWithFolder.Begin();
            }
            else
            {
                storyListOpen.Begin();
            }
        }

        private void buttonThisWeek_Click(object sender, RoutedEventArgs e)
        {
            buttonAllReminder.IsEnabled = true;
            buttonThisMonth.IsEnabled = true;
            buttonThisWeek.IsEnabled = false;
            buttonExpiredReminder.IsEnabled = true;
            buttonPinReminder.IsEnabled = true;
            listBoxAllReminder.Visibility = Visibility.Collapsed;
            listBoxExpiredReminder.Visibility = Visibility.Collapsed;
            listBoxThisMonth.Visibility = Visibility.Collapsed;
            listBoxThisWeek.Visibility = Visibility.Visible;
            listBoxPins.Visibility = Visibility.Collapsed;
            textBlockFilterTitle.Text = "این هفته";

            if (Settings.Default.FolderWatch)
            {
                storyListOpenWithFolder.Begin();
            }
            else
            {
                storyListOpen.Begin();
            }
        }

        private void buttonThisMonth_Click(object sender, RoutedEventArgs e)
        {
            buttonAllReminder.IsEnabled = true;
            buttonThisMonth.IsEnabled = false;
            buttonThisWeek.IsEnabled = true;
            buttonExpiredReminder.IsEnabled = true;
            buttonPinReminder.IsEnabled = true;
            listBoxAllReminder.Visibility = Visibility.Collapsed;
            listBoxExpiredReminder.Visibility = Visibility.Collapsed;
            listBoxThisMonth.Visibility = Visibility.Visible;
            listBoxThisWeek.Visibility = Visibility.Collapsed;
            listBoxPins.Visibility = Visibility.Collapsed;
            textBlockFilterTitle.Text = "این ماه";

            if (Settings.Default.FolderWatch)
            {
                storyListOpenWithFolder.Begin();
            }
            else
            {
                storyListOpen.Begin();
            }
        }

        private void buttonExpiredReminder_Click(object sender, RoutedEventArgs e)
        {
            buttonAllReminder.IsEnabled = true;
            buttonThisMonth.IsEnabled = true;
            buttonThisWeek.IsEnabled = true;
            buttonExpiredReminder.IsEnabled = false;
            buttonPinReminder.IsEnabled = true;
            listBoxAllReminder.Visibility = Visibility.Collapsed;
            listBoxExpiredReminder.Visibility = Visibility.Visible;
            listBoxThisMonth.Visibility = Visibility.Collapsed;
            listBoxThisWeek.Visibility = Visibility.Collapsed;
            listBoxPins.Visibility = Visibility.Collapsed;
            textBlockFilterTitle.Text = "یادآور های تاریخ گذشته";

            if (Settings.Default.FolderWatch)
            {
                storyListOpenWithFolder.Begin();
            }
            else
            {
                storyListOpen.Begin();
            }
        }

        private void buttonPinReminder_Click(object sender, RoutedEventArgs e)
        {
            buttonAllReminder.IsEnabled = true;
            buttonThisMonth.IsEnabled = true;
            buttonThisWeek.IsEnabled = true;
            buttonExpiredReminder.IsEnabled = true;
            buttonPinReminder.IsEnabled = false;
            listBoxAllReminder.Visibility = Visibility.Collapsed;
            listBoxExpiredReminder.Visibility = Visibility.Collapsed;
            listBoxThisMonth.Visibility = Visibility.Collapsed;
            listBoxThisWeek.Visibility = Visibility.Collapsed;
            listBoxPins.Visibility = Visibility.Visible;
            textBlockFilterTitle.Text = "مهم ها";

            if (Settings.Default.FolderWatch)
            {
                storyListOpenWithFolder.Begin();
            }
            else
            {
                storyListOpen.Begin();
            }
        }

        private void listBoxAllReminder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListSelected = sender as System.Windows.Controls.ListBox;
        }

        private void listBoxThisWeek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListSelected = sender as System.Windows.Controls.ListBox;
        }

        private void listBoxThisMonth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListSelected = sender as System.Windows.Controls.ListBox;
        }

        private void listBoxExpiredReminder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListSelected = sender as System.Windows.Controls.ListBox;
        }

        private void listBoxPins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListSelected = sender as System.Windows.Controls.ListBox;
        }

        private void textBoxDateTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            buttonAddReminderKey.IsEnabled = true;
        }

        private void textBoxDaysBefore_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                buttonAddReminderKey.IsEnabled = true;
            }
            catch
            {

            }
        }

        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}