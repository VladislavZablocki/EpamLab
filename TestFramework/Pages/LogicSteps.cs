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

        public static LoginPage NavigateToPage(IWebDriver driver,string url)
        {
            LoginPage page = new LoginPage(driver);
            page.driver.Navigate().GoToUrl(url);
            return new LoginPage(driver);
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
            JournalPage journalPage = new JournalPage(page.driver);
            return journalPage;
        }
        
        public static MyFavoritesArticlesPage AddFirstArticleToFavoritesFromList(this JournalPage page,string articleName, string folderName)
        {
            page.GetAddToFavoritesLinkFromListByArticleName(articleName).Click();
            page.WindowAddToFolder = new WindowAddToFolder(page.driver);
            CreateNewFolder(page.WindowAddToFolder, folderName);
            page.WindowAddToFolder.AddItemButton.Click();
            page.WindowOperationStatus = new WindowOperationStatus(page.driver);
            page.WindowOperationStatus.GoToFavoritesButton.Click();
            return new MyFavoritesArticlesPage(page.driver);
        }

        public static MyFavoritesArticlesPage AddFirstArticleToFavoritesFolderFromArticle(this JournalPage page, string articleName, string folderName)
        {
            page.GetArticleLinkByName(articleName).Click();
            ArticlePage firstArticlePage = new ArticlePage(page.driver);
            firstArticlePage.AddToFavorites.Click();
            firstArticlePage.WindowAddToFolder = new WindowAddToFolder(page.driver);
            CreateNewFolder(firstArticlePage.WindowAddToFolder, folderName);
            firstArticlePage.WindowAddToFolder.AddItemButton.Click();
            firstArticlePage.WindowOperationStatus = new WindowOperationStatus(page.driver);
            firstArticlePage.WindowOperationStatus.GoToFavoritesButton.Click();
            return new MyFavoritesArticlesPage(firstArticlePage.driver);
        }

        public static bool IsArticleInFavorites(this MyFavoritesArticlesPage page, string articleName)
        {
            bool result = true;
            try
            {
                page.Wait.Until(ExpectedConditions.ElementExists(By.XPath(string.Concat("//a[@title='", articleName,"']"))));
            }
            catch (WebDriverException)
            {
                result = false;
            }
            return result;
        }

        public static void DeleteFolder(this MyFavoritesArticlesPage page)
        {
            page.DeleteLink.Click();
            page.WindowDeleteFolder = new WindowDeleteFolder(page.driver);
            page.WindowDeleteFolder.DeleteButton.Click();
        }

        public static void CreateNewFolder(WindowAddToFolder window, string folderName)
        {
            window.NewFolderLabel.Click();
            window.InputFolderNameTextbox.SendKeys(folderName);
        }

        public static SearchingPage Search(this JournalPage page, string word)
        {
            page.SearchBox.SendKeys(word);
            page.SearchButton.Click();
            return new SearchingPage(page.driver);
        }

        public static bool IsResultsCountMoreThanHundred(this SearchingPage page)
        {
            page.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='resultCount']")));
            return int.Parse(page.SearchingResultsCount.Text.Replace("results", string.Empty)) > 100;
        }

        public static bool IsResultsCountOnPageSixty(this SearchingPage page)
        {
            return page.SearchingResults.Count == 60;
        }
        
        //WAIT loading the second page
        public static SearchingPage ChooseNumberOfPage(this SearchingPage page,string pageNumber)
        {
            page.GetNumberPageOfSearch(pageNumber).Click();
            //page.Wait.Until(ExpectedConditions.TextToBePresentInElement(page.driver.FindElement(By.XPath("//a[@class='selectedpage']")), pageNumber));
            return page;
        }

        public static void Close(this BasePage page)
        {
            page.driver.Close();
        }

        private static IWebElement GetJournalByName(this LoginPage page, string name)
        {
            return page.driver.FindElement(By.XPath(string.Concat("//h4/a[text()='", name, "']")));
        }

        private static IWebElement GetBeginningSymbolButtonBySymbol(this LoginPage page, string symbol)
        {
            return page.driver.FindElement(By.XPath(string.Concat("//div[@id='ej-journals-a-z-alpha-list']/a[text()='", symbol, "']")));
        }

        private static IWebElement GetAddToFavoritesLinkFromListByArticleName(this JournalPage page, string articleName)
        {
            return page.driver.FindElement(By.XPath(string.Concat("//a[@title='",articleName,"']//ancestor::div[1]//a[contains(@onclick,'addToMyCollectionsLinkClicked')]")));
        }

        private static IWebElement GetArticleLinkByName(this JournalPage page, string articleName)
        {
            return page.driver.FindElement(By.XPath(string.Concat("//a[@title='", articleName, "']")));
        }

        private static IWebElement GetNumberPageOfSearch(this SearchingPage page,string number)
        {
            return page.driver.FindElement(By.XPath(string.Concat("//div[@class='pagenumbers']/a[text()='",number, "']")));
        }
    }
}
