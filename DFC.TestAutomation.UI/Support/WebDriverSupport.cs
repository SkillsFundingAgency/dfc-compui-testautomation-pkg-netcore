// <copyright file="WebDriverSupport.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using DFC.TestAutomation.UI.Extension;
using DFC.TestAutomation.UI.Helper;
using DFC.TestAutomation.UI.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

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
        /// <param name="scenarioContext">The scenario context.</param>
        public WebDriverSupport(ScenarioContext scenarioContext)
        {
            this.Context = scenarioContext;
            this.BrowserHelper = new BrowserHelper(this.Context.GetSettingsLibrary<T>().BrowserSettings.BrowserName);
            this.ChromeOptions = new ChromeOptions();
            var browserOptions = this.Context.GetSettingsLibrary<T>().BrowserSettings.BrowserArguments;

            if (!browserOptions.InSandbox)
            {
                this.ChromeOptions.AddArgument("no-sandbox");
            }

            if (browserOptions.InHeadless)
            {
                this.ChromeOptions.AddArgument("--headless");
            }
        }

        private ScenarioContext Context { get; set; }

        private ChromeOptions ChromeOptions { get; set; } = new ChromeOptions();

        private BrowserHelper BrowserHelper { get; set; }

        /// <summary>
        /// Creates an instance of the Selenium webdriver.
        /// </summary>
        /// <returns>The Selenium webdriver.</returns>
        public IWebDriver Create()
        {
            switch (this.BrowserHelper.GetBrowserType())
            {
                case BrowserType.Chrome:
                    if (this.Context.GetSettingsLibrary<T>().BrowserSettings.UseProxy)
                    {
                        var proxy = this.Context.GetSettingsLibrary<T>().BrowserSettings.Proxy;

                        this.ChromeOptions.Proxy = new Proxy
                        {
                            HttpProxy = proxy.ToString(),
                            SslProxy = proxy.ToString(),
                            FtpProxy = proxy.ToString(),
                        };
                    }

                    return new ChromeDriver(GetChromeDriverPath(), this.ChromeOptions);

                case BrowserType.Firefox:
                    return new FirefoxDriver(GetFirefoxDriverPath());

                case BrowserType.BrowserStack:
                    return new BrowserStackHelper<T>(this.Context.GetSettingsLibrary<T>().BrowserStackSettings, this.Context.GetSettingsLibrary<T>().AppSettings).CreateRemoteWebDriver();

                case BrowserType.InternetExplorer:
                    return new InternetExplorerDriver(GetInternetExplorerDriverPath());

                default:
                    throw new ArgumentOutOfRangeException($"The WebDriverConfigurator class has not been updated to handle the web driver type '{this.BrowserHelper.GetBrowserType()}'. An update is required.");
            }
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
