using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using DataBinding.ViewModels;
using DataBinding.Views;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var view = new PersonView();
            var viewModel = new PersonViewModel {FirstName = "Mark Pearl"};
            view.DataContext = viewModel;
            view.Show();
        }
    }
}

