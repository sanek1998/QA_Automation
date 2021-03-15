using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Task110.Pages
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

        [FindsBy(How = How.ClassName, Using = "uname")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.ClassName, Using = "enter")]
        public IWebElement Enter { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'wide')]")]
        public IWebElement LogoutButton { get; set; }

        internal LoginPage Open()
        {
            Driver.Url = "http://tut.by";
            ((ITakesScreenshot) Driver).GetScreenshot().SaveAsFile(@"OpenScreenshot" + DateTime.Now.Ticks + ".png");
            return this;
        }

        private HomePage SubmitLogin()
        {
            Submit.Submit();
            return new HomePage(Driver);
        }

        public HomePage LoginAs(string username, string password)
        {
            Enter.Click();
            Login.SendKeys(username);
            Password.SendKeys(password);
            return SubmitLogin();
        }

        public HomePage Logout()
        {
            UserName.Click();
            LogoutButton.Click();
            return new HomePage(Driver);
        }
    }
}