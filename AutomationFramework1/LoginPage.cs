using OpenQA.Selenium;
using System;

namespace AutomationFramework1
{
    internal class LoginPage : BasePage
    {

        public LoginPage(IWebDriver driver) : base(driver){}

        /*public bool IsVisible { 
            get 
            {
                return Driver.Title.Contains("Newgistics WMS :: Login");
            }
            internal set { }
        }*/
        public bool IsVisible => Driver.Title.Equals("Newgistics WMS :: Login");

        public IWebElement SecureIDTesxtBox => Driver.FindElement(By.Id("SecureIDTextBox"));

        internal void Goto()
        {
            Driver.Navigate().GoToUrl("http://internal.qa1fxwebas1.newgistics.com/");
        }

        internal HomePage Login(string username)
        {
            SecureIDTesxtBox.SendKeys(username);
            SecureIDTesxtBox.Submit();
            return new HomePage(Driver);
        }
    }
}