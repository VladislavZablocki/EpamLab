using Pages;
using NUnit.Framework;
using System.Configuration;
using System.Reflection;
using System;
using OpenQA.Selenium;

namespace Tests
{
    [TestFixture]
    class TestSearch
    {
        [TestFixtureSetUp]
        public void CreateDictionary()
        {
            Type type = typeof(TestSearch);
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
        public void SearchWord_ResultsMoreThanHundred_True()
        {
            IWebDriver driver = Driver.GetDriver(MethodBase.GetCurrentMethod().Name);
            bool actual = LogicSteps.NavigateToPage(driver, ConfigurationManager.AppSettings["url"])
                .LoginAs(ConfigurationManager.AppSettings["ValidLogin"], ConfigurationManager.AppSettings["ValidPassword"])
                .ChooseBeginningSymbol(ConfigurationManager.AppSettings["BeginningSymbol"])
                .GoToJournal(ConfigurationManager.AppSettings["JournalPlasticAndReconstructiveSurgery"])
                .Search(ConfigurationManager.AppSettings["WordForSearch"])
                .IsResultsCountMoreThanHundred();
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void SearchWord_ResultsCountOnSecondPageSixty_True()
        {
            IWebDriver driver = Driver.GetDriver(MethodBase.GetCurrentMethod().Name);
            bool actual = LogicSteps.NavigateToPage(driver, ConfigurationManager.AppSettings["url"])
                .LoginAs(ConfigurationManager.AppSettings["ValidLogin"], ConfigurationManager.AppSettings["ValidPassword"])
                .ChooseBeginningSymbol(ConfigurationManager.AppSettings["BeginningSymbol"])
                .GoToJournal(ConfigurationManager.AppSettings["JournalPlasticAndReconstructiveSurgery"])
                .Search(ConfigurationManager.AppSettings["WordForSearch"])
                .ChooseNumberOfPage(ConfigurationManager.AppSettings["NumberOfPage"])
                .IsResultsCountOnPageSixty();
            Assert.AreEqual(true, actual);
        }
    }
}
