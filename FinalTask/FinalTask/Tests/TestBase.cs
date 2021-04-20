using Allure.Commons;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;

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
            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
            {
                AllureLifecycle.Instance.AddAttachment("Step Screenshot" + TestContext.CurrentContext.Test.MethodName + "_" + DateTime.Now.ToFileTime(), AllureLifecycle.AttachFormat.ImagePng,
                    Driver.TakeScreenshot().AsByteArray);
            }

            AllureLifecycle.Instance.RunStep("Closing driver", () =>
            {
                {
                    Driver?.Close();
                    Driver?.Dispose();
                }
            });
        }
    }
}