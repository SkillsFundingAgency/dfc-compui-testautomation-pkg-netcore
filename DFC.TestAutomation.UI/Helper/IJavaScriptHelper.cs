// <copyright file="IJavaScriptHelper.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// </copyright>

using OpenQA.Selenium;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// An interface containing definitions for all operations that require javascript.
    /// </summary>
    public interface IJavaScriptHelper
    {
        /// <summary>
        /// Determines whether the current page is reporting as ready. Ready means that the document and all sub-resources have finished loading.
        /// </summary>
        /// <returns>True if the page is ready. False if the page is not ready.</returns>
        bool IsDocumentReady();

        /// <summary>
        /// Gets the parent element of an IWebElement.
        /// </summary>
        /// <param name="childElement">The IWebElement.</param>
        /// <returns>The parent of the IWebElement.</returns>
        IWebElement GetParentElement(IWebElement childElement);

        /// <summary>
        /// Clicks an IWebElement.
        /// </summary>
        /// <param name="locator">The locator of the IWebElement.</param>
        void ClickElement(By locator);

        /// <summary>
        /// Scrolls an IWebElement into view. The horizontal alignment is set to center meaning that the IWebElement should be horizontally centered once the page has finished scrolling.
        /// </summary>
        /// <param name="webElement">The IWebElement.</param>
        void ScrollElementIntoView(IWebElement webElement);

        /// <summary>
        /// Executes javascript using IWebElements as arguments.
        /// </summary>
        /// <param name="javascript">The javascript to be executed. To reference the IWebElement use 'arguments[{index}]' where {index} is the zero based index of your IWebElements.</param>
        /// <param name="webElements">The IWebElement arguments.</param>
        /// <returns>An object, the type of which is determined by the script.</returns>
        object ExecuteScript(string javascript, params IWebElement[] webElements);

        /// <summary>
        /// Executes javascript using IWebElement locators as an arguments.
        /// </summary>
        /// <param name="javascript">The javascript to be executed. To reference the IWebElement found using your locator use 'arguments[{index}]' where {index} is the zero based index of your locator.</param>
        /// <param name="locators">The locator arguments.</param>
        /// <returns>An object, the type of which is determined by the script.</returns>
        object ExecuteScript(string javascript, params By[] locators);

        /// <summary>
        /// Executes javascript without any arguments.
        /// </summary>
        /// <param name="javascript">The javascript to be executed.</param>
        /// <returns>An object, the type of which is determined by the script.</returns>
        object ExecuteScript(string javascript);
    }
}
