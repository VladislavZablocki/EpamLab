using OpenQA.Selenium;

namespace Pages
{
    public class Driver
    {
        private Driver()
        { }

        public static IWebDriver DriverInstance;

        public static void SetDriver(AllDrivers driver)
        {
            DriverInstance = StaticDriverFactory.GetWebDriver(driver);
        }
    }
}
