# National Careers Service - UI Automation Framework
This is a SpecFlow-Selenium functional testing framework created using Selenium WebDriver with NUnit and C# in SpecFlow BDD methodology and Page Object Pattern.

# Initialisation

The various configuration frameworks are intialised by supplying appsetting.json files containing the required values

# Example Usage

```
[Binding]
    public class ContactUsConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        //private readonly IConfigurationRoot _configurationRoot;
        //private readonly IConfigSection _configSection;
        private readonly Configurator _configurator;
        private readonly IConfigSection _configSection;

        public ContactUsConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _configurator = new Configurator();
            _configurator.InitializeHostingConfig("appsettings.Environment.json");

            _configurator.AddSettingsFile("appsettings.json")
                         .AddSettingsFile("appsettings.Project.json")
                         .AddSettingsFile("appsettings.local.Project.json")
                         .AddSettingsFile("appsettings.local.json")
                         .AddSettingsFile("appsettings.RestApi.json")
                         .BuildConfig();

            _configSection = new ConfigSection(_configurator.GetConfig());

        }

        [BeforeScenario(Order = 1)]
        public void SetUpConfiguration()
        {
            _context.Set(_configSection);

            var configuration = new FrameworkConfig
            {
                TimeOutConfig = _configSection.GetConfigSection<TimeOutConfig>(),
                BrowserStackSetting = _configSection.GetConfigSection<BrowserStackSetting>(),
                TakeEveryPageScreenShot = _configurator.IsVstsExecution
            };

            _context.Set(configuration);

            var executionConfig = new EnvironmentConfig { EnvironmentName = _configurator.EnvironmentName, ProjectName = _configurator.ProjectName };

            _context.Set(executionConfig);

            var testExecutionConfig = _configSection.GetConfigSection<TestExecutionConfig>();

            _objectContext.SetBrowser(testExecutionConfig.Browser);

            var config = _configSection.GetConfigSection<ContactUs>();
            _context.SetContactUsConfig(config);

            var mongoDbconfig = _configSection.GetConfigSection<MongoDbConfig>();
            _context.SetMongoDbConfig(mongoDbconfig);

            _objectContext.Replace("browser", config.Browser);
            _objectContext.Replace("build", config.BuildNumber);
            _objectContext.Replace("EnvironmentName", config.EnvironmentName);
            
            
        }
    }
```
