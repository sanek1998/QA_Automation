using System;
using FinalTask.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace FinalTask.Pages
{
    public class Page
    {

        protected IWebDriver Driver;

        public MenuHeader MenuHeader { get; set; }

        public Page(IWebDriver driver)
        {
            Driver = driver;
            MenuHeader=new MenuHeader(driver);
        }
    }
}