using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class LoginPage : BasePage
    {
        private WebDriverWait wait;
        //private string errorMessagetext = " Invalid username or password.  Try again or register an account. ";
        private string errorMessageXpath = @"//p[@class='ej-error-message-icon']";

        [FindsBy(How = How.XPath, Using = @"//div[@class='form-group'][1]/input")]
        public IWebElement UserLogin { get; set; }

        [FindsBy(How = How.XPath, Using = @"//div[@class='form-group'][2]/input")]
        public IWebElement UserPassword { get; set; }

        [FindsBy(How = How.XPath, Using = @"//div[@id]/input[@type='submit']")]
        public IWebElement LoginButton { get; set; }

        //[FindsBy(How = How.XPath, Using = @"//p[@class='ej-error-message-icon']")]
        //public IWebElement ErrorMessage { get; set; }
        public LoginPage()
        {
            PageFactory.InitElements(this.driver, this);
            wait = new WebDriverWait(Driver.driverInsanse, TimeSpan.FromSeconds(10));
        }

        public LoginPage LoginAs(string login, string password)
        {
            UserLogin.SendKeys(login);
            UserPassword.SendKeys(password);
            LoginButton.Click();
            return this;
        }

        public bool IsValidLogin()
        {
            bool result = false;
            try
            {
                driver.FindElement(By.XPath(errorMessageXpath));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(errorMessageXpath)));
            }
            catch (WebDriverTimeoutException)
            {
                result = true;
            }
            return result;
        }

    }
}
