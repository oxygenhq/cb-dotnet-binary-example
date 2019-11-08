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

        private const string SITE_URL = @"http://automationpractice.com/index.php";

        [TestMethod]
        [TestCategory("purchase")]
        public void PurchaseDress()
        {
            var linkText = "DRESSES";
            using (var driver = Helper.GetDriver(TestContext))
            {
                driver.Navigate().GoToUrl(SITE_URL);
                var link = driver.FindElement(By.PartialLinkText(linkText));
                link.Click();

                var link2 = driver.FindElementById("layered_category_11");
                link2.Click();

                var link3 = driver.FindElement(By.PartialLinkText("Yellow"));
                link3.Click();

                var link4 = driver.FindElementById("layered_id_attribute_group_16");
                link4.Click();
            }
        }

        [TestMethod]
        [TestCategory("purchase")]
        public void PurchaseTShirt()
        {
            var linkText = "T-SHIRTS";
            using (var driver = Helper.GetDriver(TestContext))
            {
                driver.Navigate().GoToUrl(SITE_URL);
                var link = driver.FindElement(By.PartialLinkText(linkText));
                link.Click();

                var link2 = driver.FindElementById("layered_id_attribute_group_1");
                link2.Click();

                var link3 = driver.FindElement(By.PartialLinkText("Orange"));
                link3.Click();

                var link4 = driver.FindElementById("layered_id_attribute_group_13");
                link4.Click();

                var link5 = driver.FindElementById("layered_id_feature_5");
                link5.Click();
            }
        }

        [TestMethod]
        [TestCategory("purchase")]
        public void PurchaseWomenCloth()
        {
            var linkText = "WOMEN";
            using (var driver = Helper.GetDriver(TestContext))
            {
                driver.Navigate().GoToUrl(SITE_URL);
                var link = driver.FindElement(By.PartialLinkText(linkText));
                link.Click();

                var link2 = driver.FindElementById("layered_category_4");
                link2.Click();

                var link3 = driver.FindElement(By.PartialLinkText("Black"));
                link3.Click();
                
                var link4 = driver.FindElementById("layered_id_feature_5");
                link4.Click();
            }
        }

        [TestMethod]
        [TestCategory("fail")]
        public void FailTShirt()
        {
            var linkText = "TSHIRTS"; // fail
            using (var driver = Helper.GetDriver(TestContext))
            {
                driver.Navigate().GoToUrl(SITE_URL);
                var link = driver.FindElement(By.PartialLinkText(linkText));
                link.Click();

                var link2 = driver.FindElementById("layered_id_attribute_group_1");
                link2.Click();

                var link3 = driver.FindElement(By.PartialLinkText("Orange"));
                link3.Click();

                var link4 = driver.FindElementById("layered_id_attribute_group_13");
                link4.Click();

                var link5 = driver.FindElementById("layered_id_feature_5");
                link5.Click();
            }
        }

        [TestMethod]
        [TestCategory("fail")]
        public void FailDress()
        {
            var linkText = "DREzz"; // fail
            using (var driver = Helper.GetDriver(TestContext))
            {
                driver.Navigate().GoToUrl(SITE_URL);
                var link = driver.FindElement(By.PartialLinkText(linkText));
                link.Click();

                var link2 = driver.FindElementById("layered_id_attribute_group_1");
                link2.Click();

                var link3 = driver.FindElement(By.PartialLinkText("Orange"));
                link3.Click();

                var link4 = driver.FindElementById("layered_id_attribute_group_13");
                link4.Click();

                var link5 = driver.FindElementById("layered_id_feature_5");
                link5.Click();
            }
        }

        [TestMethod]
        [TestCategory("Card")]
        public void AddToCard()
        {
            var linkText = "T-SHIRTS";
            using (var driver = Helper.GetDriver(TestContext))
            {
                driver.Navigate().GoToUrl(SITE_URL);
                var link = driver.FindElement(By.PartialLinkText(linkText));
                link.Click();

                var link2 = driver.FindElementByClassName("quick-view");
                link2.Click();

                var link3 = driver.FindElementById("add_to_cart");
                link3.Click();
            }
        }
    }
}
