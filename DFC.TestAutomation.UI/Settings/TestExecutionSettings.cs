// <copyright file="TestExecutionSettings.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace DFC.TestAutomation.UI.Settings
{
    /// <summary>
    /// A model used to parse test execution specific settings from the application settings.
    /// </summary>
    public class TestExecutionSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether to take screenshots.
        /// </summary>
        public bool TakeScreenshots { get; set; }

        /// <summary>
        /// Gets or sets the timeout settings.
        /// </summary>
        public TimeoutSettings TimeoutSettings { get; set; }
    }
}
