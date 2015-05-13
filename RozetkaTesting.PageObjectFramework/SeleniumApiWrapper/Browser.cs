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
    public static class Browser
    {
        #region Private Fields and Properties

        private static IWebDriver _webDriver;
        private static string _timeOutPageReady;
        private static string _timeOutAjax;

        private static IWebDriver WebDriver
        {
            get { return _webDriver ?? StartWebDriver(); }
        }

        #endregion

        #region Static Constructor

        static Browser()
        {
            Initialize();
        }

        #endregion

        #region Private Methods

        private static void Initialize()
        {
            _timeOutPageReady = ConfigurationManager.AppSettings["TimeOutPageReady"];
            _timeOutAjax = ConfigurationManager.AppSettings["TimeOutAjax"];
        }

        private static IWebDriver StartWebDriver()
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
            return _webDriver;
        }

        private static InternetExplorerDriver StartInternetEplorer()
        {
            var internetExplorerOptions = new InternetExplorerOptions
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                InitialBrowserUrl = "about:blank",
                EnableNativeEvents = true
            };

            return new InternetExplorerDriver(Directory.GetCurrentDirectory() + "/External", internetExplorerOptions);
        }

        private static FirefoxDriver StartFirefox()
        {
            var firefoxProfile = new FirefoxProfile
            {
                AcceptUntrustedCertificates = true,
                EnableNativeEvents = true
            };

            return new FirefoxDriver(firefoxProfile);
        }

        private static ChromeDriver StartChrome()
        {
            return new ChromeDriver(Directory.GetCurrentDirectory() + "/External");
        }

        /// <summary>Waits until the condition occurs.</summary>
        /// <remarks>Used by other wait methods.</remarks>
        /// <param name="condition">The condition to wait for.</param>
        /// <param name="timeout">The time in seconds to wait.</param>
        private static void WaitUntilExpected(Func<IWebDriver, bool> condition, long timeout)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeout));
            wait.Until(condition);
        }

        #endregion

        #region Public Properties

        public static BrowserType SelectedBrowser
        {
            get { return Settings.DefaultBrowser; }
        }

        public static Uri Url
        {
            get
            {
                WaitAjax();
                return new Uri(WebDriver.Url);
            }
        }

        public static string Title
        {
            get
            {
                WaitAjax();
                return string.Format("{0}", WebDriver.Title);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Initializes the WebDriver.
        /// </summary>
        public static void Start()
        {
            _webDriver = StartWebDriver();
        }

        /// <summary>
        /// Navigates to the <see cref="url"/>.
        /// </summary>
        /// <param name="url">Target Uri.</param>
        public static void Navigate(Uri url)
        {
            if (url != null)
            {
                WebDriver.Navigate().GoToUrl(url);
            }
        }

        /// <summary>
        /// Quits and sets WebDriver to null.
        /// </summary>
        public static void Quit()
        {
            if (WebDriver == null) return;

            _webDriver.Quit();
            _webDriver = null;
        }

        /// <summary>
        /// Waits until the page is loaded.
        /// </summary>
        /// <seealso cref="WaitReadyState(int)"/>
        public static void WaitReadyState()
        {
            WaitReadyState(int.Parse(_timeOutPageReady));
        }


        /// <summary>
        /// Waits until the page is loaded.
        /// </summary>
        /// <param name="timeout">The time in seconds to wait.</param>
        /// <seealso cref="WaitReadyState()"/>
        public static void WaitReadyState(int timeout)
        {
            Func<IWebDriver, bool> condition = driver =>
                                                     (((IJavaScriptExecutor) driver).ExecuteScript("return document.readyState;"))
                                                     .ToString().Equals("complete");
            WaitUntilExpected(condition, timeout);
        }

        /// <summary>
        /// Waits until Ajax is loaded.
        /// </summary>
        public static void WaitAjax()
        {
            var sw = new Stopwatch();
            sw.Start();
            try
            {
                while (sw.Elapsed.TotalSeconds < int.Parse(_timeOutAjax))
                {
                    var ajaxIsComplete =
                        (bool)
                            ((IJavaScriptExecutor) _webDriver).ExecuteScript(
                                "return window.jQuery != undefined && jQuery.active==0");
                    if (ajaxIsComplete)
                        break;
                    Thread.Sleep(100);
                }
            }
            catch (Exception)
            {
                throw new Exception(String.Format("Ajax call time out time {0} has passed ",
                    ConfigurationManager.AppSettings["TimeOutAjax"]));
            }
            finally
            {
                sw.Stop();
            }
        }

        /// <summary>
        /// Switch to the Frame.
        /// </summary>
        /// <param name="inlineFrame">Target Frame.</param>
        public static void SwitchToFrame(IWebElement inlineFrame)
        {
            WebDriver.SwitchTo().Frame(inlineFrame);
        }

        /// <summary>
        /// Switch to the Default Content.
        /// </summary>
        public static void SwitchToDefaultContent()
        {
            WebDriver.SwitchTo().DefaultContent();
        }

        /// <summary>
        /// Find elements by selector.
        /// </summary>
        /// <param name="selector">By selector.</param>
        /// <returns>The IEnumerable of <see cref="IWebElement"/>.</returns>
        public static IEnumerable<IWebElement> FindElements(By selector)
        {
            return WebDriver.FindElements(selector);
        }

        /// <summary>
        /// Gets screenshot.
        /// </summary>
        /// <returns></returns>
        public static Screenshot GetScreenshot()
        {
            WaitReadyState();

            return ((ITakesScreenshot)WebDriver).GetScreenshot();
        }

        /// <summary>
        /// Saves screenshot in the specific <see cref="path"/>.
        /// </summary>
        /// <param name="path">The specific path for saving screenshot.</param>
        public static void SaveScreenshot(string path)
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
        public static void ResizeWindow(int width, int height)
        {
            ExecuteJavaScript(string.Format("window.resizeTo({0}, {1});", width, height));
        }

        /// <summary>
        /// Navigates back in browser/
        /// </summary>
        public static void NavigateBack()
        {
            WebDriver.Navigate().Back();
        }

        /// <summary>
        /// Refresh current page.
        /// </summary>
        public static void Refresh()
        {
            WebDriver.Navigate().Refresh();
        }

        /// <summary>
        /// Executes JavaScript code. 
        /// </summary>
        /// <param name="javaScript">The JavaScript code.</param>
        /// <param name="args">The specific arguments.</param>
        /// <returns>The object/</returns>
        public static object ExecuteJavaScript(string javaScript, params object[] args)
        {
            var javaScriptExecutor = (IJavaScriptExecutor)WebDriver;

            return javaScriptExecutor.ExecuteScript(javaScript, args);
        }

        #endregion
    }
}
