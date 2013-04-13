using System.Windows;

namespace Converters
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var viewModel = new MainViewModel { Rating = 1 };

            var view = new MainView();
            view.DataContext = viewModel;
            view.Show();
        }
    }
}
