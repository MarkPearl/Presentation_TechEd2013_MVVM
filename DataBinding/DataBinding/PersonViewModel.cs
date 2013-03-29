using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace DataBinding
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        #region ...
        public MyDelegateCommand DoItCommand { get; set; }

        public PersonViewModel()
        {
            DoItCommand = new MyDelegateCommand(DoThis, () => { return true; });
        }

        private void DoThis()
        {
            PersonGender = Gender.Female;
        }

        #endregion        

        public Gender PersonGender
        {
            get { return _personGender; }
            set { 
                _personGender = value; 
                PropertyChanged(this, new PropertyChangedEventArgs("PersonGender"));
            }
        }

        #region ...
        private string _firstName;
        private Gender _personGender;

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
        #endregion
    }

    public enum Gender
    {
        Male = 0,
        Female = 1,
    }
}

