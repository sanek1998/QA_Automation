using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using Task90.Model;

namespace Task90.Tests
{
    [TestFixture]
    public class UserAuthorizationTest : TestBase
    {
        [AllureSubSuite("Login") ]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureLink("https://github.com/sanek1998/QA_Automation")]
        [AllureTest("This test opens website tut.by and tries to login")]
        [AllureOwner("Ermolin Alexander")]
        [Test, TestCaseSource(typeof(DataProviders), "ValidUsers")]
        public void CanUserLogin(User user)
        {
            App.UserLogin(user);
            Assert.True(App.LoggedIn(), "Login to account failed");
        }

        [AllureSubSuite("Logout")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureLink("https://github.com/sanek1998/QA_Automation")]
        [AllureTest("This test opens website tut.by and tries to login then tries to logout")]
        [AllureOwner("Ermolin Alexander")]


        [Test, TestCaseSource(typeof(DataProviders), "ValidUsers")]
        public void CanUserLogout(User user)
        {
            App.UserLogin(user);
            App.UserLogout();
            Assert.True(!App.LoggedOut(), "Logout to account failed");
        }
    }
}