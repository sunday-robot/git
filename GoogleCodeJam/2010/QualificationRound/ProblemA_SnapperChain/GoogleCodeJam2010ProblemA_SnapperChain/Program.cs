using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GoogleCodeJam2010ProblemA_SnapperChain {
    class Program {
        static void Main(string[] args) {
            using (var sr = new StreamReader(args[0])) {
                int t = int.Parse(sr.ReadLine());
                for (int i = 0; i < t; i++) {
                    var f = sr.ReadLine().Split();
                    int n = int.Parse(f[0]);
                    int k = int.Parse(f[1]);
                    System.Console.WriteLine("Case #" + (i + 1) + ": " + (snapper(n, k) ? "ON" : "OFF"));
                }
            }
            System.Console.ReadLine();
        }

        static bool snapper(int n, int k) {
            int nn = 1 << n;
            int kk = k % nn;
            return kk == nn - 1;
        }
    }
}
