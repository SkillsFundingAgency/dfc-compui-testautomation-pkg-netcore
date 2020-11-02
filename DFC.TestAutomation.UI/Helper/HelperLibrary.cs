// <copyright file="HelperLibrary.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using DFC.TestAutomation.UI.Factory;
using DFC.TestAutomation.UI.Settings;
using OpenQA.Selenium;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// A container for all helper classes.
    /// </summary>
    public class HelperLibrary<T> : IHelperLibrary<T>
        where T : IAppSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HelperLibrary{T}"/> class.
        /// </summary>
        /// <param name="webDriver">The Selenium webdriver.</param>
        /// <param name="settingsLibrary">The settings library.</param>
        public HelperLibrary(IWebDriver webDriver, ISettingsLibrary<T> settingsLibrary)
        {
            this.JavaScriptHelper = new JavaScriptHelper(webDriver);
            this.WebDriverWaitHelper = new WebDriverWaitHelper(webDriver, settingsLibrary?.TestExecutionSettings.TimeoutSettings, this.JavaScriptHelper);
            this.RetryHelper = new RetryHelper(settingsLibrary.TestExecutionSettings.RetrySettings);
            this.AxeHelper = new AxeHelper(webDriver);
            this.BrowserHelper = new BrowserHelper(settingsLibrary?.BrowserSettings.BrowserName);
            this.FormHelper = new FormHelper(webDriver, this.WebDriverWaitHelper, new ActionsFactory(webDriver));
            this.CommonActionHelper = new CommonActionHelper(webDriver, this.WebDriverWaitHelper, this.RetryHelper);
            this.ScreenshotHelper = new ScreenshotHelper(webDriver);
            this.BrowserStackHelper = new BrowserStackHelper<T>(settingsLibrary.BrowserStackSettings);
        }

        /// <summary>
        /// Gets the axe helper.
        /// </summary>
        public IAxeHelper AxeHelper { get; private set; }

        /// <summary>
        /// Gets the BrowserStack helper.
        /// </summary>
        public BrowserStackHelper<T> BrowserStackHelper { get; private set; }

        /// <summary>
        /// Gets the browser helper.
        /// </summary>
        public IBrowserHelper BrowserHelper { get; private set; }

        /// <summary>
        /// Gets the form helper.
        /// </summary>
        public IFormHelper FormHelper { get; private set; }

        /// <summary>
        /// Gets the javascript helper.
        /// </summary>
        public IJavaScriptHelper JavaScriptHelper { get; private set; }

        /// <summary>
        /// Gets the common action helper.
        /// </summary>
        public ICommonActionHelper CommonActionHelper { get; private set; }

        /// <summary>
        /// Gets the Webdriver wait helper.
        /// </summary>
        public IWebDriverWaitHelper WebDriverWaitHelper { get; private set; }

        /// <summary>
        /// Gets the retry helper.
        /// </summary>
        public IRetryHelper RetryHelper { get; private set; }

        /// <summary>
        /// Gets the screenshot helper.
        /// </summary>
        public IScreenshotHelper ScreenshotHelper { get; private set; }
    }
}
