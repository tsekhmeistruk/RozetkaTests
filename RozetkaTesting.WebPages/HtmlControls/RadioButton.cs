using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace RozetkaTesting.WebPages.HtmlControls
{
    class RadioButton: BaseControl
    {
        #region Constructors

        public RadioButton(By controlDescription)
            : base(controlDescription)
        {
        }

        public RadioButton(IWebElement webElement)
            : base(webElement)
        {
        } 

        #endregion
    }
}
