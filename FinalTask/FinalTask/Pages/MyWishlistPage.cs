using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FinalTask.Pages
{
    public class MyWishlistPage : Page
    {
        public MyWishlistPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "name")]
        public IWebElement NameWishlistInput { get; set; }

        [FindsBy(How = How.Id, Using = "submitWishlist")]
        public IWebElement SubmitWishlist { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@id,'wishlist')]/td[1]/a")]
        public IWebElement WishlistName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@id,'wishlist')]/td[2]")]
        public IWebElement WishlistQty { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[contains(@class,'table-bordered')]")]
        public IList<IWebElement> TableElements { get; set; }

        [FindsBy(How = How.CssSelector, Using = "td.wishlist_delete>a")]
        public IList<IWebElement> LinksToDeleteProducts { get; set; }

        public MyWishlistPage ClearWishListTable()
        {
            if (TableElements.Count > 0)
            {
                foreach (var element in LinksToDeleteProducts)
                {
                    element.Click();
                    var alert = Driver.SwitchTo().Alert();
                    alert.Accept();
                }
            }

            return this;
        }

        public WomenPage WomenPageLinkClick()
        {
            MenuHeader.LinkToWomenPage.Click();
            return new WomenPage(Driver);
        }

        public MyWishlistPage CreateWishlist(string name)
        {
            NameWishlistInput.SendKeys(name);
            return SubmitWishlistCreate();
        }

        public MyWishlistPage SubmitWishlistCreate()
        {
            SubmitWishlist.Submit();
            return this;
        }
    }
}