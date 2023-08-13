using MelakifyMind.UIs.BackDrops;
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
using MelakifyMind.Behind;
using System.IO;
using System.Globalization;
using MelakifyDo.Properties;
using MelakifyDo;
using MelakifyMind.UIs.Automations;

namespace MelakifyMind
{
    /// <summary>
    /// Interaction logic for ToastWindow.xaml
    /// </summary>
    public partial class ToastWindow : Window
    {
        Storyboard storyToastClose = new Storyboard();
        List<Reminder> reminders = new List<Reminder>();
        PersianCalendar persian = new PersianCalendar();
        DateTime time = DateTime.Now;

        public double CloseLeft { get; set; } = SystemParameters.PrimaryScreenWidth + 100;

        public const string Path = "DOs.json";
        public ToastWindow()
        {
            InitializeComponent();
            Left = SystemParameters.PrimaryScreenWidth - Width - 16;
            Top = SystemParameters.PrimaryScreenHeight - Height - 64;
            Topmost = true;
            DataContext = this;
            storyToastClose = (Storyboard)Resources["storyClose"];
            storyToastClose.Completed += StoryToastClose_Completed;

            if (File.Exists(Path) && File.ReadAllText(Path).Length > 0)
            {
                reminders = JsonConvert.DeserializeObject<List<Reminder>>(File.ReadAllText(Path));

                var r = from re in reminders
                        where re.ShowDay == persian.GetDayOfMonth(time)
                        where re.ShowMonth == persian.GetMonth(time)
                        where re.ShowYear == persian.GetYear(time)
                        select re;

                var l = from le in reminders
                        where le.Day == persian.GetDayOfMonth(time)
                        where le.Month == persian.GetMonth(time)
                        where le.Year == persian.GetYear(time)
                        select le;


                if (r.Count() > 0 && l.Count() > 0)
                {
                    textBlockAI.Text = "وقت بخیر. موعد های مربوط به امروز شما عبارتند از: ";
                    foreach (var w in l)
                    {
                        textBlockAI.Text += $"\n\n{w.Description}";
                    }
                    textBlockAI.Text += "\n\n\nموعد های مربوط به روز های آینده که گفته بودید امروز تذکر داده شود:\n\n";
                    foreach (var w in r)
                    {
                        textBlockAI.Text += $"\n\n{w.Description} تا {w.DaysBefore} روز دیگر.";
                    }
                }
                else if (r.Count() > 0)
                {
                    textBlockAI.Text += "با سلام. ";
                    textBlockAI.Text += "موعد های مربوط به روز های آینده که گفته بودید امروز یادآوری شود:\n\n";
                    foreach (var w in r)
                    {
                        textBlockAI.Text += $"\n\n{w.Description} تا {w.DaysBefore} روز دیگر.";
                    }
                }
                else if (l.Count() > 0)
                {
                    textBlockAI.Text = "وقت بخیر. موعد های مربوط به امروز شما عبارتند از: ";
                    foreach (var w in l)
                    {
                        textBlockAI.Text += $"\n\n{w.Description}";
                    }
                }
                else
                {
                    textBlockAI.Text = "با سلام و وقت بخیر، طبق بررسی هایی که انجام دادم،";
                    textBlockAI.Text += "شما هیچ موعدی یا یادآوری برای امروز ندارید.";
                }
            }
            else
            {
                textBlockAI.Text = "سلام. من درک جادویی هستم!\n\n من جستجو انجام دادم، ولی متاسفانه شما هیچ موعدی تنظیم نکرده اید! برای ذخیره موعد به صفحه اصلی بروید ، من در آنجا هستم تا موعدی برای شما ذخیره کنم.";
            }
            
        }

        private void StoryToastClose_Completed(object? sender, EventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BackDrop.UseAcrylic(this);
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            storyToastClose.Begin();
        }

        private void buttonShowTheMain_Click(object sender, RoutedEventArgs e)
        {
            Topmost = false;
            MainWindow win = new MainWindow();
            win.Show();
            storyToastClose.Begin();
        }
    }
}
