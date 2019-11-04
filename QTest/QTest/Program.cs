using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = Q.RotationQ(0, 0, 1, Math.PI / 180);
            var v = new double[] { 1, 0, 0 };
            for (var i = 0; i < 180; i++)
            {
                v = q.Rotate(v);
                printVector3(v);
            }
            ;
        }

        private static void printVector3(double[] v) {
            Console.WriteLine("({0:f4}, {1:f4}, {2:f4})", v[0], v[1], v[2]);
        }
    }
}
