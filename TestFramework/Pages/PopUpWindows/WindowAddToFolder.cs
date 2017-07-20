using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class WindowAddToFolder
    {
        IWebDriver driver;

        [FindsBy(How = How.XPath,Using = @"//section//input[@value='Add Item(s)']")]
        public IWebElement AddItemButton { get; set; }

        [FindsBy(How = How.XPath, Using = @"//div/input[contains(@name,'txtCollectionName')]")]
        public IWebElement InputFolderNameTextbox { get; set; }

        [FindsBy(How=How.XPath,Using = @"//div[@onclick='atmcSetFocus()']")]
        public IWebElement NewFolderLabel { get; set; }

        [FindsBy(How = How.XPath,Using = @"//input[contains(@id,'rdoExistingCollection')]")]
        public IWebElement ExistingFolderRadioButton { get; set; }

        public WindowAddToFolder(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
