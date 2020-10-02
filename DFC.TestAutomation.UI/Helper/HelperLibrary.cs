// <copyright file="HelperLibrary.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DFC.TestAutomation.UI.Helper
{
    public class HelperLibrary : IHelperLibrary
    {
        public HelperLibrary(
            IJavaScriptHelper javascriptHelper,
            IWebDriverWaitHelper webDriverWaitHelper,
            IRetryHelper retryHelper,
            IAxeHelper axeHelper,
            IBrowserHelper browserHelper,
            IFormHelper formHelper,
            IHttpClientRequestHelper httpClientRequestHelper,
            IPageInteractionHelper pageInteractionHelper,
            IMongoDbConnectionHelper mongoDbConnectionHelper,
            IScreenshotHelper screenshotHelper,
            ISqlDatabaseConnectionHelper sqlDatabaseConnectionHelper)
        {
            this.JavaScriptHelper = javascriptHelper;
            this.WebDriverWaitHelper = webDriverWaitHelper;
            this.RetryHelper = retryHelper;
            this.AxeHelper = axeHelper;
            this.BrowserHelper = browserHelper;
            this.FormHelper = formHelper;
            this.HttpClientRequestHelper = httpClientRequestHelper;
            this.PageInteractionHelper = pageInteractionHelper;
            this.MongoDbConnectionHelper = mongoDbConnectionHelper;
            this.SqlDatabaseConnectionHelper = sqlDatabaseConnectionHelper;
            this.ScreenshotHelper = screenshotHelper;
        }

        public IAxeHelper AxeHelper { get; set; }

        public IBrowserHelper BrowserHelper { get; set; }

        public IFormHelper FormHelper { get; set; }

        public IHttpClientRequestHelper HttpClientRequestHelper { get; set; }

        public IJavaScriptHelper JavaScriptHelper { get; set; }

        public IPageInteractionHelper PageInteractionHelper { get; set; }

        public IWebDriverWaitHelper WebDriverWaitHelper { get; set; }

        public IMongoDbConnectionHelper MongoDbConnectionHelper { get; set; }

        public IRetryHelper RetryHelper { get; set; }

        public ISqlDatabaseConnectionHelper SqlDatabaseConnectionHelper { get; set; }

        public IScreenshotHelper ScreenshotHelper { get; set; }
    }
}
