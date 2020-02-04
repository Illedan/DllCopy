using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DllCopy.View
{
    public class Command : ICommand
    {
        private readonly Action<object> _executable;
        private readonly Func<object, bool> _canExecute;

        public Command(Action<object> executable, Func<object, bool> canExecute)
        {
            _executable = executable;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if(!CanExecute(parameter))
            {
                return;
            }
            _executable(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
