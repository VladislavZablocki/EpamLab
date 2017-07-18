using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class WindowOperationStatus
    {
        [FindsBy(How = How.XPath,Using = @"//input[contains(@name,'btnAddToMyCollection')]")]
        public IWebElement GoToFavoritesButton { get; set; }

        public WindowOperationStatus()
        {
            PageFactory.InitElements(Driver.DriverInstance, this);
        }
    }
}
