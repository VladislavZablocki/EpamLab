using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace Pages
{
    public class LogicSteps
    {
        private static string invalidLoginXpath = @"//li/a[text()='Login']";
        private static string validLoginXpath = @"//li/a[text()='Log Out']";


        public static LoginPage NavigateToPage(string url)
        {
            Driver.DriverInstance.Navigate().GoToUrl(url);
            return new LoginPage();
        }

        public static LoginPage LoginAs(LoginPage page, string login, string password)
        {
            page.UserLogin.SendKeys(login);
            page.UserPassword.SendKeys(password);
            page.LoginButton.Click();
            return page;
        }

        public static bool IsValidLogin(LoginPage page)
        {
            bool result = false;
            try
            {
                page.Wait.Until(ExpectedConditions.ElementExists(By.XPath(invalidLoginXpath)));
            }
            catch (WebDriverTimeoutException)
            {
                result = true;
            }
            return result;
        }

        public static JournalAACaseReportsPage GoToJournalAACaseReports(LoginPage page)
        {
            page.Wait.Until(ExpectedConditions.ElementExists(By.XPath(validLoginXpath)));
            page.JournalAACaseReportslLink.Click();
            page.driver.SwitchTo().Window(page.driver.WindowHandles.Last());
            JournalAACaseReportsPage journalPage = new JournalAACaseReportsPage();
            return journalPage;
        }

        public static JournalPlasticReconstructiveSurgeryPage GoToJournalPlasticReconstructiveSurgery(LoginPage page)
        {
            page.Wait.Until(ExpectedConditions.ElementExists(By.XPath(validLoginXpath)));
            page.PButton.Click();
            JournalPlasticReconstructiveSurgeryPage journalPage = new JournalPlasticReconstructiveSurgeryPage();
            page.JournalPlasticReconstructiveSurgeyryLink.Click();
            return journalPage;
        }

        public static void AddFirstArticleToFavoritesFolderFromList(JournalAACaseReportsPage page,string folderName)
        {
            page.FirstArticleAddToFavorites.Click();
            page.WindowAddToFolder = new WindowAddToFolder();
            CreateNewFolder(page, folderName);
            page.WindowAddToFolder.AddItemButton.Click();
            page.WindowOperationStatus = new WindowOperationStatus();
            page.WindowOperationStatus.GoToFavoritesButton.Click();
        }

        public static void AddFirstArticleToFavoritesFolderFromArticle(JournalAACaseReportsPage page, string folderName)
        {
            page.FirstArticleLink.Click();
            FirstArticlePage firstArticlePage = new FirstArticlePage();
            firstArticlePage.AddToFavorites.Click();
            firstArticlePage.WindowAddToFolder = new WindowAddToFolder();
            CreateNewFolder(firstArticlePage, folderName);
            firstArticlePage.WindowAddToFolder.AddItemButton.Click();
            firstArticlePage.WindowOperationStatus = new WindowOperationStatus();
            firstArticlePage.WindowOperationStatus.GoToFavoritesButton.Click();

        }

        //2 same methods. refactoring
        public static void CreateNewFolder(JournalAACaseReportsPage page,string folderName)
        {
            page.WindowAddToFolder.InputFolderNameTextbox.SendKeys(folderName);
        }

        public static void CreateNewFolder(FirstArticlePage page, string folderName)
        {
            page.WindowAddToFolder.InputFolderNameTextbox.SendKeys(folderName);
        }

        public static void Close(BasePage page)
        {
            page.driver.Close();
        }
    }
}
