using System;
using System.IO;
using CloudBeat.Frameworks.MSTest;
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
    public class UnitTest : CBTest
    {
        public UnitTest() : base() { }

        [ClassInitialize]
        public static void InitTest(TestContext context)
        {
            InitContext(context);
        }

        [TestMethod]
        [TestCategory("success")]
        public void SuccessUnitTest()
        {
            StartStep("1");
            StartStep("2");
            StartStep("3");
            EndStep("2");
            StartStep("4");
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