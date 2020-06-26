using OpenQA.Selenium;

namespace AutomationFramework1
{
    internal class HomePage : BasePage
    {
        
        public HomePage(IWebDriver driver) : base(driver){}

        public bool IsVisible => Driver.Title.Equals("Newgistics WMS :: Home");
    }
}