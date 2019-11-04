using System;
using System.Collections.Generic;
using System.Text;
using RpcKomokubetsuEnzanShiki;

namespace TestRpcKomokubetsuEnzanShiki {
    class Program {
        static void test() {
            var list = Loader.Load("Parameter\\AnalysisParameters\\ReactionProfileCheck.PRM");
            System.Console.WriteLine(list.ToString());
        }

        static void Main(string[] args) {
            test();
            System.Console.ReadLine();
        }
    }
}
