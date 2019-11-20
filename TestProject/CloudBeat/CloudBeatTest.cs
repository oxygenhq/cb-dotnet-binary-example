using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.CloudBeat
{
    [TestClass]
    public abstract class CloudBeatTest
    {
        public TestContext TestContext { get; set; }

        public CloudbeatWebDriver _driver;

        [TestInitialize]
        public void TestInitialize()
        {
            _driver = new CloudbeatWebDriver(TestContext);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                _driver.TakeScreenShot();
            }

            _driver.Dispose();
        }
    }
}
