using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using FinalTask.Model;
using FinalTask.Pages;
using NUnit.Framework;

namespace FinalTask.Tests
{
    [AllureSuite("This tests for checking cart")]
    public class AddThreeProductToCartTests : TestBase
    {
        [AllureSubSuite("AddThreeProductToCartSuccessfullTest")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureLink("https://github.com/sanek1998/QA_Automation")]
        [AllureTest("This test add 3 items to cart")]
        [AllureOwner("Ermolin Alexander")]
        [Test, TestCaseSource(typeof(DataProviderUser), "ValidUsers")]
        public void AddThreeProductToCartSuccessfullTest(User user)
        {
            var expectedValue = 3;
            var page = new HomePage(Driver).Open()
                                           .MenuHeader.SingInClick()
                                           .LoginAs(user.Email, user.Password)
                                           .CartLinkClick()
                                           .ClearCartTable()
                                           .WomenPageLinkClick()
                                           .AddThreeItemToCart()
                                           .CartLinkClick();
            Assert.AreEqual(expectedValue, page.ItemsInCart.Count, "The expected number of products in the wishlist does not match the actual number");
          }
    }
}