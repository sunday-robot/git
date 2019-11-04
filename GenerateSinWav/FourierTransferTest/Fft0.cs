using System;

namespace GenerateSinWav
{
    public class Fft0
    {
        // a[n] = 1 / PI Int(-PI, PI, f(theta) * cos(n * theta))
        // b[n] = 1 / PI Int(-PI, PI, f(theta) * sin(n * theta))
        public static void transfer(double[] f, double[] a, double[] b, int n)
        {
            for (int i = 0; i < n; i++)
            {
                double aa = 0;
                double bb = 0;
                for (int t = 0; t < f.Length; t++)
                {
                    var nTheta = i * Math.PI * (t * 2.0 / f.Length - 1);
                    aa += f[t] * Math.Cos(nTheta);
                    bb += f[t] * Math.Sin(nTheta);
                }
                a[i] = aa * 2 / f.Length;
                b[i] = bb * 2 / f.Length;
            }
        }

        // f(theta) = a[0] / 2 + sigma(1, Infinity, a[n] * cos(n * theta) + b[n] * sin(n * theta)
        public static void reverseTransfer(double[] a, double[] b, int n, double[] f)
        {
            for (int t = 0; t < f.Length; t++)
            {
                double theta = Math.PI * (2.0 * t / f.Length - 1);
                double ff = a[0] / 2;
                for (int i = 1; i < n; i++)
                {
                    double nTheta = i * theta;
                    ff += a[i] * Math.Cos(nTheta) + b[i] * Math.Sin(nTheta);
                }
                f[t] = ff;
            }
        }
    }
}
