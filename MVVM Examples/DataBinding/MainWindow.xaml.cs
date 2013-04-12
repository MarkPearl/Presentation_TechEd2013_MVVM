using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Person _cusotmer; 

        public MainWindow()
        {
            InitializeComponent();

            _cusotmer = new Person
                {
                    Name = "Bob", 
                    Nicknames = new List<string> {"Nickname 1", "Nickname 2"}
                };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _cusotmer.Name = "New Name";
            _cusotmer.Nicknames.Add("Another Nickname");
        }
    }
}
