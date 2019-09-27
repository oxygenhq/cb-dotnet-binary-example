using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace TestProject.CloudBeat
{
    public static class Helper
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
            var browserName = testContext.Properties["browserName"].ToString();
            foreach (var enumName in Enum.GetNames(typeof(BrowserType)))
            {
                if (browserName.Contains(enumName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return Enum.Parse<BrowserType>(enumName);
                }
            }
            
            return BrowserType.Chrome;
        }
    }

    public enum BrowserType
    {
        Chrome,
        Firefox,
        IE
    }
}