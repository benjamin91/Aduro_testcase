using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TIM_2015_Test.Support;

namespace TIM_2015_Test.Configurations
{
    /// <summary>
    /// Summary description for TestBase
    /// </summary>
    [TestClass]
    public class TestBase
    {
        public static IWebDriver driver;
        public static string BROWSER = "chrome";
        public static string BASE_URL = "https://test.travel2pay.com/TIM";
        public static string USERNAME = "auto_tester";
        public static string PASSWORD = "Attt@t2p";
        
        public TestBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [AssemblyInitialize]
        public static void Setup(TestContext context)
        {
            TIM.GetBrowser(BROWSER);
            driver.Manage().Window.Maximize();
            TIM.Login(USERNAME, PASSWORD);
        }

        [AssemblyCleanup]
        public static void End()
        {
            driver.Quit();
        }
    }
}
