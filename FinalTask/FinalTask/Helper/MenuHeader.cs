using System;
using FinalTask.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace FinalTask.Helper
{
    public class MenuHeader
    {
        protected IWebDriver _driver;
        protected WebDriverWait wait;

     //   private static MenuHeader instance;

        [FindsBy(How = How.CssSelector, Using = ".sfHoverForce>a")]
        private IWebElement WomenTab;

        [FindsBy(How = How.ClassName, Using = "account")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[contains(@class,'menu-content')]/li[1]/a")]
        public IWebElement LinkToWomenPage { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "div.shopping_cart>a")]
        public IWebElement LinkToCartPage{ get; set; }

        public MenuHeader(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        //protected MenuHeader(IWebDriver driver)
        //{
        //    _driver = driver;
        //    wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        //    PageFactory.InitElements(driver, this);
        //}

        //public static MenuHeader getInstance(IWebDriver driver)
        //{
        //    if (instance == null)
        //        instance = new MenuHeader(driver);
        //    return instance;
        //}

        //internal WomenTabPage WomenTabClick()
        //{
        //    WomenTab.Click();
        //    return new WomenTabPage(_driver);
        //}

        private void SingOut()
        {
            if (_driver.FindElements(By.ClassName("header_user_info")).Count == 2)
            {
                _driver.FindElement(By.ClassName("logout")).Click();
            }
        }

        internal AuthenticationPage SingInClick()
        {
            
            _driver.FindElement(By.ClassName("login")).Click();
            return new AuthenticationPage(_driver);
        }
    }
}