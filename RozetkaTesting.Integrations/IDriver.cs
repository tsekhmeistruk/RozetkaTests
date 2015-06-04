using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace RozetkaTesting.Integrations
{
    public interface IDriver
    {
        /// <summary>
        /// Gets the Type of selected browser.
        /// </summary>
        BrowserType SelectedBrowser { get; }

        /// <summary>
        /// Gets current URL.
        /// </summary>
        Uri Url { get; }

        /// <summary>
        /// Gets current Title. 
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Starts Driver.
        /// </summary>
        void Start();

        /// <summary>
        /// Navigates to the specific URL.
        /// </summary>
        /// <param name="url">Specific URL.</param>
        void Navigate(Uri url);

        /// <summary>
        /// Quits and sets WebDriver to null.
        /// </summary>
        void Quit();

        /// <summary>
        /// Switch to the Frame.
        /// </summary>
        /// <param name="inlineFrame">Target Frame.</param>
        void SwitchToFrame(IWebElement inlineFrame);

        /// <summary>
        /// Switch to the Default Content.
        /// </summary>
        void SwitchToDefaultContent();

        /// <summary>
        /// Gets screenshot.
        /// </summary>
        /// <returns>The Screenshot.</returns>
        Screenshot GetScreenshot();

        /// <summary>
        /// Saves screenshot in the specific <see cref="path" />.
        /// </summary>
        /// <param name="path">The specific path for saving screenshot.</param>
        void SaveScreenshot(string path);

        /// <summary>
        /// Resizes window.
        /// </summary>
        /// <param name="width">Width of window.</param>
        /// <param name="height">Height of window.</param>
        void ResizeWindow(int width, int height);

        /// <summary>
        /// Navigates back in a browser.
        /// </summary>
        void NavigateBack();

        /// <summary>
        /// Refresh current page.
        /// </summary>
        void Refresh();

        /// <summary>
        /// Executes JavaScript code.
        /// </summary>
        /// <param name="javaScript">The JavaScript code.</param>
        /// <param name="args">The specific arguments.</param>
        /// <returns>The object.</returns>
        object ExecuteJavaScript(string javaScript, params object[] args);

        /// <summary>
        /// Finds the web element.
        /// </summary>
        /// <param name="by">The specific locator.</param>
        /// <returns>The <see cref="IWebElement" /> object.</returns>
        IWebElement FindElement(By @by);

        /// <summary>
        /// Finds the web elements.
        /// </summary>
        /// <param name="by">The specific locator.</param>
        /// <returns>The collection of <see cref="IWebElement" /> objects.</returns>
        ReadOnlyCollection<IWebElement> FindElements(By @by);
    }
}
