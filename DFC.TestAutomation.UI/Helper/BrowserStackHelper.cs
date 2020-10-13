// <copyright file="BrowserStackHelper.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using DFC.TestAutomation.UI.Settings;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// Provides helper functions for BrowserStack related operations.
    /// </summary>
    /// <typeparam name="T">The application settings type. This must be an interface member of IAppSettings.</typeparam>
    public class BrowserStackHelper<T> : IBrowserStackHelper
        where T : IAppSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrowserStackHelper{T}"/> class.
        /// </summary>
        /// <param name="browserStackSettings">The BrowserStack settings</param>
        /// <param name="appSettings">The project settings.</param>
        public BrowserStackHelper(BrowserStackSettings browserStackSettings, T appSettings, BuildSettings buildSettings)
        {
            this.BrowserStackSettings = browserStackSettings;
            this.BuildSettings = buildSettings;
            this.AppSettings = appSettings;

            if (this.BrowserStackSettings.Username == null || this.BrowserStackSettings.AccessKey == null)
            {
                throw new Exception("Unable to initialise the BrowserStackSetup class as the settings do not contain a Browserstack username and/or password. You can set this configuration in the appsettings.json file.");
            }

            if (!this.RecognisedBrowsers.Contains(this.BrowserStackSettings.BrowserName.Trim().ToLower(CultureInfo.CurrentCulture)))
            {
                throw new InvalidOperationException($"Unable to initialise the BrowserStackHelper class as the browser '{this.BrowserStackSettings.BrowserName}' was not recognised.");
            }
        }

        private List<string> RecognisedBrowsers { get; } = new List<string>()
        {
            "ie",
            "edge",
            "chrome",
            "firefox",
            "safari",
        };

        private BrowserStackSettings BrowserStackSettings { get; set; }

        private BuildSettings BuildSettings { get; set; }

        private T AppSettings { get; set; }

        /// <summary>
        /// Creates an instance of the Selenium remote webdriver.
        /// </summary>
        /// <returns>The Selenium remote webdriver.</returns>
        public IWebDriver CreateRemoteWebDriver()
        {
            var driverOptions = this.GetDriverOptions();
            driverOptions.AcceptInsecureCertificates = true;
            driverOptions.AddAdditionalCapability("browser", this.BrowserStackSettings.BrowserName);
            driverOptions.AddAdditionalCapability("browser_version", this.BrowserStackSettings.BrowserVersion);
            driverOptions.AddAdditionalCapability("os", this.BrowserStackSettings.OperatingSystem);
            driverOptions.AddAdditionalCapability("os_version", this.BrowserStackSettings.OperatingSystemVersion);
            driverOptions.AddAdditionalCapability("resolution", this.BrowserStackSettings.ScreenResolution);
            driverOptions.AddAdditionalCapability("browserstack.user", this.BrowserStackSettings.Username);
            driverOptions.AddAdditionalCapability("browserstack.key", this.BrowserStackSettings.AccessKey);
            driverOptions.AddAdditionalCapability("build", this.BuildSettings.BuildNumber);
            driverOptions.AddAdditionalCapability("project", this.BrowserStackSettings.Project);
            driverOptions.AddAdditionalCapability("browserstack.debug", this.BrowserStackSettings.EnableDebug);
            driverOptions.AddAdditionalCapability("browserstack.networkLogs", this.BrowserStackSettings.EnableNetworkLogs);
            driverOptions.AddAdditionalCapability("browserstack.timezone", "Europe/London");
            driverOptions.AddAdditionalCapability("browserstack.video", this.BrowserStackSettings.RecordVideo);
            driverOptions.AddAdditionalCapability("browserstack.seleniumLogs", this.BrowserStackSettings.EnableSeleniumLogs);

            return new RemoteWebDriver(this.AppSettings.AppUrl, driverOptions);
        }

        private DriverOptions GetDriverOptions()
        {
            switch (this.BrowserStackSettings.BrowserName.ToLower(CultureInfo.CurrentCulture))
            {
                case "chrome":
                    return new ChromeOptions();

                case "ie":
                    return new InternetExplorerOptions();

                case "edge":
                    return new EdgeOptions();

                case "firefox":
                    return new FirefoxOptions();

                case "safari":
                    return new SafariOptions();

                default:
                    throw new ArgumentOutOfRangeException("Unable to create the browser specific driver options. An update is required.");
            }
        }
    }
}
