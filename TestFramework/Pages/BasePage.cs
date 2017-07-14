using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Pages
{
    public abstract class BasePage
    {
        public string Title { get; set; }
        public IWebDriver driver = Driver.DriverInstance;
        public WebDriverWait Wait;
    }
}
