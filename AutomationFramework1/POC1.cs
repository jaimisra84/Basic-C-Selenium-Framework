using System;
using System.IO;
using System.Reflection;
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
        public void LoginTest1()
        {
            Driver = GetChromeDriver();
            var loginPage = new LoginPage(Driver);
            loginPage.Goto();
            Assert.IsTrue(loginPage.IsVisible,"Not able to validate the title of the LOGIN PAGE");
            var homePage = loginPage.Login("devbadge");

            //var homePage = new HomePage(Driver);
            System.Threading.Thread.Sleep(10000);
            Assert.IsTrue(homePage.IsVisible,"Not able to validate the title of the HOME PAGE");
        }
        private IWebDriver GetChromeDriver()
        {
            var outputDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputDir);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
