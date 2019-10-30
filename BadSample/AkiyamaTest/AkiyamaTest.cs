using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadSample.Akiyama
{
    [TestClass]
    public class AkiyamaTest
    {
        bool doTest(decimal amount, MemberRank memberRank, int years, decimal discountedAmount)
        {
            var ans = DiscountManager.ApplyDiscount(amount, memberRank, years);

            return ans == discountedAmount;
        }

        [TestMethod]
        public void _0_NotRegistered()
        {
            Assert.IsTrue(doTest(0m, MemberRank.NonMember, 0, 0m));
        }

        [TestMethod]
        public void _123_NotRegistered()
        {
            Assert.IsTrue(doTest(123m, MemberRank.NonMember, 0, 123m));
        }

        [TestMethod]
        public void _123_SimpleCustomer_0()
        {
            Assert.IsTrue(doTest(123m, MemberRank.Silver, 0, 123m * 0.9m));
        }

        [TestMethod]
        public void _123_SimpleCustomer_1()
        {
            Assert.IsTrue(doTest(123m, MemberRank.Silver, 1, 123m * 0.9m * 0.99m));
        }

        [TestMethod]
        public void _123_SimpleCustomer_3()
        {
            Assert.IsTrue(doTest(123m, MemberRank.Silver, 3, 123m * 0.9m * 0.97m));
        }

        [TestMethod]
        public void _123_SimpleCustomer_5()
        {
            Assert.IsTrue(doTest(123m, MemberRank.Silver, 5, 123m * 0.9m * 0.95m));
        }

        [TestMethod]
        public void _123_SimpleCustomer_6()
        {
            Assert.IsTrue(doTest(123m, MemberRank.Silver, 6, 123m * 0.9m * 0.95m));
        }

        [TestMethod]
        public void _123_ValuableCustomer_3()
        {
            Assert.IsTrue(doTest(123m, MemberRank.Gold, 3, 123m * 0.7m * 0.97m));
        }

        [TestMethod]
        public void _123_MostValuableCustomer_3()
        {
            Assert.IsTrue(doTest(123m, MemberRank.Platinum, 3, 123m * 0.5m * 0.97m));
        }
    }
}
