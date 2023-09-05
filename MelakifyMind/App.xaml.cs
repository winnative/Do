using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using melakify.Do;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Threading;

namespace melakify.Do
{
    
    public partial class App : System.Windows.Application
    {
        private void HelloError(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            System.Windows.MessageBox.Show(e.Exception.Message);
            e.Handled = true;
        }
    }
}