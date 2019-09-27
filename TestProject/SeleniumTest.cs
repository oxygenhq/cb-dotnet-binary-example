using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.CloudBeat;

namespace TestProject
{
    [TestClass]
    public class SeleniumTest
    {
        public TestContext TestContext { get; set; }
        
        [TestMethod]
        [TestCategory("success")]
        public void SuccessSeleniumTest()
        {
            var linkText = "Complete list of Wikipedias";
            using (var driver = Helper.GetDriver(TestContext))
            {
                driver.Navigate().GoToUrl(@"https://en.wikipedia.org/wiki/Main_Page");
                var link = driver.FindElement(By.PartialLinkText(linkText));
                var jsToBeExecuted = $"window.scroll(0, {link.Location.Y});";
                ((IJavaScriptExecutor)driver).ExecuteScript(jsToBeExecuted);
                var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
                var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText(linkText)));
                clickableElement.Click();
            }
        }

        [TestMethod]
        [TestCategory("fail")]
        public void FailSeleniumTest()
        {
            var linkText = "Complete list of Wikipedias";
            using (var driver = Helper.GetDriver(TestContext))
            {
                driver.Navigate().GoToUrl(@"https://google.com");
                var link = driver.FindElement(By.PartialLinkText(linkText));
                var jsToBeExecuted = $"window.scroll(0, {link.Location.Y});";
                ((IJavaScriptExecutor)driver).ExecuteScript(jsToBeExecuted);
                var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
                var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText(linkText)));
                clickableElement.Click();
            }
        }
    }
}
