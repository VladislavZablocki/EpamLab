using Pages;
using NUnit.Framework;
using System.Configuration;
using System.Reflection;
using System;
using OpenQA.Selenium;

namespace Tests
{
    [TestFixture]
    class TestFavoritesArticle
    {
        [TestFixtureSetUp]
        public void CreateDictionary()
        {
            Type type = typeof(TestFavoritesArticle);
            Driver.SetDriver(AllDrivers.FireFox);
            foreach (var method in type.GetMethods())
            {
                if (method.Name != "CreateDictionary" && method.ReturnType.Name == "Void")
                {
                    Driver.AddToDictionary(method.Name);
                }
            }
        }

        [Test]
        [Parallelizable]
        public void AddToFavoriteFromList()
        {
            IWebDriver driver = Driver.GetDriver(MethodBase.GetCurrentMethod().Name);
            MyFavoritesArticlesPage page = LogicSteps.NavigateToPage(driver, ConfigurationManager.AppSettings["url"])
                .LoginAs(ConfigurationManager.AppSettings["ValidLogin"], ConfigurationManager.AppSettings["ValidPassword"])
                .GoToJournal(ConfigurationManager.AppSettings["JournalNameAACaseReports"])
                .AddFirstArticleToFavoritesFromList(ConfigurationManager.AppSettings["ArticleNameSpinCordSrimulation"], ConfigurationManager.AppSettings["FolderName1"]);
            bool actual = page.IsArticleInFavorites(ConfigurationManager.AppSettings["ArticleNameSpinCordSrimulation"]);
            page.DeleteFolder();
            Assert.AreEqual(true, actual);
        }

        [Test]
        [Parallelizable]
        public void AddToFavoriteFromArticle()
        {
            IWebDriver driver = Driver.GetDriver(MethodBase.GetCurrentMethod().Name);
            MyFavoritesArticlesPage page = LogicSteps.NavigateToPage(driver, ConfigurationManager.AppSettings["url"])
                .LoginAs(ConfigurationManager.AppSettings["ValidLogin"], ConfigurationManager.AppSettings["ValidPassword"])
                .GoToJournal(ConfigurationManager.AppSettings["JournalNameAACaseReports"])
                .AddFirstArticleToFavoritesFolderFromArticle(ConfigurationManager.AppSettings["ArticleNameSpinCordSrimulation"], ConfigurationManager.AppSettings["FolderName2"]);
            bool actual = page.IsArticleInFavorites(ConfigurationManager.AppSettings["ArticleNameSpinCordSrimulation"]);
            page.DeleteFolder();
            Assert.AreEqual(true, actual);
        }
    }
}
