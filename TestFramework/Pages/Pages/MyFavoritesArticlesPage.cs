using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class MyFavoritesArticlesPage : BasePage
    {
        [FindsBy(How = How.XPath,Using = @"//a[contains(@id,'lnkDeleteMyCollection')]")]
        public IWebElement DeleteLink { get; set; }

        public WindowDeleteFolder WindowDeleteFolder;

        public MyFavoritesArticlesPage()
        {
            this.Wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(20));
            Wait.Until(ExpectedConditions.ElementExists(By.XPath(@"//div[@class='ej-box-issue-departments']")));
            PageFactory.InitElements(this.driver, this);
        }
    }
}
