using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionsExplorerTest {
    class App {
        public static void Main(string[] args) {
#if false
            var t = new ProjectFileLoaderTest();
            t.LoadTest();
#endif
            SolutionFileLoaderTest.Test();
            return;
        }
    }
}
