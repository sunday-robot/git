using System;
using System.ComponentModel;

namespace MvvmBindingSample
{
    public sealed class Model : INotifyPropertyChanged
    {
        public static Model Instance = new Model();

        string firstName = "(fist name)";

        string lastName = "(last name)";

        public event PropertyChangedEventHandler PropertyChanged;

        public string FirstName {
            get => firstName;
            set {
                firstName = value;
                notifyPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName {
            get => lastName;
            set {
                lastName = value;
                notifyPropertyChanged(nameof(LastName));
            }
        }
        void notifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
