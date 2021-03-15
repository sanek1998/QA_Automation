using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Task110.Pages;

namespace Task110.Tests
{
    [TestFixture]
    public class TestExample
    {
        private IWebDriver _driver;
        
        [SetUp]
        public void Start()
        {
            var option = new ChromeOptions();


            _driver = new RemoteWebDriver(new Uri("http://10.10.104.72:8888/wd/hub/"), option);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            _driver.Url = "https://www.google.com";


        }

        [TearDown]
        public void Stop()
        {
            _driver.Quit();

        }

        [Test]
        public void TestExampleMethod()
        {
            _driver.FindElement(By.ClassName("gLFyf gsfi")).SendKeys("Selenium Grid");
        }

    }
}