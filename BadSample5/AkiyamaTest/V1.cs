using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Akiyama
{
    [TestClass]
    public class V1Test
    {
        bool Test(string newPassword, string userName, string currentPassword, bool result)
        {
            var target = new PasswordValidatorV1();
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
    }
}
