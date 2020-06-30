using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace AutomationResources
{
    public class WebDriverFactory
    {
        public IWebDriver Create(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.CHROME:
                    return GetChromeDriver();
                default:
                    throw new ArgumentOutOfRangeException("No Such Browser Exists!!!");
            }
        }
        private IWebDriver GetChromeDriver()
        {
            var outputDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputDir);
        }
    }
}
