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
            LoginPage page = LogicSteps.LoginAs(
                    LogicSteps.NavigateToPage(@"http://journals.lww.com"), "Vladtest", "1234qwer");
            bool actual = LogicSteps.IsValidLogin(page);
            LogicSteps.Close(page);
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void InvalidLogin()
        {
            LoginPage page = LogicSteps.LoginAs(
                    LogicSteps.NavigateToPage(@"http://journals.lww.com"), "Vladtesfds", "1234qwer");
            bool actual = LogicSteps.IsValidLogin(page);
            LogicSteps.Close(page);
            Assert.AreEqual(false, actual);
        }

        [Test]
        public void GoFirstLink()
        {
            JournalPage page = LogicSteps.GoToFirstJournal(
                LogicSteps.LoginAs(
                    LogicSteps.NavigateToPage(@"http://journals.lww.com"), "Vladtest", "1234qwer"));
            LogicSteps.AddFirstArticleToFavoritesFolderFromList(page,"new");
        }

        [Test]
        public void TestFromArticle()
        {
            JournalPage page = LogicSteps.GoToFirstJournal(
                LogicSteps.LoginAs(
                    LogicSteps.NavigateToPage(@"http://journals.lww.com"), "Vladtest", "1234qwer"));
            LogicSteps.AddFirstArticleToFavoritesFolderFromArticle(page, "new");
        }

        [Test]
        public void GoToPlasticAndReconstructiveSurgeryJournaltest()
        {
            JournalPlasticReconstructiveSurgeryPage page = LogicSteps.GoToJournalPlasticReconstructiveSurgery(
                LogicSteps.LoginAs(
                    LogicSteps.NavigateToPage(@"http://journals.lww.com"), "Vladtest", "1234qwer"));
        }
    }
}
