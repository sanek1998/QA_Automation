using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using FinalTask.Model;
using FinalTask.Pages;
using NUnit.Framework;

namespace FinalTask.Tests
{
    [AllureSuite("This tests for checking wishlist")]
    public class AutoCreatedWishlistTests : TestBase
    {
        [AllureSubSuite("AddWishlistSuccessfulTest"), AllureSeverity(SeverityLevel.Critical),
         AllureLink("https://github.com/sanek1998/QA_Automation"),
         AllureTest("This test create wishlist and then add item to this wishlist"), AllureOwner("Ermolin Alexander"),
         Test, TestCaseSource(typeof(DataProviderUser), "ValidUsers")]
        public void AutoCreatedWishlistTest(User user)
        {
            var page = new HomePage(Driver).Open()
                                           .MenuHeader.SingInClick()
                                           .LoginAs(user.Email, user.Password)
                                           .WishlistClick()
                                           .ClearWishListTable()
                                           .WomenPageLinkClick()
                                           .MoveToElementFirstItem()
                                           .AddToWishlisClick()
                                           .CloseFancyboxClick()
                                           .GoToMyAccaount()
                                           .WishlistClick();
            Assert.True(page.LinksToDeleteProducts.Count == 1, "Wishlist was not created");
        }
    }
}