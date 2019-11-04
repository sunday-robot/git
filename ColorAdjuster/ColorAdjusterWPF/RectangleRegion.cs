using System.Drawing;

namespace ColorAdjuster
{
    // 矩形領域を示すクラス
    public class RectangleRegion {
        public Point TopLeft { get; set; }  // 矩形領域の左上の位置
        public Point BottomRight { get; set; }      // 矩形領域の右下の位置

        public override string ToString() {
            return string.Format("({0},{1})-({2},{3})", TopLeft.X, TopLeft.Y, BottomRight.X, BottomRight.Y);
        }
    }
}
