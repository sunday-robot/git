using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolutionsExplorer;

namespace SolutionsExplorerTest {
    class SolutionFileLoaderTest {
        public static void Test() {
            LoadTest();
        }

        public static void LoadTest() {
//            var sf = SolutionFileLoader.Load(@"..\..\Sample.sln");
            var sf = SolutionFileLoader.Load(@"..\..\..\SolutionsExplorer.sln");
        }
    }
}
