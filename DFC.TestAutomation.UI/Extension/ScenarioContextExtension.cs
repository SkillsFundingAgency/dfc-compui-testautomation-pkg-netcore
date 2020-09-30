using DFC.TestAutomation.UI.Config;
using DFC.TestAutomation.UI.Helper;
using DFC.TestAutomation.UI.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DFC.TestAutomation.UI.Extension
{
    public static class ScenarioContextExtension
    {
        public static ObjectContext GetObjectContext(this ScenarioContext context)
        {
            return context.Get<ObjectContext>();
        }

        public static void SetObjectContext(this ScenarioContext context, ObjectContext objectContext)
        {
            context.Set(objectContext);
        }

        public static IWebDriver GetWebDriver(this ScenarioContext context)
        {
            return context.Get<IWebDriver>();
        }

        public static void SetWebDriver(this ScenarioContext context, IWebDriver webDriver)
        {
            context.Set(webDriver);
        }

        public static IConfigurator<T> GetConfiguration<T>(this ScenarioContext context) where T : IConfiguration
        {
            return context.Get<IConfigurator<T>>();
        }

        public static void SetConfiguration<T>(this ScenarioContext context, IConfigurator<T> configuration) where T : IConfiguration
        {
            context.Set(configuration);
        }

        public static IJavaScriptHelper GetJavascriptHelper(this ScenarioContext context)
        {
            return context.Get<IJavaScriptHelper>();
        }

        public static void SetJavascriptHelper(this ScenarioContext context, IJavaScriptHelper javascriptHelper)
        {
            context.Set(javascriptHelper);
        }
    }
}
