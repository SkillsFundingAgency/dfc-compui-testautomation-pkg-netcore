// <copyright file="ISettingsLibrary.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using DFC.TestAutomation.UI.Settings;

namespace DFC.TestAutomation.UI.TestSupport
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
