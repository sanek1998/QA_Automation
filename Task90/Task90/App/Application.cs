using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Task90.Model;
using Task90.Pages;

namespace Task90.App
{
    public class Application
    {
        private readonly IWebDriver _driver;

        private readonly LoginPage _loginPage;
        private HomePage _homePage;

        public Application()
        {
            _driver = new ChromeDriver();
            _loginPage = new LoginPage(_driver);
            _homePage = new HomePage(_driver);
        }

        public void TestLoggingAsScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var nameFile= @"TestFailScreenshot" + DateTime.Now.Ticks +".png";
                ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile(nameFile,ScreenshotImageFormat.Png);

            }
        }

       public void Quit()
        {
            _driver.Quit();
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