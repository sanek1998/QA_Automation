using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task2
{
    public class TutByTest
    {
        private static readonly string TUT_BY_URL = "https://tut.by";
        private static readonly string USERNAME = "seleniumtests@tut.by";
        private static readonly string PASSWORD = "123456789zxcvbn";
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            _driver.Url = TUT_BY_URL;
        }

        [Test]
        public void AuthorizationTest()
        {
            var authorizationForm = By.XPath("//a[@class= 'enter']");
            _driver.FindElement(authorizationForm).Click();

            var loginInput = By.XPath("//input[@name='login']");
            _driver.FindElement(loginInput).SendKeys(USERNAME);

            var passwordInput = By.XPath("//input[@name='password']");
            _driver.FindElement(passwordInput).SendKeys(PASSWORD);

            var clickEnter = By.XPath("//input[@class='button m-green auth__enter']");
            _driver.FindElement(clickEnter).Click();

            var name = By.XPath("//span [@class='uname']");
            Assert.True(_driver.FindElement(name).Displayed, "Login name is not displayed! Authorization failed");
        }

        [Test]
        public void AuthorizationUseByMethodsTest()
        {
            var authorizationForm = By.ClassName("enter");
            _driver.FindElement(authorizationForm).Click();

            var loginInput = By.Name("login");
            _driver.FindElement(loginInput).SendKeys(USERNAME);

            var passwordInput = By.Name("password");
            _driver.FindElement(passwordInput).SendKeys(PASSWORD);

            var clickEnter = By.CssSelector("input[class='button m-green auth__enter']");
            _driver.FindElement(clickEnter).Click();

            var name = By.ClassName("uname");
            Assert.True(_driver.FindElement(name).Displayed, "Login name is not displayed! Authorization failed");
        }

        [TearDown]
        public void TearDownTest()
        {
            _driver.Close();
        }
    }
}