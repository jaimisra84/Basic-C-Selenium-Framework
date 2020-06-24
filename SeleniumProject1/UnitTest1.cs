using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.Support.UI;
//using static SeleniumExtras.WaitHelpers.ExpectedConditions;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace SeleniumProject1
{

    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            var driver = GetChromeDriver();
            driver.Navigate().GoToUrl("http://internal.qa1fxwebas1.newgistics.com/");
            //Driver Navigation Functions
            //driver.Navigate().Back();
            //driver.Navigate().Forward();
            //driver.Navigate().Refresh();

            // Using implicit waits
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            //Using Explicit wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            //Driver Interrogation
            Console.WriteLine(driver.CurrentWindowHandle);
            Console.WriteLine(driver.WindowHandles);
            Console.WriteLine(driver.PageSource);
            Console.WriteLine(driver.Title);
            Console.WriteLine(driver.Url);

            var pwdField = driver.FindElement(By.Id("SecureIDTextBox"));
            Assert.IsTrue(pwdField.Displayed);
            Assert.IsTrue(pwdField.Enabled);
            Assert.IsFalse(pwdField.Selected);
            pwdField.Clear();
            pwdField.SendKeys("devbadge");
            pwdField.SendKeys(Keys.Enter);

            var productSKU = wait.Until((d) =>
            {
                return d.FindElement(By.Id("ctl00_ProductLookupTextBox_inputTextBox"));
            });
            Assert.IsTrue(productSKU.Displayed);
            productSKU.SendKeys("IN-SCWEL319");
            var productSearchBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("ctl00_ProductSearchButton")));
            productSearchBtn.Click();
        }

        private IWebDriver GetChromeDriver()
        {
            var outputDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputDir);
        }
    }
}
