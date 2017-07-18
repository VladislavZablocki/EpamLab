using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class JournalPage : BasePage
    {
        [FindsBy(How = How.XPath,Using = @"//article[1]//a[contains(@onclick,'addToMyCollection')]")]
        public IWebElement FirstArticleAddToFavorites { get; set; }

        [FindsBy(How = How.XPath,Using = @"//h4/a[contains(@title,'Spinal Cord')]")]
        public IWebElement FirstArticleLink { get; set; }

        public WindowOperationStatus WindowOperationStatus; 
        public WindowAddToFolder WindowAddToFolder;

        public JournalPage()
        {
            this.Title = "Case Reports";
            this.Wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(20));
            Wait.Until(ExpectedConditions.ElementExists(By.XPath(@"//div[@id='main-container-content']")));
            PageFactory.InitElements(this.driver, this);
        }
    }
}
