using Pages;
using NUnit.Framework;
using System.Configuration;

namespace Tests
{
    [TestFixture]
    public class TestLogin
    {
        [SetUp]
        public void SetDriver()
        {
            Driver.SetDriver(AllDrivers.FireFox);
        }

        [Test]
        public void Login_ValidLoginValidPassword_Enter()
        {
            LoginPage page = LogicSteps.NavigateToPage(@"http://journals.lww.com")
                .LoginAs(ConfigurationManager.AppSettings["ValidLogin"],
                ConfigurationManager.AppSettings["ValidPassword"]);
            bool actual = page.IsValidLogin();
            page.Close();
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void Login_ValidLoginInvalidPassword_DontEnter()
        {
            LoginPage page = LogicSteps.NavigateToPage(@"http://journals.lww.com")
                .LoginAs(ConfigurationManager.AppSettings["ValidLogin"],
                ConfigurationManager.AppSettings["InvalidPassword"]);
            bool actual = page.IsValidLogin();
            page.Close();
            Assert.AreEqual(false, actual);
        }

        [Test]
        public void Login_InvalidLoginValidPassword_DontEnter()
        {
            LoginPage page = LogicSteps.NavigateToPage(@"http://journals.lww.com")
                .LoginAs(ConfigurationManager.AppSettings["InvalidLogin"],
                ConfigurationManager.AppSettings["ValidPassword"]);
            bool actual = page.IsValidLogin();
            page.Close();
            Assert.AreEqual(false, actual);
        }

        [Test]
        public void Login_InvalidLoginInvalidPassword_DontEnter()
        {
            LoginPage page = LogicSteps.NavigateToPage(@"http://journals.lww.com")
               .LoginAs(ConfigurationManager.AppSettings["InvalidLogin"],
               ConfigurationManager.AppSettings["InvalidPassword"]);
            bool actual = page.IsValidLogin();
            page.Close();
            Assert.AreEqual(false, actual);
        }
    }
}
