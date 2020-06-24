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
        private readonly IConfigSection _configSection;

        public ContactUsConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            Configurator.InitializeHostingConfig("appsettings.Environment.json");
            Configurator.InitializeConfig(new[] { "appsettings.json", "appsettings.Project.json", "appsettings.local.Project.json", "appsettings.local.json", "appsettings.RestApi.json" });
            _configSection = new ConfigSection(Configurator.GetConfig());
        }

        [BeforeScenario(Order = 1)]
        public void SetUpConfiguration()
        {
            _context.Set(_configSection);

            var configuration = new FrameworkConfig
            {
                TimeOutConfig = _configSection.GetConfigSection<TimeOutConfig>(),
                BrowserStackSetting = _configSection.GetConfigSection<BrowserStackSetting>(),
                TakeEveryPageScreenShot = Configurator.IsVstsExecution
            };

            _context.Set(configuration);

            var executionConfig = new EnvironmentConfig { EnvironmentName = Configurator.EnvironmentName, ProjectName = Configurator.ProjectName };

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
