using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FinalTask.Pages
{
    public class AuthenticationPage : Page
    {
        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement Login { get; set; }

        [FindsBy(How = How.Name, Using = "passwd")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        public IWebElement LoginSubmit { get; set; }

        [FindsBy(How = How.Id, Using = "email_create")]
        public IWebElement EmailRegistration { get; set; }


        public AuthenticationPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        internal AuthenticationPage Open()
        {
            Driver.Url = "http://automationpractice.com/index.php?controller=authentication&back=my-account";
            return this;
        }

        public MyAccountPage LoginAs(string email, string password)
        {
            Login.SendKeys(email);
            Password.SendKeys(password);
            return SubmitLogin();
        }

        public RegistrationPage EmailSendForRegistration(string email)

        {
            EmailRegistration.SendKeys(email);
            return SubmitRegistration();
        }

        private MyAccountPage SubmitLogin()
        {
            LoginSubmit.Submit();
            return new MyAccountPage(Driver);
        }

        private RegistrationPage SubmitRegistration()
        {
            EmailRegistration.Submit();
            return new RegistrationPage(Driver);
        }
    }
}