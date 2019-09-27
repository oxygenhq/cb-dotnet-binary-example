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
        [TestCategory("success")]
        public void SuccessUnitTest()
        {
            Assert.AreEqual(3, 2 + 1);
        }


        [TestMethod]
        [TestCategory("fail")]
        public void FailUnitTest()
        {
            Assert.AreEqual(3, 1 + 1);
        }
    }
}