using FinalTask.Helper;
using OpenQA.Selenium;

namespace FinalTask.Pages
{
    public class Page
    {
        protected IWebDriver Driver;

        public Page(IWebDriver driver)
        {
            Driver = driver;
            MenuHeader = new MenuHeader(driver);
        }

        public MenuHeader MenuHeader { get; set; }
    }
}