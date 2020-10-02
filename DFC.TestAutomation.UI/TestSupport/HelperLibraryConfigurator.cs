// <copyright file="HelperLibraryConfigurator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using DFC.TestAutomation.UI.Extension;
using DFC.TestAutomation.UI.Helper;
using DFC.TestAutomation.UI.Settings;
using TechTalk.SpecFlow;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class HelperLibraryConfigurator<T> : IHelperLibraryConfigurator
        where T : IAppSettings
    {
        public HelperLibraryConfigurator(ScenarioContext context)
        {
            this.JavaScriptHelper = new JavaScriptHelper(context.GetWebDriver());
            this.WebDriverWaitHelper = new WebDriverWaitHelper(context.GetWebDriver(), context.GetSettingsLibrary<T>().TimeoutSettings, this.JavaScriptHelper);
            this.RetryHelper = new RetryHelper();
            this.AxeHelper = new AxeHelper(context.GetWebDriver());
            this.BrowserHelper = new BrowserHelper(context.GetSettingsLibrary<T>().BrowserSettings.BrowserName);
            this.FormCompletionHelper = new FormHelper(context.GetWebDriver(), this.WebDriverWaitHelper, this.RetryHelper, this.JavaScriptHelper);
            this.HttpRequestHelper = null;
            this.PageInteractionHelper = new CommonActionHelper(context.GetWebDriver(), this.WebDriverWaitHelper, this.RetryHelper);
            this.MongoDbConnectionHelper = new MongoDbConnectionHelper(context.GetSettingsLibrary<T>().MongoDatabaseSettings);
            this.SqlDatabaseConnectionHelper = new SqlDatabaseHelper("NEED A CONN STRING");
            this.ScreenshotHelper = new ScreenshotHelper(context);
        }

        public IJavaScriptHelper JavaScriptHelper { get; set; }

        public IWebDriverWaitHelper WebDriverWaitHelper { get; set; }

        public IAxeHelper AxeHelper { get; set; }

        public IRetryHelper RetryHelper { get; set; }

        public IBrowserHelper BrowserHelper { get; set; }

        public IFormHelper FormCompletionHelper { get; set; }

        public IHttpRequestHelper HttpRequestHelper { get; set; }

        public ICommonActionHelper PageInteractionHelper { get; set; }

        public IMongoDbConnectionHelper MongoDbConnectionHelper { get; set; }

        public IScreenshotHelper ScreenshotHelper { get; set; }

        public ISqlDatabaseHelper SqlDatabaseConnectionHelper { get; set; }

        public IHelperLibrary CreateHelperLibrary()
        {
            return new HelperLibrary(
                this.JavaScriptHelper,
                this.WebDriverWaitHelper,
                this.RetryHelper,
                this.AxeHelper,
                this.BrowserHelper,
                this.FormCompletionHelper,
                this.HttpRequestHelper,
                this.PageInteractionHelper,
                this.MongoDbConnectionHelper,
                this.ScreenshotHelper,
                this.SqlDatabaseConnectionHelper);
        }
    }
}