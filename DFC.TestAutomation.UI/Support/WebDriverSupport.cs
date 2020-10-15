// <copyright file="WebDriverSupport.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using DFC.TestAutomation.UI.Helper;
using DFC.TestAutomation.UI.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.IO;
using System.Reflection;

namespace DFC.TestAutomation.UI.Support
{
    /// <summary>
    /// Provides support functions for Selenium webdriver related operations.
    /// </summary>
    /// <typeparam name="T">The application settings type. This must be an interface member of IAppSettings.</typeparam>
    public class WebDriverSupport<T> : IWebDriverSupport
        where T : IAppSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebDriverSupport{T}"/> class.
        /// </summary>
        /// <param name="settingsLibrary">The settings library.</param>
        public WebDriverSupport(ISettingsLibrary<T> settingsLibrary)
        {
            this.SettingsLibrary = settingsLibrary;
            this.BrowserHelper = new BrowserHelper(this.SettingsLibrary.BrowserSettings.BrowserName);
            this.ChromeOptions = new ChromeOptions();
            var browserOptions = this.SettingsLibrary.BrowserSettings.BrowserArguments;

            if (!browserOptions.InSandbox)
            {
                this.ChromeOptions.AddArgument("no-sandbox");
            }

            if (browserOptions.InHeadless)
            {
                this.ChromeOptions.AddArgument("--headless");
            }
        }

        private ISettingsLibrary<T> SettingsLibrary { get; set; }

        private ChromeOptions ChromeOptions { get; set; } = new ChromeOptions();

        private BrowserHelper BrowserHelper { get; set; }

        /// <summary>
        /// Creates an instance of the Selenium webdriver.
        /// </summary>
        /// <returns>The Selenium webdriver.</returns>
        public IWebDriver Create()
        {
            IWebDriver webDriver = null;

            switch (this.BrowserHelper.GetBrowserType())
            {
                case BrowserType.Chrome:
                    if (this.SettingsLibrary.BrowserSettings.UseProxy)
                    {
                        var proxy = this.SettingsLibrary.BrowserSettings.Proxy;

                        this.ChromeOptions.Proxy = new Proxy
                        {
                            HttpProxy = proxy.ToString(),
                            SslProxy = proxy.ToString(),
                            FtpProxy = proxy.ToString(),
                        };
                    }

                    webDriver = new ChromeDriver(GetChromeDriverPath(), this.ChromeOptions);
                    break;

                case BrowserType.Firefox:
                    webDriver = new FirefoxDriver(GetFirefoxDriverPath());
                    break;

                case BrowserType.BrowserStack:
                    webDriver = new BrowserStackHelper<T>(this.SettingsLibrary.BrowserStackSettings, this.SettingsLibrary.BuildSettings).CreateRemoteWebDriver();
                    break;

                case BrowserType.InternetExplorer:
                    webDriver = new InternetExplorerDriver(GetInternetExplorerDriverPath());
                    break;

                default:
                    throw new ArgumentOutOfRangeException($"The WebDriverConfigurator class has not been updated to handle the web driver type '{this.BrowserHelper.GetBrowserType()}'. An update is required.");
            }

            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(this.SettingsLibrary.TestExecutionSettings.TimeoutSettings.PageNavigation);
            return webDriver;
        }

        private static string GetWebDriverPathForExecutable(string executableName)
        {
            if (executableName == null)
            {
                throw new NullReferenceException("The executable name parameter must be set.");
            }

            executableName = executableName.Replace(".exe", string.Empty, StringComparison.CurrentCulture);
            string driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            FileInfo[] file = Directory.GetParent(driverPath).GetFiles($"{executableName}.exe", SearchOption.AllDirectories);
            var info = file.Length != 0 ? file[0].DirectoryName : driverPath;
            return info;
        }

        private static string GetChromeDriverPath()
        {
            return GetWebDriverPathForExecutable("chromedriver.exe");
        }

        private static string GetFirefoxDriverPath()
        {
            return GetWebDriverPathForExecutable("geckodriver.exe");
        }

        private static string GetInternetExplorerDriverPath()
        {
            return GetWebDriverPathForExecutable("IEDriverServer");
        }
    }
}
