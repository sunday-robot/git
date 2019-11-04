using System;
using System.Windows.Input;

namespace MvvmBindingSample
{
    public sealed class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter) => executeAction(parameter);

        public bool CanExecute(object parameter) => canExecuteFunc(parameter);

        readonly Action<object> executeAction;

        readonly Func<object, bool> canExecuteFunc;

        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecuteFunc)
        {
            this.executeAction = executeAction;
            this.canExecuteFunc = canExecuteFunc;
        }

        public DelegateCommand(Action<object> executeAction) : this(executeAction, (_) => true) { }

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, null);
    }
}
