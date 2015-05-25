using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace RozetkaTesting.WebPages.HtmlControls
{
    class CheckBox: BaseControl
    {
        #region Constructors

        public CheckBox(By controlDescription) : base(controlDescription)
        {
        }

        public CheckBox(IWebElement webElement) : base(webElement)
        {
        }

        #endregion
    }
}
