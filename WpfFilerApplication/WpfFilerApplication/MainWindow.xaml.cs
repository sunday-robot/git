using System.Windows;
using WpfFilerApplication.ViewModel;

namespace WpfFilerApplication {
    /// <summary>
    /// Window1.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void SelectedDirectoryChanged(object sender, RoutedPropertyChangedEventArgs<object> e) {
            listViewFiles.DataContext = e.NewValue;
        }
    }
}
