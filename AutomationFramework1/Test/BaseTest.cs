using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace AutomationFramework1.Test
{
    public class BaseTest
    {
        public IWebDriver Driver { get; set; }
        [TestInitialize]
        public void TestInitialize()
        {
            var factory = new AutomationResources.WebDriverFactory();
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