using NUnit.Framework;
using Task80.Model;

namespace Task80.Tests
{
    [TestFixture]
    public class UserAuthorizationTest : TestBase
    {
        [Test, TestCaseSource(typeof(DataProviders), "ValidUsers")]
        public void CanUserLogin(User user)
        {
            App.UserLogin(user);
            Assert.True(App.LoggedIn(), "Login to account failed");
        }

        [Test, TestCaseSource(typeof(DataProviders), "ValidUsers")]
        public void CanUserLogout(User user)
        {
            App.UserLogin(user);
            App.UserLogout();
            Assert.True(App.LoggedOut(), "Logout to account failed");
        }
    }
}