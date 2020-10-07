// <copyright file="IWebDriverWaitHelper.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using OpenQA.Selenium;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// Provides helper functions for all operations that require an implicit wait.
    /// </summary>
    public interface IWebDriverWaitHelper
    {
        /// <summary>
        /// Waits for an IWebElement to be present on the current page.
        /// </summary>
        /// <param name="locator">The IWebElements locator.</param>
        void WaitForElementToBePresent(By locator);

        /// <summary>
        /// Waits for an iframe to be vaialable and when available, the Selenium webdriver switches focus to it.
        /// </summary>
        /// <param name="locator">The iframes locator.</param>
        void WaitForFrameToBeAvailableAndSwitchToIt(By locator);

        /// <summary>
        /// Waits for an IWebElement to be present and contain specific text on the current page.
        /// </summary>
        /// <param name="locator">The IWebElements locator.</param>
        /// <param name="text">The expected text. This is case sensitive. The value is not trimmed before being asserted on.</param>
        void WaitForElementToContainText(By locator, string text);

        /// <summary>
        /// Waits for an IWebElement to be present and displayed on the current page.
        /// </summary>
        /// <param name="locator">The IWebElements locator.</param>
        void WaitForElementToBeDisplayed(By locator);

        /// <summary>
        /// Waits for an IWebElement to be clickable. Clickable means the IWebElement is present and enabled.
        /// </summary>
        /// <param name="locator">The IWebElements locator.</param>
        void WaitForElementToBeClickable(By locator);

        /// <summary>
        /// Waits for the page DOM to report as ready. Ready means that the document and all sub-resources have finished loading.
        /// </summary>
        void WaitForPageToLoad();

        /// <summary>
        /// Sets the implicit wait timeout. This should be used only in cases where you wish to override the configured implicit wait.
        /// It is recommended that the reset method is called once the time sensitive operation is complete so that the implicit
        /// wait is set back to its original setting.
        /// </summary>
        /// <param name="milliseconds">Implicit wait in milliseconds.</param>
        void SetImplicitWait(int milliseconds);

        /// <summary>
        /// Resets the implicit wait timeout. This is a helpful function for when the implicit wait has been altered for a particular
        /// operation. The reset sets the implicit wait back to its cofigured setting.
        /// </summary>
        void ResetImplicitWait();
    }
}
