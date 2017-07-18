using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class JournalPage : BasePage
    {
        [FindsBy(How = How.XPath,Using = @"//article[1]//a[contains(@onclick,'addToMyCollection')]")]
        public IWebElement FirstArticle { get; set; }

        public JournalPage()
        {
            this.Title = "Case Reports";
            this.Wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(20));
            Wait.Until(ExpectedConditions.TitleContains(this.Title));
            PageFactory.InitElements(this.driver, this);
            FirstArticle.Click();
        }
    }
}
