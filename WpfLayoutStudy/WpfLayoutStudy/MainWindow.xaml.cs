using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfLayoutStudy
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private CanvasLayoutStudyWindow _CanvasLayoutStudyWindow;
        private StackPanelLayoutStudyWindow _StackPanelLayoutStudyWindow;
        private DockPanelLayoutStudyWindow _DockPanelLayoutStudyWindow;
        private ExplorerLikeWindow _ExplorerLikeWindow;
        private ScrollViewerStudyWindow _ScrollViewerStudyWindow = new ScrollViewerStudyWindow();

        public MainWindow()
        {
            InitializeComponent();
            _CanvasLayoutStudyWindow = new CanvasLayoutStudyWindow();
            _StackPanelLayoutStudyWindow = new StackPanelLayoutStudyWindow();
            _DockPanelLayoutStudyWindow = new DockPanelLayoutStudyWindow();
            _ExplorerLikeWindow = new ExplorerLikeWindow();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _CanvasLayoutStudyWindow.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _StackPanelLayoutStudyWindow.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _DockPanelLayoutStudyWindow.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            _ExplorerLikeWindow.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            _ScrollViewerStudyWindow.ShowDialog();
        }
    }
}
