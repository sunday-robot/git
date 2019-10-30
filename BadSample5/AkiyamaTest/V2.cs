using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Akiyama
{
    [TestClass]
    public class V2Test
    {
        bool Test(string newPassword, string userName, string currentPassword, bool result)
        {
            var target = new PasswordValidatorV2();
            return target.IsValid(newPassword, userName, currentPassword) == result;
        }

        [TestMethod]
        public void TestValidPassword()
        {
            Assert.IsTrue(Test("12345678", "userName", "currentPassword", true));
        }

        [TestMethod]
        public void TestShortPassword()
        {
            Assert.IsTrue(Test("1234567", "userName", "currentPassword", false));
        }

        [TestMethod]
        public void TestSameAsUserName()
        {
            Assert.IsTrue(Test("userName", "userName", "currentPassword", false));
        }

        [TestMethod]
        public void TestSameAsCurrentPassword()
        {
            Assert.IsTrue(Test("currentPassword", "userName", "currentPassword", false));
        }

        [TestMethod]
        public void TestNgKeyword1()
        {
            Assert.IsTrue(Test("password", "userName", "currentPassword", false));
        }

        [TestMethod]
        public void TestNgKeyword2()
        {
            Assert.IsTrue(Test("qwerty", "userName", "currentPassword", false));
        }

        [TestMethod]
        public void TestNgKeyword3()
        {
            Assert.IsTrue(Test("abc123", "userName", "currentPassword", false));
        }

    }
}
