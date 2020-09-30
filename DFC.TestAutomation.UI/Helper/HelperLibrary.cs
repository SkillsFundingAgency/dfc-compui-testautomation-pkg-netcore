﻿using DFC.TestAutomation.UI.Config;

namespace DFC.TestAutomation.UI.Helper
{
    public class HelperLibrary<T> : IHelperLibrary where T : IConfiguration
    {
        public HelperLibrary(IJavaScriptHelper javascriptHelper, IWebDriverWaitHelper webDriverWaitHelper, IRetryHelper retryHelper,
            IAxeHelper axeHelper, IBrowserHelper browserHelper, IFormCompletionHelper formCompletionHelper, HttpClientRequestHelper httpClientRequestHelper,
            IPageInteractionHelper pageInteractionHelper, IMongoDbConnectionHelper mongoDbConnectionHelper,
            ISqlDatabaseConnectionHelper sqlDatabaseConnectionHelper)
        {
            this.JavaScriptHelper = javascriptHelper;
            this.WebDriverWaitHelper = webDriverWaitHelper;
            this.RetryHelper = retryHelper;
            this.AxeHelper = axeHelper;
            this.BrowserHelper = browserHelper;
            this.FormCompletionHelper = formCompletionHelper;
            this.HttpClientRequestHelper = httpClientRequestHelper;
            this.PageInteractionHelper = pageInteractionHelper;
            this.MongoDbConnectionHelper = mongoDbConnectionHelper;
            this.SqlDatabaseConnectionHelper = sqlDatabaseConnectionHelper;
        }

        public IAxeHelper AxeHelper { get; set; }

        public IBrowserHelper BrowserHelper { get; set; }

        public IFormCompletionHelper FormCompletionHelper { get; set; }

        public HttpClientRequestHelper HttpClientRequestHelper { get; set; }

        public IJavaScriptHelper JavaScriptHelper { get; set; }

        public IPageInteractionHelper PageInteractionHelper { get; set; }

        public IWebDriverWaitHelper WebDriverWaitHelper { get; set; }

        public IMongoDbConnectionHelper MongoDbConnectionHelper { get; set; }

        public IRetryHelper RetryHelper { get; set; }

        public ISqlDatabaseConnectionHelper SqlDatabaseConnectionHelper { get; set; }
    }
}
