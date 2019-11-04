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
    public class FileSelectorTests
    {
        [TestMethod()]
        public void SelectTest()
        {
            var fileSizeDictionary = new Dictionary<string, long>();
            fileSizeDictionary.Add("abc", 1000);
            fileSizeDictionary.Add("def", 1000);
            fileSizeDictionary.Add("ghi", 1000);
            fileSizeDictionary.Add("jkl", 1000);

            var fileCounDictionary = new Dictionary<string, int>();
            fileCounDictionary.Add("abc", 1);
            fileCounDictionary.Add("def", 1);
            fileCounDictionary.Add("ghi", 1);
            fileCounDictionary.Add("jkl", 1);

            var selectedFiles = FileSelector.Select(fileSizeDictionary, fileCounDictionary, 5000000, 5);
            foreach (var e in selectedFiles)
            {
                Console.Out.WriteLine(e);
            }
            //            Assert.Fail();
        }

        private static long getFileSizeSum(List<string> selectedFiles, Dictionary<string, long> allFiles)
        {
            long sum = 0;
            foreach (var fileName in selectedFiles)
                sum += allFiles[fileName];
            return sum;
        }
    }
}