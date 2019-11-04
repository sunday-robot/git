using System;
using System.Collections.Generic;
using System.Drawing;

namespace ColorConverter
{
    /// <summary>
    /// おかしなホワイトバランス処理が施された画像の色を、指定された色訂正情報に従い変換する。
    /// ここでは入力画像の各画素のRGB値のについて、ホワイトバランス以外の色補正処理が行われていないことを前提としている。
    /// </summary>
    public class WhiteBalanceCorrecter : IColorConverter
    {
        /// <summary>
        /// ホワイトバランス補正用係数
        /// 元画像の画素値に、以下の係数をかけることで補正する。
        /// </summary>
        private double _kRed;
        private double _kGreen;
        private double _kBlue;

        /// <summary>
        /// コンストラクタ
        /// 引数で与えられた色の正誤表をもとに、補正用係数を計算する。
        /// ここでは単純に、正誤表の各行について補正係数を求め、この平均値を
        /// </summary>
        /// <param name="colorTuples">色の正誤表</param>
        public WhiteBalanceCorrecter(List<Tuple<Color, Color>> colorTuples)
        {
            foreach (var colorTuple in colorTuples)
            {
                var wrong = colorTuple.Item1;   // 元画像での誤った画素値
                var correct = colorTuple.Item2; // 本来の画素値
                _kRed += (double)correct.R / wrong.R;
                _kGreen += (double)correct.G / wrong.G;
                _kBlue += (double)correct.B / wrong.B;
            }
            _kRed /= colorTuples.Count;
            _kGreen /= colorTuples.Count;
            _kBlue /= colorTuples.Count;
        }

        /// <summary>
        /// 色を変換する
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public Color Convert(Color color)
        {
            int r = (int)Math.Max(_kRed * color.R, 255);
            int g = (int)Math.Max(_kGreen * color.G, 255);
            int b = (int)Math.Max(_kBlue * color.B, 255);
            return Color.FromArgb(r, g, b);
        }
    }
}
