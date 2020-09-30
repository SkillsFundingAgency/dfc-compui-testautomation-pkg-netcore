using DFC.TestAutomation.UI.Config;

namespace DFC.TestAutomation.UI.Helper
{
    public class HelperLibrary<T> : IHelperLibrary where T : IConfiguration
    {
        public HelperLibrary(IJavaScriptHelper javascriptHelper, IWebDriverWaitHelper webDriverWaitHelper, IRetryHelper retryHelper,
            IAxeHelper axeHelper, IBrowserHelper browserHelper, FormCompletionHelper formCompletionHelper, HttpClientRequestHelper httpClientRequestHelper,
            IPageInteractionHelper pageInteractionHelper, MongoDatabaseConfiguration mongoDatabaseConfiguration, RegexHelper regexHelper,
            SqlDatabaseConnectionHelper sqlDatabaseConnectionHelper, TableRowHelper tableRowHelper)
        {
            this.JavaScriptHelper = javascriptHelper;
            this.WebDriverWaitHelper = webDriverWaitHelper;
            this.RetryHelper = retryHelper;
            this.AxeHelper = axeHelper;
            this.BrowserHelper = browserHelper;
            this.FormCompletionHelper = formCompletionHelper;
            this.HttpClientRequestHelper = httpClientRequestHelper;
            this.PageInteractionHelper = pageInteractionHelper;
            this.MongoDbConnectionHelper = MongoDbConnectionHelper;
            this.RegexHelper = regexHelper;
            this.SqlDatabaseConnectionHelper = sqlDatabaseConnectionHelper;
            this.TableRowHelper = tableRowHelper;
        }

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
