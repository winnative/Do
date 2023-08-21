using melakify.Automation.UI;
using melakify.Entities.Behind;
using melakify.UI.BackDrop;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
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
using Windows.UI.WindowManagement;
using static melakify.Behind.ML.ML2;
using System.Data.SQLite;
using System.Reflection.PortableExecutable;
using melakify.Automation.Behind;
using Windows.ApplicationModel.VoiceCommands;
using MelakifyDo.Properties;
using DNTPersianUtils.Core;

namespace melakify.Do
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

                    var result = from remind in reminders
                                 where remind.ShowDay == new PersianCalendar().GetDayOfMonth(DateTime.Now)
                                 where remind.ShowMonth == new PersianCalendar().GetMonth(DateTime.Now)
                                 where remind.ShowYear == new PersianCalendar().GetYear(DateTime.Now)
                                 select remind;
                }
                else
                {
                    SQLiteConnection.CreateFile(Path);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            finally
            {
                connection.Close();
            }

            if (reminders.Count > 0)
            {
                scrollViewerRoot.Visibility = Visibility.Visible;
                textBlockNoReminder.Visibility = Visibility.Collapsed;
                imageNoReminder.Visibility = Visibility.Collapsed;
                textBlockNoReminderComment.Visibility = Visibility.Collapsed;

                var fewDays = from f in reminders
                              where f.Day - new PersianCalendar().GetDayOfMonth(DateTime.Now) >= 1 && f.Day - new PersianCalendar().GetDayOfMonth(DateTime.Now) <= 3
                              where f.Month == new PersianCalendar().GetMonth(DateTime.Now)
                              where f.Year == new PersianCalendar().GetYear(DateTime.Now)
                              select f;

                var week = from w in reminders
                           where w.Day - new PersianCalendar().GetDayOfMonth(DateTime.Now) >= 1 && w.Day - new PersianCalendar().GetDayOfMonth(DateTime.Now) <= 7
                           where w.Month == new PersianCalendar().GetMonth(DateTime.Now)
                           where w.Year == new PersianCalendar().GetYear(DateTime.Now)
                           select w;

                var month = from m in reminders
                            where m.Month == new PersianCalendar().GetMonth(DateTime.Now)
                            where m.Year == new PersianCalendar().GetYear(DateTime.Now)
                            select m;

                var pin = from p in reminders
                          where p.IsImportant == "مهم"
                          select p;

                if (pin.Count() > 0)
                {
                    listBoxDatePins.Visibility = Visibility.Visible;
                    textBlockDatePins.Visibility = Visibility.Visible;
                    listBoxDatePins.ItemsSource = pin;
                }

                if (fewDays.Count() > 0)
                {
                    textBlockDateFewDays.Visibility = Visibility.Visible;
                    listBoxDateFewDays.Visibility = Visibility.Visible;
                    listBoxDateFewDays.ItemsSource = fewDays;
                }
                else
                {
                    textBlockDateFewDays.Visibility = Visibility.Collapsed;
                    listBoxDateFewDays.Visibility = Visibility.Collapsed;
                }

                if (week.Count() > 0)
                {
                    textBlockDateCurrentWeek.Visibility = Visibility.Visible;
                    listBoxDateWeek.Visibility = Visibility.Visible;
                    listBoxDateWeek.ItemsSource = week;
                }
                else
                {
                    textBlockDateCurrentWeek.Visibility = Visibility.Collapsed;
                    listBoxDateWeek.Visibility = Visibility.Collapsed;
                }

                if (month.Count() > 0)
                {
                    textBlockDateCurrentMonth.Visibility = Visibility.Visible;
                    listBoxDateMonth.Visibility = Visibility.Visible;
                    listBoxDateMonth.ItemsSource = month;
                }
                else
                {
                    textBlockDateCurrentMonth.Visibility = Visibility.Collapsed;
                    listBoxDateMonth.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                scrollViewerRoot.Visibility = Visibility.Collapsed;
                textBlockNoReminder.Visibility = Visibility.Visible;
                imageNoReminder.Visibility = Visibility.Visible;
                textBlockNoReminderComment.Visibility = Visibility.Visible;
            }

        }

        public enum FlyoutIcon
        {
            Info,
            Error,
            Successful
        }

        public const string Path = @"DOs.json";

        SQLiteConnection connection = new SQLiteConnection("DataSource=DOs.sqlite; Version=3;");
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
        Reminder newReminder = new Reminder();
        Reminder selectedReminder = new Reminder();
        List<Reminder> reminders = new List<Reminder>();
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
            Background = Brushes.Transparent;
            this.DataContext = gridContent;

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


            storyPreviewClose.Completed += StoryPreviewClose_Completed;
            storyMessageClose.Completed += StoryMessageClose_Completed;
            storyMessageOpen.Completed += StoryMessageOpen_Completed;
            storyMessageForceClose.Completed += StoryMessageForceClose_Completed;
            storyContentClose.Completed += StoryContentClose_Completed;
            storySettingsClose.Completed += StorySettingsClose_Completed;
            storyBoardExpandAIClose.Completed += StoryBoardExpandAIClose_Completed;
            storyAddClose.Completed += StoryAddClose_Completed;

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
            BackDrop.UseNewMica(this);

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
        }

        private void buttonMessageAIClose_Click(object sender, RoutedEventArgs e)
        {
            storyMessageClose.Stop();
            storyMessageForceClose.Begin();
        }

        private void buttonBackToHome_Click(object sender, RoutedEventArgs e)
        {
            storySettingsClose.Begin();
            borderSearch.Visibility = Visibility.Visible;

            textBlockNavigationHome.IsEnabled = false;
            textBlockNavigationHome.Opacity = 1;
            imageBetweenNevigation.Visibility = Visibility.Collapsed;
            textBlockNevigationBackDrop.Visibility = Visibility.Collapsed;
        }

        private void borderMessageAI_MouseEnter(object sender, MouseEventArgs e)
        {
            storyMessageClose.Pause();
        }

        private void borderMessageAI_MouseLeave(object sender, MouseEventArgs e)
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

            if (buttonAddReminderKey.Content=="ویرایش کردن")
            {
                command.CommandText = "UPDATE TblReminder SET Description=@Description, DaysBefore=@DaysBefore, Day=@Day, Month=@Month, Year=@Year, ShowDay=@ShowDay, ShowMonth=@ShowMonth, ShowYear=@ShowYear, IsImportant=@IsImportant WHERE Description=@Desc AND DaysBefore=@OldBefore AND Day=@OldDay AND Month=@OldMonth AND Year=@OldYear";
            }
            else if (buttonAddReminderKey.Content=="اضافه کردن")
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

            if (textBlockIsImportantContent.Foreground == Brushes.Black)
            {
                isImportant = "";
            }
            else if (textBlockIsImportantContent.Foreground == Brushes.IndianRed)
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

        }

        private void textBoxDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            melakify.Automation.UI.Automation.PlaceHolderAI((TextBox)sender, "توضیحات مربوط به یادآور");

            if (((TextBox)sender).Text != "")
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
            textBlockIsImportantContent.Foreground = Brushes.Black;
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
            if (textBlockIsImportantContent.Foreground == Brushes.Black)
            {
                textBlockIsImportantContent.Foreground = Brushes.IndianRed;
            }
            else if (textBlockIsImportantContent.Foreground == Brushes.IndianRed)
            {
                textBlockIsImportantContent.Foreground = Brushes.Black;
            }
        }

        private void EditLists_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = false;
            selectedReminder = (Reminder)((ListBox)sender).SelectedItem;
            try
            {
                textBoxDescription.Text = selectedReminder.Description;
                textBoxDaysBefore.Text = selectedReminder.DaysBefore.ToString();
                textBoxDateTime.Text = string.Format($"{selectedReminder.Year:0000}/{selectedReminder.Month:00}/{selectedReminder.Day:00}");

                if (selectedReminder.IsImportant == "")
                {
                    textBlockIsImportantContent.Foreground = Brushes.Black;
                }
                else
                {
                    textBlockIsImportantContent.Foreground = Brushes.IndianRed;
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
            }
            finally
            {
                connection.Close();
            }
        }

        private void windowRoot_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
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
            buttonBackCalendar.IsEnabled = false;
            buttonForwardCalendar.IsEnabled = true;
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

            for (int i = 0; i < 35; i++)
            {
                ((Button)gridDaysOfCalendar.Children[i]).IsEnabled = false;
                ((Button)gridDaysOfCalendar.Children[i]).Content = "";
            }

            DateTime? time = $"{YearNumber}/{MonthNumber}/{1}".ToGregorianDateTime();
            int firstWeekDay = AutoBack.DateTime.Convert.ToNumberWeekDay(time.Value.DayOfWeek.ToString());

            switch (firstWeekDay)
            {
                case 1:
                    if (new PersianCalendar().IsLeapMonth(YearNumber, MonthNumber))
                    {
                        for (int i = 0; i < 31; i++)
                        {
                            ((Button)gridDaysOfCalendar.Children[i]).Content = i + 1;
                            ((Button)gridDaysOfCalendar.Children[i]).IsEnabled = true;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 30; i++)
                        {
                            ((Button)gridDaysOfCalendar.Children[i]).Content = i + 1;
                            ((Button)gridDaysOfCalendar.Children[i]).IsEnabled = true;
                        }
                    }
                    break;
                case 2:
                    if (new PersianCalendar().IsLeapMonth(YearNumber, MonthNumber))
                    {
                        for (int i = 0; i < 31; i++)
                        {
                            ((Button)gridDaysOfCalendar.Children[i + 1]).Content = i + 1;
                            ((Button)gridDaysOfCalendar.Children[i + 1]).IsEnabled = true;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 30; i++)
                        {
                            ((Button)gridDaysOfCalendar.Children[i + 1]).Content = i + 1;
                            ((Button)gridDaysOfCalendar.Children[i + 1]).IsEnabled = true;
                        }
                    }
                    break;
                case 3:
                    if (new PersianCalendar().IsLeapMonth(YearNumber, MonthNumber))
                    {
                        for (int i = 0; i < 31; i++)
                        {
                            ((Button)gridDaysOfCalendar.Children[i + 2]).Content = i + 1;
                            ((Button)gridDaysOfCalendar.Children[i + 2]).IsEnabled = true;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 30; i++)
                        {
                            ((Button)gridDaysOfCalendar.Children[i + 2]).Content = i + 1;
                            ((Button)gridDaysOfCalendar.Children[i + 2]).IsEnabled = true;
                        }
                    }
                    break;
                case 4:
                    if (new PersianCalendar().IsLeapMonth(YearNumber, MonthNumber))
                    {
                        for (int i = 0; i < 31; i++)
                        {
                            ((Button)gridDaysOfCalendar.Children[i + 3]).Content = i + 1;
                            ((Button)gridDaysOfCalendar.Children[i + 3]).IsEnabled = true;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 30; i++)
                        {
                            ((Button)gridDaysOfCalendar.Children[i + 3]).Content = i + 1;
                            ((Button)gridDaysOfCalendar.Children[i + 3]).IsEnabled = true;
                        }
                    }
                    break;
                case 5:
                    if (new PersianCalendar().IsLeapMonth(YearNumber, MonthNumber))
                    {
                        for (int i = 0; i < 31; i++)
                        {
                            ((Button)gridDaysOfCalendar.Children[i + 4]).Content = i + 1;
                            ((Button)gridDaysOfCalendar.Children[i + 4]).IsEnabled = true;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 30; i++)
                        {
                            ((Button)gridDaysOfCalendar.Children[i + 4]).Content = i + 1;
                            ((Button)gridDaysOfCalendar.Children[i + 4]).IsEnabled = true;
                        }
                    }
                    break;
                case 6:
                    if (new PersianCalendar().IsLeapMonth(YearNumber, MonthNumber))
                    {
                        for (int i = 0; i < 31; i++)
                        {
                            ((Button)gridDaysOfCalendar.Children[i + 5]).Content = i + 1;
                            ((Button)gridDaysOfCalendar.Children[i + 5]).IsEnabled = true;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 30; i++)
                        {
                            ((Button)gridDaysOfCalendar.Children[i + 5]).Content = i + 1;
                            ((Button)gridDaysOfCalendar.Children[i + 5]).IsEnabled = true;
                        }
                    }
                    break;
                case 7:
                    if (new PersianCalendar().IsLeapMonth(YearNumber, MonthNumber))
                    {
                        for (int i = 0; i < 31; i++)
                        {
                            ((Button)gridDaysOfCalendar.Children[i + 6]).Content = i + 1;
                            ((Button)gridDaysOfCalendar.Children[i + 6]).IsEnabled = true;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 30; i++)
                        {
                            ((Button)gridDaysOfCalendar.Children[i + 6]).Content = i + 1;
                            ((Button)gridDaysOfCalendar.Children[i + 6]).IsEnabled = true;
                        }
                    }
                    break;
            }
        }

        private void textBoxDescription_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (textBoxDescription.Text != "")
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

                    if (textBlockIsImportantContent.Foreground == Brushes.Black)
                    {
                        isImportant = "";
                    }
                    else if (textBlockIsImportantContent.Foreground == Brushes.IndianRed)
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
                }
            }
        }

        private void YearCalendarButton_Click(object sender, RoutedEventArgs e)
        {
            int year = Convert.ToInt32(((Button)sender).Content.ToString());
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

            gridCalendarMainBar.Visibility = Visibility.Visible;
            gridCalendarMainDays.Visibility = Visibility.Visible;
            gridCalendarYear.Visibility = Visibility.Collapsed;
        }

        private void buttonCalendarMonthYear_Click(object sender, RoutedEventArgs e)
        {
            gridCalendarYear.Visibility = Visibility.Visible;
            gridCalendarMainBar.Visibility = Visibility.Collapsed;
            gridCalendarMainDays.Visibility = Visibility.Collapsed;
        }

        private void textBlockSettingsTitle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            storySettingsClose.Begin();
            borderSearch.Visibility = Visibility.Visible;

            textBlockNavigationHome.IsEnabled = false;
            textBlockNavigationHome.Opacity = 1;
            imageBetweenNevigation.Visibility = Visibility.Collapsed;
            textBlockNevigationBackDrop.Visibility = Visibility.Collapsed;
        }

        
        private void borderOnStartupActivator_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Settings.Default.OnStartup)
            {
                storyOnStartupEnable.Begin();
                Settings.Default.OnStartup = false;
            }
            else
            {
                storyOnStartupDisable.Begin();
                Settings.Default.OnStartup = true;
            }
            Settings.Default.Save();
        }

        private void borderReminderFirstActivator_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Settings.Default.FirstReminder)
            {
                storyReminderFirstEnable.Begin();
                Settings.Default.FirstReminder = false;
            }
            else
            {
                storyReminderFirstDisable.Begin();
                Settings.Default.FirstReminder = true;
            }
            Settings.Default.Save();
        }
    }
}