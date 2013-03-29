using System.ComponentModel;
using DataBinding.Annotations;

namespace DataBinding
{
    public class PersonViewModel : INotifyPropertyChanged
    {
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

        public event PropertyChangedEventHandler PropertyChanged = delegate { }; 
    }
}

