using System;
using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using FinalTask.Helper;
using FinalTask.Model;
using FinalTask.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace FinalTask.Tests
{
    [AllureSuite("This tests for checking wishlist")]

    public class AddWishlistTest : TestBase
    {
        private readonly string nameWishlist = "Test Name";

        [AllureSubSuite("AddWishlistSuccessfulTest")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureLink("https://github.com/sanek1998/QA_Automation")]
        [AllureTest("This test create wishlist and then add item to this wishlist")]
        [AllureOwner("Ermolin Alexander")]
        [Test, TestCaseSource(typeof(DataProviderUser), "ValidUsers")]
        public void AddWishlistSuccessfulTest(User user)
        {
            var page = new HomePage(Driver).Open()
                                            .MenuHeader.SingInClick()
                                            .LoginAs(user.Email, user.Password)
                                            .WishlistClick()
                                            .ClearWishListTable()
                                            .CreateWishlist(nameWishlist);

            var addedNameWishlist = page.WishlistName.Text;
            Assert.AreEqual(nameWishlist, addedNameWishlist, "the name of the expected wishlist does not match the actual name");

            page.ClearWishListTable();


            page.WomenPageLinkClick()
                .MoveToElementFirstItem()
                .AddToWishlisClick()
                .CloseFancyboxClick()
                .GoToMyAccaount()
                .WishlistClick();
            
            Assert.True(page.LinksToDeleteProducts.Count == 1);

            var qty = int.TryParse(page.WishlistQty.Text, out var result)
                ? result
                : throw new ArgumentException("conversion error to a number");

            Assert.AreEqual(1, qty, "The expected number of wishlist is not the same as the current one");
        }
    }
}