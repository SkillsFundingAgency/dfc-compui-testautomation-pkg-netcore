// <copyright file="IHelperLibrary.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DFC.TestAutomation.UI.Helper
{
    public interface IHelperLibrary
    {
        IAxeHelper AxeHelper { get; }

        IBrowserHelper BrowserHelper { get; }

        IFormHelper FormHelper { get; }

        IJavaScriptHelper JavaScriptHelper { get; }

        ICommonActionHelper CommonActionHelper { get; }

        IWebDriverWaitHelper WebDriverWaitHelper { get; }

        IMongoDatabaseHelper MongoDbConnectionHelper { get; }

        IRetryHelper RetryHelper { get; }

        ISqlDatabaseHelper SqlDatabaseHelper { get; }

        IScreenshotHelper ScreenshotHelper { get; }
    }
}
