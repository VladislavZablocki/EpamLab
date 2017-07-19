using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class WindowDeleteFolder
    {
        [FindsBy(How = How.XPath,Using = @"//input[contains(@name,'deleteMyCollectionControl$btnDelete')]")]
        public IWebElement DeleteButton { get; set; }

        public WindowDeleteFolder()
        {
            PageFactory.InitElements(Driver.DriverInstance, this);
        }
    }
}
