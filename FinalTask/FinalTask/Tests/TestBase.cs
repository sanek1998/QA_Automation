using System;
using Allure.Commons;
using FinalTask.Model;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace FinalTask.Tests
{
    [TestFixture]
    public class TestBase : AllureReport
    {
        protected IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            //var option = new ChromeOptions();
            //Driver = new RemoteWebDriver(new Uri("http://10.10.104.72:8888/wd/hub"), option);

            Driver = new ChromeDriver();
           // Driver = new FirefoxDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
            AllureLifecycle.Instance.SetCurrentTestActionInException(() =>
            {
                AllureLifecycle.Instance.AddAttachment("Step Screenshot", AllureLifecycle.AttachFormat.ImagePng,
                    Driver.TakeScreenshot().AsByteArray);
            });
        }

        [TearDown]
        public void Stop()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile("Screenshot_" + TestContext.CurrentContext.Test.MethodName + "_" + DateTime.Now.ToFileTime() + ".png");
            }

            AllureLifecycle.Instance.RunStep("Closing driver", () => {
                {
                    Driver?.Close();
                    Driver?.Dispose();
                }
            });
        }


        protected bool WaitUntilElementDisplayedByClassName(string className)
        {
            var waiter = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(10000));

            var element = waiter.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = Driver.FindElement(By.ClassName(className));
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