namespace MVVMCalc.Common
{
    using System;
    using System.Windows.Input;

    public sealed class DelegateCommand : ICommand
    {
        private readonly Action execute;

        private readonly Func<bool> canExecute;

        public DelegateCommand(Action execute) : this(execute, () => true) { }

        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        void ICommand.Execute(object parameter) => execute();

        bool ICommand.CanExecute(object parameter) => canExecute();

        /// <summary>
        /// CanExecuteの結果に変更があったことを通知するイベント。
        /// WPFのCommandManagerのRequerySuggestedイベントをラップする形で実装しています。
        /// </summary>
        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
