using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using FinalTask.Helper;
using FinalTask.Model;
using FinalTask.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace FinalTask.Tests
{
    [AllureSuite("This tests for checking login")]
    public class LoginTests : TestBase
    {
        [AllureSubSuite("LoginTrueTest"), AllureSeverity(SeverityLevel.Critical),
         AllureLink("https://github.com/sanek1998/QA_Automation"), AllureTest("This test login to account"),
         AllureOwner("Ermolin Alexander"), Test, TestCaseSource(typeof(DataProviderUser), "ValidUsers")]
        public void LoginTrueTest(User user)
        {
            var page = new HomePage(Driver)
                       .Open()
                       .MenuHeader.SingInClick()
                       .LoginAs(user.Email, user.Password);
            Assert.True(Driver.WaiterByElementIsDisplayed(By.ClassName(page.MenuHeader.UserName.GetAttribute("class")),5000),
                "Account login failed");
        }


        [Test, TestCaseSource(typeof(DataProviderUser), "ValidUsers")]
        public void LoginFalseTest(User user)
        {
            var page = new HomePage(Driver)
                       .Open()
                       .MenuHeader.SingInClick();

            var expectedTitle = Driver.Title;
            page.LoginAs(user.Email, user.Password + "123");
            var actualTitle = Driver.Title;
            Assert.AreEqual(expectedTitle, actualTitle,
                "the expected values do not match the actual values when you log in to your account");
        }
    }
}