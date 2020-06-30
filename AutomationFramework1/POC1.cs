using System;
using System.IO;
using System.Reflection;
using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationFramework1
{
    [TestClass]
    [TestCategory("E2E Scenarios")]
    public class POC1
    {
        private IWebDriver Driver { get; set; }

        [TestMethod]
        [TestProperty("Author","DHANANJAI")]
        [Description("This test validates the LOGIN functionality")]
        public void LoginTest1()
        {           
            var loginPage = new LoginPage(Driver);
            loginPage.Goto();

            var homePage = loginPage.Login("devbadge");
            System.Threading.Thread.Sleep(10000);
            Assert.IsTrue(homePage.IsVisible, "Not able to validate the title of the HOME PAGE");
        }
        [TestMethod]
        [TestProperty("Author", "DHANANJAI")]
        [Description("This test validates the navigation functionality till the PRODUCT DETAILS PAGE")]
        public void LoginTest2()
        {
            //Driver = GetChromeDriver();
            var loginPage = new LoginPage(Driver);
            loginPage.Goto();

            var homePage = loginPage.Login("devbadge");
            System.Threading.Thread.Sleep(10000);
            Assert.IsTrue(homePage.IsVisible, "Not able to validate the title of the HOME PAGE");

            var productPage = homePage.SearchProduct("1886397");
            System.Threading.Thread.Sleep(10000);
            Assert.IsTrue(productPage.IsVisible, "Not able to validate the title of the PRODUCT PAGE");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.CHROME);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            Driver.Close();
            Driver.Quit();
        }

    }
}
