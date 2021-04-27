using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task80.Pages
{
    public class Page
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        public Page(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }
    }
}