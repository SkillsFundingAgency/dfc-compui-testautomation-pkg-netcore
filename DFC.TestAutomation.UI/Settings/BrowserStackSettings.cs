// <copyright file="BrowserStackSettings.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;

namespace DFC.TestAutomation.UI.Settings
{
    /// <summary>
    /// A model used to parse BrowserStack settings from the application settings.
    /// </summary>
    public class BrowserStackSettings
    {
        /// <summary>
        /// Gets or sets the BrowserStack username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the BrowserStack access key.
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// Gets or sets the BrowserStack remote address url.
        /// </summary>
        public Uri WebdriverRemoteServerUrl { get; set; }

        /// <summary>
        /// Gets or sets the remote browser version.
        /// </summary>
        public string BrowserVersion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether BrowserStack should log network activity.
        /// </summary>
        public bool EnableNetworkLogs { get; set; }
    }
}
