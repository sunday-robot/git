using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LiveStitchingTest
{
    class StitchedImage
    {
        /// <summary>
        /// 貼り合わせ画像の最大の長さ。
        /// 貼り合わせ画像の幅、高さがこれを超える場合は、長辺がこの長さとなる縮小画像となる。
        /// </summary>
        private const int _MaxLength = 1000;

        /// <summary>
        /// 貼り合わせ画像の本来(*)の左上頂点のX座標
        /// (*)貼り合わせ画像は単純に貼り合わせるだけではサイズが大きくなりすぎるので、幅、高さが
        /// _MaxLengthを超えないように縮小する。
        /// </summary>
        private double _X = 0;

        /// <summary>
        /// 貼り合わせ画像の本来の左上頂点のY座標
        /// </summary>
        private double _Y = 0;
        
        /// <summary>
        /// 貼り合わせ画像の本来の幅
        /// </summary>
        private double _Width = 0;

        /// <summary>
        /// 貼り合わせ画像の本来の高さ
        /// </summary>
        private double _Height = 0;

        /// <summary>
        /// 表示用に適当なサイズに縮小された画像。
        /// </summary>
        private BitmapSource _bitmap = null;

        public StitchedImage()
        {

        }

        public double X
        {
            get
            {
                return _X;
            }
            set
            {
                _X = value;
            }
        }

        public double Y
        {
            get
            {
                return _Y;
            }
            set
            {
                _Y = value;
            }
        }

        public double Width
        {
            get
            {
                return _Width;
            }
            set
            {
                _Width = value;
            }
        }

        public double Height
        {
            get
            {
                return _Height;
            }
            set
            {
                _Height = value;
            }
        }

        public BitmapSource BitmapSource
        {
            get
            {
                return _bitmap;
            }
            set
            {
                _bitmap = value;
            }
        }

        //RenderTargetBitmap _renderTargetBitmap;
        //private DrawingVisual _drawVisual = new DrawingVisual();
    }
}
