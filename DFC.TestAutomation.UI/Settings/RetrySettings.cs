// <copyright file="RetrySettings.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace DFC.TestAutomation.UI.Settings
{
    /// <summary>
    /// A model used to parse retry settings from the application settings.
    /// </summary>
    public class RetrySettings
    {
        /// <summary>
        /// Gets or sets the number of retires before throwing an exception.
        /// </summary>
        public int NumberOfRetries { get; set; }

        /// <summary>
        /// Gets or sets the explicit wait between retry attempts.
        /// </summary>
        public int ExplicitWaitInSeconds { get; set; }
    }
}
