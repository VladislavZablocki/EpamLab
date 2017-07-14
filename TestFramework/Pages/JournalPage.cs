using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class JournalPage : BasePage
    {
        public JournalPage()
        {
            this.Title = "A & A Case Reports";
            this.Wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
        }
    }
}
