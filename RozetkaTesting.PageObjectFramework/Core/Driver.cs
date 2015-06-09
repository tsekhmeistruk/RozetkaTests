using System;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using RozetkaTesting.Framework.Helpers;
using RozetkaTesting.Integrations;

namespace RozetkaTesting.Framework.Core
{
    /// <summary>
    /// Represents the Selenium WebDriver abstraction layer for interacting with the Browser.
    /// </summary>
    public class Driver: IDriver
    {
        #region Config parameters

        private static int _implicitWait;
        private static int _defaultWait;

        #endregion

        #region IWebDriver

        private IWebDriver _webDriver;

        private IWebDriver WebDriver
        {
            get { return _webDriver ?? StartWebDriver(); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor of the driver w/o parameters.
        /// </summary>
        public Driver()
        {
            Initialize();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Returns the type of browser.
        /// </summary>
        public BrowserType SelectedBrowser
        {
            get
            {
                return GetBrowserType();
            }
        }

        /// <summary>
        /// Returns the current URL.
        /// </summary>
        public Uri Url
        {
            get
            {
                return new Uri(WebDriver.Url);
            }
        }

        /// <summary>
        /// Returns the current Title.
        /// </summary>
        public string Title
        {
            get
            {
                return string.Format("{0}", WebDriver.Title);
            }
        }

        #endregion

        #region IDriver Implementation

        /// <summary>
        /// Initializes the WebDriver.
        /// </summary>
        public void Start()
        {
            _webDriver = StartWebDriver();
            WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Navigates to the <see cref="url" />.
        /// </summary>
        /// <param name="url">Target Uri.</param>
        public void Navigate(Uri url)
        {
            if (url != null)
            {
                WebDriver.Navigate().GoToUrl(url);
            }
        }

        /// <summary>
        /// Quits and sets WebDriver to null.
        /// </summary>
        public void Quit()
        {
            if (WebDriver == null)
            {
                return;
            }

            _webDriver.Quit();
            _webDriver = null;
        }

        /// <summary>
        /// Switch to the Frame.
        /// </summary>
        /// <param name="inlineFrame">Target Frame.</param>
        public void SwitchToFrame(IWebElement inlineFrame)
        {
            WebDriver.SwitchTo().Frame(inlineFrame);
        }

        /// <summary>
        /// Switch to the Default Content.
        /// </summary>
        public void SwitchToDefaultContent()
        {
            WebDriver.SwitchTo().DefaultContent();
        }

        /// <summary>
        /// Gets screenshot.
        /// </summary>
        /// <returns>The Screenshot.</returns>
        public Screenshot GetScreenshot()
        {
            return ((ITakesScreenshot) WebDriver).GetScreenshot();
        }

        /// <summary>
        /// Saves screenshot in the specific <see cref="path" />.
        /// </summary>
        /// <param name="path">The specific path for saving screenshot.</param>
        public void SaveScreenshot(string path)
        {
            if (!String.IsNullOrEmpty(path))
            {
                GetScreenshot().SaveAsFile(path, ImageFormat.Jpeg);
            }
        }

        /// <summary>
        /// Resizes window.
        /// </summary>
        /// <param name="width">Width of window.</param>
        /// <param name="height">Height of window.</param>
        public void ResizeWindow(int width, int height)
        {
            ExecuteJavaScript(string.Format("window.resizeTo({0}, {1});", width, height));
        }

        /// <summary>
        /// Navigates back in a browser.
        /// </summary>
        public void NavigateBack()
        {
            WebDriver.Navigate().Back();
        }

        /// <summary>
        /// Refresh current page.
        /// </summary>
        public void Refresh()
        {
            WebDriver.Navigate().Refresh();
        }

        /// <summary>
        /// Executes JavaScript code.
        /// </summary>
        /// <param name="javaScript">The JavaScript code.</param>
        /// <param name="args">The specific arguments.</param>
        /// <returns>The object.</returns>
        public object ExecuteJavaScript(string javaScript, params object[] args)
        {
            var javaScriptExecutor = (IJavaScriptExecutor) WebDriver;
            return javaScriptExecutor.ExecuteScript(javaScript, args);
        }

        /// <summary>
        /// Driver waits until the element is appear.
        /// </summary>
        /// <param name="elementLocator">Locator of element.</param>
        /// <param name="seconds">Time limit for waiting.</param>
        public void WaitUntilElementIsPresent(By elementLocator, int seconds)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(seconds));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
        }

        /// <summary>
        /// Driver waits until the element is appear during default time for waiting.
        /// </summary>
        /// <param name="elementLocator">Locator of element.</param>
        public void WaitUntilElementIsPresent(By elementLocator)
        {
            WaitUntilElementIsPresent(elementLocator, _defaultWait);
        }

        #endregion

        #region ISearchContext
        //TODO 
        /// <summary>
        /// Finds the web element.
        /// </summary>
        /// <param name="by">The specific locator.</param>
        /// <returns>The <see cref="IWebElement" /> object.</returns>
        public IWebElement FindElement(By @by)
        {
            return WebDriver.FindElement(@by);
        }

        /// <summary>
        /// Finds the web elements.
        /// </summary>
        /// <param name="by">The specific locator.</param>
        /// <returns>The collection of <see cref="IWebElement" /> objects.</returns>
        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            return WebDriver.FindElements(@by);
        }

        #endregion

        #region Private Methods

        private IWebDriver StartWebDriver()
        {
            if (_webDriver != null)
            {
                return _webDriver;
            }

            switch (SelectedBrowser)
            {
                case BrowserType.Chrome:
                    _webDriver = StartChrome();
                    break;

                case BrowserType.Firefox:
                    _webDriver = StartFirefox();
                    break;

                case BrowserType.InternetExplorer:
                    _webDriver = StartInternetExplorer();
                    break;

                default:
                    throw new Exception(string.Format("Unknown browser selected: {0}.", SelectedBrowser));
            }

            _webDriver.Manage().Window.Maximize();
            SetImplicitWait(_implicitWait);
            return _webDriver;
        }

        private InternetExplorerDriver StartInternetExplorer()
        {
            var internetExplorerOptions = new InternetExplorerOptions
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                InitialBrowserUrl = "about:blank",
                EnableNativeEvents = true
            };

            return new InternetExplorerDriver("../../../RozetkaTesting.PageObjectFramework/External/",
                internetExplorerOptions);
        }

        private FirefoxDriver StartFirefox()
        {
            return new FirefoxDriver();
        }

        private ChromeDriver StartChrome()
        {
            return new ChromeDriver("../../../RozetkaTesting.PageObjectFramework/External/");
        }

        private void SetImplicitWait(int seconds)
        {
            _webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(seconds));
        }

        private BrowserType GetBrowserType()
        {
            string browser = ConfigHelper.GetBrowserName();

            switch (browser)
            {
                case "Firefox":
                    return BrowserType.Firefox;

                case "Chrome":
                    return BrowserType.Chrome;

                case "IE":
                    return BrowserType.InternetExplorer;

                default:
                    throw new Exception("Work browser was not appointed.");
            }
        }

        private void Initialize()
        {
            if (!int.TryParse(ConfigHelper.GetImplicitWaitTime(), out _implicitWait))
            {
                throw new Exception("Incorrect config data of Implicit waiting time.");
            }

            if (!int.TryParse(ConfigHelper.GetDefaultWaitTime(), out _defaultWait))
            {
                throw new Exception("Incorrect config data of Default waiting time.");
            }
        }

        #endregion
    }
}
