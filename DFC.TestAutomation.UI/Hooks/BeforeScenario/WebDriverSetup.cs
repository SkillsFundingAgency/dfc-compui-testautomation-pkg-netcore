using DFC.TestAutomation.UI.Config;
using DFC.TestAutomation.UI.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace DFC.TestAutomation.UI.Hooks.BeforeScenario
{
    [Binding]
    public class WebDriverSetup
    {
        private readonly string DriverPath;

        private IWebDriver WebDriver;

        private readonly ScenarioContext _context;

        private readonly ObjectContext _objectContext;

        private readonly BrowserStackConfiguration _browserStackConfig;

        private readonly TimeoutConfiguration _timeoutConfig;

        private readonly EnvironmentConfiguration _executionConfig;

        private const string ChromeDriverServiceName = "chromedriver.exe";

        private const string FirefoxDriverServiceName = "geckodriver.exe";

        private const string InternetExplorerDriverServiceName = "IEDriverServer.exe";

        public WebDriverSetup(ScenarioContext context)
        {
            DriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _browserStackConfig = context.Get<BrowserStackConfiguration>();
            _timeoutConfig = context.Get<TimeoutConfiguration>();
            _executionConfig = context.Get<EnvironmentConfiguration>();
        }

        public static string FindDriverService(string executableName)
        {
            string driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            FileInfo[] file = Directory.GetParent(driverPath).GetFiles(executableName, SearchOption.AllDirectories);
            var info = file.Length != 0 ? file[0].DirectoryName : driverPath;
            return info;
        }

        private void InitialiseZapProxyChrome()
        {
            const string PROXY = "localhost:8080";
            var chromeOptions = new ChromeOptions();
            var proxy = new Proxy
            {
                HttpProxy = PROXY,
                SslProxy = PROXY,
                FtpProxy = PROXY
            };
            chromeOptions.Proxy = proxy;

            WebDriver = new ChromeDriver(FindDriverService(ChromeDriverServiceName), chromeOptions);
        }

        private ChromeDriver ChromeDriver(List<string> arguments)
        {
            arguments.Add("no-sandbox");
            return new ChromeDriver(FindDriverService(ChromeDriverServiceName),
                                                 AddArguments(arguments),
                                                 TimeSpan.FromMinutes(this._timeoutConfig.CommandTimeout));
        }

        private ChromeOptions AddArguments(List<string> arguments)
        {
            var chromeOptions = new ChromeOptions();
            arguments.ForEach((x) => chromeOptions.AddArgument(x));
            return chromeOptions;
        }
    }
}
