using System;
using System.ComponentModel;
using System.Windows.Input;

namespace MvvmBindingSample
{
    public sealed class ViewModel : INotifyPropertyChanged
    {
        #region BindingProperties
        public string FirstName {
            get => model.FirstName;
            set => model.FirstName = value;
        }

        public string LastName {
            get => model.LastName;
            set => model.LastName = value;
        }

        public string FullName {
            get => model.FirstName + " " + model.LastName;
        }

        public ICommand ClearCommand { get => clearCommand; }
        #endregion BindingProperties

        public event PropertyChangedEventHandler PropertyChanged;

        readonly Model model;

        readonly DelegateCommand clearCommand;

        public ViewModel()
        {
            model = Model.Instance;
            model.PropertyChanged += ModelChangedHandlers;

            clearCommand = new DelegateCommand(
                (object parameter) =>
                {
                    model.FirstName = string.Empty;
                    model.LastName = string.Empty;
                },
                (object parameter) =>(model.FirstName.Length != 0) || (model.LastName.Length != 0));
        }

        void ModelChangedHandlers(object sender, PropertyChangedEventArgs eventArgs)
        {
            switch (eventArgs.PropertyName)
            {
                case nameof(Model.FirstName):
                    NotifyChanged(nameof(FirstName));
                    NotifyChanged(nameof(FullName));
                    clearCommand.RaiseCanExecuteChanged();
                    break;
                case nameof(Model.LastName):
                    NotifyChanged(nameof(LastName));
                    NotifyChanged(nameof(FullName));
                    clearCommand.RaiseCanExecuteChanged();
                    break;
                default:
                    throw new SystemException();
            }
        }

        void NotifyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
