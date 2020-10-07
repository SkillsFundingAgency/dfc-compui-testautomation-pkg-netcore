// <copyright file="BrowserArguments.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// </copyright>

namespace DFC.TestAutomation.UI.Settings
{
    /// <summary>
    /// A model used to parse browser arguments from the application settings.
    /// </summary>
    public class BrowserArguments
    {
        /// <summary>
        /// Gets or sets a value indicating whether the browser is in sandbox mode.
        /// </summary>
        public bool InSandbox { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the browser is in headless mode.
        /// </summary>
        public bool InHeadless { get; set; }
    }
}