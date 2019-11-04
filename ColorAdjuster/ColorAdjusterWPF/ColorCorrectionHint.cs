using System.Drawing;

namespace ColorAdjuster
{
    /// <summary>
    /// 色補正処理のためのヒント(画像内の領域と、その領域の本来の色)
    /// </summary>
    class ColorCorrectionHint
    {
        /// <summary>
        /// 画像内の矩形領域
        /// </summary>
        public RectangleRegion Region { set; get; }

        /// <summary>
        /// 画像内の矩形領域の(ユーザーにとって)本来の色
        /// </summary>
        public Color CorrectColor { set; get; }

        /// <summary>
        /// コンストラクタ(特記事項なし)
        /// </summary>
        /// <param name="region">画像内の領域</param>
        /// <param name="correctColor">画像内の領域の本来の色</param>
        public ColorCorrectionHint(RectangleRegion region, Color correctColor)
        {
            Region = region;
            CorrectColor = correctColor;
        }

        /// <summary>
        /// 画像内の領域の色(の平均)を返す
        /// </summary>
        /// <param name="bitmap">画像</param>
        /// <returns>画像内の領域の色(の平均)</returns>
        public Color getOriginalColor(Bitmap bitmap)
        {
            int r = 0;
            int g = 0;
            int b = 0;
            for (int y = Region.TopLeft.Y; y <= Region.BottomRight.Y; y++)
            {
                for (int x = Region.TopLeft.X; x <= Region.BottomRight.X; x++)
                {
                    var color = bitmap.GetPixel(x, y);
                    r += color.R;
                    g += color.G;
                    b += color.B;
                }
            }
            var pixelCount = (Region.BottomRight.X - Region.TopLeft.X + 1)
                * (Region.BottomRight.Y - Region.TopLeft.Y + 1);
            return Color.FromArgb(r / pixelCount, g / pixelCount, b / pixelCount);
        }
    }
}
