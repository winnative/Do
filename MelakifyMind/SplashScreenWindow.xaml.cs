using MelakifyMind;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace melakify.Do
{
    /// <summary>
    /// Interaction logic for SplashScreenWindow.xaml
    /// </summary>
    public partial class SplashScreenWindow : Window
    {
        public SplashScreenWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BackDrop.UseAcrylic(this);
        }

        private void storyBoardClose_Completed(object sender, EventArgs e)
        {
            melakify.Do.MainWindow win = new melakify.Do.MainWindow();
            win.Show();
            Close();
        }
    }
}
