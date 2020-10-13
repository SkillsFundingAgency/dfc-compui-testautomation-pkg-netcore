// <copyright file="IBrowserStackHelper.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using OpenQA.Selenium;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// An interface containing definitions for for all BrowserStack related operations.
    /// </summary>
    public interface IBrowserStackHelper
    {
        /// <summary>
        /// Creates an instance of the Selenium remote webdriver.
        /// </summary>
        /// <returns>The Selenium remote webdriver.</returns>
        IWebDriver CreateRemoteWebDriver();
    }
}
