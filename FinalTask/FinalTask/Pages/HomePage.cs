using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FinalTask.Pages
{
    public class HomePage : Page
    {
        private readonly string _url = "http://automationpractice.com";

        public HomePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        public HomePage Open()
        {
            Driver.Url = _url;
            return this;
        }
    }
}