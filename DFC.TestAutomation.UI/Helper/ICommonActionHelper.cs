// <copyright file="ICommonActionHelper.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// An interface containing definitions for all axe (web accessibility testing) related operations.
    /// </summary>
    public interface ICommonActionHelper
    {
        /// <summary>
        /// Assesses whether the IWebElement contains expected text. The comparison is case insensitive and the expected text parameter
        /// is trimmed before being compared.
        /// </summary>
        /// <param name="locator">The IWebElement locator.</param>
        /// <param name="expectedText">The expected text.</param>
        /// <returns>True if the IWebElement contains the expected text. False if the IWebElement does not contain the expected text.</returns>
        bool ElementContainsText(By locator, string expectedText);

        /// <summary>
        /// Gets the attribute value for an IWebElement.
        /// </summary>
        /// <param name="locator">The IWebElement locator.</param>
        /// <param name="attributeName">The attribute name.</param>
        /// <returns>The atrribute value.</returns>
        string GetAttributeValue(By locator, string attributeName);

        /// <summary>
        /// Gets the text value from all IWebElements with a given locator.
        /// </summary>
        /// <param name="locator">The IWebELement locator.</param>
        /// <returns>The string value.</returns>
        string GetTextFromElements(By locator);

        /// <summary>
        /// Gets the count of the IWebElement collection returned when locating all IWebElements with the given locator.
        /// </summary>
        /// <param name="locator">The IWebElement locator.</param>
        /// <returns>An integer indicating how many IWebElements are located using the locator.</returns>
        int GetCountOfElements(By locator);

        /// <summary>
        /// Assesses whether an IWebElement is present.
        /// </summary>
        /// <param name="locator">The IWebElement locator.</param>
        /// <returns>A value indicating whether the IwebElement is present.</returns>
        bool IsElementPresent(By locator);

        /// <summary>
        /// Assesses whether an IWebElement is displayed.
        /// </summary>
        /// <param name="locator">The IWebElement locator.</param>
        /// <returns>A value indicating whether an IWebElement is displayed.</returns>
        bool IsElementDisplayed(By locator);

        /// <summary>
        /// Sets the focus on an IwebElement.
        /// </summary>
        /// <param name="locator">The IWebElement locator.</param>
        void SetElementFocus(By locator);

        /// <summary>
        /// Switches to an iframe.
        /// </summary>
        /// <param name="locator">The iframe locator.</param>
        void SwitchToFrame(By locator);

        /// <summary>
        /// Gets the text value from an IWebElement.
        /// </summary>
        /// <param name="locator">The IWebElement locator.</param>
        /// <returns>The text value from the IwebElement.</returns>
        string GetText(By locator);

        /// <summary>
        /// Gets the text value from an IWebElement.
        /// </summary>
        /// <param name="webElement">The IWebElement.</param>
        /// <returns>The text value from the IwebElement.</returns>
        string GetText(IWebElement webElement);

        /// <summary>
        /// Gets the current browsers url.
        /// </summary>
        /// <returns>The current url.</returns>
        Uri GetUrl();

        /// <summary>
        /// Gets all select options for a select IWebElement.
        /// </summary>
        /// <param name="locator">The IWebElement locator.</param>
        /// <returns>All select options.</returns>
        IList<IWebElement> GetAllSelectOptions(By locator);
    }
}
