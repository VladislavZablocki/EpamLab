using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace Pages
{
    public class SearchingPage : BasePage
    {
        [FindsBy(How=How.XPath,Using = @"//div[@class='resultCount']")]
        public IWebElement SearchingResultsCount { get; set; }

        [FindsBy(How = How.XPath, Using = @"//div[@class='wp-feature-articles']/div/article")]
        public IList<IWebElement> SearchingResults { get; set; }

        public SearchingPage(IWebDriver driver)
        {
            this.driver = driver;
            this.Wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(20));
            Wait.Until(ExpectedConditions.ElementExists(By.XPath(@"//div[@id='main-container-content']")));
            PageFactory.InitElements(this.driver, this);
        }
    }
}
