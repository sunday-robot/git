using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ColorAdjuster
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private Model _Model;
        private ViewModel _viewModel;

        public MainWindow()
        {
            _Model = new Model();
            _viewModel = new ViewModel(_Model);
            InitializeComponent();
            DataContext = _viewModel;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // 処理対象の画像ファイルをユーザーに指定してもらう。
            var ofd = new System.Windows.Forms.OpenFileDialog();
            var result = ofd.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK)
                return;
            _viewModel.LoadBitmap(ofd.FileName);
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 原画像と、変換後の画像の拡大率を、選択されたものに変更する。
        }

        // マウスドラッグで作成途中の矩形領域
        private RectangleRegion _newRectangleRegion;

        /// <summary>
        /// マウスドラッグ開始時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void image1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var p = e.GetPosition(this.OriginalImageImage);
            var dp = new System.Drawing.Point((int)p.X, (int)p.Y);
            _newRectangleRegion = new RectangleRegion
            {
                TopLeft = dp
            };
        }

        /// <summary>
        /// マウスドラッグ終了時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void image1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (this._newRectangleRegion == null)
            {
                // マウスボタンが押された状態で、本領域に進入しそこでマウスボタンが話された状態なので、なにもしない。
                return;
            }
            var p = e.GetPosition(this.OriginalImageImage);
            var dp = new System.Drawing.Point((int)p.X, (int)p.Y);
            _newRectangleRegion.BottomRight = dp;
            _viewModel.AddRegion(_newRectangleRegion);
            MessageBox.Show(_newRectangleRegion.ToString());
        }

    }
}
