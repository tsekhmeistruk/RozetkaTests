using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace RozetkaTesting.WebPages.HtmlControls
{
    class HtmlControl: BaseControl
    {
        #region Constructors

        public HtmlControl(By controlDescription) : base(controlDescription)
        {
        }

        public HtmlControl(IWebElement webElement) : base(webElement)
        {
        }

        #endregion
    }
}
