using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task50
{
    [TestFixture]
    public class DownloadingAndRefreshingTest
    {
        private static readonly string URL = "https://www.seleniumeasy.com/test/bootstrap-download-progress-demo.html";
        private IWebDriver _driver;


        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver {Url = URL};
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
        }

        [TearDown]
        public void TearDownTest()
        {
            _driver.Quit();
        }

        [Test]
        public void ProgressBarForDownloadTest()
        {
            _driver.FindElement(By.Id("cricle-btn")).Click();

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            var element = wait.Until(condition =>
            {
                try
                {
                    var progressString = _driver.FindElement(By.ClassName("percenttext")).Text;
                    progressString = progressString.Replace("%", "");
                    var result = int.TryParse(progressString, out var value)
                        ? value
                        : throw new Exception("Cannot convert from string to number");
                    return result >= 50;
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

            _driver.Navigate().Refresh();
        }
    }
}