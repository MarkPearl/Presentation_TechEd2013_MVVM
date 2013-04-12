using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Behaviours
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var viewModel = new MainViewModel
            {
                Name = "Bob"
            };

            var view = new MainView();
            view.DataContext = viewModel;
            view.Show();
        }
    }
}
