using System;
using FinalTask.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace FinalTask.Helper
{
    public class MenuHeader
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        public MenuHeader(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "account")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[contains(@class,'menu-content')]/li[1]/a")]
        public IWebElement LinkToWomenPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.shopping_cart>a")]
        public IWebElement LinkToCartPage { get; set; }

        internal AuthenticationPage SingInClick()
        {
            Driver.FindElement(By.ClassName("login")).Click();
            return new AuthenticationPage(Driver);
        }
    }
}