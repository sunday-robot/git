using System;
using System.Collections.Generic;
using System.Drawing;

namespace ColorAdjuster
{
    public class Model
    {
        /// <summary>
        /// 画像
        /// </summary>
        public Bitmap Bitmap { private set; get; }

        /// <summary>
        /// 
        /// </summary>
        private string _bitmapFilePath = "(not loaded)";

        /// <summary>
        /// 色補正処理のためのヒント(画像内の領域と、その領域の本来の色)のリスト
        /// </summary>
        private List<ColorCorrectionHint> _colorCorrectionHints;

        public string BitmapFilePath
        {
            get
            {
                return _bitmapFilePath;
            }
        }

        public void SetBitmap(String bitmapFilePath, Bitmap bitmap)
        {
            _bitmapFilePath = bitmapFilePath;
            Bitmap = bitmap;
        }
    }
}
