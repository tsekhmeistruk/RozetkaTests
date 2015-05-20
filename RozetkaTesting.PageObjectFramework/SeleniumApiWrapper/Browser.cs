using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using RozetkaTesting.Framework.Enums;
using RozetkaTesting.Framework.Helpers;

namespace RozetkaTesting.Framework.SeleniumApiWrapper
{
    public class Browser : ISearchContext
    {
        #region IWebDriver

        private IWebDriver _webDriver;

        private IWebDriver WebDriver
        {
            get { return _webDriver ?? StartWebDriver(); }
        }

        #endregion

        #region Public Properties

        public BrowserType SelectedBrowser
        {
            get
            {
                Dictionary<string, string> browserConfig = JsonHelper.Deserialize(
                    "../../../RozetkaTesting.PageObjectFramework/External/BrowserConfig.json");
                string browser;
                browserConfig.TryGetValue("type", out browser);

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
        }

        public Uri Url
        {
            get { return new Uri(WebDriver.Url); }
        }

        public string Title
        {
            get { return string.Format("{0}", WebDriver.Title); }
        }

        #endregion

        #region WebDriver functionality

        /// <summary>
        ///     Initializes the WebDriver.
        /// </summary>
        public void Start()
        {
            _webDriver = StartWebDriver();
            WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        /// <summary>
        ///     Navigates to the <see cref="url" />.
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
        ///     Quits and sets WebDriver to null.
        /// </summary>
        public void Quit()
        {
            if (WebDriver == null) return;

            _webDriver.Quit();
            _webDriver = null;
        }

        /// <summary>
        ///     Switch to the Frame.
        /// </summary>
        /// <param name="inlineFrame">Target Frame.</param>
        public void SwitchToFrame(IWebElement inlineFrame)
        {
            WebDriver.SwitchTo().Frame(inlineFrame);
        }

        /// <summary>
        ///     Switch to the Default Content.
        /// </summary>
        public void SwitchToDefaultContent()
        {
            WebDriver.SwitchTo().DefaultContent();
        }

        /// <summary>
        ///     Gets screenshot.
        /// </summary>
        /// <returns></returns>
        public Screenshot GetScreenshot()
        {
            return ((ITakesScreenshot) WebDriver).GetScreenshot();
        }

        /// <summary>
        ///     Saves screenshot in the specific <see cref="path" />.
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
        ///     Resizes window.
        /// </summary>
        /// <param name="width">Width of window.</param>
        /// <param name="height">Height of window</param>
        public void ResizeWindow(int width, int height)
        {
            ExecuteJavaScript(string.Format("window.resizeTo({0}, {1});", width, height));
        }

        /// <summary>
        ///     Navigates back in browser/
        /// </summary>
        public void NavigateBack()
        {
            WebDriver.Navigate().Back();
        }

        /// <summary>
        ///     Refresh current page.
        /// </summary>
        public void Refresh()
        {
            WebDriver.Navigate().Refresh();
        }

        /// <summary>
        ///     Executes JavaScript code.
        /// </summary>
        /// <param name="javaScript">The JavaScript code.</param>
        /// <param name="args">The specific arguments.</param>
        /// <returns>The object/</returns>
        public object ExecuteJavaScript(string javaScript, params object[] args)
        {
            var javaScriptExecutor = (IJavaScriptExecutor) WebDriver;

            return javaScriptExecutor.ExecuteScript(javaScript, args);
        }

        #endregion

        #region ISearchContext

        /// <summary>
        ///     Finds the web element.
        /// </summary>
        /// <param name="by"></param>
        /// <returns>The <see cref="IWebElement" /> object.</returns>
        public IWebElement FindElement(By @by)
        {
            return WebDriver.FindElement(@by);
        }

        /// <summary>
        ///     Finds the web elements.
        /// </summary>
        /// <param name="by"></param>
        /// <returns>The collection of <see cref="IWebElement" /> objects.</returns>
        ReadOnlyCollection<IWebElement> ISearchContext.FindElements(By @by)
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
                    _webDriver = StartInternetEplorer();
                    break;

                default:
                    throw new Exception(string.Format("Unknown browser selected: {0}.", SelectedBrowser));
            }

            _webDriver.Manage().Window.Maximize();
            SetImplicitWait(10); //TODO rewrite
            return _webDriver;
        }

        private InternetExplorerDriver StartInternetEplorer()
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
            var firefoxProfile = new FirefoxProfile
            {
                AcceptUntrustedCertificates = true,
                EnableNativeEvents = true
            };

            return new FirefoxDriver(firefoxProfile);
        }

        private ChromeDriver StartChrome()
        {
            return new ChromeDriver("../../../RozetkaTesting.PageObjectFramework/External/");
        }

        private void SetImplicitWait(int seconds)
        {
            _webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(seconds));
        }

        #endregion
    }
}
