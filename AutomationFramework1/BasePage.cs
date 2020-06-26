using OpenQA.Selenium;

namespace AutomationFramework1
{
    internal class BasePage
    {
        protected IWebDriver Driver { get; set; }
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}