using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace Pages
{
    public class LogicSteps
    {
        private static string invalidLoginXpath = @"//li/a[text()='Login']";
        private static string validLoginXpath = @"//li/a[text()='Log Out']";
        private static string firstJornalLinkXpath = @"//article[1]/h4/a";


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

        public static JournalPage GoToFirstJournal(LoginPage page)
        {
            page.Wait.Until(ExpectedConditions.ElementExists(By.XPath(validLoginXpath)));
            IWebElement firstJournal = page.driver.FindElement(By.XPath(firstJornalLinkXpath));
            firstJournal.Click();
            JournalPage journalPage = new JournalPage();
            CloseTab(page, 0);
            return journalPage;
        }

        public static void CloseTab(BasePage page,int number)
        {
            var tab = page.driver.WindowHandles;
            page.driver.SwitchTo().Window(tab[number]);
            Close(page);
        }

        public static void Close(BasePage page)
        {
            page.driver.Close();
        }
    }
}
