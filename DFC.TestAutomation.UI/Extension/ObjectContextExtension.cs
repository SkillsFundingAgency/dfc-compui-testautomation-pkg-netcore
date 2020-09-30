using DFC.TestAutomation.UI.TestSupport;
using System;
using System.Collections.Generic;

namespace DFC.TestAutomation.UI.Extension
{
    public static class ObjectContextExtension
    {
        public static string GetBrowser(this ObjectContext objectContext)
        {
            return objectContext.Get("browser");
        }

        public static void SetBrowser(this ObjectContext objectContext, string browser)
        {
            objectContext.Set("browser", browser);
        }

        public static void SetDirectory(this ObjectContext objectContext, string value)
        {
            objectContext.Set("directory", value);
        }

        public static void SetFile(this ObjectContext objectContext, string value)
        {
            objectContext.Set("file", value);
        }

        public static void SetBrowserName(this ObjectContext objectContext, object value)
        {
            objectContext.Set("browsername", value);
        }

        public static void SetBrowserVersion(this ObjectContext objectContext, object value)
        {
            objectContext.Set("browserVersion", value);
        }

        public static string GetDirectory(this ObjectContext objectContext)
        {
            return objectContext.Get("directory");
        }

        public static string GetFile(this ObjectContext objectContext)
        {
            return objectContext.Get("file");
        }

        public static string GetUrl(this ObjectContext objectContext)
        {
            return objectContext.Get("webdriverurl");
        }

        public static void SetUrl(this ObjectContext objectContext, string value)
        {
            objectContext.Set("webdriverurl", value);
        }

        public static void SetBrowserstackResponse(this ObjectContext objectContext)
        {
            objectContext.Set("browserstackfailedtoupdatetestresult", true);
        }

        public static bool FailedtoUpdateTestResultInBrowserStack(this ObjectContext objectContext)
        {
            return objectContext.KeyExists<bool>("browserstackfailedtoupdatetestresult");
        }

        public static void SetAfterScenarioException(this ObjectContext objectContext, Exception value)
        {
            var exceptions = objectContext.GetAfterScenarioExceptions();
            exceptions.Add(value);
        }

        public static void SetAfterScenarioExceptions(this ObjectContext objectContext, List<Exception> afterscenarioexceptions)
        {
            objectContext.Set("afterscenarioexceptions", afterscenarioexceptions);
        }

        public static List<Exception> GetAfterScenarioExceptions(this ObjectContext objectContext)
        {
            return objectContext.Get<List<Exception>>("afterscenarioexceptions");
        }
    }
}
