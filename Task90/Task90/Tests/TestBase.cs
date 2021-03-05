using Allure.Commons;
using NUnit.Framework;
using Task90.App;

namespace Task90.Tests
{
    public class TestBase: AllureReport
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