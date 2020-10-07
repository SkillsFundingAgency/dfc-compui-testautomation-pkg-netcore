// <copyright file="BrowserSettings.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// </copyright>

using System;

namespace DFC.TestAutomation.UI.Settings
{
    /// <summary>
    /// A model used to parse browser settings from the application settings.
    /// </summary>
    public class BrowserSettings
    {
        /// <summary>
        /// Gets or sets the browser name.
        /// </summary>
        public string BrowserName { get; set; }

        /// <summary>
        /// Gets or sets the browser version.
        /// </summary>
        public string BrowserVersion { get; set; }

        /// <summary>
        /// Gets or sets the browser arguments.
        /// </summary>
        public BrowserArguments BrowserArguments { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use a proxy.
        /// </summary>
        public bool UseProxy { get; set; }

        /// <summary>
        /// Gets or sets the proxy url.
        /// </summary>
        public Uri Proxy { get; set; }
    }
}
