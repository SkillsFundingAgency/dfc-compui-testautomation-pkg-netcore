// <copyright file="TimeoutSettings.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace DFC.TestAutomation.UI.Settings
{
    /// <summary>
    /// A model used to parse timeout settings from the application settings.
    /// </summary>
    public class TimeoutSettings
    {
        /// <summary>
        /// Gets or sets the page navigation timeout in seconds.
        /// </summary>
        public int PageNavigation { get; set; }

        /// <summary>
        /// Gets or sets the implicit timeout in seconds.
        /// </summary>
        public int ImplicitWait { get; set; }
    }
}
