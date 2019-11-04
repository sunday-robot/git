using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace UserNameControl
{
    /// <summary>
    /// ユーザーコントロールの習作
    /// 
    /// (仕様)
    /// コントロール名：
    /// UserNameControl
    /// 
    /// バインディングプロパティ；
    /// - 名前：
    /// UserName
    /// - 型：
    /// UserName(標準のものではなく、独自の型)
    /// 
    /// </summary>
    public partial class UserNameControl : UserControl, INotifyPropertyChanged
    {
        static readonly DependencyProperty UserNameProperty = DependencyProperty.Register(
               nameof(UserName),
               typeof(UserName),
               typeof(UserNameControl),
               new PropertyMetadata(
                   new UserName("", ""),   // default value
                   (d, e) => ((UserNameControl)d).UpdateView()));

        public event PropertyChangedEventHandler PropertyChanged;

        public UserName UserName {
            get => (UserName)GetValue(UserNameProperty);
            set {
                Console.WriteLine($"UserNameControlのUserName.setが呼ばれました。");
                SetValue(UserNameProperty, value);
            }
        }

        public string FirstName {
            get => UserName.FirstName;
            set  {
                Console.WriteLine($"UserNameControlのFirstName.setが呼ばれました。");
                UserName = new UserName(value, UserName.LastName);
            }
        }

        public string LastName {
            get => UserName.LastName;
            set => UserName = new UserName(UserName.FirstName, value);
        }

        public UserNameControl()
        {
            InitializeComponent();
        }

        void UpdateView()
        {
            Console.WriteLine($"UserNameControlの表示を更新します。");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
        }
    }
}
