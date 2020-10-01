using DFC.TestAutomation.UI.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class BrowserStackConfigurator<T> : IBrowserStackConfigurator where T : IConfiguration
    {
        private BrowserStackConfiguration BrowserStackConfiguration { get; set; }
        private BrowserConfiguration BrowserConfiguration { get; set; }
        private EnvironmentConfiguration EnvironmentConfiguration { get; set; }
        private BuildConfiguration BuildConfiguration { get; set; }
        private ProjectConfiguration ProjectConfiguration { get; set; }

        public BrowserStackConfigurator(IConfigurator<T> configuration)
        {
            this.BrowserStackConfiguration = configuration.Data.BrowserStackConfiguration;
            this.BrowserConfiguration = configuration.Data.BrowserConfiguration;
            this.EnvironmentConfiguration = configuration.Data.EnvironmentConfiguration;
            this.BuildConfiguration = configuration.Data.BuildConfiguration;
            this.ProjectConfiguration = configuration.Data.ProjectConfiguration;

            if(BrowserStackConfiguration.BrowserStackUsername == null || BrowserStackConfiguration.BrowserStackPassword == null)
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
            chromeOptions.AddAdditionalCapability("browserstack.user", this.BrowserStackConfiguration.BrowserStackUsername, true);
            chromeOptions.AddAdditionalCapability("browserstack.key", this.BrowserStackConfiguration.BrowserStackPassword, true);
            chromeOptions.AddAdditionalCapability("build", $"dfc.acceptance.{this.EnvironmentConfiguration.EnvironmentName.ToUpper()}.{this.BuildConfiguration.BuildNumber}", true);
            chromeOptions.AddAdditionalCapability("project", this.ProjectConfiguration.AppName, true);
            chromeOptions.AddAdditionalCapability("browserstack.debug", "true", true);
            chromeOptions.AddAdditionalCapability("browserstack.networkLogs", this.BrowserStackConfiguration.EnableNetworkLogs, true);
            chromeOptions.AddAdditionalCapability("browserstack.timezone", this.BrowserStackConfiguration.Timezone, true);
            chromeOptions.AddAdditionalCapability("browserstack.console", "info", true);

            return new RemoteWebDriver(this.BrowserStackConfiguration.RemoteAddressUri, chromeOptions);
        }
    }
}
