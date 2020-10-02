using DFC.TestAutomation.UI.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class BrowserStackConfigurator<T> : IBrowserStackConfigurator where T : IAppSettings
    {
        private BrowserStackSettings BrowserStackConfiguration { get; set; }
        private BrowserSettings BrowserConfiguration { get; set; }
        private EnvironmentSettings EnvironmentConfiguration { get; set; }
        private BuildSettings BuildConfiguration { get; set; }
        private T ProjectConfiguration { get; set; }

        public BrowserStackConfigurator(ISettingsLibrary<T> configuration)
        {
            this.BrowserStackConfiguration = configuration.BrowserStackSettings;
            this.BrowserConfiguration = configuration.BrowserSettings;
            this.EnvironmentConfiguration = configuration.EnvironmentSettings;
            this.BuildConfiguration = configuration.BuildSettings;
            this.ProjectConfiguration = configuration.AppSettings;

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
