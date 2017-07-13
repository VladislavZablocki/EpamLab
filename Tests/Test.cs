using Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;

namespace Tests
{
    [TestFixture]
    public class Test
    {
        [SetUp]
        public void SetDriver()
        {
            Driver.SetDriver(AllDrivers.FireFox);
        }

        [Test]
        public void ValidLogin()
        {
            bool actual = LogicSteps.NavigateToPage(@"https://journals.lww.com").LoginAs("Vladtest", "1234qwer").IsValidLogin();
            Assert.AreEqual(false, actual);
        }

        [Test]
        public void InvalidLogin()
        {
            bool actual = LogicSteps.NavigateToPage(@"https://journals.lww.com").LoginAs("ываывф", "1234qwer").IsValidLogin();
            Assert.AreEqual(false, actual);
        }
    }
}
