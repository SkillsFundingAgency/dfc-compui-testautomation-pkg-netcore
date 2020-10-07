// <copyright file="HelperLibrary.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// </copyright>

using DFC.TestAutomation.UI.Extension;
using DFC.TestAutomation.UI.Settings;
using TechTalk.SpecFlow;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// A container for all helper classes.
    /// </summary>
    public class HelperLibrary<T> : IHelperLibrary
        where T : IAppSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HelperLibrary{T}"/> class.
        /// </summary>
        /// <param name="context">The scenario context.</param>
        public HelperLibrary(ScenarioContext context)
        {
            this.JavaScriptHelper = new JavaScriptHelper(context.GetWebDriver());
            this.WebDriverWaitHelper = new WebDriverWaitHelper(context.GetWebDriver(), context.GetSettingsLibrary<T>().TestExecutionSettings.TimeoutSettings, this.JavaScriptHelper);
            this.RetryHelper = new RetryHelper();
            this.AxeHelper = new AxeHelper(context.GetWebDriver());
            this.BrowserHelper = new BrowserHelper(context.GetSettingsLibrary<T>().BrowserSettings.BrowserName);
            this.FormHelper = new FormHelper(context.GetWebDriver(), this.WebDriverWaitHelper, this.RetryHelper, this.JavaScriptHelper);
            this.CommonActionHelper = new CommonActionHelper(context.GetWebDriver(), this.WebDriverWaitHelper, this.RetryHelper);
            this.ScreenshotHelper = new ScreenshotHelper(context);
        }

        /// <summary>
        /// Gets the axe helper.
        /// </summary>
        public IAxeHelper AxeHelper { get; private set; }

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
