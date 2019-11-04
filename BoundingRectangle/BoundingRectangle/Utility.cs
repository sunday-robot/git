using System;

namespace BoundingRectangle
{
    public static class Utility
    {
        public static void GetBoundingRectangleSize(double width, double height, double degree, out double brWidth, out double brHeight)
        {
            var radian = degree * Math.PI / 180;

            // 角度を0～π/2の範囲にする。
            if (radian < -Math.PI / 2)
                radian = Math.PI + radian;
            else if (radian < 0)
                radian = -radian;
            else if (radian > Math.PI / 2)
                radian = Math.PI - radian;

            var s = Math.Sin(radian);
            var c = Math.Cos(radian);

            brWidth = c * width + s * height;
            brHeight = s * width + c * height;
        }
    }
}
