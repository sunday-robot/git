using System.Windows;

namespace BoundingRectangle
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        MyViewModel _vm => (MyViewModel)DataContext;

        public MainWindow()
        {
            DataContext = new MyViewModel();
            InitializeComponent();
            _vm.Width = 100;
            _vm.Height = 200;
            _vm.Angle = 30;
        }
    }
}
