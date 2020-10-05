// <copyright file="EnvironmentSettings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DFC.TestAutomation.UI.Settings
{
    /// <summary>
    /// A model used to parse environment settings from the application settings.
    /// </summary>
    public class EnvironmentSettings
    {
        /// <summary>
        /// Gets or sets the environment name.
        /// </summary>
        public string EnvironmentName { get;  set; }

        /// <summary>
        /// Gets or sets the operating system.
        /// </summary>
        public string OperatingSystem { get;  set; }

        /// <summary>
        /// Gets or sets the operating system version.
        /// </summary>
        public string OperatingSystemVersion { get;  set; }

        /// <summary>
        /// Gets or sets the screen resolution.
        /// </summary>
        public string ScreenResolution { get;  set; }
    }
}
