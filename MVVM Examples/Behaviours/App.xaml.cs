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
