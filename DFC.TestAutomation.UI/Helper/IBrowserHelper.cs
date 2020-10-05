// <copyright file="IBrowserHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
        /// Assesses whether the current test execution is cloud based.
        /// </summary>
        /// <returns>True in the case where the current test execution is cloud based. False if the current execution is not cloud based.</returns>
        bool IsExecutingInTheCloud();
    }
}
