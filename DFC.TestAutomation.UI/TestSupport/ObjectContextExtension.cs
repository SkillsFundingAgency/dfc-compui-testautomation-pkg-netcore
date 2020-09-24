using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.TestAutomation.UI.TestSupport
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string BrowserKey = "browser";
        private const string DirectoryKey = "directory";
        private const string FileKey = "file";
        private const string AfterScenarioExceptions = "afterscenarioexceptions";
        private const string BrowserNameKey = "browsername";
        private const string BrowserVersionKey = "browserVersion";
        private const string BrowserstackFailedToUpdateTestResult = "browserstackfailedtoupdatetestresult";
        private const string WebDriverUrl = "webdriverurl";
        #endregion

        public static string GetBrowser(this ObjectContext objectContext)
        {
            return objectContext.Get(BrowserKey);
        }

        public static void SetBrowser(this ObjectContext objectContext, string browser)
        {
            objectContext.Set(BrowserKey, browser);
        }

        public static void SetDirectory(this ObjectContext objectContext, string value)
        {
            objectContext.Set(DirectoryKey, value);
        }

        public static void SetFile(this ObjectContext objectContext, string value)
        {
            objectContext.Set(FileKey, value);
        }

        public static void SetBrowserName(this ObjectContext objectContext, object value)
        {
            objectContext.Set(BrowserNameKey, value);
        }

        public static void SetBrowserVersion(this ObjectContext objectContext, object value)
        {
            objectContext.Set(BrowserVersionKey, value);
        }

        public static string GetDirectory(this ObjectContext objectContext)
        {
            return objectContext.Get(DirectoryKey);
        }

        public static string GetFile(this ObjectContext objectContext)
        {
            return objectContext.Get(FileKey);
        }

        public static string GetUrl(this ObjectContext objectContext)
        {
            return objectContext.Get(WebDriverUrl);
        }

        public static void SetUrl(this ObjectContext objectContext, string value)
        {
            objectContext.Set(WebDriverUrl, value);
        }

        public static void SetBrowserstackResponse(this ObjectContext objectContext)
        {
            objectContext.Set(BrowserstackFailedToUpdateTestResult, true);
        }

        public static bool FailedtoUpdateTestResultInBrowserStack(this ObjectContext objectContext)
        {
            return objectContext.KeyExists<bool>(BrowserstackFailedToUpdateTestResult);
        }

        public static void SetAfterScenarioException(this ObjectContext objectContext, Exception value)
        {
            var exceptions = objectContext.GetAfterScenarioExceptions();
            exceptions.Add(value);
        }

        public static void SetAfterScenarioExceptions(this ObjectContext objectContext, List<Exception> afterscenarioexceptions)
        {
            objectContext.Set(AfterScenarioExceptions, afterscenarioexceptions);
        }

        public static List<Exception> GetAfterScenarioExceptions(this ObjectContext objectContext)
        {
            return objectContext.Get<List<Exception>>(AfterScenarioExceptions);
        }
    }
}
