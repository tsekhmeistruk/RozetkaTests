using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace RozetkaTesting.WebPages.HtmlControls
{
    class Label: BaseControl
    {
        #region Constructors

        public Label(By controlDescription) : base(controlDescription)
        {
        }

        public Label(IWebElement webElement) : base(webElement)
        {
        }

        #endregion
    }
}
