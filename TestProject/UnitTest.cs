using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace TestProject
{
    [TestClass]
    public class UnitTest
    {
        public TestContext TestContext { get; set; }
        
        [TestMethod]
        public void TestWithChromeDriver()
        {
            var linkText = "Complete list of Wikipedias";
            using (var driver = GetDriver())
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

        private RemoteWebDriver GetDriver()
        {
            switch (GetBrowserTypeFromArgs())
            {
                case BrowserType.Chrome:
                    return new ChromeDriver();
                case BrowserType.Firefox:
                    return new FirefoxDriver();
                case BrowserType.IE:
                    return new InternetExplorerDriver();
                default:
                    return new ChromeDriver();
            }
        }

        private BrowserType GetBrowserTypeFromArgs()
        {
            return Enum.TryParse(TestContext.Properties["BrowserName"]?.ToString(), false, out BrowserType browserType) 
                        ? browserType : BrowserType.Chrome;
        }
    }

    public enum BrowserType
    {
        Chrome,
        Firefox,
        IE
    }
}