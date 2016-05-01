using System;
using System.Windows.Input;

namespace LiveChatMobile.ViewModels
{
    public class DelegateCommand : ICommand
    {
        Action<object> execute;
        Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> _execute, Func<object, bool> _canExecute)
        {
            execute = _execute;
            canExecute = _canExecute;
        }

        public DelegateCommand(Action<object> _execute)
        {
            execute = _execute;
            canExecute = AlwaysCanExecute;
        }

        public void Execute(object param)
        {
            execute(param);
        }

        public bool CanExecute(object param)
        {
            return canExecute(param);
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }

        private bool AlwaysCanExecute(object param)
        {
            return true;
        }
    }
}
