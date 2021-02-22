using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task50
{
    [TestFixture]
    public class AlertsTest
    {
        private static readonly string URL = "https://www.seleniumeasy.com/test/javascript-alert-box-demo.html";
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
        public void JavaScriptConfirmBoxClickedYesTest()
        {
            _driver.FindElement(By.XPath("//button[@onclick='myConfirmFunction()']")).Click();
            var alert = _driver.SwitchTo().Alert();
            alert.Accept();

            var actualValue = _driver.FindElement(By.Id("confirm-demo")).Text;
            var expectedValue = "You pressed OK!";

            Assert.AreEqual(actualValue, expectedValue);
        }

        [Test]
        public void JavaScriptConfirmBoxClickedNoTest()
        {
            _driver.FindElement(By.XPath("//button[@onclick='myConfirmFunction()']")).Click();
            var alert = _driver.SwitchTo().Alert();
            alert.Dismiss();

            var actualValue = _driver.FindElement(By.Id("confirm-demo")).Text;
            var expectedValue = "You pressed Cancel!";

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void JavaScriptAlertBoxGetAlertTextTest()
        {
            _driver.FindElement(By.XPath("//button[@onclick='myAlertFunction()']")).Click();
            var alert = _driver.SwitchTo().Alert();

            var actualValue = alert.Text;
            var expectedValue = "I am an alert box!";

            Assert.AreEqual(expectedValue, actualValue);

        }

        [Test]
        public void JavaScriptAlertBoxSendKeysTestClickedYes()
        {
            _driver.FindElement(By.XPath("//button[@onclick='myPromptFunction()']")).Click();
            var alert = _driver.SwitchTo().Alert();
            const string inputValue = "Sasha";
            alert.SendKeys(inputValue);
            alert.Accept();

            var actualValue = _driver.FindElement(By.Id("prompt-demo")).Text;
            var expectedValue = "You have entered '" + inputValue + "' !";

            Assert.AreEqual(expectedValue, actualValue);

        }

        [Test]
        public void JavaScriptAlertBoxSendKeysTestClickedNo()
        {
            _driver.FindElement(By.XPath("//button[@onclick='myPromptFunction()']")).Click();
            var alert = _driver.SwitchTo().Alert();
            const string inputValue = "Sasha";
            alert.SendKeys(inputValue);
            alert.Dismiss();

            var actualValue = _driver.FindElement(By.Id("prompt-demo")).Text;
            
            Assert.AreEqual(string.Empty,actualValue);

        }
    }
}