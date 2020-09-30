using DFC.TestAutomation.UI.Config;

namespace DFC.TestAutomation.UI.Helper
{
    public class HelperLibrary<T> : IHelperLibrary where T : IConfiguration
    {
        public HelperLibrary(IJavaScriptHelper javascriptHelper, IWebDriverWaitHelper webDriverWaitHelper, IRetryHelper retryHelper,
            IAxeHelper axeHelper, IBrowserHelper browserHelper, IFormCompletionHelper formCompletionHelper, HttpClientRequestHelper httpClientRequestHelper,
            IPageInteractionHelper pageInteractionHelper, MongoDbConnectionHelper mongoDbConnectionHelper,
            ISqlDatabaseConnectionHelper sqlDatabaseConnectionHelper, TableRowHelper tableRowHelper)
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
            this.TableRowHelper = tableRowHelper;
        }

        public IAxeHelper AxeHelper { get; set; }

        public IBrowserHelper BrowserHelper { get; set; }

        public IFormCompletionHelper FormCompletionHelper { get; set; }

        public HttpClientRequestHelper HttpClientRequestHelper { get; set; }

        public IJavaScriptHelper JavaScriptHelper { get; set; }

        public IPageInteractionHelper PageInteractionHelper { get; set; }

        public IWebDriverWaitHelper WebDriverWaitHelper { get; set; }

        public MongoDbConnectionHelper MongoDbConnectionHelper { get; set; }

        public IRetryHelper RetryHelper { get; set; }

        public ISqlDatabaseConnectionHelper SqlDatabaseConnectionHelper { get; set; }

        public TableRowHelper TableRowHelper { get; set; }
    }
}
