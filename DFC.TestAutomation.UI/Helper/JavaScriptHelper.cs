// <copyright file="JavaScriptHelper.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using OpenQA.Selenium;
using System.Linq;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// Provides helper functions for operations that require javascript injection.
    /// </summary>
    public class JavaScriptHelper : IJavaScriptHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JavaScriptHelper"/> class.
        /// </summary>
        /// <param name="webDriver">The Selenium Webdriver.</param>
        public JavaScriptHelper(IWebDriver webDriver)
        {
            this.WebDriver = webDriver;
        }

        private IWebDriver WebDriver { get; set; }

        /// <summary>
        /// Determines whether the current page is reporting as ready. Ready means that the document and all sub-resources have finished loading.
        /// </summary>
        /// <returns>True if the page is ready. False if the page is not ready.</returns>
        public bool IsDocumentReady()
        {
            return this.ExecuteScript("return document.readyState").Equals("complete");
        }

        /// <summary>
        /// Gets the parent element of an IWebElement.
        /// </summary>
        /// <param name="childElement">The IWebElement.</param>
        /// <returns>The parent of the IWebElement.</returns>
        public IWebElement GetParentElement(IWebElement childElement)
        {
            return this.ExecuteScript("return arguments[0].parentNode;", childElement) as IWebElement;
        }

        /// <summary>
        /// Clicks an IWebElement.
        /// </summary>
        /// <param name="locator">The locator of the IWebElement.</param>
        public void ClickElement(By locator)
        {
            var webElement = this.WebDriver.FindElement(locator);
            this.ExecuteScript("arguments[0].click();", webElement);
        }

        /// <summary>
        /// Scrolls an IWebElement into view. The horizontal alignment is set to center meaning that the IWebElement should be horizontally centered once the page has finished scrolling.
        /// </summary>
        /// <param name="webElement">The IWebElement.</param>
        public void ScrollElementIntoView(IWebElement webElement)
        {
            this.ExecuteScript("arguments[0].scrollIntoView({ inline: 'center' });", webElement);
        }

        /// <summary>
        /// Executes javascript using IWebElements as arguments.
        /// </summary>
        /// <param name="javascript">The javascript to be executed. To reference the IWebElement use 'arguments[{index}]' where {index} is the zero based index of your IWebElements.</param>
        /// <param name="webElements">The IWebElement arguments.</param>
        /// <returns>An object, the type of which is determined by the script.</returns>
        public object ExecuteScript(string javascript, params IWebElement[] webElements)
        {
            object[] arguements = webElements?.OfType<object>().ToArray();
            return ((IJavaScriptExecutor)this.WebDriver).ExecuteScript(javascript, arguements);
        }

        /// <summary>
        /// Executes javascript using IWebElement locators as an arguments.
        /// </summary>
        /// <param name="javascript">The javascript to be executed. To reference the IWebElement found using your locator use 'arguments[{index}]' where {index} is the zero based index of your locator.</param>
        /// <param name="locators">The locator arguments.</param>
        /// <returns>An object, the type of which is determined by the script.</returns>
        public object ExecuteScript(string javascript, params By[] locators)
        {
            IWebElement[] webElementArray = new IWebElement[locators.Length];

            for (var index = 0; index < locators.Length; index++)
            {
                webElementArray[index] = this.WebDriver.FindElement(locators[index]);
            }

            return this.ExecuteScript(javascript, webElementArray);
        }

        /// <summary>
        /// Executes javascript without any arguments.
        /// </summary>
        /// <param name="javascript">The javascript to be executed.</param>
        /// <returns>An object, the type of which is determined by the script.</returns>
        public object ExecuteScript(string javascript)
        {
            return ((IJavaScriptExecutor)this.WebDriver).ExecuteScript(javascript);
        }
    }
}
