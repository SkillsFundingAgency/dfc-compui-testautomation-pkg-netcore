// <copyright file="BrowserStackSettings.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;

namespace DFC.TestAutomation.UI.Settings
{
    /// <summary>
    /// A model used to parse BrowserStack settings from the application settings.
    /// </summary>
    public class BrowserStackSettings
    {
        /// <summary>
        /// Gets or sets the browser.
        ///
        /// Firefox, Safari, IE, Chrome, Opera, Edge.
        /// </summary>
        public string BrowserName { get; set; }

        /// <summary>
        /// Gets or sets the operating system. This can be set to 'Windows' or 'OS X'.
        /// </summary>
        public string OperatingSystem { get; set; }

        /// <summary>
        /// Gets or sets the operating system version.
        ///
        /// Windows: XP, 7, 8, 8.1 and 10.
        ///
        /// OS X: Snow Leopard, Lion, Mountain Lion, Mavericks, Yosemite, El Capitan, Sierra, High Sierra, Mojave.
        /// </summary>
        public string OperatingSystemVersion { get; set; }

        /// <summary>
        /// Gets or sets the screen resolution.
        ///
        /// Windows XP / 7: 800x600, 1024x768, 1280x800, 1280x1024, 1366x768, 1440x900, 1680x1050, 1600x1200, 1920x1200, 1920x1080,
        /// 2048x1536.
        ///
        /// Windows 8 / 8.1 / 10) : 1024x768, 1280x800, 1280x1024, 1366x768, 1440x900, 1680x1050, 1600x1200, 1920x1200, 1920x1080,
        /// 2048x1536.
        ///
        /// OS X: 1024x768, 1280x960, 1280x1024, 1600x1200, 1920x1080.
        ///
        /// Default: 1024x76.
        /// </summary>
        public string ScreenResolution { get; set; }

        /// <summary>
        /// Gets or sets the BrowserStack username.
        ///
        /// For running your Selenium and Appium tests on BrowserStack, it requires a username for authenticating the user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the BrowserStack access key.
        ///
        /// For running your Selenium and Appium tests on BrowserStack, it requires an access key for authenticating the user.
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// Gets or sets the remote browser version.
        ///
        /// Use 'latest', 'latest-beta' or 'latest[-n number]' format to automatically choose the current beta release of the browser
        /// or the latest(and other older) browser versions.
        ///
        /// For specific browser versions pass a particular browser version number.
        ///
        /// Default: Latest stable version of browser is used.
        /// </summary>
        public string BrowserVersion { get; set; }

        /// <summary>
        /// Gets or sets the build name. This allows the user to specify a name for a logical group of tests i.e. Build 1.0
        ///
        /// Default: Untitled Build.
        /// </summary>
        public string Build { get; set; }

        /// <summary>
        /// Gets or sets the project name. This allows the user to specify a name for a logical group of builds i.e. login form.
        ///
        /// Default: Untitled Project.
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not to take screenshots at various steps in your tests.
        ///
        /// Default: false.
        /// </summary>
        public bool EnableDebug { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to capture network logs for your test.
        ///
        /// Note: You may experience minor reductions in performance when testing with Network Logs turned on.
        ///
        /// Default: false.
        /// </summary>
        public bool EnableNetworkLogs { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to enable video recording during your test.
        ///
        /// Default: true.
        /// </summary>
        public bool RecordVideo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to enable selenium logs.
        ///
        /// Default: true.
        /// </summary>
        public string EnableSeleniumLogs { get; set; }
    }
}
