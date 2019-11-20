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
    public class SeleniumTest : CloudBeatTest
    {
        private const string SITE_URL = @"http://automationpractice.com/index.php";



        [TestMethod]
        [TestCategory("purchase")]
        public void PurchaseDress()
        {
            var linkText = "DRESSES";
            _driver.Navigate().GoToUrl(SITE_URL);
            var link = _driver.FindElement(By.PartialLinkText(linkText));
            link.Click();

            var link2 = _driver.FindElement(By.Id("layered_category_11"));
            link2.Click();

            var link3 = _driver.FindElement(By.PartialLinkText("Yellow"));
            link3.Click();

            var link4 = _driver.FindElement(By.Id("layered_id_attribute_group_16"));
            link4.Click();
        }

        [TestMethod]
        [TestCategory("purchase")]
        public void PurchaseTShirt()
        {
            var linkText = "T-SHIRTS";
            _driver.Navigate().GoToUrl(SITE_URL);
            var link = _driver.FindElement(By.PartialLinkText(linkText));
            link.Click();

            var link2 = _driver.FindElement(By.Id("layered_id_attribute_group_1"));
            link2.Click();

            var link3 = _driver.FindElement(By.PartialLinkText("Orange"));
            link3.Click();

            var link4 = _driver.FindElement(By.Id("layered_id_attribute_group_13"));
            link4.Click();

            var link5 = _driver.FindElement(By.Id("layered_id_feature_5"));
            link5.Click();
        }


        [TestMethod]
        [TestCategory("Card")]
        public void AddToCard()
        {
            var linkText = "T-SHIRTS";

            _driver.Navigate().GoToUrl(SITE_URL);
            var link = _driver.FindElement(By.PartialLinkText(linkText));
            link.Click();

            var link2 = _driver.FindElement(By.ClassName("quick-view"));
            link2.Click();

            var link3 = _driver.FindElement(By.Id("add_to_cart"));
            link3.Click();
        }
    }
}
