// <copyright file="ISettingsLibrary.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DFC.TestAutomation.UI.Settings
{
    public interface ISettingsLibrary<T>
    {
        public T AppSettings { get; }

        public BrowserSettings BrowserSettings { get; }

        public BrowserStackSettings BrowserStackSettings { get; }

        public BuildSettings BuildSettings { get; }

        public EnvironmentSettings EnvironmentSettings { get; }

        public MongoDatabaseSettings MongoDatabaseSettings { get; }

        public TimeoutSettings TimeoutSettings { get; }
    }
}
