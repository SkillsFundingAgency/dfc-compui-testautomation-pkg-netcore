// <copyright file="BrowserStackHelper.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using DFC.TestAutomation.UI.Settings;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using RestSharp;
using RestSharp.Authenticators;
using System;
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
        /// <param name="webDriver">The Selenium webdriver.</param>
        /// <param name="settingsLibrary">The settings library.</param>
        public BrowserStackHelper(IWebDriver webDriver, ISettingsLibrary<T> settingsLibrary)
        {
            this.WebDriver = webDriver;
            this.BrowserStackSettings = settingsLibrary?.BrowserStackSettings;
            this.BrowserSettings = settingsLibrary?.BrowserSettings;
            this.EnvironmentSettings = settingsLibrary?.EnvironmentSettings;
            this.BuildSettings = settingsLibrary?.BuildSettings;
            this.ProjectSettings = settingsLibrary.AppSettings;

            if (this.BrowserStackSettings.Username == null || this.BrowserStackSettings.AccessKey == null)
            {
                throw new Exception("Unable to initialise the BrowserStackSetup class as the settings do not contain a Browserstack username and/or password. You can set this configuration in the appsettings.json file.");
            }
        }

        private IWebDriver WebDriver { get; set; }

        private BrowserStackSettings BrowserStackSettings { get; set; }

        private BrowserSettings BrowserSettings { get; set; }

        private EnvironmentSettings EnvironmentSettings { get; set; }

        private BuildSettings BuildSettings { get; set; }

        private T ProjectSettings { get; set; }

        /// <summary>
        /// Creates an instance of the Selenium remote webdriver.
        /// </summary>
        /// <returns>The Selenium remote webdriver.</returns>
        public IWebDriver CreateRemoteWebDriver()
        {
            var chromeOptions = new ChromeOptions
            {
                AcceptInsecureCertificates = true,
            };

            chromeOptions.AddAdditionalCapability("browser", this.BrowserSettings.BrowserName, true);
            chromeOptions.AddAdditionalCapability("browser_version", this.BrowserStackSettings.BrowserVersion, true);
            chromeOptions.AddAdditionalCapability("os", this.EnvironmentSettings.OperatingSystem, true);
            chromeOptions.AddAdditionalCapability("os_version", this.EnvironmentSettings.OperatingSystemVersion, true);
            chromeOptions.AddAdditionalCapability("resolution", this.EnvironmentSettings.ScreenResolution, true);
            chromeOptions.AddAdditionalCapability("browserstack.user", this.BrowserStackSettings.Username, true);
            chromeOptions.AddAdditionalCapability("browserstack.key", this.BrowserStackSettings.AccessKey, true);
            chromeOptions.AddAdditionalCapability("build", $"dfc.acceptance.{this.EnvironmentSettings.EnvironmentName.ToUpper(CultureInfo.CurrentCulture)}.{this.BuildSettings.BuildNumber}", true);
            chromeOptions.AddAdditionalCapability("project", this.ProjectSettings.AppName, true);
            chromeOptions.AddAdditionalCapability("browserstack.debug", "true", true);
            chromeOptions.AddAdditionalCapability("browserstack.networkLogs", this.BrowserStackSettings.EnableNetworkLogs, true);
            chromeOptions.AddAdditionalCapability("browserstack.timezone", "Europe/London", true);
            chromeOptions.AddAdditionalCapability("browserstack.console", "info", true);

            return new RemoteWebDriver(this.BrowserStackSettings.WebdriverRemoteServerUrl, chromeOptions);
        }
    }
}
