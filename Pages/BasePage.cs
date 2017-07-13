using OpenQA.Selenium;

namespace Pages
{
    public class BasePage
    {
        public string Title { get; set; }

        protected IWebDriver driver = Driver.driverInsanse;
    }
}
