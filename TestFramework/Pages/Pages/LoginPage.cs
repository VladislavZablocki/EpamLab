﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class LoginPage : BasePage
    {
        

        [FindsBy(How = How.XPath, Using = @"//div[@class='form-group'][1]/input")]
        public IWebElement UserLogin { get; set; }

        [FindsBy(How = How.XPath, Using = @"//div[@class='form-group'][2]/input")]
        public IWebElement UserPassword { get; set; }

        [FindsBy(How = How.XPath, Using = @"//div[@id]/input[@type='submit']")]
        public IWebElement LoginButton { get; set; }

        [FindsBy(How =How.XPath,Using = @"//div[@id='ej-journals-a-z-alpha-list']/a[text()='P']")]
        public IWebElement PButton { get; set; }

        [FindsBy(How =How.XPath,Using = @"//h4/a[text()='A&A Case Reports']")]
        public IWebElement FirstJournalLink { get; set; }

        [FindsBy(How = How.XPath,Using = @"//h4/a[text()='Plastic and Reconstructive Surgery']")]
        public IWebElement JournalPlasticReconstructiveSurgeyryLink { get; set; }
        
        public LoginPage()
        {
            PageFactory.InitElements(this.driver, this);
            this.Wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
        }
    }
}