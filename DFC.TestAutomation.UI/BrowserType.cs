// <copyright file="BrowserType.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace DFC.TestAutomation.UI
{
    /// <summary>
    /// Defines the type of browser.
    /// </summary>
    public enum BrowserType
    {
        /// <summary>
        /// Google Chrome browser.
        /// </summary>
        Chrome,

        /// <summary>
        /// Mozilla Firefox browser.
        /// </summary>
        Firefox,

        /// <summary>
        /// Microsoft Internet Explorer.
        /// </summary>
        InternetExplorer,

        /// <summary>
        /// BrowserStack (in the cloud).
        /// </summary>
        BrowserStack,
    }
}