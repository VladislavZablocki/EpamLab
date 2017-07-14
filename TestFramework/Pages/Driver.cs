using OpenQA.Selenium;

namespace Pages
{
    public class Driver
    {
        private Driver()
        { }

        public static IWebDriver driverInsanse;

        public static void SetDriver(AllDrivers driver)
        {
            driverInsanse = StaticDriverFactory.GetWebDriver(driver);
        }
    }
}
