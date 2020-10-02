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
        /// Initializes a new instance of the <see cref="HelperLibrary"/> class. The <see cref="HttpRequestHelper"/> defaults to null. This can be set at runtime.
        /// </summary>
        /// <param name="javascriptHelper">The javascript helper.</param>
        /// <param name="webDriverWaitHelper">The Webdriver wait helper.</param>
        /// <param name="retryHelper">The retry helper.</param>
        /// <param name="axeHelper">The axe helper.</param>
        /// <param name="browserHelper">The browser helper.</param>
        /// <param name="formHelper">The form helper.</param>
        /// <param name="httpRequestHelper">The HTTP request helper.</param>
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
            IHttpRequestHelper httpRequestHelper,
            ICommonActionHelper commonActionHelper,
            IMongoDbConnectionHelper mongoDbConnectionHelper,
            IScreenshotHelper screenshotHelper,
            ISqlDatabaseHelper sqlDatabaseHelper)
        {
            this.JavaScriptHelper = javascriptHelper;
            this.WebDriverWaitHelper = webDriverWaitHelper;
            this.RetryHelper = retryHelper;
            this.AxeHelper = axeHelper;
            this.BrowserHelper = browserHelper;
            this.FormHelper = formHelper;
            this.HttpRequestHelper = httpRequestHelper;
            this.CommonActionHelper = commonActionHelper;
            this.MongoDbConnectionHelper = mongoDbConnectionHelper;
            this.SqlDatabaseHelper = sqlDatabaseHelper;
            this.ScreenshotHelper = screenshotHelper;
        }

        /// <summary>
        /// Gets or sets the axe helper.
        /// </summary>
        public IAxeHelper AxeHelper { get; set; }

        /// <summary>
        /// Gets or sets the browser helper.
        /// </summary>
        public IBrowserHelper BrowserHelper { get; set; }

        /// <summary>
        /// Gets or sets the form helper.
        /// </summary>
        public IFormHelper FormHelper { get; set; }

        /// <summary>
        /// Gets or sets the HTTP request helper.
        /// </summary>
        public IHttpRequestHelper HttpRequestHelper { get; set; }

        /// <summary>
        /// Gets or sets the javascript helper.
        /// </summary>
        public IJavaScriptHelper JavaScriptHelper { get; set; }

        /// <summary>
        /// Gets or sets the common action helper.
        /// </summary>
        public ICommonActionHelper CommonActionHelper { get; set; }

        /// <summary>
        /// Gets or sets the Webdriver wait helper.
        /// </summary>
        public IWebDriverWaitHelper WebDriverWaitHelper { get; set; }

        /// <summary>
        /// Gets or sets the Mongo database helper.
        /// </summary>
        public IMongoDbConnectionHelper MongoDbConnectionHelper { get; set; }

        /// <summary>
        /// Gets or sets the retry helper.
        /// </summary>
        public IRetryHelper RetryHelper { get; set; }

        /// <summary>
        /// Gets or sets the SQL database helper.
        /// </summary>
        public ISqlDatabaseHelper SqlDatabaseHelper { get; set; }

        /// <summary>
        /// Gets or sets the screenshot helper.
        /// </summary>
        public IScreenshotHelper ScreenshotHelper { get; set; }
    }
}
