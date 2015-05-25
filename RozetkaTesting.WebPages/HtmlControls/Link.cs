using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace RozetkaTesting.WebPages.HtmlControls
{
    class Link: BaseControl
    {
        #region Constructors

        public Link(By controlDescription) : base(controlDescription)
        {
        }

        public Link(IWebElement webElement) : base(webElement)
        {
        }

        #endregion
    }
}
