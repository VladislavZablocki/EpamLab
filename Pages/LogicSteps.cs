namespace Pages
{
    public class LogicSteps
    {
        public static LoginPage NavigateToPage(string url)
        {
            Driver.driverInsanse.Navigate().GoToUrl(url);
            return new LoginPage();
        }
    }
}
