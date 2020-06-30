using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationFramework1
{
    internal class HomePage : BasePage
    {
        //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
        public IWebElement ProductSearchTesxtBox => Driver.FindElement(By.Id("ctl00_ProductLookupTextBox_inputTextBox"));
        public IWebElement ProductSearchButton => Driver.FindElement(By.Id("ctl00_ProductSearchButton"));
        private string PageTitle => "Newgistics WMS :: Home";
        public bool IsVisible => Driver.Title.Equals(PageTitle);

        public HomePage(IWebDriver driver) : base(driver){}

        internal ProductPage SearchProduct(string productID)
        {
            ProductSearchTesxtBox.SendKeys(productID);
            ProductSearchButton.Click();
            return new ProductPage(Driver);
        }
    }
}