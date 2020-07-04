using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using System;

namespace AutomationFramework1.Test
{
    public class BaseTest
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        
        protected IWebDriver Driver { get; private set; }

        public TestContext TestContext { get; set; }

        private ScreenshotTaker ScreenshotTaker { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            log.Debug("***** TEST STARTED *****");
            log.Debug("***** TEST STARTED *****");
            Reporter.AddTestCaseMetadataToHtmlReport(TestContext);
            var factory = new AutomationResources.WebDriverFactory();
            Driver = factory.Create(BrowserType.CHROME);
            ScreenshotTaker = new ScreenshotTaker(Driver, TestContext);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            log.Debug(GetType().FullName + " Started Method Tear Down");
            try
            {
                TakeScreenshotForTestFailure();
            } 
            catch (Exception e)
            {
                log.Error(e.Source);
                log.Error(e.StackTrace);
                log.Error(e.InnerException);
                log.Error(e.Message);
            }
            finally
            {
                Driver.Close();
                Driver.Quit();
                log.Debug("***** TEST STOPED *****");
                log.Debug("***** TEST STOPED *****");
            }
        }

        private void TakeScreenshotForTestFailure()
        {
            if (ScreenshotTaker != null)
            {
                ScreenshotTaker.CreateScreenshotIfTestFailed();
                Reporter.ReportTestOutcome(ScreenshotTaker.ScreenshotFilePath);
            }
            else
            {
                Reporter.ReportTestOutcome("");
            }
        }

        private void StopBrowser()
        {
            if (Driver == null)
                return;
        }
    }
}