using Pages;
using NUnit.Framework;
using System.Configuration;

namespace Tests
{
    [TestFixture]
    class TestFavoritesArticle
    {
        [SetUp]
        public void SetDriver()
        {
            Driver.SetDriver(AllDrivers.FireFox);
        }

        [Test]
        public void AddToFavoriteFromList()
        {
            LogicSteps.NavigateToPage(ConfigurationManager.AppSettings["url"])
                .LoginAs(ConfigurationManager.AppSettings["ValidLogin"],ConfigurationManager.AppSettings["ValidPassword"])
                .GoToJournal(ConfigurationManager.AppSettings["JournalPlasticAndReconstructiveSurgery"]);
           
            
        }

        //[Test]
        //public void AddToFavoriteFromArticle()
        //{
        //    JournalAACaseReportsPage page = LogicSteps.GoToJournalAACaseReports(
        //        LogicSteps.NavigateToPage(@"http://journals.lww.com")
        //        .LoginAs("Vladtest", "1234qwer"));
        //    LogicSteps.AddFirstArticleToFavoritesFolderFromArticle(page, "new");
        //}

        ////[TearDown]
        //public void DeleteFolder()
        //{
        //    MyFavoritesArticlesPage page = LogicSteps.GoToFavoriteArticlesPage(
        //        LogicSteps.NavigateToPage(@"http://journals.lww.com")
        //        .LoginAs("Vladtest", "1234qwer"));
        //    LogicSteps.DeleteFolder(page);
        //}
    }
}
