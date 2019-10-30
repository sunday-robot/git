using System;

namespace AdamOptimizer
{
    /// <summary>
    /// 一つの重み値用のADAMオプティマイザー
    /// </summary>
    class AdamOptimizer
    {
        const double _epsilon = 0.00000001;
        readonly double _alpha;
        readonly double _beta1;
        readonly double _beta2;
        int _t = 0;
        double _m = 0;
        double _v = 0;

        public AdamOptimizer(double alpha = 0.001, double beta1 = 0.9, double beta2 = 0.999)
        {
            _alpha = alpha;
            _beta1 = beta1;
            _beta2 = beta2;
        }

        public double newW(   // 新しい重み値
            double w,   // 変更対象の重み値の現在の値
            double g)   // 重み値の微分値
        {
            _m = _beta1 * _m + (1 - _beta1) * g;
            _v = _beta2 * _v + (1 - _beta2) * g * g;

            var mHat = _m / (1 - Math.Pow(_beta1, _t));
            var vHat = _v / (1 - Math.Pow(_beta2, _t));
            var newW = w - _alpha * mHat / Math.Sqrt(vHat + _epsilon);

            _t++;

            return newW;
        }
    }
}
