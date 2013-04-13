using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Commanding
{
    public class MainViewModel : ViewModelBase
    {
        private string _name;

        public ICommand DoSomething { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }                    
    }       
}