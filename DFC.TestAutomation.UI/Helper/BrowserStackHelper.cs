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
        /// <param name="browserStackSettings">The BrowserStack settings.</param>
        /// <param name="buildSettings">The build settings.</param>
        public BrowserStackHelper(BrowserStackSettings browserStackSettings, BuildSettings buildSettings)
        {
            this.BrowserStackSettings = browserStackSettings;

            if (this.BrowserStackSettings.Username == null || this.BrowserStackSettings.AccessKey == null)
            {
                throw new Exception("Unable to initialise the BrowserStackSetup class as the settings do not contain a Browserstack username and/or password. You can set this configuration in the appsettings.json file.");
            }

            if (!this.RecognisedBrowsers.Contains(this.BrowserStackSettings.BrowserName.Trim().ToLower(CultureInfo.CurrentCulture)))
            {
                throw new InvalidOperationException($"Unable to initialise the BrowserStackHelper class as the browser '{this.BrowserStackSettings.BrowserName}' was not recognised.");
            }

            this.AdditionalCapabilities.Add("browser", this.BrowserStackSettings.BrowserName);
            this.AdditionalCapabilities.Add("browser_version", this.BrowserStackSettings.BrowserVersion);
            this.AdditionalCapabilities.Add("os", this.BrowserStackSettings.OperatingSystem);
            this.AdditionalCapabilities.Add("os_version", this.BrowserStackSettings.OperatingSystemVersion);
            this.AdditionalCapabilities.Add("resolution", this.BrowserStackSettings.ScreenResolution);
            this.AdditionalCapabilities.Add("browserstack.user", this.BrowserStackSettings.Username);
            this.AdditionalCapabilities.Add("browserstack.key", this.BrowserStackSettings.AccessKey);
            this.AdditionalCapabilities.Add("build", buildSettings?.BuildNumber);
            this.AdditionalCapabilities.Add("project", this.BrowserStackSettings.Project);
            this.AdditionalCapabilities.Add("browserstack.debug", this.BrowserStackSettings.EnableDebug);
            this.AdditionalCapabilities.Add("browserstack.networkLogs", this.BrowserStackSettings.EnableNetworkLogs);
            this.AdditionalCapabilities.Add("browserstack.timezone", "Europe/London");
            this.AdditionalCapabilities.Add("browserstack.video", this.BrowserStackSettings.RecordVideo);
            this.AdditionalCapabilities.Add("browserstack.seleniumLogs", this.BrowserStackSettings.EnableSeleniumLogs);
        }

        private Dictionary<string, object> AdditionalCapabilities { get; set; } = new Dictionary<string, object>();

        private List<string> RecognisedBrowsers { get; } = new List<string>()
        {
            "ie",
            "edge",
            "chrome",
            "firefox",
            "safari",
        };

        private BrowserStackSettings BrowserStackSettings { get; set; }

        /// <summary>
        /// Creates an instance of the Selenium remote webdriver.
        /// </summary>
        /// <returns>The Selenium remote webdriver.</returns>
        public IWebDriver CreateRemoteWebDriver()
        {
            var driverOptions = this.GetDriverOptions();
            return new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), driverOptions);
        }

        private DriverOptions GetDriverOptions()
        {
            switch (this.BrowserStackSettings.BrowserName.ToLower(CultureInfo.CurrentCulture))
            {
                case "chrome":
                    var chromeDriverOptions = new ChromeOptions();
                    foreach (var capability in this.AdditionalCapabilities)
                    {
                        chromeDriverOptions.AddAdditionalCapability(capability.Key, capability.Value, true);
                    }

                    return chromeDriverOptions;

                case "ie":
                    var ieDriverOptions = new InternetExplorerOptions();
                    foreach (var capability in this.AdditionalCapabilities)
                    {
                        ieDriverOptions.AddAdditionalCapability(capability.Key, capability.Value, true);
                    }

                    return ieDriverOptions;

                case "edge":
                    var edgeDriverOptions = new EdgeOptions();
                    foreach (var capability in this.AdditionalCapabilities)
                    {
                        edgeDriverOptions.AddAdditionalCapability(capability.Key, capability.Value);
                    }

                    return edgeDriverOptions;

                case "firefox":
                    var firefoxDriverOptions = new FirefoxOptions();
                    foreach (var capability in this.AdditionalCapabilities)
                    {
                        firefoxDriverOptions.AddAdditionalCapability(capability.Key, capability.Value, true);
                    }

                    return firefoxDriverOptions;

                case "safari":
                    var safariDriverOptions = new SafariOptions();
                    foreach (var capability in this.AdditionalCapabilities)
                    {
                        safariDriverOptions.AddAdditionalCapability(capability.Key, capability.Value);
                    }

                    return safariDriverOptions;

                default:
                    throw new ArgumentOutOfRangeException("Unable to create the browser specific driver options. An update is required.");
            }
        }
    }
}
