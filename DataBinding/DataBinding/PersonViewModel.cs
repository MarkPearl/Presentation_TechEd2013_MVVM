using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace DataBinding
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        public MyDelegateCommand DoItCommand { get; set; }
        private bool _canExecute = true;

        public PersonViewModel()
        {
            DoItCommand = new MyDelegateCommand(DoThis, CanExecuteButton);
        }

        private bool CanExecuteButton()
        {
            return _canExecute;
        }

        private void DoThis()
        {
            MessageBox.Show("Hello World");
            _canExecute = false;
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

    public class MyDelegateCommand : ICommand
    {
        private readonly Action _executeMethod;
        private readonly Func<bool> _canExecute;

        public MyDelegateCommand(Action executeMethod, Func<bool> canExecute )
        {
            _executeMethod = executeMethod;
            _canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            _executeMethod.Invoke();
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke();
        }

        public event EventHandler CanExecuteChanged = delegate { }; 

        public void UpdateCanExecuteState()
        {
            CanExecuteChanged(this, EventArgs.Empty);            
        }
    } 
}

