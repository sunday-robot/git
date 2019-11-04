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

namespace KuruKuru
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ellipse.Height = 10;
            Ellipse a;
        }

        private void _GameCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // クリックされた位置が回転軸の場合、回転させる。
            // 回転軸ではない場合、何もしない。
            // TODO
        }
    }

//    class PetalShape : Shape
//    {
////        PetalDrawing _PetalDrawing;

//        protected override void OnRender(DrawingContext drawingContext)
//        {
//            base.OnRender(drawingContext);
//        }
//    }

}
