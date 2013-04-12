using System.Windows;
using System.Windows.Input;

namespace Behaviours
{
    public class MainViewModel : ViewModelBase
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public ICommand DoSomething { get; set; }

        public MainViewModel()
        {
            DoSomething = new DelegateCommand(SayHello, CanSayHello);
        }
        private void SayHello()
        {
            MessageBox.Show("Hello " + Name);
        }

        private bool CanSayHello()
        {
            if (Name == "Bob") return true;
            return false;
        }
    }
}