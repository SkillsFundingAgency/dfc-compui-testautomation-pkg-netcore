using DFC.TestAutomation.UI.Settings;
using DFC.TestAutomation.UI.Extension;
using DFC.TestAutomation.UI.Helper;
using TechTalk.SpecFlow;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class HelperLibraryConfigurator<T> : IHelperLibraryConfigurator where T : IAppSettings
    {
        public IJavaScriptHelper JavaScriptHelper { get; set; }

        public IWebDriverWaitHelper WebDriverWaitHelper { get; set; }

        public IAxeHelper AxeHelper { get; set; }

        public IRetryHelper RetryHelper { get; set; }

        public IBrowserHelper BrowserHelper { get; set; }

        public IFormCompletionHelper FormCompletionHelper { get; set; }

        public IHttpClientRequestHelper HttpClientRequestHelper { get; set; }

        public IPageInteractionHelper PageInteractionHelper { get; set; }

        public IMongoDbConnectionHelper MongoDbConnectionHelper { get; set; }

        public IScreenshotHelper ScreenshotHelper { get; set; }

        public ISqlDatabaseConnectionHelper SqlDatabaseConnectionHelper { get; set; }

        public HelperLibraryConfigurator(ScenarioContext context)
        {
            this.JavaScriptHelper = new JavaScriptHelper(context.GetWebDriver());
            this.WebDriverWaitHelper = new WebDriverWaitHelper(context.GetWebDriver(), context.GetConfiguration<T>().TimeoutSettings, this.JavaScriptHelper);
            this.RetryHelper = new RetryHelper();
            this.AxeHelper = new AxeHelper(context.GetWebDriver());
            this.BrowserHelper = new BrowserHelper(context.GetConfiguration<T>().BrowserSettings.BrowserName);
            this.FormCompletionHelper = new FormCompletionHelper(context.GetWebDriver(), this.WebDriverWaitHelper, this.RetryHelper, this.JavaScriptHelper);
            this.HttpClientRequestHelper = new HttpClientRequestHelper("NEED AN ACCESS TOKEN");
            this.PageInteractionHelper = new PageInteractionHelper(context.GetWebDriver(), this.WebDriverWaitHelper, this.RetryHelper);
            this.MongoDbConnectionHelper = new MongoDbConnectionHelper(context.GetConfiguration<T>().MongoDatabaseSettings);
            this.SqlDatabaseConnectionHelper = new SqlDatabaseConnectionHelper("NEED A CONN STRING");
            this.ScreenshotHelper = new ScreenshotHelper(context);
        }

        public IHelperLibrary CreateHelperLibrary()
        {
            return new HelperLibrary(
                this.JavaScriptHelper,
                this.WebDriverWaitHelper,
                this.RetryHelper,
                this.AxeHelper,
                this.BrowserHelper,
                this.FormCompletionHelper,
                this.HttpClientRequestHelper,
                this.PageInteractionHelper,
                this.MongoDbConnectionHelper,
                this.ScreenshotHelper,
                this.SqlDatabaseConnectionHelper);
        }
    }
}