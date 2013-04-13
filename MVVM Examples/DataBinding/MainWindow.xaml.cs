using System.Collections.Generic;
using System.Windows;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Person _person;

        public MainWindow()
        {
            InitializeComponent();

            _person = new Person
                {
                    Name = "Bob",
                    Nicknames = new List<string>
                        {
                            "Original Nickname 1", 
                            "Original Nickname 2"
                        }
                };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _person.Name = "New Name";
            _person.Nicknames.Add("Additional Nickname");
        }
    }
}
