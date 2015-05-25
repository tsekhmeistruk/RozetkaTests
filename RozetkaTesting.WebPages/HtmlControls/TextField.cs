using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace RozetkaTesting.WebPages.HtmlControls
{
    class TextField: BaseControl
    {
        #region Constructors

        public TextField(By controlDescription)
            : base(controlDescription)
        {
        }

        public TextField(IWebElement webElement)
            : base(webElement)
        {
        } 

        #endregion
    }
}
