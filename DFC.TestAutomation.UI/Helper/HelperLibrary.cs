using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.TestAutomation.UI.Helper
{
    public class HelperLibrary
    {
        public IAxeHelper AxeHelper { get; set; }
        public IBrowserHelper BrowserHelper { get; set; }
        public FormCompletionHelper FormCompletionHelper { get; set; }
        public HttpClientRequestHelper HttpClientRequestHelper { get; set; }
        public IJavaScriptHelper JavaScriptHelper { get; set; }
        public IPageInteractionHelper PageInteractionHelper { get; set; }
        public IWebDriverWaitHelper WebDriverWaitHelper { get; set; }
        public MongoDbConnectionHelper MongoDbConnectionHelper { get; set; }
        public RegexHelper RegexHelper { get; set; }
        public IRetryHelper RetryHelper { get; set; }
        public SqlDatabaseConnectionHelper SqlDatabaseConnectionHelper { get; set; }
        public TableRowHelper TableRowHelper { get; set; }
    }
}
