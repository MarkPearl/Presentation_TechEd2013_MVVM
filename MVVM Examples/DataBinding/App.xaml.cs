using System.Collections.Generic;
using System.Windows;
using DataBinding.Stuff;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            #region ...

            var frodo = new Dog
                {
                    Name = "Frodo",
                    Nicknames = new List<string> { "doggy dog" }
                };

            var kit = new Car
                {
                    Name = "Kit"
                };            

            #endregion       

            var person = new Person
            {
                Name = "Bob",
                Nicknames = new List<string> { "Original Nickname 1" }
            };

            var mainWindow = new MainWindow();
            mainWindow.Show();            
        }
    }
}
