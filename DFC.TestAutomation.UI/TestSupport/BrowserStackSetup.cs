using DFC.TestAutomation.UI.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class BrowserStackSetup<T> : IBrowserStackSetup where T : IConfiguration
    {
        private BrowserStackConfiguration BrowserStackConfiguration { get; set; }
        private BrowserConfiguration BrowserConfiguration { get; set; }
        private EnvironmentConfiguration EnvironmentConfiguration { get; set; }
        private BuildConfiguration BuildConfiguration { get; set; }
        private ProjectConfiguration ProjectConfiguration { get; set; }

        public BrowserStackSetup(IConfigurator<T> configuration)
        {
            this.BrowserStackConfiguration = configuration.Data.BrowserStackConfiguration;
            this.BrowserConfiguration = configuration.Data.BrowserConfiguration;
            this.EnvironmentConfiguration = configuration.Data.EnvironmentConfiguration;
            this.BuildConfiguration = configuration.Data.BuildConfiguration;
            this.ProjectConfiguration = configuration.Data.ProjectConfiguration;

            if(BrowserStackConfiguration.BrowserStackUser == null || BrowserStackConfiguration.BrowserStackKey == null)
            {
                throw new Exception("Unable to initialise the BrowserStackSetup class as the settings do not contain a Browserstack username and/or password. You can set this configuration in the appsettings.json file.");
            }
        }

        public IWebDriver CreateRemoteWebDriver()
        {
            var chromeOptions = new ChromeOptions
            {
                AcceptInsecureCertificates = true
            };

            chromeOptions.AddAdditionalCapability("browser", this.BrowserConfiguration.BrowserName, true);
            chromeOptions.AddAdditionalCapability("browser_version", this.BrowserConfiguration.BrowserVersion, true);
            chromeOptions.AddAdditionalCapability("os", this.EnvironmentConfiguration.OperatingSystem, true);
            chromeOptions.AddAdditionalCapability("os_version", this.EnvironmentConfiguration.OperatingSystemVersion, true);
            chromeOptions.AddAdditionalCapability("resolution", this.EnvironmentConfiguration.ScreenResolution, true);
            chromeOptions.AddAdditionalCapability("browserstack.user", this.BrowserStackConfiguration.BrowserStackUser, true);
            chromeOptions.AddAdditionalCapability("browserstack.key", this.BrowserStackConfiguration.BrowserStackKey, true);
            chromeOptions.AddAdditionalCapability("build", $"dfc.acceptance.{this.EnvironmentConfiguration.EnvironmentName.ToUpper()}.{this.BuildConfiguration.BuildNumber}", true);
            chromeOptions.AddAdditionalCapability("project", this.ProjectConfiguration.ProjectName, true);
            chromeOptions.AddAdditionalCapability("browserstack.debug", "true", true);
            chromeOptions.AddAdditionalCapability("name", this.BrowserStackConfiguration.Name, true);
            chromeOptions.AddAdditionalCapability("browserstack.networkLogs", this.BrowserStackConfiguration.EnableNetworkLogs, true);
            chromeOptions.AddAdditionalCapability("browserstack.timezone", this.BrowserStackConfiguration.TimeZone, true);
            chromeOptions.AddAdditionalCapability("browserstack.console", "info", true);

            return new RemoteWebDriver(this.BrowserStackConfiguration.ServerName, chromeOptions);
        }
    }
}
