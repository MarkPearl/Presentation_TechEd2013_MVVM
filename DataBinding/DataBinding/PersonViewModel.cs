using System.Collections.ObjectModel;
using System.ComponentModel;
using DataBinding.Annotations;

namespace DataBinding
{
    public class PersonViewModel : INotifyPropertyChanged
    {
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
        #endregion

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

        #region ...
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        #endregion
    }
}

