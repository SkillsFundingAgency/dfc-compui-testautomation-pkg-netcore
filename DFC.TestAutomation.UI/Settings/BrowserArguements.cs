// <copyright file="BrowserArguements.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DFC.TestAutomation.UI.Settings
{
    /// <summary>
    /// A model used to parse browser arguements from the application settings.
    /// </summary>
    public class BrowserArguements
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
