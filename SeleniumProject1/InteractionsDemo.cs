

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using Assert = NUnit.Framework.Assert;

namespace SeleniumProject1
{
    [TestFixture]
    public class InteractionsDemo
    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;
        private Actions _actions;
        [Test]
        public void DragNDropExample1()
        {
            _driver.Navigate().GoToUrl("http://jqueryui.com/droppable/");
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));
            IWebElement sourceEle = _driver.FindElement(By.Id("draggable"));
            IWebElement targetEle = _driver.FindElement(By.Id("droppable"));
            _actions.DragAndDrop(sourceEle, targetEle).Perform();
            NUnit.Framework.Assert.AreEqual("Dropped!", targetEle.Text);
        }

        [Test]
        public void DragNDropExample2()
        {
            _driver.Navigate().GoToUrl("http://jqueryui.com/droppable/");
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));
            IWebElement sourceEle = _driver.FindElement(By.Id("draggable"));
            IWebElement targetEle = _driver.FindElement(By.Id("droppable"));

            var drag = _actions
                .ClickAndHold(sourceEle)
                .MoveToElement(targetEle)
                .Release(targetEle)
                .Build();

            drag.Perform();
            NUnit.Framework.Assert.AreEqual("Dropped!", targetEle.Text);
        }

        [Test]
        public void DragNDropUsingJavaScript()
        {
            _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/drag_and_drop");
            var jsFile = File.ReadAllText(@"C:\Users\dh001mi\source\repos\SeleniumProject1\drag_and_drop_helper.js");
            IJavaScriptExecutor jse = _driver as IJavaScriptExecutor;
            //Executing the JAVA Script
            jse.ExecuteScript(jsFile + "$('#column-a').simulateDragDrop({ dropTarget: '#column-b'});");
            Assert.AreEqual("A",_driver.FindElement(By.XPath("//*[@id='column-b']/header")).Text);
        }

        [Test]
        public void ResizingExample()
        {
            _driver.Navigate().GoToUrl("http://jqueryui.com/resizable/");
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));
            IWebElement resEle = _driver.FindElement(By.XPath("//*[@class='ui-resizable-handle ui-resizable-se ui-icon ui-icon-gripsmall-diagonal-se']"));
            _actions.ClickAndHold(resEle).MoveByOffset(5, 5).Perform();
            NUnit.Framework.Assert.IsTrue(_driver.FindElement(By.XPath("//*[@id='resizable' and @style]")).Displayed);

        }

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(6));
            _actions = new Actions(_driver);
        }

        [TearDown]
        public void Teardown()
        {
            //_driver.Close();
            //_driver.Quit();
        }
    }
}
