using FinalTask.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace FinalTask.Pages
{
    public class RegistrationPage : Page
    {
        public RegistrationPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        //YOUR PERSONAL INFORMATION

        [FindsBy(How = How.XPath, Using = "//label[@for='id_gender1']")]
        public IWebElement LabelMr { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[@for='id_gender2']")]
        public IWebElement LabelMrs { get; set; }

        [FindsBy(How = How.Id, Using = "customer_firstname")]
        public IWebElement CustomerFirstNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "customer_lastname")]
        public IWebElement CustomerLastNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement EmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "passwd")]
        public IWebElement PasswordInput { get; set; }

        [FindsBy(How = How.Id, Using = "days")]
        public IWebElement DaySelect { get; set; }

        [FindsBy(How = How.Id, Using = "months")]
        public IWebElement MonthsSelect { get; set; }

        [FindsBy(How = How.Id, Using = "years")]
        public IWebElement YearsSelect { get; set; }

        [FindsBy(How = How.Id, Using = "newsletter")]
        public IWebElement NewsletterCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "optin")]
        public IWebElement OptinCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "firstname")]

        // ADDRESS
        public IWebElement FirstNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "lastname")]
        public IWebElement LastNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "company")]
        public IWebElement CompsnyInput { get; set; }

        [FindsBy(How = How.Id, Using = "address1")]
        public IWebElement Address1Input { get; set; }


        [FindsBy(How = How.Id, Using = "address2")]
        public IWebElement Address2Input { get; set; }

        [FindsBy(How = How.Id, Using = "city")]
        public IWebElement CityInput { get; set; }


        [FindsBy(How = How.Id, Using = "id_state")]
        public IWebElement StateSelect { get; set; }

        [FindsBy(How = How.Id, Using = "postcode")]
        public IWebElement PostcodeInput { get; set; }

        [FindsBy(How = How.Id, Using = "id_country")]
        public IWebElement CountrySelect { get; set; }

        [FindsBy(How = How.Id, Using = "other")]
        public IWebElement OtherInput { get; set; }

        [FindsBy(How = How.Id, Using = "phone")]
        public IWebElement PhoneInput { get; set; }

        [FindsBy(How = How.Id, Using = "phone_mobile")]
        public IWebElement PhoneMobileInput { get; set; }

        [FindsBy(How = How.Id, Using = "alias")]
        public IWebElement AliasInput { get; set; }

        // Submit Registration
        [FindsBy(How = How.Id, Using = "submitAccount")]
        public IWebElement SubmitAccount { get; set; }

        public RegistrationPage FillData(User user)
        {
            FillPersonalInformation(user.IsMan, user.FirstName, user.LastName,
                user.Email, user.Password, user.BirthDate, user.IsNewsletter, user.IsSpecialOffers);
            FillAddress(user.FirstName, user.LastName, user.Company, user.Address1, user.Address1,
                user.City, user.State, user.Zip, user.Country, user.AdditionalInformation,
                user.HomePhone, user.MobilePhone, user.Alias);

            return this;
        }

        public HomePage SubmitCreateAccount()
        {
            SubmitAccount.Submit();
            return new HomePage(Driver);
        }

        private void FillPersonalInformation(bool isMan, string firstName, string lastName,
            string email, string password, BirthDate birthDate, bool isNewsletter, bool isSpecialOffers)
        {
            WebElementClick(isMan ? LabelMr : LabelMrs);
            CustomerFirstNameInput.SendKeys(firstName);
            CustomerLastNameInput.SendKeys(lastName);
            EmailInput.Clear();
            EmailInput.SendKeys(email);
            PasswordInput.SendKeys(password);
            SelectByValue(new SelectElement(DaySelect), birthDate.DayOfBirth);
            SelectByValue(new SelectElement(MonthsSelect), ((int) birthDate.MonthOfBirth).ToString());
            SelectByValue(new SelectElement(YearsSelect), birthDate.YearOfBirth);
            ClickCheckBox(isNewsletter, NewsletterCheckbox);
            ClickCheckBox(isSpecialOffers, OptinCheckbox);
        }

        private void FillAddress(string firstName, string lastName, string company,
            string address1, string address2, string city, string state, string postcode, string country,
            string other, string phone, string phoneMobile, string alias)
        {
            FirstNameInput.SendKeys(firstName);
            LastNameInput.SendKeys(lastName);
            CompsnyInput.SendKeys(company);
            Address1Input.SendKeys(address1);
            Address2Input.SendKeys(address2);
            CityInput.SendKeys(city);
            SelectByText(new SelectElement(StateSelect), state);
            PostcodeInput.SendKeys(postcode);
            SelectByText(new SelectElement(CountrySelect), country);
            OtherInput.SendKeys(other);
            PhoneInput.SendKeys(phone);
            PhoneMobileInput.SendKeys(phoneMobile);
            AliasInput.SendKeys(alias);
        }

        private void WebElementClick(IWebElement element)
        {
            element.Click();
        }

        private void ClickCheckBox(bool isClick, IWebElement element)
        {
            if (isClick)
            {
                element.Click();
            }
        }

        private void SelectByValue(SelectElement element, string value)
        {
            element.SelectByValue(value);
        }

        private void SelectByText(SelectElement element, string value)
        {
            element.SelectByText(value);
        }

        public bool IsMultipleSelect(IWebElement element)
        {
            return new SelectElement(element).IsMultiple;
        }

    }
}