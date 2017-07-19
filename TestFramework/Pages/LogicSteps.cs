using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace Pages
{
    static public class LogicSteps
    {
        private static string invalidLoginXpath = @"//li/a[text()='Login']";
        private static string validLoginXpath = @"//li/a[text()='Log Out']";
        private static string loginPageMainContainer = @"//div[@id='main-container-content']";


        public static LoginPage NavigateToPage(string url)
        {
            Driver.DriverInstance.Navigate().GoToUrl(url);
            return new LoginPage();
        }

        public static LoginPage LoginAs(this LoginPage page, string login, string password)
        {
            page.UserLogin.SendKeys(login);
            page.UserPassword.SendKeys(password);
            page.LoginButton.Click();
            return page;
        }

        public static bool IsValidLogin(this LoginPage page)
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

        public static LoginPage ChooseBeginningSymbol(this LoginPage page, string symbol)
        {
            page.Wait.Until(ExpectedConditions.ElementExists(By.XPath(loginPageMainContainer)));
            page.GetBeginningSymbolButtonBySymbol(symbol).Click();
            return page;
        }

        public static JournalPage GoToJournal(this LoginPage page, string name)
        {
            page.Wait.Until(ExpectedConditions.ElementExists(By.XPath(validLoginXpath)));
            page.GetJournalByName(name).Click();
            page.driver.SwitchTo().Window(page.driver.WindowHandles.Last());
            JournalPage journalPage = new JournalPage();
            return journalPage;
        }
        
        public static void AddFirstArticleToFavoritesFolderFromList(this JournalPage page, string folderName)
        {
            page.FirstArticleAddToFavorites.Click();
            page.WindowAddToFolder = new WindowAddToFolder();
            CreateNewFolder(page.WindowAddToFolder, folderName);
            page.WindowAddToFolder.AddItemButton.Click();
            page.WindowOperationStatus = new WindowOperationStatus();
            page.WindowOperationStatus.GoToFavoritesButton.Click();
        }

        public static void AddFirstArticleToFavoritesFolderFromArticle(JournalPage page, string folderName)
        {
            page.FirstArticleLink.Click();
            FirstArticlePage firstArticlePage = new FirstArticlePage();
            firstArticlePage.AddToFavorites.Click();
            firstArticlePage.WindowAddToFolder = new WindowAddToFolder();
            CreateNewFolder(firstArticlePage.WindowAddToFolder, folderName);
            firstArticlePage.WindowAddToFolder.AddItemButton.Click();
            firstArticlePage.WindowOperationStatus = new WindowOperationStatus();
            firstArticlePage.WindowOperationStatus.GoToFavoritesButton.Click();
        }

        public static MyFavoritesArticlesPage GoToFavoriteArticlesPage(LoginPage page)
        {
            page.UserActionToolBar.Click();
            page.FavoriteLink.Click();
            MyFavoritesArticlesPage favoritePage = new MyFavoritesArticlesPage();
            return favoritePage;
        }

        public static void DeleteFolder(MyFavoritesArticlesPage page)
        {
            page.DeleteLink.Click();
            page.WindowDeleteFolder = new WindowDeleteFolder();
            page.WindowDeleteFolder.DeleteButton.Click();
        }

        public static void CreateNewFolder(WindowAddToFolder window, string folderName)
        {
            window.InputFolderNameTextbox.SendKeys(folderName);
        }

        public static void Close(this BasePage page)
        {
            page.driver.Close();
        }

        public static JournalPlasticReconstructiveSurgeryPage GoToJournalPlasticReconstructiveSurgery(LoginPage page)
        {
            page.Wait.Until(ExpectedConditions.ElementExists(By.XPath(validLoginXpath)));
            JournalPlasticReconstructiveSurgeryPage journalPage = new JournalPlasticReconstructiveSurgeryPage();
            page.JournalPlasticReconstructiveSurgeyryLink.Click();
            return journalPage;
        }

        private static IWebElement GetJournalByName(this LoginPage page, string name)
        {
            return page.driver.FindElement(By.XPath(string.Concat("//h4/a[text()='", name, "']")));
        }

        private static IWebElement GetBeginningSymbolButtonBySymbol(this LoginPage page, string symbol)
        {
            return page.driver.FindElement(By.XPath(string.Concat("//div[@id='ej-journals-a-z-alpha-list']/a[text()='", symbol, "']")));
        }

    }
}
