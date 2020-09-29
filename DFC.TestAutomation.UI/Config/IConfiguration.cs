using DFC.TestAutomation.UI.Helpers;

namespace DFC.TestAutomation.UI.Config
{
    public interface IConfiguration
    {
        ProjectConfig ProjectConfig { get; set; }

        TimeOutConfig TimeOutConfig { get; set; }

        BrowserStackSetting BrowserStackConfig { get; set; }

        EnvironmentConfig EnvironmentConfig { get; set; }

        TestExecutionConfig TestExecutionConfig { get; set; }

        MongoDbConfig MongoDbConfig { get; set; }
    }
}
