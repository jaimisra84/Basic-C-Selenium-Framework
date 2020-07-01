using AutomationFramework1.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationFramework1
{
    [TestClass]
    [TestCategory("E2E Scenarios for second feature -- POC2")]
    public class POC2 : Test.BaseTest
    {
        [TestMethod]
        [TestProperty("Author","DHANANJAI")]
        [Description("This test validates the LOGIN functionality for second feature -- POC2")]
        public void LoginTest1()
        {           
            var loginPage = new LoginPage(Driver);
            loginPage.Goto();

            var homePage = loginPage.Login("devbadge");
            System.Threading.Thread.Sleep(10000);
            Assert.IsTrue(homePage.IsVisible, "Not able to validate the title of the HOME PAGE");
        }

        [TestMethod]
        [TestProperty("Author", "DHANANJAI")]
        [Description("This test validates the navigation functionality till the PRODUCT DETAILS PAGE for second feature --POC2")]
        public void LoginTest2()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.Goto();

            var homePage = loginPage.Login("devbadge");
            System.Threading.Thread.Sleep(10000);
            Assert.IsTrue(homePage.IsVisible, "Not able to validate the title of the HOME PAGE");

            var productPage = homePage.SearchProduct("1886397");
            System.Threading.Thread.Sleep(10000);
            Assert.IsTrue(productPage.IsVisible, "Not able to validate the title of the PRODUCT PAGE");
        }
    }
}
