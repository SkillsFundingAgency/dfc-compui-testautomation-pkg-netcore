﻿// <copyright file="SettingsLibrary.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.Extensions.Configuration;
using System.IO;

namespace DFC.TestAutomation.UI.Settings
{
    /// <summary>
    /// A container for all application settings.
    /// </summary>
    /// <typeparam name="T">The application settings type. This must be an interface member of IAppSettings.</typeparam>
    public class SettingsLibrary<T> : ISettingsLibrary<T>
        where T : IAppSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsLibrary{T}"/> class.
        /// </summary>
        public SettingsLibrary()
        {
            var configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            configurationBuilder.AddEnvironmentVariables();
            var configurationRoot = configurationBuilder.Build();
            this.AppSettings = configurationRoot.GetSection("AppSettings").Get<T>();
            this.BrowserSettings = configurationRoot.GetSection("BrowserSettings").Get<BrowserSettings>();
            this.BrowserStackSettings = configurationRoot.GetSection("BrowserStackSettings").Get<BrowserStackSettings>();
            this.BuildSettings = configurationRoot.GetSection("BuildSettings").Get<BuildSettings>();
            this.EnvironmentSettings = configurationRoot.GetSection("EnvironmentSettings").Get<EnvironmentSettings>();
            this.TestExecutionSettings = configurationRoot.GetSection("TestExecutionSettings").Get<TestExecutionSettings>();
        }

        /// <summary>
        /// Gets the app specific settings.
        /// </summary>
        public T AppSettings { get; private set; }

        /// <summary>
        /// Gets the browser settings.
        /// </summary>
        public BrowserSettings BrowserSettings { get; private set; }

        /// <summary>
        /// Gets the BrowserStack settings.
        /// </summary>
        public BrowserStackSettings BrowserStackSettings { get; private set; }

        /// <summary>
        /// Gets the build settings.
        /// </summary>
        public BuildSettings BuildSettings { get; private set; }

        /// <summary>
        /// Gets the environments settings.
        /// </summary>
        public EnvironmentSettings EnvironmentSettings { get; private set; }

        /// <summary>
        /// Gets the test execution settings.
        /// </summary>
        public TestExecutionSettings TestExecutionSettings { get; private set; }
    }
}
