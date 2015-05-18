using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using RozetkaTesting.Framework.Enums;

namespace RozetkaTesting.Framework.SeleniumApiWrapper
{
    public class Browser
    {
        #region Private Fields and Properties

        private IWebDriver _webDriver;
        private IWebDriver WebDriver
        {
            get { return _webDriver ?? StartWebDriver(); }
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

            return new InternetExplorerDriver(Directory.GetCurrentDirectory() + "/External", internetExplorerOptions);
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
            return new ChromeDriver(Directory.GetCurrentDirectory() + "/External");
        }

        /// <summary>Waits until the condition occurs.</summary>
        /// <remarks>Used by other wait methods.</remarks>
        /// <param name="condition">The condition to wait for.</param>
        /// <param name="timeout">The time in seconds to wait.</param>
        private void WaitUntilExpected(Func<IWebDriver, bool> condition, long timeout)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeout));
            wait.Until(condition);
        }

        private void SetImplicitWait(int seconds)
        {
            _webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(seconds));
        }

        #endregion

        #region Public Properties

        public BrowserType SelectedBrowser
        {
            get { return Settings.DefaultBrowser; }
        }

        public Uri Url
        {
            get
            {
                return new Uri(WebDriver.Url);
            }
        }

        public string Title
        {
            get
            {
                return string.Format("{0}", WebDriver.Title);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Initializes the WebDriver.
        /// </summary>
        public void Start()
        {
            _webDriver = StartWebDriver();
            WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Navigates to the <see cref="url"/>.
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
            if (WebDriver == null) return;

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
        /// Find elements by selector.
        /// </summary>
        /// <param name="selector">By selector.</param>
        /// <returns>The IEnumerable of <see cref="IWebElement"/>.</returns>
        public IEnumerable<IWebElement> FindElements(By selector)
        {
            return WebDriver.FindElements(selector);
        }

        /// <summary>
        /// Gets screenshot.
        /// </summary>
        /// <returns></returns>
        public Screenshot GetScreenshot()
        {
            return ((ITakesScreenshot)WebDriver).GetScreenshot();
        }

        /// <summary>
        /// Saves screenshot in the specific <see cref="path"/>.
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
        /// <param name="height">Height of window</param>
        public void ResizeWindow(int width, int height)
        {
            ExecuteJavaScript(string.Format("window.resizeTo({0}, {1});", width, height));
        }

        /// <summary>
        /// Navigates back in browser/
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
        /// <returns>The object/</returns>
        public object ExecuteJavaScript(string javaScript, params object[] args)
        {
            var javaScriptExecutor = (IJavaScriptExecutor)WebDriver;

            return javaScriptExecutor.ExecuteScript(javaScript, args);
        }

        #endregion
    }
}
