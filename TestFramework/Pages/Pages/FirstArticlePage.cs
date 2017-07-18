using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class FirstArticlePage : BasePage
    {
        //try to write good xpath!
        //[FindsBy(How = How.XPath,Using = @"//a[contains(@onclick,'ArticleTools_ShowAddToMyCollectionsPopUp();')]")]
        [FindsBy(How = How.CssSelector, Using = @"#ctl00_ctl45_g_6b631144_b049_4651_95c7_4dc1e5fa0848 > section:nth-child(1) > div:nth-child(2) > div:nth-child(1) > ul:nth-child(1) > li:nth-child(6) > a:nth-child(2)")]
        public IWebElement AddToFavorites { get; set; }

        public WindowOperationStatus WindowOperationStatus;
        public WindowAddToFolder WindowAddToFolder;

        public FirstArticlePage()
        {
            this.Wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(20));
            //Wait.Until(ExpectedConditions.ElementExists(By.XPath(@"//section[@id='wpArticleTools']")));
            Wait.Until(ExpectedConditions.ElementExists(By.XPath(@"//section[@id='wpArticleTools']")));
            PageFactory.InitElements(this.driver, this);
        }
    }
}
