using System.Collections.Generic;
using System.Threading;
using FinalTask.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace FinalTask.Pages
{
    public class WomenPage : Page
    {
        [FindsBy(How = How.XPath, Using = "//ul[contains(@class,'product_list')]/li")]
        public IList<IWebElement> ItemsLiElements { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".wishlist>a")]
        public IWebElement AddToWishlist { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Close']")]
        public IWebElement CloseFancybox { get; set; }

        public WomenPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public WomenPage MoveToElementFirstItem()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(ItemsLiElements[0]).Perform();
            return this;
        }

        public WomenPage AddToWishlisClick()
        {
            AddToWishlist.Click();
            return this;
        }

        public WomenPage CloseFancyboxClick()
        {
            CloseFancybox.Click();
            return this;
        }

        public MyAccountPage GoToMyAccaount()
        {
            MenuHeader.UserName.Click();
            return new MyAccountPage(Driver);
        }

        public WomenPage AddThreeItemToCart()
        {

            Actions action = new Actions(Driver);
            for (int i = 0; i < 3; i++)
            {
                action.MoveToElement(ItemsLiElements[i]).Perform();
                Driver.FindElement(By.XPath($"//li[{i + 1}]/div/div/div[@class='button-container']/a[contains(@class,'ajax_add_to_cart_button')]")).Click();
                if (Driver.WaiterByElementIsDisplayed(By.Id("layer_cart")))
                {
                    Driver.FindElement(By.XPath("//span[contains(@class, 'continue')]")).Click();
                }
            }

            return this;
        }

        public CartPage CartLinkClick()
        {
            MenuHeader.LinkToCartPage.Click();
            return new CartPage(Driver);
        }
    }
}