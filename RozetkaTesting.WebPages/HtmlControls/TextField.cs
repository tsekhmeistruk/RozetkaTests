using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace RozetkaTesting.WebPages.HtmlControls
{
    /// <summary>
    /// 
    /// </summary>
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

        /// <summary>
        /// Gets text field by locator.
        /// </summary>
        /// <param name="locator">TextField locator.</param>
        /// <returns>TextField control.</returns>
        public static TextField ByLocator(By locator)
        {
            return new TextField(locator);
        }

        /// <summary>
        /// Gets TextField by Id.
        /// </summary>
        /// <param name="id">The Id of TextField.</param>
        /// <returns>TextField control.</returns>
        public static TextField ById(string id)
        {
            return new TextField(By.XPath(String.Format("//input[@id='{0}']", id)));
        }

        /// <summary>
        /// Gets text value.
        /// </summary>
        public string GetValue()
        {
            return GetWebElement().GetAttribute("value");
        }

        /// <summary>
        /// Clears TextField and type specific value.
        /// </summary>
        /// <param name="value">The text for typing.</param>
        public void ClearAndType(string value)
        {
            IWebElement textFieldElement = GetWebElement();
            textFieldElement.Clear();
            textFieldElement.SendKeys(value);
        }
    }
}
