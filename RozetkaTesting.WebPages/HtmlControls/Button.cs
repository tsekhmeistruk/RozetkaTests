using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace RozetkaTesting.WebPages.HtmlControls
{
    class Button: BaseControl
    {
        #region Constructors

        public Button(By controlDescription) : base(controlDescription)
        {
        }

        public Button(IWebElement webElement) : base(webElement)
        {
        }

        #endregion
    }
}
