using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace AutomationFramework1.Pages
{
    internal class ProductPage : BasePage
    {
        public IWebElement ProductPageTitleLabel => Driver.FindElement(By.XPath("//div[@class = 'section_title']"));
        public IWebElement EditProductButton => Driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_EditProductButton"));
        private string PageTitle => "Newgistics WMS ::";
        //public bool IsVisible => Driver.Title.Contains(PageTitle);

        public bool IsVisible
        {
            get
            {
                try
                {
                   return EditProductButton.Displayed;

                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        public ProductPage(IWebDriver driver) : base(driver){}



    }
}