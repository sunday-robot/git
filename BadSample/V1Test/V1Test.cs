using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadSample.V1
{
    [TestClass]
    public class V1Test
    {
        bool doTest(decimal amount, int accountStatus, int years, decimal discountedAmount)
        {
            var class1 = new Class1();

            var ans = class1.Calculate(amount, accountStatus, years);

            return ans == discountedAmount;
        }

        [TestMethod]
        public void _0_1()
        {
            Assert.IsTrue(doTest(0m, 1, 0, 0m));
        }

        [TestMethod]
        public void _123_1()
        {
            Assert.IsTrue(doTest(123m, 1, 0, 123m));
        }

        [TestMethod]
        public void _123_2_0()
        {
            Assert.IsTrue(doTest(123m, 2, 0, 123m * 0.9m));
        }

        [TestMethod]
        public void _123_2_1()
        {
            Assert.IsTrue(doTest(123m, 2, 1, 123m * 0.9m * 0.99m));
        }

        [TestMethod]
        public void _123_2_3()
        {
            Assert.IsTrue(doTest(123m, 2, 3, 123m * 0.9m * 0.97m));
        }

        [TestMethod]
        public void _123_2_5()
        {
            Assert.IsTrue(doTest(123m, 2, 5, 123m * 0.9m * 0.95m));
        }

        [TestMethod]
        public void _123_2_6()
        {
            Assert.IsTrue(doTest(123m, 2, 6, 123m * 0.9m * 0.95m));
        }

        [TestMethod]
        public void _123_3_3()
        {
            Assert.IsTrue(doTest(123m, 3, 3, 123m * 0.7m * 0.97m));
        }

        [TestMethod]
        public void _123_4_3()
        {
            Assert.IsTrue(doTest(123m, 4, 3, 123m * 0.5m * 0.97m));
        }
    }
}
