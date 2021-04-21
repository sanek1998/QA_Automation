using System;
using Allure.Commons;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;

namespace FinalTask.Tests
{
    [TestFixture]
    public class TestBase : AllureReport
    {
        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
        }

        [TearDown]
        public void Stop()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                AllureLifecycle.Instance.AddAttachment(
                    "Step Screenshot" + TestContext.CurrentContext.Test.MethodName + "_" + DateTime.Now.ToFileTime(),
                    AllureLifecycle.AttachFormat.ImagePng,
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

        protected IWebDriver Driver;
    }
}