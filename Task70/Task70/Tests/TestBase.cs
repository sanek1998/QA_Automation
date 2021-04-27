using NUnit.Framework;
using Task70.App;

namespace Task70.Tests
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
            App.Quit();
            App = null;
        }

    }
}