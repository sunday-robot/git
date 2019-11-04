using System.Windows.Media.Imaging;

namespace LiveStitchingTest
{

    /// <summary>
    /// 2枚の画像(ここでは説明のため、基準画像と比較画像と呼ぶ)のズレ量を計算する。
    /// 画像マッチングにて、ある画像の相対座標を計算する。基準画像と、画像のニセの画像ずれ計算器
    /// 本来は2枚の画像から、ズレ量を計算するもの。
    /// </summary>
    public class ImageShiftCalculator
    {
        private ImageShiftCalculator()
        {
        }

        private static double _dummyX;
        private static double _dummyY;

        /// <summary>
        /// 2枚の画像のズレ量を計算する。
        /// ズレ量は、
        /// </summary>
        /// <param name="newImage"></param>
        /// <param name="oldImage"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void Calc(BitmapSource newImage, BitmapSource oldImage, out double x, out double y)
        {
            x = _dummyX;
            y = _dummyY;
        }

        public static void SetDummyXY(double x, double y)
        {
            _dummyX = x;
            _dummyY = y;
        }
    }
}
