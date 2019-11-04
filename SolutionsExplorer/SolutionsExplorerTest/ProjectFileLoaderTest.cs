using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using NUnit.Framework;
using SolutionsExplorer;

namespace SolutionsExplorerTest {
    //    [TestFixture]
    class ProjectFileLoaderTest {
        //        [Test]
        public void LoadTest() {
            var pf = ProjectFileLoader.Load(@"Sample.xml", @"..\..");
            foreach (var s in pf.SourceFiles) {
                System.Console.WriteLine(s);
            }
            System.Console.ReadLine();
            //            NUnit.Framework.Assert.IsNull(pf);
        }
    }
}
