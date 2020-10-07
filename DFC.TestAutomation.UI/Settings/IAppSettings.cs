// <copyright file="IAppSettings.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;

namespace DFC.TestAutomation.UI.Settings
{
    /// <summary>
    /// An interface containing definitions for app specific settings.
    /// </summary>
    public interface IAppSettings
    {
        /// <summary>
        /// Gets or sets the name of the application being tested.
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// Gets or sets the url of the landing page for the application being tested.
        /// </summary>
        public Uri AppUrl { get; set; }
    }
}
