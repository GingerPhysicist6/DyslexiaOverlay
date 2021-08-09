using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Overlay
{
    public class RelayCommand : ICommand
    {
        Action<object> methodToCall;
        Predicate<object> canExecuteMethod;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> MethodToCall, Predicate<object> CanExecuteMethod)
        {
            methodToCall = MethodToCall;
            canExecuteMethod = CanExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            methodToCall(parameter);
        }
    }
}