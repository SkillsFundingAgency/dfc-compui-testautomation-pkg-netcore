using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.TestAutomation.UI.Helper
{
    public interface IHelperLibrary
    {
        IAxeHelper AxeHelper { get; set; }

        IBrowserHelper BrowserHelper { get; set; }

        IFormCompletionHelper FormCompletionHelper { get; set; }

        HttpClientRequestHelper HttpClientRequestHelper { get; set; }

        IJavaScriptHelper JavaScriptHelper { get; set; }

        IPageInteractionHelper PageInteractionHelper { get; set; }

        IWebDriverWaitHelper WebDriverWaitHelper { get; set; }

        MongoDbConnectionHelper MongoDbConnectionHelper { get; set; }

        RegexHelper RegexHelper { get; set; }

        IRetryHelper RetryHelper { get; set; }

        SqlDatabaseConnectionHelper SqlDatabaseConnectionHelper { get; set; }

        TableRowHelper TableRowHelper { get; set; }
    }
}
