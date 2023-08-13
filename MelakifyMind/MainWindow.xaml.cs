using MelakifyMind.UIs.Automations;
using MelakifyMind.UIs.BackDrops;
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
using MelakifyMind.Behind;
using MelakifyMind.Behind.MelakifyML;
using System.Collections;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
using System.Globalization;
using Windows.UI.WindowManagement;

namespace MelakifyMind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum FlyoutIcon
        {
            Info,
            Error,
            Successful
        }

        public const string Path = @"DOs.json";
        Hashtable HashMonth = new Hashtable();
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
        Reminder newReminder = new Reminder();
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
            this.DataContext = gridRoot;

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


            storyPreviewClose.Completed += StoryPreviewClose_Completed;
            storyMessageClose.Completed += StoryMessageClose_Completed;
            storyMessageOpen.Completed += StoryMessageOpen_Completed;
            storyMessageForceClose.Completed += StoryMessageForceClose_Completed;
            storyContentClose.Completed += StoryContentClose_Completed;
            storySettingsClose.Completed += StorySettingsClose_Completed;
            storyBoardExpandAIClose.Completed += StoryBoardExpandAIClose_Completed;
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

            HashMonth.Add("فروردین", 1);
            HashMonth.Add("اردیبهشت", 2);
            HashMonth.Add("خرداد", 3);
            HashMonth.Add("تیر", 4);
            HashMonth.Add("مرداد", 5);
            HashMonth.Add("شهریور", 6);
            HashMonth.Add("مهر", 7);
            HashMonth.Add("آبان", 8);
            HashMonth.Add("آذر", 9);
            HashMonth.Add("دی", 10);
            HashMonth.Add("بهمن", 11);
            HashMonth.Add("اسفند", 12);

            if (File.Exists(Path) && File.ReadAllText(Path).Length > 0)
            {
                reminders = JsonConvert.DeserializeObject<List<Reminder>>(File.ReadAllText(Path));
            }

            if (reminders.Count > 0)
            {
                scrollViewerRoot.Visibility = Visibility.Visible;
                textBlockNoReminder.Visibility = Visibility.Collapsed;
                imageNoReminder.Visibility = Visibility.Collapsed;

                var fewDays = from f in reminders
                              where f.Day - new PersianCalendar().GetDayOfMonth(DateTime.Now) >= 1 && f.Day - new PersianCalendar().GetDayOfMonth(DateTime.Now) <= 3
                              where
                              select f;

                var week = from w in reminders
                           where w.Day - new PersianCalendar().GetDayOfMonth(DateTime.Now) >= 1 && w.Day - new PersianCalendar().GetDayOfMonth(DateTime.Now) <= 7
                           select w;

                var month = from m in reminders
                            where m.Month == new PersianCalendar().GetMonth(DateTime.Now)
                            select m;

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
            }

            Storyboard openAI = (Storyboard)Resources["storyMessageScreen"];
            openAI.Begin();
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
    }
}