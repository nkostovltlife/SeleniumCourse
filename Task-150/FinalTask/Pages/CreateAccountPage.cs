using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace FinalTask.Pages
{
    public class CreateAccountPage : BasePage
    {
        private const string firstName = "Nikolay";
        private const string lastName = "Kostov";
        private const string password = "Welcome1";
        private const string day = "1";
        private const string month = "1";
        private const string year = "2000";
        private const string company = "Coherent";
        private const string address = "Sofia, 1000";
        private const string city = "Sofia";
        private const string state = "Florida";
        private const string postCode = "11111";
        private const string mobilePhone = "(555) 555-1234";
        private const string addressAlias = "Alias";

        private By dayBy = By.Id("days");
        private By monthBy = By.Id("months");
        private By yearBy = By.Id("years");
        private By stateBy = By.Id("id_state");
        private By countryBy = By.Id("id_country");
        private By myWishlistBy = By.CssSelector("a[title='My wishlists']");


        [FindsBy(How = How.Id, Using = "id_gender1")]
        public IWebElement MrRadioButton;

        [FindsBy(How = How.Id, Using = "customer_firstname")]
        public IWebElement CustomerFirstName;

        [FindsBy(How = How.Id, Using = "customer_lastname")]
        public IWebElement CustomerLastName;

        [FindsBy(How = How.Id, Using = "passwd")]
        public IWebElement Password;

        public SelectElement Day => new SelectElement(Driver.FindElement(dayBy));
        public SelectElement Month => new SelectElement(Driver.FindElement(monthBy));
        public SelectElement Year => new SelectElement(Driver.FindElement(yearBy));

        [FindsBy(How = How.Id, Using = "optin")]
        public IWebElement SpecialOffersCheckBox;

        [FindsBy(How = How.Id, Using = "firstname")]
        public IWebElement FirstName;

        [FindsBy(How = How.Id, Using = "lastname")]
        public IWebElement LastName;

        [FindsBy(How = How.Id, Using = "company")]
        public IWebElement Company;

        [FindsBy(How = How.Id, Using = "address1")]
        public IWebElement Address;

        [FindsBy(How = How.Id, Using = "city")]
        public IWebElement City;

        public SelectElement State => new SelectElement(Driver.FindElement(stateBy));

        [FindsBy(How = How.Id, Using = "postcode")]
        public IWebElement Postcode;

        public SelectElement Country => new SelectElement(Driver.FindElement(countryBy));

        [FindsBy(How = How.Id, Using = "phone_mobile")]
        public IWebElement MobilePhone;

        [FindsBy(How = How.Id, Using = "alias")]
        public IWebElement AddressAlias;

        [FindsBy(How = How.Id, Using = "submitAccount")]
        public IWebElement RegisterButton;

        public CreateAccountPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void ClickRegisterButton()
        {
            RegisterButton.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(myWishlistBy));
        }

        public void FillRegistrationForm()
        {
            MrRadioButton.Click();
            EnterText(CustomerFirstName, firstName);
            EnterText(CustomerLastName, lastName);
            EnterText(Password, password);
            Day.SelectByValue(day);
            Month.SelectByValue(month);
            Year.SelectByValue(year);
            SpecialOffersCheckBox.Click();
            EnterText(FirstName, firstName);
            EnterText(LastName, lastName);
            EnterText(Company, company);
            EnterText(Address, address);
            EnterText(City, city);
            State.SelectByText(state);
            EnterText(Postcode, postCode);
            EnterText(MobilePhone, mobilePhone);
            EnterText(AddressAlias, addressAlias);
        }
    }
}
