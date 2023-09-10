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
using System.IO;
using System.Globalization;
using MelakifyMind.Properties;
using MelakifyMind;
using melakify.Automation.UI;
using System.Data.SQLite;
using System.Net;
using System.Drawing;
using System.Windows.Forms;
using Emtudio.Systems.Controllers;
using Emtudio.Systems.Entities;

namespace melakify.Do
{
    /// <summary>
    /// Interaction logic for ToastWindow.xaml
    /// </summary>
    public partial class ToastWindow : Window
    {
        ReminderContext context = new ReminderContext();
        bool hasData = false;
        Storyboard storyToastClose = new Storyboard();
        Storyboard storyToastContent = new Storyboard();
        Storyboard storyToastContentBack = new Storyboard();
        PersianCalendar persian = new PersianCalendar();
        List<Reminder> Reminders = new List<Reminder>();
        SQLiteConnection connection = new SQLiteConnection($@"DataSource = {DataPathChecker.Path}; Version = 3;");
        SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS TblReminder (Description varchar(50), DaysBefore int, Day int, Month int, Year int, ShowDay int, ShowMonth int, ShowYear int, IsImportant varchar(4))");
        SQLiteDataReader reader;
        DateTime time = DateTime.Now;

        public double CloseLeft { get; set; } = SystemParameters.PrimaryScreenWidth + 100;

        public ToastWindow()
        {
            try
            {
                InitializeComponent();
                borderToast.Background = Settings.Default.ColorBackground;
                context.OnModelOpening();
                if (!Settings.Default.FirstReminder)
                {
                    MainWindow win = new MainWindow();
                    win.Show();
                    Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
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
                DataPathChecker.PathChecker();

                Topmost = true;
                DataContext = this;
                storyToastClose = (Storyboard)Resources["storyClose"];
                storyToastContent = (Storyboard)Resources["storyToastNext"];
                storyToastContentBack = (Storyboard)Resources["storyToastPre"];
                storyToastClose.Completed += StoryToastClose_Completed;


                try
                {
                    if (File.Exists(DataPathChecker.Path))
                    {
                        var result = (from remind in context.Reminders.ToList()
                                     where remind.Time.Date.AddDays(-remind.DaysBefore) == DateTime.Now.Date
                                     select remind).ToList();

                        Reminders = result;

                        if (result.Count() > 0)
                        {
                            textBoxDescription.Text = $"{Reminders[0].Description} برای {Reminders[0].DaysDistance}";
                            buttonDismiss.Visibility = Visibility.Visible;
                            hasData = true;
                            textBlockReminderCount.Visibility = Visibility.Visible;
                            textBlockReminderCount.Text = $"({1} از {Reminders.Count})";
                        }
                        else
                        {
                            textBoxDescription.Text = "سلام. برای امروز یادآوری ندارید.";
                            buttonDismiss.Visibility = Visibility.Visible;
                            hasData = false;
                            textBlockReminderCount.Visibility = Visibility.Collapsed;
                        }

                        if (result.Count() > 1)
                        {
                            buttonDismiss.Content = "بعدی";
                            borderSeprator.Visibility = Visibility.Visible;
                            buttonNextReminder.Visibility = Visibility.Visible;
                            buttonPreviousReminder.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            buttonDismiss.Content = "فهمیدم";
                            borderSeprator.Visibility = Visibility.Collapsed;
                            buttonNextReminder.Visibility = Visibility.Collapsed;
                            buttonPreviousReminder.Visibility = Visibility.Collapsed;
                        }

                    }
                    else
                    {
                        textBoxDescription.Text = "با سلام. یادآوری در حافظه برنامه وجود ندارد!";
                    }
                }
                finally
                {
                    connection.Close();
                }

                Left = SystemParameters.PrimaryScreenWidth - Width;
                Top = SystemParameters.PrimaryScreenHeight - Height - 64;

                int basicHeight = 180;

                if (textBoxDescription.LineCount == 1)
                {
                    Height = basicHeight;
                }
                else if (textBoxDescription.LineCount == 2)
                {
                    Height = basicHeight + 20;
                }
                else if (textBoxDescription.LineCount == 3)
                {
                    Height = basicHeight + 40;
                }
                else if (textBoxDescription.LineCount == 4)
                {
                    Height = basicHeight + 60;
                }
                else if (textBoxDescription.LineCount > 5)
                {
                    Height = basicHeight + 80;
                }
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

        public int iToast = 1;

        private void buttonDismiss_Click(object sender, RoutedEventArgs e)
        {
            if (hasData)
            {
                if (Reminders.Count > 1)
                {
                    if (iToast != (Reminders.Count))
                    {
                        storyToastContent.Begin();
                        textBoxDescription.Text = $"{Reminders[iToast].Description} برای {Reminders[iToast].DaysDistance}";
                        iToast = iToast + 1;
                        textBlockReminderCount.Text = $"({iToast} از {Reminders.Count})";
                        if (iToast != (Reminders.Count))
                        {
                            buttonDismiss.Content = "بعدی";
                        }
                        else
                        {
                            buttonDismiss.Content = "فهمیدم";
                        }
                    }
                    else
                    {
                        storyToastClose.Begin();
                    }
                }
                else
                {
                    storyToastClose.Begin();
                }
            }
            else
            {
                storyToastClose.Begin();
            }
            buttonPreviousReminder.IsEnabled = true;
        }

        private void buttonCloseJustNow_Click(object sender, RoutedEventArgs e)
        {
            storyToastClose.Begin();
        }

        private void buttonNextReminder_Click(object sender, RoutedEventArgs e)
        {
            if (hasData)
            {
                if (Reminders.Count > 1)
                {
                    if (iToast != (Reminders.Count))
                    {
                        storyToastContent.Begin();
                        textBoxDescription.Text = $"{Reminders[iToast].Description} برای {Reminders[iToast].DaysDistance}";
                        iToast = iToast + 1;
                        textBlockReminderCount.Text = $"({iToast} از {Reminders.Count})";
                        if (iToast != (Reminders.Count))
                        {
                            buttonDismiss.Content = "بعدی";
                        }
                        else
                        {
                            buttonDismiss.Content = "فهمیدم";
                            buttonNextReminder.IsEnabled = false;
                        }
                    }
                    else
                    {
                        buttonNextReminder.IsEnabled = false;
                    }
                }
                else
                {
                    buttonNextReminder.IsEnabled = false;
                }
            }
            else
            {
                buttonNextReminder.IsEnabled = false;
            }
            buttonPreviousReminder.IsEnabled = true;
        }

        private void buttonPreviousReminder_Click(object sender, RoutedEventArgs e)
        {
            if (hasData)
            {
                if (Reminders.Count > 1)
                {
                    if (iToast != 1)
                    {
                        storyToastContentBack.Begin();
                        iToast = iToast - 1;
                        textBoxDescription.Text = $"{Reminders[iToast - 1].Description} برای {Reminders[iToast - 1].DaysDistance}";
                        textBlockReminderCount.Text = $"({iToast} از {Reminders.Count})";

                        if (iToast != (Reminders.Count))
                        {
                            buttonDismiss.Content = "بعدی";
                        }
                        else
                        {
                            buttonDismiss.Content = "فهمیدم";
                            buttonNextReminder.IsEnabled = false;
                        }

                        if (iToast == 1)
                        {
                            buttonPreviousReminder.IsEnabled = false;
                        }
                    }
                    else
                    {
                        buttonPreviousReminder.IsEnabled = false;
                    }
                }
                else
                {
                    buttonPreviousReminder.IsEnabled = false;
                }
            }
            else
            {
                buttonPreviousReminder.IsEnabled = false;
            }
            buttonNextReminder.IsEnabled = true;
        }
    }
}
