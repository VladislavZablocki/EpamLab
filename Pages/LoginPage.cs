using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class LoginPage : BasePage
    {
        private WebDriverWait wait;
        private string errorMessageClassName = "ej-error-message";

        [FindsBy(How = How.Id,Using = @"ctl00_ctl45_g_e504d159_38de_4cbf_9f4d_b2c12b300979_ctl00_txt_UserName")]
        public IWebElement UserLogin { get; set; }

        [FindsBy(How = How.Id, Using = @"ctl00_ctl45_g_e504d159_38de_4cbf_9f4d_b2c12b300979_ctl00_txt_Password")]
        public IWebElement UserPassword { get; set; }

        [FindsBy(How = How.Id, Using = @"ctl00_ctl45_g_e504d159_38de_4cbf_9f4d_b2c12b300979_ctl00_LoginButton")]
        public IWebElement LoginButton { get; set; }

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
            bool result = true;
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(errorMessageClassName)));
            }
            catch (WebDriverTimeoutException)
            {
                result = false;
            }
            return result;
        }

    }
}
