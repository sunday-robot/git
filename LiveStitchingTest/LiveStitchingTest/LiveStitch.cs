using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LiveStitchingTest
{
    class LiveStitch
    {
        #region constants

        /// <summary>
        /// 貼り合わせを行う周期[frame]
        /// </summary>
        private const int _stitchingInterval = 1;

        #endregion constants

        #region member variables

        /// <summary>
        /// 最新フレームの位置(最初の画像位置が原点)[pixel]
        /// </summary>
        private double _lastFrameX;

        /// <summary>
        /// 最新フレームの位置(最初の画像位置が原点)[pixel]
        /// </summary>
        private double _lastFrameY;

        /// <summary>
        /// 最新フレームの画像(次の画像とのずれ量算出を行うのに必要)
        /// </summary>
        private BitmapSource _lastFrameBitmap;

#if false
        /// <summary>
        /// 最も左に位置したフレームのX座標[pixel]
        /// </summary>
        private double _left;

        /// <summary>
        /// 最も上に位置したフレームのY座標[pixel]
        /// </summary>
        private double _top;

        /// <summary>
        /// 最も右に位置したフレームの右辺のX座標[pixel]
        /// </summary>
        private double _right;

        /// <summary>
        /// 最も下に位置したフレームの下辺のY座標[pixel]
        /// </summary>
        private double _bottom;
#endif
        /// <summary>
        /// 貼り合わせ画像
        /// </summary>
        private StitchedImage _stitchedImage;


        /// <summary>
        /// フレームカウンタ
        /// 画像合成処理は、指定されたインターバルでしか行われない。この変数でインターバルカウントを行う。
        /// </summary>
        private int _frameCount;

        #endregion member variables

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="cellWidth">個別画像の幅[pixel]</param>
        /// <param name="cellHeight">個別画像の高さ[pixel]</param>
        public LiveStitch()
        {
            _lastFrameX = 0;
            _lastFrameY = 0;
            _lastFrameBitmap = null;

#if false
            _left = 0;
            _top = 0;
            _right = 0;
            _bottom = 0;
#endif
            _stitchedImage = new StitchedImage();
            _frameCount = 0;
        }

        #region public methods
        /// <summary>
        /// 新たな画像を追加する。
        /// (貼り合わせ画像生成は、指定されたインターバルで行われる)
        /// </summary>
        /// <param name="newFrame"></param>
        public void AddFrame(BitmapSource newFrame)
        {
            Console.WriteLine("AddFrame()");

            // 直前の画像との位置のズレを求める。
            double x;
            double y;
            _CalculateRelativePosition(_lastFrameBitmap, newFrame, out x, out y);
            Console.WriteLine("RelativePosition = ({0}, {1})", x, y);

            _lastFrameX += x;
            _lastFrameY += y;
            _lastFrameBitmap = newFrame;

            if (_frameCount == 0)
            {
                var newX = Math.Min(_lastFrameX, _stitchedImage.X);
                var newRight = Math.Max(_lastFrameX + _lastFrameBitmap.Width, _stitchedImage.X + _stitchedImage.Width);
                var newY = Math.Min(_lastFrameY, _stitchedImage.Y);
                var newBottom = Math.Max(_lastFrameY + _lastFrameBitmap.Height, _stitchedImage.Y + _stitchedImage.Height);
                var newWidth = newRight - newX;
                var newHeight = newBottom - newY;

                Console.WriteLine("StichedImage = ({0}, {1}), ({2}, {3})", newX, newY, newWidth, newHeight);

                // 画像合成を行う
                int reductionRatio;
                _GetStrictedImageSize(newWidth, newHeight, 1000, out reductionRatio);

                // 
                var rtb = new RenderTargetBitmap((int)(newWidth / reductionRatio), (int)(newHeight / reductionRatio), 96, 96, PixelFormats.Default);
                var dv = new DrawingVisual();
                {
                    var dc = dv.RenderOpen();

                    if (_stitchedImage != null)
                    {
                        // 現状の貼り合わせ画像を、新しい貼り合わせ画像に貼り付ける。
                        dc.DrawImage(_stitchedImage.BitmapSource, new Rect(
                            (_stitchedImage.X - newX) / reductionRatio,
                            (_stitchedImage.Y - newY) / reductionRatio,
                            _stitchedImage.Width / reductionRatio,
                            _stitchedImage.Height / reductionRatio));
                    }
                    // 新しい画像も貼り付ける。
                    dc.DrawImage(newFrame, new Rect(
                        (_lastFrameX - newX) / reductionRatio,
                        (_lastFrameY - newY) / reductionRatio,
                        newFrame.Width / reductionRatio,
                        newFrame.Height / reductionRatio));
                    dc.Close();
                }
                rtb.Render(dv);
                _stitchedImage.X = newX;
                _stitchedImage.Y = newY;
                _stitchedImage.Width = newWidth;
                _stitchedImage.Height = newHeight;
                _stitchedImage.BitmapSource = rtb;
            }

            _frameCount++;
            if (_frameCount >= _stitchingInterval)
                _frameCount = 0;
        }

        private static Rect _translate(Rect oldRect, double ox, double oy, double newMagnificationRatio)
        {
            var newRect = new Rect(
                (oldRect.X - ox) * newMagnificationRatio,
                (oldRect.Y - oy) * newMagnificationRatio,
                oldRect.Width * newMagnificationRatio,
                oldRect.Height * newMagnificationRatio);
            return newRect;
        }

        /// <summary>
        /// 貼り合わせ画像を返す。
        /// </summary>
        /// <returns>貼り合わせ画像</returns>
        public StitchedImage GetStitchedImage()
        {
            return _stitchedImage;
            //width = _right - _left;
            //height = _bottom - _top;
        }

        #endregion public methods

        #region private methods

        /// <summary>
        /// lastImageを基準として、newImageの相対座標を計算する。
        /// </summary>
        /// <param name="baseImage"></param>
        /// <param name="newImage"></param>
        /// <param name="x">newImageの相対座標X</param>
        /// <param name="y">newImageの相対座標Y</param>
        private static void _CalculateRelativePosition(BitmapSource baseImage, BitmapSource newImage, out double x, out double y)
        {
            if (baseImage == null)
            {
                x = 0;
                y = 0;
                return;
            }
            ImageShiftCalculator.Calc(newImage, baseImage, out x, out y);
#if false
            x = (_random.NextDouble() - 0.5) * 100;
            y = (_random.NextDouble() - 0.5) * 100;
#endif
        }

        #endregion private methods

        private static Random _random = new Random();

        private static void _GetStrictedImageSize(
            double originalWidth, double originalHeight, int maxLength, out int reductionRatio)
        {
            var originalLength = Math.Max(originalWidth, originalHeight);
            if (originalLength <= maxLength)
                reductionRatio = 1;
            else
            {
                reductionRatio =  1 << ((int) Math.Ceiling(Math.Log(originalLength / maxLength, 2)));
            }
        }

#if false
        public void GetSumShiftInRestrictedImage(out int x, out int y)
        {
            x = 
        }
#endif
    }
}
