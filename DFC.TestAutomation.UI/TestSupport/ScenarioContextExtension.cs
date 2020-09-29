using DFC.TestAutomation.UI.Config;
using DFC.TestAutomation.UI.Helpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DFC.TestAutomation.UI.TestSupport
{
    public static class ScenarioContextExtension
    {
        #region Constants
        private const string ExploreCareersConfigKey = "explorecareersconfig";
        private const string HomepageConfigKey = "homepageconfig";
        private const string FindACourseConfigKey = "findacourseconfig";
        private const string FindACourseApiConfigKey = "findacourseapiconfig";
        private const string CompositeAppsConfigKey = "compositeappsconfig";
        private const string SkillsAssessmentConfigKey = "skillsassessmentconfig";
        private const string ContactUsConfigKey = "contactusconfig";
        private const string MatchYourSkillsToCareerConfigKey = "matchyourskillstocareerconfig";
        private const string MongoDbConfigKey = "mongodbconfig";
        private const string WebDriverKey = "webdriver";
        #endregion

        public static IConfigurator<IConfiguration> GetConfiguration(this ScenarioContext context)
        {
            return context.Get<IConfigurator<IConfiguration>>();
        }

        public static void SetConfiguration(this ScenarioContext context, IConfigurator<IConfiguration> configuration)
        {
            context.Set(configuration);
        }

        public static ObjectContext GetObjectContext(this ScenarioContext context)
        {
            return context.Get<ObjectContext>();
        }

        public static void SetObjectContext(this ScenarioContext context, ObjectContext objectContext)
        {
            context.Set<ObjectContext>(objectContext);
        }

        public static void SetExploreCareersConfig<T>(this ScenarioContext context, T value)
        {
            Set(context, value, ExploreCareersConfigKey);
        }

        public static void SetSkillsAssessmentConfig<T>(this ScenarioContext context, T value)
        {
            Set(context, value, SkillsAssessmentConfigKey);
        }

        public static void SetContactUsConfig<T>(this ScenarioContext context, T value)
        {
            Set(context, value, ContactUsConfigKey);
        }

        public static void SetFindACourseConfig<T>(this ScenarioContext context, T value)
        {
            Set(context, value, FindACourseConfigKey);
        }

        public static void SetCompositeAppsConfig<T>(this ScenarioContext context, T value)
        {
            Set(context, value, CompositeAppsConfigKey);
        }

        public static void SetFindACourseApiConfig<T>(this ScenarioContext context, T value)
        {
            Set(context, value, FindACourseApiConfigKey);
        }

        public static void SetHomepageConfig<T>(this ScenarioContext context, T value)
        {
            Set(context, value, HomepageConfigKey);
        }

        public static void SetMatchYourSkillsToCareer<T>(this ScenarioContext context, T value)
        {
            Set(context, value, MatchYourSkillsToCareerConfigKey);
        }

        public static T GetExploreCareersConfig<T>(this ScenarioContext context)
        {
            return Get<T>(context, ExploreCareersConfigKey);
        }

        public static T GetHomepageConfig<T>(this ScenarioContext context)
        {
            return Get<T>(context, HomepageConfigKey);
        }

        public static T GetFindACourseConfig<T>(this ScenarioContext context)
        {
            return Get<T>(context, FindACourseConfigKey);
        }

        public static T GetCompositeAppsConfig<T>(this ScenarioContext context)
        {
            return Get<T>(context, CompositeAppsConfigKey);
        }

        public static T GetFindACourseApiConfig<T>(this ScenarioContext context)
        {
            return Get<T>(context, FindACourseApiConfigKey);
        }

        public static T GetSkillsAssessmentConfig<T>(this ScenarioContext context)
        {
            return Get<T>(context, SkillsAssessmentConfigKey);
        }

        public static T GetContactUsConfig<T>(this ScenarioContext context)
        {
            return Get<T>(context, ContactUsConfigKey);
        }

        public static T GetMatchYourSkillsToCareerConfig<T>(this ScenarioContext context)
        {
            return Get<T>(context, MatchYourSkillsToCareerConfigKey);
        }

        public static void SetMongoDbConfig(this ScenarioContext context, MongoDatabaseConfiguration value)
        {
            Set(context, value, MongoDbConfigKey);
        }

        public static MongoDatabaseConfiguration GetMongoDbConfig(this ScenarioContext context)
        {
            return Get<MongoDatabaseConfiguration>(context, MongoDbConfigKey);
        }

        public static void SetWebDriver(this ScenarioContext context, IWebDriver webDriver)
        {
            Set(context, webDriver, WebDriverKey);
        }

        public static IWebDriver GetWebDriver(this ScenarioContext context)
        {
            return Get<IWebDriver>(context, WebDriverKey);
        }

        private static void Set<T>(ScenarioContext context, T value, string key)
        {
            context.Set(value, key);
        }

        public static T Get<T>(ScenarioContext context, string key)
        {
            return context.Get<T>(key);
        }
    }
}
