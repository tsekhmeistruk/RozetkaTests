using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace RozetkaTesting.Integrations
{
    public interface IDriver
    {
        //TODO Add comments
        BrowserType SelectedBrowser { get; }
        Uri Url { get; }
        string Title { get; }

        void Start();
        void Navigate(Uri url);
        void Quit();
        void SwitchToFrame(IWebElement inlineFrame);
        void SwitchToDefaultContent();
        Screenshot GetScreenshot();
        void SaveScreenshot(string path);
        void ResizeWindow(int width, int height);
        void NavigateBack();
        void Refresh();
        object ExecuteJavaScript(string javaScript, params object[] args);
        IWebElement FindElement(By @by);
        ReadOnlyCollection<IWebElement> FindElements(By @by);
    }
}
