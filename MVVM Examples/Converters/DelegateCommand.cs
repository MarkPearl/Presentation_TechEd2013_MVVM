using System;
using System.Windows.Input;

namespace Converters
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _executeMethod;
        private readonly Func<bool> _canExecute;

        public DelegateCommand(Action executeMethod, Func<bool> canExecute)
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