using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class WindowAddToFolder
    {
        [FindsBy(How = How.XPath,Using = @"//section//input[@value='Add Item(s)']")]
        public IWebElement AddItemButton { get; set; }

        [FindsBy(How = How.XPath, Using = @"//div/input[contains(@name,'txtCollectionName')]")]
        public IWebElement InputFolderNameTextbox { get; set; }

        [FindsBy(How=How.XPath,Using = @"//input[contains(@id,'rdoNewCollection')]")]
        public IWebElement NewFolderRadioButton { get; set; }

        [FindsBy(How = How.XPath,Using = @"//input[contains(@id,'rdoExistingCollection')]")]
        public IWebElement ExistingFolderRadioButton { get; set; }


        //private WebDriverWait wait;

        public WindowAddToFolder()
        {
            //this.wait = new WebDriverWait(Driver.DriverInstance, TimeSpan.FromSeconds(10));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(@"$x(//header[@class='wk-modal-header ejp-modal-header'])")));
            PageFactory.InitElements(Driver.DriverInstance,this);
        }
    }
}
