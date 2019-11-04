using System;
using System.Collections.Generic;
using System.Drawing;

namespace ColorConverter
{
    public sealed class MyColorConverter : IColorConverter {

        private List<Tuple<Color, Color>> _colorTuples;
        /// <summary>
        /// 色の変換を行う。
        /// </summary>
        /// <param name="color">処理対象の色</param>
        /// <param name="colorTuples">色変換情報</param>
        /// <returns></returns>
        public MyColorConverter(List<Tuple<Color, Color>> colorTuples) {
            _colorTuples = colorTuples;
        }

        public Color Convert(Color color) {
            double weightSum = 0;
            double wr = 0;
            double wg = 0;
            double wb = 0;
            foreach (var colorTuple in _colorTuples) {
                var weight = GetWeight(colorTuple.Item1, color);
                var difference = GetColorDifference(colorTuple.Item2, colorTuple.Item1);
                wr += weight * difference.Item1;
                wg += weight * difference.Item2;
                wb += weight * difference.Item3;
                weightSum += weight;
            }
            int r = RoundToByte(color.R + wr / weightSum);
            int g = RoundToByte(color.G + wg / weightSum);
            int b = RoundToByte(color.B + wb / weightSum);
            return Color.FromArgb(r, g, b);
        }

        private static double GetWeight(Color color1, Color color2) {
            var difference = GetColorDifference(color1, color2);
            var distance = GetLength(difference);
            var weight = 1 / (distance + 1);
            return weight;
        }

        private static int RoundToByte(double v) {
            if (v < 0)
                return 0;
            if (v > 255)
                return 255;
            return (int)v;
        }

        private static Tuple<int, int, int> GetColorDifference(Color color1, Color color2) {
            var r = (int)color1.R - (int)color2.R;
            var g = (int)color1.G - (int)color2.G;
            var b = (int)color1.B - (int)color2.B;
            return new Tuple<int, int, int>(r, g, b);
        }

        private static double GetLength(Tuple<int, int, int> v) {
            return Math.Sqrt(v.Item1 * v.Item1 + v.Item2 * v.Item2 + v.Item3 * v.Item3);
        }

        private class ColorDifference {
            int r;
            int g;
            int b;
        }
    }

}