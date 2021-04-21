using System.Collections.Generic;
using FinalTask.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace FinalTask.Pages
{
    public class WomenPage : Page
    {
        public WomenPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//ul[contains(@class,'product_list')]/li")]
        public IList<IWebElement> ItemsLiElements { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".wishlist>a")]
        public IWebElement AddToWishlist { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Close']")]
        public IWebElement CloseFancybox { get; set; }

        public WomenPage MoveToElementFirstItem()
        {
            var action = new Actions(Driver);
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

        public WomenPage AddItemsToCart(int count)
        {
            var action = new Actions(Driver);

            for (var i = 0; i < count; i++)
            {
                action.MoveToElement(ItemsLiElements[i]).Perform();
                AddItem(i);
            }

            return this;
        }

        private void AddItem(int index)
        {
            Driver.FindElement(By.XPath($"//li[{index + 1}]/div/div/div[@class='button-container']/a[contains(@class,'ajax_add_to_cart_button')]"))
                  .Click();
            if (Driver.WaiterByElementIsDisplayed(By.Id("layer_cart"), 5000))
            {
                Driver.FindElement(By.XPath("//span[contains(@class, 'continue')]")).Click();
            }
        }

        public CartPage CartLinkClick()
        {
            MenuHeader.LinkToCartPage.Click();
            return new CartPage(Driver);
        }
    }
}