// <copyright file="ICommonActionHelper.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
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
        /// Gets a hyperlink IWebElement with a specific text value.
        /// </summary>
        /// <param name="locator">The IWebElement locator.</param>
        /// <param name="linkText">The hyperlink text.</param>
        /// <returns>The hyperlink IWebElement with a text value equal to the link text.</returns>
        IWebElement GetLinkByText(By locator, string linkText);

        /// <summary>
        /// Gets a hyperlink IWebElement containing a specific text value.
        /// </summary>
        /// <param name="locator">The IWebElement locator.</param>
        /// <param name="linkText">The hyperlink text.</param>
        /// <returns>The hyperlink IWebElement with a text value containing the link text.</returns>
        IWebElement GetLinkContainingText(By locator, string linkText);

        /// <summary>
        /// Gets a table row IWebElement containing a cell with specific text.
        /// </summary>
        /// <param name="tableIdentifier">The table IWebElement locator.</param>
        /// <param name="cellText">The cell text.</param>
        /// <returns>The table row IWebElement.</returns>
        string GetTableRowContainingCellWithText(By tableIdentifier, string cellText);

        /// <summary>
        /// Gets all table row IWebElements.
        /// </summary>
        /// <param name="tableIdentifier">The table IWebelement locator.</param>
        /// <returns>All table row IWebElements.</returns>
        List<IWebElement> GetAllTableRows(By tableIdentifier);

        /// <summary>
        /// Gets all select options for a select IWebElement.
        /// </summary>
        /// <param name="locator">The IWebElement locator.</param>
        /// <returns>All select options.</returns>
        List<string> GetAllSelectOptions(By locator);
    }
}
