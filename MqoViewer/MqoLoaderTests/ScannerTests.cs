using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mq.Tests
{
    [TestClass()]
    public class ScannerTests
    {
        /// <summary>
        /// 1
        /// </summary>
        [TestMethod()]
        public void GetTest_1()
        {
            _Test("abc", new List<object> { new Symbol("abc") });
        }

        /// <summary>
        /// 2-1
        /// </summary>
        [TestMethod()]
        public void GetTest_2_1()
        {
            _Test("123", new List<object> { 123.0 });
        }

        /// <summary>
        /// 2-2
        /// </summary>
        [TestMethod()]
        public void GetTest_2_2()
        {
            _Test("123.456", new List<object> { 123.456 });
        }

        /// <summary>
        /// 2-3
        /// </summary>
        [TestMethod()]
        public void GetTest_2_3()
        {
            _Test("-123", new List<object> { -123.0 });
        }

        /// <summary>
        /// 2-4
        /// </summary>
        [TestMethod()]
        public void GetTest_2_4()
        {
            _Test("-123.456", new List<object> { -123.456 });
        }

        /// <summary>
        /// 3
        /// </summary>
        [TestMethod()]
        public void GetTest_3()
        {
            _Test("\"string\"", new List<object> { "string" });
        }

        /// <summary>
        /// 4-1
        /// </summary>
        [TestMethod()]
        public void GetTest_4_1()
        {
            _Test(
                "abc {  }",
                new List<object>
                {
                    new Symbol("abc"),
                    new Symbol("{"),
                    new Symbol("}")
                });
        }

        /// <summary>
        /// 各テストメソッドの下請けメソッド
        /// </summary>
        /// <param name="inputString">input string</param>
        /// <param name="expectedTokens">expected result</param>
        private static void _Test(string inputString, List<object> expectedTokens)
        {
            // <param name="inputString">入力文字列</param>
            // <param name="expectedTokens">正しい処理結果(入力文字列をトークンのリストにしたもの)</param>
            var sr = new StringReader(inputString);
            var target = new Scanner(sr);
            target.FetchLine();
            foreach (var expected in expectedTokens)
            {
                var actual = target.Get();
                Assert.AreEqual(expected, actual);
            }

            Assert.IsNull(target.Get());
        }
    }
}