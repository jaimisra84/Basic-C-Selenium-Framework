using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace AutomationFramework1
{
    internal class LoginPage : BasePage
    {
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
            Driver.Navigate().GoToUrl("http://internal.qa1fxwebas1.newgistics.com/");
            Assert.IsTrue(IsVisible, "Not able to validate the title of the LOGIN PAGE");
        }

        internal HomePage Login(string userName)
        {
            SecureIDTesxtBox.SendKeys(userName);
            SecureIDTesxtBox.Submit();
            return new HomePage(Driver);
        }
    }
}