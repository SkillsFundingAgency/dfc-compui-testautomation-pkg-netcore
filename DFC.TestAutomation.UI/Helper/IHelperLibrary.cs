﻿namespace DFC.TestAutomation.UI.Helper
{
    public interface IHelperLibrary
    {
        IAxeHelper AxeHelper { get; set; }

        IBrowserHelper BrowserHelper { get; set; }

        IFormCompletionHelper FormCompletionHelper { get; set; }

        IHttpClientRequestHelper HttpClientRequestHelper { get; set; }

        IJavaScriptHelper JavaScriptHelper { get; set; }

        IPageInteractionHelper PageInteractionHelper { get; set; }

        IWebDriverWaitHelper WebDriverWaitHelper { get; set; }

        IMongoDbConnectionHelper MongoDbConnectionHelper { get; set; }

        IRetryHelper RetryHelper { get; set; }

        ISqlDatabaseConnectionHelper SqlDatabaseConnectionHelper { get; set; }
    }
}