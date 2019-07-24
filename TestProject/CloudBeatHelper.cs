using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace TestProject
{
    public static class CloudBeatHelper
    {
        public static RemoteWebDriver GetDriver(TestContext testContext)
        {
            switch (GetBrowserTypeFromArgs(testContext))
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

        private static BrowserType GetBrowserTypeFromArgs(TestContext testContext)
        {
            return Enum.TryParse(testContext.Properties["BrowserName"]?.ToString(), false, out BrowserType browserType) 
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