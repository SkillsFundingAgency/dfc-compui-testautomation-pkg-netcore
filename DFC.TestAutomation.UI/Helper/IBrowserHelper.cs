// <copyright file="IBrowserHelper.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// An interface containing definitions for for all web browser related operations.
    /// </summary>
    public interface IBrowserHelper
    {
        /// <summary>
        /// Gets a BrowserType.
        /// </summary>
        /// <returns>A BrowserType based on the browser name.</returns>
        BrowserType GetBrowserType();

        /// <summary>
        /// Assesses whether the current test execution is hosted in BrowserStack.
        /// </summary>
        /// <returns>True in the case where the current test execution is hosted in BrowserStack. False if the current execution is not hosted in BrowserStack.</returns>
        bool IsExecutingInBrowserStack();
    }
}
