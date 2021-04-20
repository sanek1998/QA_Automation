using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using FinalTask.Helper;
using FinalTask.Model;
using FinalTask.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace FinalTask.Tests
{
    [AllureSuite("This tests for checking registration")]
    public class RegistrationTests : TestBase
    {
        [AllureSubSuite("TestCaseSource")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureLink("https://github.com/sanek1998/QA_Automation")]
        [AllureTest("This test registers a new user")]
        [AllureOwner("Ermolin Alexander")]
        [Test, TestCaseSource(typeof(DataProviderGenerateUser), "GenerateNewUser")]
        public void RegistrationTestTrue(User user)
        {
            var page = new HomePage(Driver).Open()
                                           .MenuHeader.SingInClick()
                                           .EmailSendForRegistration(user.Email);


            // Check is multiple selection
            Assert.False(page.IsMultipleSelect(page.DaySelect)
                         && page.IsMultipleSelect(page.MonthsSelect)
                         && page.IsMultipleSelect(page.YearsSelect), "Select is multiple");

            page.FillData(user)
                .SubmitCreateAccount();

            Assert.True(Driver.WaiterByElementIsDisplayed(By.ClassName(page.MenuHeader.UserName.GetAttribute("class"))), "The account was not created");
        }
    }
}