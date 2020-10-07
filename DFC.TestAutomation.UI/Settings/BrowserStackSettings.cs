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
        public string BrowserStackUsername { get; set; }

        /// <summary>
        /// Gets or sets the BrowserStack password.
        /// </summary>
        public string BrowserStackPassword { get; set; }

        /// <summary>
        /// Gets or sets the BrowserStack remote address url.
        /// </summary>
        public Uri RemoteAddressUri { get; set; }

        /// <summary>
        /// Gets or sets the BrowserStack base url.
        /// </summary>
        public Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether BrowserStack should log network activity.
        /// </summary>
        public bool EnableNetworkLogs { get; set; }

        /// <summary>
        /// Gets or sets the BrowserStack timezone.
        /// </summary>
        public string Timezone { get; set; }

        /// <summary>
        /// Gets or sets the name used by BrowserStack when referencing the test run.
        /// </summary>
        public string Name { get; set; }
    }
}
