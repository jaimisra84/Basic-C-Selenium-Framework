using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using System;

namespace AutomationFramework1.Pages
{
    internal class LoginPage : BasePage
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        public IWebElement SecureIDTesxtBox => Driver.FindElement(By.Id("SecureIDTextBox"));
        public bool IsVisible => Driver.Title.Equals(PageTitle);
        /*public bool IsVisible { 
            get 
            {
                return Driver.Title.Contains("Newgistics WMS :: Login");
            }
            internal set { }
        }*/
        private string PageTitle => "Newgistics WMS :: Login";

        public LoginPage(IWebDriver driver) : base(driver){}

        internal void Goto()
        {
            var url = "http://internal.qa1fxwebas1.newgistics.com/";
            Driver.Navigate().GoToUrl(url);
            Assert.IsTrue(IsVisible, "Not able to validate the title of the LOGIN PAGE");
            log.Info($"Opening the URL: {url}");
            Reporter.LogPassingTestStep($"Opening the URL: {url}");
        }

        internal HomePage Login(string userName)
        {
            SecureIDTesxtBox.SendKeys(userName);
            SecureIDTesxtBox.Submit();
            log.Info($"Entering the username: {userName} and clicking on submit");
            Reporter.LogPassingTestStep($"Entering the username: {userName} and clicking on submit");
            return new HomePage(Driver);
        }
    }
}