using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Task70.Pages
{
    public class LoginPage : Page
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "login")]
        public IWebElement Login { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='button m-green auth__enter']")]
        public IWebElement Submit { get; set; }

        internal LoginPage Open()
        {
            Driver.Url = "http://tut.by";
            return this;
        }

        private HomePage SubmitLogin()
        {
            Submit.Submit();
            return new HomePage(Driver);
        }

        public HomePage LoginAs(string username, string password)
        {
            Driver.FindElement(By.ClassName("enter")).Click();
            Login.SendKeys(username);
            Password.SendKeys(password);
            return SubmitLogin();
        }

        public HomePage Logout()
        {
            Driver.FindElement(By.ClassName("uname")).Click();
            Driver.FindElement(By.XPath("//a[contains(@class,'wide')]")).Click();
            return new HomePage(Driver);
        }
    }
}