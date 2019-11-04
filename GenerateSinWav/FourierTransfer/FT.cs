using System;

namespace FourierTransfer
{
    public class FT
    {
        /*
         * f(theta) = sigma(c[n] * e^(i * n * theta), n, -inf, +inf)
         * c[n] = 1 / 2 * pi * integral(f(theta) * e^(-i * n * theta), theta, -pi, pi)
         * 
         * オイラーの公式
         * e^(i * theta) = cos(theta) + i * sin(theta)
         */

        /// <summary>
        /// フーリエ変換を行う(=フーリエ級数群を求める)<br/>
        /// </summary>
        /// <remarks>
        /// 級数群Aと級数群Bの配列サイズは、同じにしておくこと。
        /// </remarks>
        /// <param name="f">変換対象の関数</param>
        /// <param name="a">級数群A</param>
        /// <param name="b">級数群B</param>
        public static void Transfer(double[] f, double[] a, double[] b)
        {
#if false
            int center = a.Length / 2;
            for (int i = 0; i < a.Length; i++)
            {
                var reSum = 0.0;
                var imSum = 0.0;
                var n = i - center;
                for (int j = 0; j < f.Length; j++)
                {
                    var theta = Math.PI * (j * 2.0 / f.Length - 1);
                    var nTheta = n * theta;
                    reSum += f[j] * Math.Cos(nTheta);
                    imSum -= f[j] * Math.Sin(nTheta);
                }
                a[i] = reSum / f.Length;
                b[i] = imSum / f.Length;
            }
#else
            int center = a.Length / 2;
            for (int i = 0; i < a.Length; i++)
            {
                var reSum = 0.0;
                var imSum = 0.0;
                var n = i - center;
                var deltaTheta = 2 * Math.PI / f.Length;
                for (int j = 0; j < f.Length; j++)
                {
                    var theta = Math.PI * (2.0 * j / f.Length - 1);
                    var nTheta = n * theta;
                    reSum += f[j] * Math.Cos(nTheta) * deltaTheta;
                    imSum -= f[j] * Math.Sin(nTheta) * deltaTheta;
                }
                a[i] = reSum;
                b[i] = imSum;
            }
#endif
        }

        /*
         * f(theta) = sigma(c[n] * e^(i * n * theta), n, -inf, +inf)
         */

        /// <summary>
        /// 逆フーリエ変換を行う<br/>
        /// </summary>
        /// <param name="a">級数群A</param>
        /// <param name="b">級数群B</param>
        /// <param name="f">逆変換された関数</param>
        public static void ReverseTransfer(double[] a, double[] b, double[] f)
        {
            int center = a.Length / 2;
            for (int i = 0; i < f.Length; i++)
            {
                var theta = Math.PI * (i * 2 / f.Length - 1);
                for (int j = 0; j < a.Length; j++)
                {
                    var n = j - center;
                    var x = n * theta;
                    var re = Math.Cos(x);
                    var im = Math.Sin(x);

                    var rere = a[j] * re - b[j] * im;
                    var imim = a[j] * im + b[j] * re;
                }
            }
        }

#if false
        public static void transfer(double[] f, Complex[] c)
        {
            int center = c.Length / 2;
            for (int i = 0; i < c.Length; i++)
            {
                var sum = new Complex(0, 0);
                for (int j = 0; j < f.Length; j++)
                {
                    var theta = Math.PI * (j * 2.0 / f.Length - 1);
                    sum += f[j] * epow(-(i - center) * theta);
                }
                c[i] = 1 / (2 * Math.PI) * sum;
            }
        }

        static Complex epow(double theta)
        {
            var re = Math.Cos(theta);
            var im = Math.Sin(theta);
            return new Complex(re, im);
        }

#endif
    }
#if false
    class Complex
    {
        public double Re;
        public double Im;

        public Complex(double re, double im)
        {
            Re = re;
            Im = im;
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Re + b.Re, a.Im + b.Im);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            var re = a.Re * b.Re - a.Im * b.Im;
            var im = a.Re * b.Im + a.Im * b.Re;
            return new Complex(re, im);
        }

        public static Complex operator *(double a, Complex b)
        {
            var re = a * b.Re;
            var im = a * b.Im;
            return new Complex(re, im);
        }
    }
#endif
}
