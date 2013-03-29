using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace DataBinding
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        public MyDelegateCommand DoItCommand { get; set; }

        public PersonViewModel()
        {
            DoItCommand = new MyDelegateCommand(DoThis, () => { return true; });
        }

        private void DoThis()
        {
            MessageBox.Show("Hello World");
            DoItCommand.UpdateCanExecuteState();
        }

        #region ...
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
                }
            }
        }

        private ObservableCollection<string> _nicknames;
        
        public ObservableCollection<string> NickNames
        {
            get { return _nicknames; }
            set
            {
                if (_nicknames != value)
                {
                    _nicknames = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Nicknames"));
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        #endregion
    }
}

