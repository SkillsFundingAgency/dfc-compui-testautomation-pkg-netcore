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

        public static IWebDriver Init(BrowserStackSetting options, EnvironmentConfig executionConfig)
        {
            CheckBrowserStackLogin(options);

            var chromeOption = new ChromeOptions
            {
                AcceptInsecureCertificates = true
            };
            AddAdditionalCapability(chromeOption, "browser", options.Browser);
            AddAdditionalCapability(chromeOption, "browser_version", options.BrowserVersion);
            AddAdditionalCapability(chromeOption, "os", options.Os);
            AddAdditionalCapability(chromeOption, "os_version", options.Osversion);
            AddAdditionalCapability(chromeOption, "resolution", options.Resolution);
            AddAdditionalCapability(chromeOption, "browserstack.user", options.BrowserStackUser);
            AddAdditionalCapability(chromeOption, "browserstack.key", options.BrowserStackKey);
            AddAdditionalCapability(chromeOption, "build", $"dfc.acceptance.{executionConfig.EnvironmentName.ToUpper()}.{options.BuildNumber}");
            AddAdditionalCapability(chromeOption, "project", options.Project);
            AddAdditionalCapability(chromeOption, "browserstack.debug", "true");
            AddAdditionalCapability(chromeOption, "name", options.Name);
            AddAdditionalCapability(chromeOption, "browserstack.networkLogs", options.EnableNetworkLogs);
            AddAdditionalCapability(chromeOption, "browserstack.timezone", options.TimeZone);
            AddAdditionalCapability(chromeOption, "browserstack.console", "info");

            return new RemoteWebDriver(new Uri(options.ServerName), chromeOption);
        }

        private static void CheckBrowserStackLogin(BrowserStackSetting options)
        {
            if (options.BrowserStackUser == null || options.BrowserStackKey == null)
                throw new Exception("Please enter browserstack credentials");
        }

        private static void AddAdditionalCapability(ChromeOptions chromeOptions, string capabilityName, object capabilityValue)
        {
            chromeOptions.AddAdditionalCapability(capabilityName, capabilityValue, true);
        }
    }
}
