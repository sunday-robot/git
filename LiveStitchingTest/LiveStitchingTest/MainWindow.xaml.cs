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
using System.Drawing;
using System.Windows.Interop;

namespace LiveStitchingTest
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private LiveStitch _liveStitcher;
        private BitmapSource _dummyImage;

        public MainWindow()
        {
            InitializeComponent();

            _liveStitcher = new LiveStitch();
            var bitmap = (Bitmap)Bitmap.FromFile("dummy.jpg");
            var intPtr = bitmap.GetHbitmap();
            var sizeOptions = BitmapSizeOptions.FromEmptyOptions();
            _dummyImage = Imaging.CreateBitmapSourceFromHBitmap(intPtr, IntPtr.Zero, Int32Rect.Empty, sizeOptions);
            _dummyImage.Freeze();
        }

        private void ScrollViewer_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    ImageShiftCalculator.SetDummyXY(0, -100);
                    break;
                case Key.Down:
                    ImageShiftCalculator.SetDummyXY(0, 100);
                    break;
                case Key.Left:
                    ImageShiftCalculator.SetDummyXY(-100, 0);
                    break;
                case Key.Right:
                    ImageShiftCalculator.SetDummyXY(100, 0);
                    break;
                case Key.Enter:
                    var si = _liveStitcher.GetStitchedImage();
                    PngWriter.Write(si.BitmapSource, "aaa.png");
                    return;
                default:
                    return;
            }

            _liveStitcher.AddFrame(_dummyImage);
            var stitchedImage = _liveStitcher.GetStitchedImage();
            this.StitchedImage.Source = stitchedImage.BitmapSource;
            this.StitchedImage.Width = stitchedImage.BitmapSource.Width;
            this.StitchedImage.Height = stitchedImage.BitmapSource.Height;
        }

        private void ScrollViewer_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            ScrollViewer_KeyDown_1(sender, e);
            e.Handled = true;
        }
    }
}
