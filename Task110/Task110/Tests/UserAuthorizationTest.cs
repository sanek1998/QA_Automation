using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using Task110.Model;

namespace Task110.Tests
{
    [TestFixture]
    public class UserAuthorizationTest : TestBase
    {
        [AllureSubSuite("Login"), AllureSeverity(SeverityLevel.Critical),
         AllureLink("https://github.com/sanek1998/QA_Automation"),
         AllureTest("This test opens website tut.by and tries to login"), AllureOwner("Ermolin Alexander"), Test,
         TestCaseSource(typeof(DataProviders), "ValidUsers")]
        public void CanUserLogin(User user)
        {
            UserLogin(user);
            Assert.True(LoggedIn(), "Login to account failed");
        }

        [AllureSubSuite("Logout"), AllureSeverity(SeverityLevel.Critical),
         AllureLink("https://github.com/sanek1998/QA_Automation"),
         AllureTest("This test opens website tut.by and tries to login then tries to logout"),
         AllureOwner("Ermolin Alexander"), Test, TestCaseSource(typeof(DataProviders), "ValidUsers")]
        public void CanUserLogout(User user)
        {
            UserLogin(user);
            UserLogout();
            Assert.True(!LoggedOut(), "Logout to account failed");
        }
    }
}