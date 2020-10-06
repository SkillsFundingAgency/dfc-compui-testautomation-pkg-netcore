// <copyright file="IWebDriverSupport.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using OpenQA.Selenium;

namespace DFC.TestAutomation.UI.TestSupport
{
    /// <summary>
    /// An interface containing definitions for for all Selenium webdriver related operations.
    /// </summary>
    public interface IWebDriverSupport
    {
        /// <summary>
        /// Creates an instance of the Selenium webdriver.
        /// </summary>
        /// <returns>The Selenium webdriver.</returns>
        IWebDriver Create();
    }
}
