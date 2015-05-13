using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using RozetkaTesting.Framework.Enums;

namespace RozetkaTesting.Framework.SeleniumApiWrapper
{
    public static class Browser
    {
        #region Private Fields and Properties

        private static IWebDriver _webDriver;

        private static IWebDriver WebDriver
        {
            get { return _webDriver ?? StartWebDriver(); }
        }

        #endregion

        #region Private Methods

        private static IWebDriver StartWebDriver()
        {
            if (_webDriver != null)
            {
                return _webDriver;
            }

            switch (SelectedBrowser)
            {
                case Browsers.Chrome:
                    _webDriver = StartChrome();
                    break;

                case Browsers.Firefox:
                    _webDriver = StartFirefox();
                    break;

                case Browsers.InternetExplorer:
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

            return new InternetExplorerDriver(Directory.GetCurrentDirectory(), internetExplorerOptions);
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
            return new ChromeDriver(Directory.GetCurrentDirectory());
        }

        #endregion

        #region Public Methods

        public static Browsers SelectedBrowser
        {
            //TODO: Can be refactored and than the type of browser will be fetched from settings 
            //Something like this: return Settings.Default.Browser; 
            get { return Browsers.Firefox; }
        }

        public static void Start()
        {
            _webDriver = StartWebDriver();
        }

        public static void Navigate()
        {
            
        }

        #endregion
    }
}
