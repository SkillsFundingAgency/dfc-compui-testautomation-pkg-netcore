// <copyright file="IHelperLibrary.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DFC.TestAutomation.UI.Helper
{
    public interface IHelperLibrary
    {
        IAxeHelper AxeHelper { get; set; }

        IBrowserHelper BrowserHelper { get; set; }

        IFormHelper FormHelper { get; set; }

        IHttpRequestHelper HttpRequestHelper { get; set; }

        IJavaScriptHelper JavaScriptHelper { get; set; }

        ICommonActionHelper CommonActionHelper { get; set; }

        IWebDriverWaitHelper WebDriverWaitHelper { get; set; }

        IMongoDbConnectionHelper MongoDbConnectionHelper { get; set; }

        IRetryHelper RetryHelper { get; set; }

        ISqlDatabaseHelper SqlDatabaseHelper { get; set; }

        IScreenshotHelper ScreenshotHelper { get; set; }
    }
}
