using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task110.Pages
{
    public class Page
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        public Page(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
    }
}