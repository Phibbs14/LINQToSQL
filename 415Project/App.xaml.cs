using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace _415Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ViewModels.MainWindowVM vm = new ViewModels.MainWindowVM();
            MainWindow = new MainWindow() { DataContext = vm };
            MainWindow.Show();
        }
    }
}
