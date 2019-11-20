using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.Extensions;
using System;

namespace TestProject
{
    public class CloudbeatWebDriver : RemoteWebDriver
    {
        private TestContext _context;

        public CloudbeatWebDriver(TestContext testContext) : base(GetUri(testContext), GetCapabilities(testContext))
        {
            _context = testContext;
            this.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void TakeScreenShot()
        {
            var screenShotPath = $"{_context.FullyQualifiedTestClassName}_{_context.TestName}.png";
            this.TakeScreenshot().SaveAsFile(screenShotPath);
            _context.AddResultFile(screenShotPath);
        }

        private static Uri GetUri(TestContext testContext) => new Uri(testContext.Properties["SeleniumUrl"]?.ToString());

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
            var browserName = testContext.Properties["browserName"]?.ToString();
            foreach (var enumName in Enum.GetNames(typeof(BrowserType)))
            {
                if (browserName != null && browserName.Contains(enumName, StringComparison.InvariantCultureIgnoreCase))
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
