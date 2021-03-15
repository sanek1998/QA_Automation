using System;
using Allure.Commons;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Task110.Model;
using Task110.Pages;

namespace Task110.Tests
{
    [TestFixture]
    public class TestBase : AllureReport
    {
        private  IWebDriver _driver;

        private  LoginPage _loginPage;
        private HomePage _homePage;

        [SetUp]
        public void Start()
        {
            var option = new ChromeOptions();


            _driver = new RemoteWebDriver(new Uri("http://10.10.104.72:8888/wd/hub/"), option);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);


            //   _driver = new ChromeDriver();
            _loginPage = new LoginPage(_driver);
        }

        [TearDown]
        public void Stop()
        {
           
           TestLoggingAsScreenshot();

              _driver.Quit();
            
        }

        public void TestLoggingAsScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var nameFile = @"TestFailScreenshot" + DateTime.Now.Ticks + ".png";
                ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile(nameFile, ScreenshotImageFormat.Png);
            }
        }

       
        public void UserLogin(User user)
        {
            _loginPage.Open();
            _homePage = _loginPage.LoginAs(user.Login, user.Password);
        }

        public void UserLogout()
        {
            _homePage = _loginPage.Logout();
        }

        public bool LoggedIn() => _homePage.AtPage() && WaitUntilElementDisplayed("uname");

        public bool LoggedOut() => _homePage.AtPage() && WaitUntilElementDisplayed("enter");

        private bool WaitUntilElementDisplayed(string className)
        {
            var waiter = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(5000));

            var element = waiter.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = _driver.FindElement(By.ClassName(className));
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
            return element;
        }
    }
}
