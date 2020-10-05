// <copyright file="IAppSettings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DFC.TestAutomation.UI.Settings
{
    /// <summary>
    /// An interface containing definitions for app specific settings.
    /// </summary>
    public interface IAppSettings
    {
        /// <summary>
        /// The name of the application being tested.
        /// </summary>
        public string AppName { get; set; }
    }
}
