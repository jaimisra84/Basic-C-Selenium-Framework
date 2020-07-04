using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using System;

namespace AutomationFramework1
{
    class ScreenshotTaker
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        private readonly IWebDriver _driver;
        private readonly TestContext _testContext;

        private string ScreenshotFileName { get; set; }

        public string ScreenshotFilePath { get; private set; }

        public ScreenshotTaker(IWebDriver driver, TestContext testContext)
        {
            if (driver == null)
                return;
            _driver = driver;
            _testContext = testContext;
            ScreenshotFileName = _testContext.TestName;
        }     

        internal void CreateScreenshotIfTestFailed()
        {
            if (_testContext.CurrentTestOutcome == UnitTestOutcome.Failed ||
                _testContext.CurrentTestOutcome == UnitTestOutcome.Inconclusive)
                TakesScreenshotForFailure();
        }

        private Screenshot GetScreenshot()
        {
            return ((ITakesScreenshot)_driver)?.GetScreenshot();
        }

        private bool TakesScreenshotForFailure()
        {
            //throw new NotImplementedException();
            ScreenshotFileName = $"FAIL_{ScreenshotFileName}";
            var ss = GetScreenshot();
            var successfullySaved = TryToSaveScreenshot(ScreenshotFileName, ss);
            if (successfullySaved)
                log.Error($"Screenshot of Error=>{ScreenshotFilePath}");
            return successfullySaved;
        }

        public string TakeScreenshot(string screenShotFileName)
        {
            var ss = GetScreenshot();
            var successfullySaved = TryToSaveScreenshot(screenShotFileName, ss);

            return successfullySaved ? ScreenshotFilePath : "";
        }

        private bool TryToSaveScreenshot(string screenshotFileName, Screenshot ss)
        {
            try
            {
                SaveScreenshot(screenshotFileName, ss);
                return true;
            }
            catch (Exception e)
            {
                log.Error(e.InnerException);
                log.Error(e.Message);
                log.Error(e.StackTrace);
                return false;
            }
        }

        private void SaveScreenshot(string screenshotName, Screenshot ss)
        {
            if (ss == null)
                return;
            ScreenshotFilePath = $"{Reporter.LatestResultsReportFolder}\\Screenshot\\{screenshotName}.jpg";
            ScreenshotFilePath = ScreenshotFilePath.Replace('/', ' ').Replace('"', ' ');
            ss.SaveAsFile(ScreenshotFilePath, ScreenshotImageFormat.Png);
        }
    }
}
