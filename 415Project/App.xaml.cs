using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _415Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // So text boxes to select their text on focus
            EventManager.RegisterClassHandler(typeof(TextBox),
                                              TextBox.GotFocusEvent,
                                              new RoutedEventHandler(TextBox_GotFocus));

            ViewModels.MainWindowVM vm = new ViewModels.MainWindowVM();
            MainWindow = new MainWindow() { DataContext = vm };
            MainWindow.Show();
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }
    }
}
