using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoveFileRandomly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveFileRandomly.Tests
{
    [TestClass()]
    public class FileConutFileUtilTests
    {
        [TestMethod()]
        public void SaveTest()
        {
            // テスト実行
            var dictionary = new Dictionary<string, int>();
            dictionary.Add("abc", 1);
            dictionary.Add("def", 2);
            dictionary.Add("000", 100);
            FileCountFileUtil.Save(dictionary, ".");

            // 結果確認
            var dictioanry2 = FileCountFileUtil.Load(".");
            Assert.AreEqual(dictionary.Count, dictioanry2.Count);
            foreach (var e in dictionary)
            {
                var v2 = dictioanry2[e.Key];
                Assert.AreEqual(e.Value, v2);
            }
        }
    }
}