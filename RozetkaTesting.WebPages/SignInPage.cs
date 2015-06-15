using System;
using OpenQA.Selenium;
using RozetkaTesting.Integrations;
using RozetkaTesting.WebPages.Attributes;
using RozetkaTesting.WebPages.Helpers;
using RozetkaTesting.WebPages.HtmlControls;

namespace RozetkaTesting.WebPages
{
    [Page("SignIn")]
    public class SignInPage: BasePage
    {
        #region Private Fields

        private string _loginName;
        private string _passwordName;
        private string _buttonSignIn;

        private string _invalidPasswordErrorXpath;
        private string _invalidEmailErrorXpath;

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

        private TextField Input_Email()
        {
            return TextField.ByLocator(By.XPath(GetXpathByName(_loginName)));
        }

        private TextField Input_Password()
        {
            return TextField.ByLocator(By.XPath(GetXpathByName(_passwordName)));
        }

        private Button Button_SignIn()
        {
            return Button.ByXPath(_buttonSignIn);
        }

        #endregion

        #region SignInPage Functionality

        /// <summary>
        /// Fills SignIn form.
        /// </summary>
        /// <param name="email">User email.</param>
        /// <param name="password">User password.</param>
        public void FillRegistrationForm(string email, string password)
        {
            Input_Email().ClearAndType(email);
            Input_Password().ClearAndType(password);
        }

        /// <summary>
        /// Submits SignIn form.
        /// </summary>
        public void SubmitRegistration()
        {
            Button_SignIn().Click();
        }

        /// <summary>
        /// Checks the appearance of error message about invalid password.
        /// </summary>
        /// <returns>True if the error message is appear.</returns>
        public bool IsInvalidPasswordErrorAppear()
        {
            return (Driver.FindElements(By.XPath(_invalidPasswordErrorXpath)).Count == 1);
        }

        /// <summary>
        /// Checks the appearance of error message about invalid email.
        /// </summary>
        /// <returns>True if the error message is appear.</returns>
        public bool IsInvalidEmailErrorAppear()
        {
            return (Driver.FindElements(By.XPath(_invalidEmailErrorXpath)).Count == 1);
        }

        #endregion

        #region Override Methods

        protected override void Initialize()
        {
            PageTitle = "ROZETKA — Вход в интернет-магазин";
            PageUri = UrlBuilder.Get("my", "signin", true);


            _loginName = "login";
            _passwordName = "password";
            _buttonSignIn = "//button[@class='btn-link btn-link-blue btn-link-sign']";
            _invalidPasswordErrorXpath = "//div[@class='pos-fix sprite-side message code5']";
            _invalidEmailErrorXpath = "//div[@class='pos-fix sprite-side message code4']";
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
