using System.Windows;
using System.Windows.Input;

namespace WpfPaint
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        WpfPaintModel model;
        ViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            model = new WpfPaintModel();
            viewModel = new ViewModel(model);
            DataContext = viewModel;
        }


        // マウスボタンを押したときに円を描画
        private void CanvasImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                viewModel.SrartDraw(e.GetPosition((IInputElement)sender));
        }

        // マウスを押しながら移動したときの描画 
        private void CanvasImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                viewModel.ExtendStroke(e.GetPosition((IInputElement)sender));
        }
    }
}
