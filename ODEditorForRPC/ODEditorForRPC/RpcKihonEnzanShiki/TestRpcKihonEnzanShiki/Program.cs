using System;
using System.Collections.Generic;
using System.Text;
using RpcKihonEnzanShiki;

namespace TestRpcKihonEnzanShiki {
    class Program {
        static void Main(string[] args) {
            TestRpcKihonEnzanShiki.TestMain();
            TestRpcKihonEnzanshikiLoader.TestMain();
            System.Console.ReadLine();
        }
    }

    public static class TestRpcKihonEnzanShiki {
        static void testRpcKihonEnzanShiki(string exp_string) {
            Expression e;
            try {
                e = Parser.Parse(exp_string);
            } catch (Exception exp) {
                System.Console.WriteLine("パース失敗。" + exp.Message);
                return;
            }
            System.Console.WriteLine("パース結果 : " + e.ToString());
            var ans = e.Evaluate(2, 3, 5);
            System.Console.WriteLine(exp_string + " = " + ans.ToString());
        }

        public static void TestMain() {
#if true
            testRpcKihonEnzanShiki("");
            testRpcKihonEnzanShiki("A");
            testRpcKihonEnzanShiki("A+B");
            testRpcKihonEnzanShiki("A+B+C");
            testRpcKihonEnzanShiki("-A");
            testRpcKihonEnzanShiki("-A-B");
            testRpcKihonEnzanShiki("1+3");
            testRpcKihonEnzanShiki("2*3");
            testRpcKihonEnzanShiki("2*3/4");
            testRpcKihonEnzanShiki("(2+3)*4/12");
            testRpcKihonEnzanShiki("(2-5)*4/12");
            testRpcKihonEnzanShiki("|2-5|*4/12+A");
            testRpcKihonEnzanShiki("|2-5|*4/12+A+D+a");
#endif
            testRpcKihonEnzanShiki("a");
            testRpcKihonEnzanShiki("A+");
            testRpcKihonEnzanShiki("((1+2)*(3+4)+4)/3");
            testRpcKihonEnzanShiki("|((1+2)*(3+4)+4)/3");
            testRpcKihonEnzanShiki("||2-5|+|2-C||");
        }
    }

    public static class TestRpcKihonEnzanshikiLoader {
        static void testRpcKihonEnzanShikiLoader(string fileName) {
            var list = RpcKihonEnzanShikiLoader.Load(fileName);
            foreach (var e in list) {
                System.Console.WriteLine(e.ToString());
            }
        }

        public static void TestMain() {
            testRpcKihonEnzanShikiLoader("Parameter\\AnalysisParameters\\ReactionProfileCheckFormula.xml");
        }
    }
}
