using OpenQA.Selenium;

namespace Task110.Pages
{
    public class HomePage : Page
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public bool AtPage() => Driver.Title.Equals("Белорусский портал TUT.BY. Новости Беларуси и мира");
    }
}