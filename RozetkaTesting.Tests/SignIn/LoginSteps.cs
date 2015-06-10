using NUnit.Framework;
using RozetkaTesting.Tests.SpecFlow;
using RozetkaTesting.WebPages;
using TechTalk.SpecFlow;

namespace RozetkaTesting.Tests.SignIn
{
    [Binding]
    public class LoginSteps
    {
        [Given(@"I am on the SignIn page")]
        public void GivenIAmOnTheSignInPage()
        {
            PageFactory.Get<SignInPage>().Open();
        }

        [Given(@"I enter a valid registered email and invalid password")]
        public void GivenITypeValidRegisteredEmailAndInvalidPassword()
        {
            string email = "qwertbnm@qwertbnm.com";
            string password = "invalidPass";

            PageFactory.Get<SignInPage>().FillRegistrationForm(email, password);
        }

        [When(@"I press Login button")]
        public void WhenIPressLoginButton()
        {
            PageFactory.Get<SignInPage>().SubmitRegistration();
        }

        [Then(@"the invalid password warning is appear")]
        public void ThenTheInvalidPasswordWarningIsAppear()
        {
            Assert.IsTrue(PageFactory.Get<SignInPage>().IsInvalidPasswordErrorAppear());
        }

        [Given(@"I enter invalid registered email and invalid password")]
        public void GivenITypeInvalidRegisteredEmailAndInvalidPassword()
        {
            string invalidEmail = "invalidEmail@qwertbnm.com";
            string password = "invalidPass";

            PageFactory.Get<SignInPage>().FillRegistrationForm(invalidEmail, password);
        }

        [Then(@"the invalid email warning is appear")]
        public void ThenTheInvalidEmailWarningIsAppear()
        {
            Assert.IsTrue(PageFactory.Get<SignInPage>().IsInvalidEmailErrorAppear());
        }

        [Given(@"I enter valid registered email and valid password")]
        public void GivenIEnterValidRegisteredEmailAndValidPassword()
        {
            string email = "qwertbnm@qwertbnm.com";
            string password = "qwertbnm";

            PageFactory.Get<SignInPage>().FillRegistrationForm(email, password);
        }

        [Then(@"I see my profile page")]
        public void ThenISeeMyProfilePage()
        {
            Assert.IsTrue(PageFactory.Get<SignInPage>().IsLogin());
        }
    }
}
