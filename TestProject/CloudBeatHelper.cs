using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
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
            return new RemoteWebDriver(new Uri(testContext.Properties["SeleniumUrl"].ToString()), GetCapabilities(testContext));
        }

        private static ICapabilities GetCapabilities(TestContext testContext)
        {
            switch (GetBrowserTypeFromArgs(testContext))
            {
                case BrowserType.Chrome:
                    return new ChromeOptions().ToCapabilities();
                case BrowserType.Firefox:
                    return new FirefoxOptions().ToCapabilities();
                case BrowserType.IE:
                    return new InternetExplorerOptions().ToCapabilities();
                default:
                    return new ChromeOptions().ToCapabilities();
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