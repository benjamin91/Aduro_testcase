using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TIM_2015_Test.Configurations;
using OpenQA.Selenium.Chrome;

namespace TIM_2015_Test.Support
{
    class TIM : TestBase
    {
        public static IWebDriver GetBrowser(string browser)
        {
            if (string.Compare(browser, "chrome", true) == 0)
                return new ChromeDriver();
            else
                Console.WriteLine("Browser " + browser + " is not installed");
            return null;
        }

        public static IWebElement GetElement(string how, string locator)
        {
            if (string.Compare(how, "id", true) == 0)
                return driver.FindElement(By.Id(locator));
            else if (string.Compare(how, "name", true) == 0)
                return driver.FindElement(By.Name(locator));
            else if (string.Compare(how, "xpath", true) == 0)
                return driver.FindElement(By.XPath(locator));
            else if (string.Compare(how, "css", true) == 0)
                return driver.FindElement(By.CssSelector(locator));
            else if (string.Compare(how, "class", true) == 0)
                return driver.FindElement(By.ClassName(locator));
            else
                return null;
        }

        public static void Login(string username, string password)
        {
            Visit("/Home/Login");
            FillIn("name", "Username", USERNAME);
            FillIn("name", "Password", PASSWORD);
            Submit("xpath", "//button");
        }

        public static void Visit(string path)
        {
            driver.Navigate().GoToUrl("/Home/Login");
        }

        public static void FillIn(string how, string locator, string text)
        {
            GetElement(how, locator).Clear();
            GetElement(how, locator).SendKeys(text);
        }

        public static void Submit(string how, string locator)
        {
            GetElement(how, locator).Click();
        }

    }
}
