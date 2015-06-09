using System;
using OpenQA.Selenium;
using RozetkaTesting.Integrations;
using RozetkaTesting.WebPages.HtmlControls;

namespace RozetkaTesting.WebPages
{
    public class ProfilePage: BasePage
    {
        #region Private Fields

        /*-----User info-----*/
        private string _labelPersonalTitle;
        private string _inputUserName;
        private string _inputUserMail;

        /*-----Change password-----*/
        private string _inputOldPassword;
        private string _inputNewPassword;
        private string _inputNewPasswordAgain;
        private string _buttonSaveChanges;
        private string _linkCancel;

        /*-----Exit-----*/
        private string _linkExit;

        #endregion

        #region Constructor

        public ProfilePage(IDriver driver) : base(driver)
        {
        }

        #endregion

        #region Controls

        /*-----Personal info area-----*/
        private Label Label_Title()
        {
            return Label.ByXPath(_labelPersonalTitle);
        }

        private Label Label_Username()
        {
            return Label.ByXPath(_inputUserName);
        }

        private Label Label_UserMail()
        {
            return Label.ByXPath(_inputUserMail);
        }

        /*-----Change password area-----*/
        private TextField Input_OldPassword()
        {
            return TextField.ByLocator(By.XPath(_inputOldPassword));
        }

        private TextField Input_NewPassword()
        {
            return TextField.ByLocator(By.XPath(_inputNewPassword));
        }

        private TextField Input_NewPasswordAgain()
        {
            return TextField.ByLocator(By.XPath(_inputNewPasswordAgain));
        }

        private Button Button_SaveChanges()
        {
            return Button.ByXPath(_buttonSaveChanges);
        }

        private Link Link_Cancel()
        {
            return Link.ByLocator(By.XPath(_linkCancel));
        }

        /*-----Exit-----*/
        private Link Link_Exit()
        {
            return Link.ByText(_linkExit);
        }

        #endregion

        #region ProfilePage Functionality

        /// <summary>
        /// Types old password and new password with repeating.
        /// </summary>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        public void InputOldAndNewPasswords(string oldPassword, string newPassword)
        {
            Input_OldPassword().ClearAndType(oldPassword);
            Input_NewPassword().ClearAndType(newPassword);
            Input_NewPasswordAgain().ClearAndType(newPassword);
        }

        /// <summary>
        /// Submits password changing. 
        /// </summary>
        public void SubmitPasswordChanging()
        {
            Button_SaveChanges().Click();
        }

        /// <summary>
        /// Cancels password changing.
        /// </summary>
        public void CanceledPasswordChanging()
        {
            Link_Cancel().Click();
        }
        #endregion

        #region Override Methods

        protected override void Initialize()
        {
            PageUri = new Uri("https://my.rozetka.com.ua/profile/personal-information/");
            PageTitle = "ROZETKA — Личные данные | Личный кабинет";

            _labelPersonalTitle = "//*[@id='personal_information']//h1";
            _inputUserName = "//div[@id='personal_information']//div[text()='Имя']/following-sibling::div";
            _inputUserMail = "//div[@id='personal_information']//div[text()='Электронная почтa']/following-sibling::div/ul/li";

            _inputOldPassword = "//input[@name='oldpassword']";
            _inputNewPassword = "//input[@name='newpassword']";
            _inputNewPasswordAgain = "//input[@name='newpassword2']";

            _buttonSaveChanges = "//*[@id='change_password_block']//*[text()='Сохранить']";
            _linkCancel = "//*[@id='change_password_block']//*[text()='Отмена']";

            _linkExit = "Выход";
        }

        #endregion
    }
}
