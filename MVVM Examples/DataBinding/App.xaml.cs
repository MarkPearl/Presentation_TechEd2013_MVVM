using System.Collections.Generic;
using System.Windows; 

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var person = new Person
            {
                Name = "Bob",
                Nicknames = new List<string> { "Original Nickname 1" }
            };

            var mainWindow = new MainWindow();

            mainWindow.DataContext = person;

            mainWindow.Show();
        } 
    }
}
