using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Task80.App;

namespace Task80.Tests
{
    public class TestBase
    {
        public Application App;

        [SetUp]
        public void Start()
        {
            App = new Application();
        }

        [TearDown]
        public void Stop()
        {
            App.TestLoggingAsScreenshot();
            App.Quit();
            App = null;

        }

    }
}