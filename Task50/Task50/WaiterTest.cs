using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task50
{
    [TestFixture]
    public class WaiterTest
    {
        private static readonly string URL = "https://www.seleniumeasy.com/test/dynamic-data-loading-demo.html";
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver { Url = URL };
             _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
        }

        [TearDown]
        public void TearDownTest()
        {
            _driver.Quit();
        }

        [Test]
        [Obsolete]
        public void GetRandomUserUsedWaiterFirstVariantTest()
        {
            _driver.FindElement(By.Id("save")).Click();

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var imgElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div>img")));
            var element = imgElement.Displayed;

            Assert.True(element);
        }


        [Test]
        public void GetRandomUserUsedWaiterSecondVariantTest()
        {
            _driver.FindElement(By.Id("save")).Click();

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = _driver.FindElement(By.CssSelector("div>img"));
                    return elementToBeDisplayed.Displayed;
                }
                catch (InvalidElementStateException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });

            Assert.True(element);
        }

    }

}