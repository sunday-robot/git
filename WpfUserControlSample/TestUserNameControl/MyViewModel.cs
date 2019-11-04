using System;
using System.ComponentModel;
using UserNameControl;

namespace WpfUserControlSample
{
    class MyViewModel : INotifyPropertyChanged
    {
        string firstName = "";
        string lastName = "";

        public event PropertyChangedEventHandler PropertyChanged;

        void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public UserName UserName {
            get => new UserName(firstName, lastName);
            set {
                Console.WriteLine($"ViewModelの、UserName.setが呼ばれました。");
                firstName = value.FirstName;
                lastName = value.LastName;
                Console.WriteLine($"ViewModelから、UserNameの更新を通知します。");
                NotifyPropertyChanged(nameof(UserName));
                Console.WriteLine($"ViewModelから、FullNameの更新を通知します。");
                NotifyPropertyChanged(nameof(FullName));
            }
        }

        public string FullName {
            get => $"<<{firstName}>> <<{lastName}>>";
        }

        internal void ClearUserName()
        {
            UserName = new UserName("", "");
        }
    }
}
