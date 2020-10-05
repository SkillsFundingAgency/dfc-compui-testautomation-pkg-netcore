// <copyright file="ISettingsLibrary.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DFC.TestAutomation.UI.Settings
{
    /// <summary>
    /// An interface containing all definitions for application settings.
    /// </summary>
    /// <typeparam name="T">The application settings type. This must be an interface member of IAppSettings.</typeparam>
    public interface ISettingsLibrary<T>
    {
        /// <summary>
        /// Gets the application specific settings.
        /// </summary>
        public T AppSettings { get; }

        /// <summary>
        /// Gets the browser settings.
        /// </summary>
        public BrowserSettings BrowserSettings { get; }

        /// <summary>
        /// Gets the BrowserStack settings.
        /// </summary>
        public BrowserStackSettings BrowserStackSettings { get; }

        /// <summary>
        /// Gets the build settings.
        /// </summary>
        public BuildSettings BuildSettings { get; }

        /// <summary>
        /// Gets the environment settings.
        /// </summary>
        public EnvironmentSettings EnvironmentSettings { get; }

        /// <summary>
        /// Gets the Mongo database settings.
        /// </summary>
        public MongoDatabaseSettings MongoDatabaseSettings { get; }

        /// <summary>
        /// Gets the timeout settings.
        /// </summary>
        public TimeoutSettings TimeoutSettings { get; }
    }
}
