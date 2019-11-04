using FourierTransfer;
using System;

namespace GenerateSinWav
{
    class FftTest
    {
        public void test1()
        {
            int n = 11;
            var a = new double[n];
            var b = new double[n];
            var f = new double[80];

            for (int i = 0; i < f.Length; i++)
            {
                f[i] = Math.Sin(i * 2 * Math.PI / f.Length - Math.PI);
                Console.WriteLine("f({0}) = {1:f3}", i, f[i]);
            }

            FT.Transfer(f, a, b);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("(a[{0}], b[{0}]) = ({1:f3}, {2:f3})", i, a[i], b[i]);
            }

            FT.ReverseTransfer(a, b, f);

            for (int i = 0; i < f.Length; i++)
            {
                Console.WriteLine("f({0}) = {1:f3}", i, f[i]);
            }

            Console.ReadLine();
        }

        public static void Main(string[] args)
        {
            var ft = new FftTest();
            ft.test1();
        }
    }
}
