using System;
using OpenQA.Selenium;
using RozetkaTesting.Integrations;
using RozetkaTesting.WebPages.HtmlControls;

namespace RozetkaTesting.WebPages
{
    public class SignInPage: BasePage
    {
        #region XPath strings of web elements
        
        private string _labelHeader;
        private string _nameName;
        private string _emailName;
        private string _passwordName;
        private string _buttonSignIn;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes new Instance of <see cref="SignInPage"/>
        /// </summary>
        /// <param name="driver"><see cref="IDriver"/> object.</param>
        public SignInPage(IDriver driver) : base(driver)
        {
        }

        #endregion

        #region Controls

        private Label Label_Header()
        {
            return Label.ByXPath(_labelHeader);
        }

        private TextField Input_Name()
        {
            return TextField.ByLocator(By.XPath(GetXpathByName(_nameName)));   
        }

        private TextField Input_Email()
        {
            return TextField.ByLocator(By.XPath(GetXpathByName(_emailName)));
        }

        private TextField Input_Password()
        {
            return TextField.ByLocator(By.XPath(GetXpathByName(_passwordName)));
        }

        private Button Button_SignIn()
        {
            return Button.ByText(_buttonSignIn);
        }

        #endregion

        #region SignInPage Functionality

        /// <summary>
        /// Fills registration form.
        /// </summary>
        /// <param name="name">Registration name.</param>
        /// <param name="email">Registration email.</param>
        /// <param name="password">Registration password.</param>
        public void FillRegistrationForm(string name, string email, string password)
        {
            Input_Name().ClearAndType(name);
            Input_Email().ClearAndType(email);
            Input_Password().ClearAndType(password);
        }

        /// <summary>
        /// Submits registration form.
        /// </summary>
        public void SubmitRegistration()
        {
            Button_SignIn().Click();
        }

        #endregion

        #region Overrided Methods

        protected override void Initialize()
        {
            PageTitle = "ROZETKA — Регистрация";
            PageUri = new Uri("https://my.rozetka.com.ua/signup/");

            _labelHeader = "//*[@class='clearfix signup']/h1";
            _nameName = "title";
            _emailName = "email";
            _passwordName = "password";
            _buttonSignIn = "Зарегистрироваться";
        }

        #endregion

        #region Private Methods

        private string GetXpathByName(string nameAttr)
        {
            return String.Format("//*[@class='input-text auth-input-text'][@name='{0}']", nameAttr);
        }

        #endregion
    }
}
