using System.ComponentModel;

namespace DataBinding.ViewModels
{
    public class PersonViewModel : ViewModelBase
    {
        private string _firstName;

        public PersonViewModel()
        {
            DoItCommand = new DelegateCommand(() => FirstName = "Reset", () => { return true; });
        }

        public DelegateCommand DoItCommand { get; set; }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
                }
            }
        }
    } 
}

