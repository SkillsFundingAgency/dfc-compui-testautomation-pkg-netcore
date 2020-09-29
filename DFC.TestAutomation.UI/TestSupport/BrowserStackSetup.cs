using DFC.TestAutomation.UI.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class BrowserStackSetup
    {

        static BrowserStackSetup()
        {
        }

        public static IWebDriver Init(IConfigurator<IConfiguration> configuration)
        {
            var browserStackConfig = configuration.Data.BrowserStackConfiguration;
            var browserConfig = configuration.Data.BrowserConfiguration;
            var environmentConfig = configuration.Data.EnvironmentConfiguration;
            var buildConfig = configuration.Data.BuildConfiguration;
            var projectConfig = configuration.Data.ProjectConfiguration;

            CheckBrowserStackLogin(browserStackConfig.BrowserStackUser, browserStackConfig.BrowserStackKey);

            var chromeOption = new ChromeOptions
            {
                AcceptInsecureCertificates = true
            };
            AddAdditionalCapability(chromeOption, "browser", browserConfig.BrowserName);
            AddAdditionalCapability(chromeOption, "browser_version", browserConfig.BrowserVersion);
            AddAdditionalCapability(chromeOption, "os", environmentConfig.OperatingSystem);
            AddAdditionalCapability(chromeOption, "os_version", environmentConfig.OperatingSystemVersion);
            AddAdditionalCapability(chromeOption, "resolution", environmentConfig.ScreenResolution);
            AddAdditionalCapability(chromeOption, "browserstack.user", browserStackConfig.BrowserStackUser);
            AddAdditionalCapability(chromeOption, "browserstack.key", browserStackConfig.BrowserStackKey);
            AddAdditionalCapability(chromeOption, "build", $"dfc.acceptance.{environmentConfig.EnvironmentName.ToUpper()}.{buildConfig.BuildNumber}");
            AddAdditionalCapability(chromeOption, "project", projectConfig.ProjectName);
            AddAdditionalCapability(chromeOption, "browserstack.debug", "true");
            AddAdditionalCapability(chromeOption, "name", browserStackConfig.Name);
            AddAdditionalCapability(chromeOption, "browserstack.networkLogs", browserStackConfig.EnableNetworkLogs);
            AddAdditionalCapability(chromeOption, "browserstack.timezone", browserStackConfig.TimeZone);
            AddAdditionalCapability(chromeOption, "browserstack.console", "info");

            return new RemoteWebDriver(browserStackConfig.ServerName, chromeOption);
        }

        private static void CheckBrowserStackLogin(string browserStackUser, string browserStackKey)
        {
            if (browserStackUser == null || browserStackKey == null)
                throw new Exception("Please enter browserstack credentials");
        }

        private static void AddAdditionalCapability(ChromeOptions chromeOptions, string capabilityName, object capabilityValue)
        {
            chromeOptions.AddAdditionalCapability(capabilityName, capabilityValue, true);
        }
    }
}
