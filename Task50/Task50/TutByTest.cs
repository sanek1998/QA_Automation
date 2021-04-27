using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task50
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
            _driver = new ChromeDriver {Url = TUT_BY_URL};
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
            // _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(3);
        }

        [Test]
        public void AuthorizationTestUseThreadSleep1000ms()
        {
            var authorizationForm = By.XPath("//a[@class= 'enter']");
            _driver.FindElement(authorizationForm).Click();

            var loginInput = By.XPath("//input[@name='login']");
            _driver.FindElement(loginInput).SendKeys(USERNAME);

            var passwordInput = By.XPath("//input[@name='password']");
            _driver.FindElement(passwordInput).SendKeys(PASSWORD);

            Thread.Sleep(1000);

            var clickEnter = By.XPath("//input[@class='button m-green auth__enter']");
            _driver.FindElement(clickEnter).Click();

            var name = By.XPath("//span [@class='uname']");
            Assert.True(_driver.FindElement(name).Displayed, "Login name is not displayed! Authorization failed");
        }

        [Test]
        public void AuthorizationTestUseWater()
        {
            var authorizationForm = By.XPath("//a[@class= 'enter']");
            _driver.FindElement(authorizationForm).Click();

            var loginInput = By.XPath("//input[@name='login']");
            _driver.FindElement(loginInput).SendKeys(USERNAME);

            var passwordInput = By.XPath("//input[@name='password']");
            _driver.FindElement(passwordInput).SendKeys(PASSWORD);

            var clickEnter = By.XPath("//input[@class='button m-green auth__enter']");
            _driver.FindElement(clickEnter).Click();

            var waiter = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(5000));
           
            var element = waiter.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = _driver.FindElement(By.ClassName("uname"));
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
           
            Assert.True(element, "Login name is not displayed! Authorization failed");
        }


        [TearDown]
        public void TearDownTest()
        {
            _driver.Quit();
        }
    }
}