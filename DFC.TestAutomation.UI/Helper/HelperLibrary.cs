// <copyright file="HelperLibrary.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// A container for all helper classes.
    /// </summary>
    public class HelperLibrary : IHelperLibrary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HelperLibrary"/> class.
        /// </summary>
        /// <param name="javascriptHelper">The javascript helper.</param>
        /// <param name="webDriverWaitHelper">The Webdriver wait helper.</param>
        /// <param name="retryHelper">The retry helper.</param>
        /// <param name="axeHelper">The axe helper.</param>
        /// <param name="browserHelper">The browser helper.</param>
        /// <param name="formHelper">The form helper.</param>
        /// <param name="commonActionHelper">The common action helper.</param>
        /// <param name="mongoDbConnectionHelper">The Mongo database connection helper.</param>
        /// <param name="screenshotHelper">The screenshot helper.</param>
        /// <param name="sqlDatabaseHelper">The SQL database connection helper.</param>
        public HelperLibrary(
            IJavaScriptHelper javascriptHelper,
            IWebDriverWaitHelper webDriverWaitHelper,
            IRetryHelper retryHelper,
            IAxeHelper axeHelper,
            IBrowserHelper browserHelper,
            IFormHelper formHelper,
            ICommonActionHelper commonActionHelper,
            IScreenshotHelper screenshotHelper)
        {
            this.JavaScriptHelper = javascriptHelper;
            this.WebDriverWaitHelper = webDriverWaitHelper;
            this.RetryHelper = retryHelper;
            this.AxeHelper = axeHelper;
            this.BrowserHelper = browserHelper;
            this.FormHelper = formHelper;
            this.CommonActionHelper = commonActionHelper;
            this.ScreenshotHelper = screenshotHelper;
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
