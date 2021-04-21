using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FinalTask.Pages
{
    public class MyAccountPage : Page
    {
        public MyAccountPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "li.lnk_wishlist>a")]
        public IWebElement WishlistLink { get; set; }

        public MyWishlistPage WishlistClick()
        {
            WishlistLink.Click();
            return new MyWishlistPage(Driver);
        }

        public CartPage CartLinkClick()
        {
            MenuHeader.LinkToCartPage.Click();
            return new CartPage(Driver);
        }
    }
}