using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FinalTask.Pages
{
    public class CartPage : Page
    {
        public CartPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "cart_quantity_delete")]
        public IList<IWebElement> CartQuantityDeleteElements { get; set; }

        [FindsBy(How = How.XPath, Using = " //table[@id='cart_summary']/tbody/tr")]
        public IList<IWebElement> ItemsInCart { get; set; }

        public CartPage ClearCartTable()
        {
            if (CartQuantityDeleteElements.Count > 0)
            {
                foreach (var webElement in CartQuantityDeleteElements)
                {
                    webElement.Click();
                }
            }

            return this;
        }

        public WomenPage WomenPageLinkClick()
        {
            MenuHeader.LinkToWomenPage.Click();
            return new WomenPage(Driver);
        }
    }
}