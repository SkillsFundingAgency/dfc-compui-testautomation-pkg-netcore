using DFC.TestAutomation.UI.Config;
using DFC.TestAutomation.UI.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class WebDriverConfigurator
    {
        private string ChromeDriverPath => GetWebDriverPathForExecutable("chromedriver.exe");
        private string FirefoxDriverPath => GetWebDriverPathForExecutable("geckodriver.exe");
        private string InternetExplorerDriverPath => GetWebDriverPathForExecutable("IEDriverServer");

        private string BrowserName { get; set; }
        private BrowserStackSetting BrowserStackSetting { get; set; }
        private EnvironmentConfig EnvironmentConfig { get; set; }
        private ChromeOptions ChromeOptions { get; set; } = new ChromeOptions();

        private Dictionary<string, WebDriverType> BrowserIndex = new Dictionary<string, WebDriverType>()
        {
            { "browserstack", WebDriverType.BrowserStack },
            { "cloud", WebDriverType.BrowserStack },
            { "zapProxyChrome", WebDriverType.Chrome },
            { "ie", WebDriverType.InternetExplorer },
            { "internetexplorer", WebDriverType.InternetExplorer },
            { "firefox", WebDriverType.Firefox },
            { "mozillafirefox", WebDriverType.Firefox },
            { "chrome", WebDriverType.Chrome },
            { "googlechrome", WebDriverType.Chrome },
            { "local", WebDriverType.Chrome },
            { "chromeheadless", WebDriverType.Chrome },
            { "headlessbrowser", WebDriverType.Chrome },
            { "headless", WebDriverType.Chrome }
        };

        public WebDriverConfigurator(IConfigurator<IConfiguration> configuration)
        {
            this.EnvironmentConfig = configuration.Data.EnvironmentConfig;
            this.BrowserStackSetting = configuration.Data.BrowserStackConfig;
            this.BrowserName = configuration.Data.ProjectConfig.Browser.ToLower().Trim();
            this.ChromeOptions = chromeOptions;

            if (!this.BrowserIndex.ContainsKey(this.BrowserName))
            {
                throw new InvalidOperationException($"Unable to initialise the WebDriverConfigurator class as the browser '{this.BrowserName}' was not recognised.");
            }
        }

        private static string GetWebDriverPathForExecutable(string executableName)
        {
            if (executableName == null)
            {
                throw new NullReferenceException("The executable name parameter must be set.");
            }

            executableName = executableName.Replace(".exe", string.Empty, StringComparison.CurrentCulture);
            string driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            FileInfo[] file = Directory.GetParent(driverPath).GetFiles($"{executableName}.exe", SearchOption.AllDirectories);
            var info = file.Length != 0 ? file[0].DirectoryName : driverPath;
            return info;
        }

        public IWebDriver Create()
        {
            switch(this.BrowserIndex[this.BrowserName])
            {
                case WebDriverType.Chrome:
                    this.ChromeOptions.AddArgument("no-sandbox");

                    if (this.BrowserName.Contains("headless"))
                    {
                        this.ChromeOptions.AddArgument("--headless");
                    }

                    if (this.BrowserName.Contains("zap"))
                    {
                        if(this.ChromeOptions.Proxy == null)
                        {
                            this.ChromeOptions.Proxy = new Proxy
                            {
                                HttpProxy = "localhost:8080",
                                SslProxy = "localhost:8080",
                                FtpProxy = "localhost:8080",
                            };
                        }
                    }

                    return new ChromeDriver(this.ChromeDriverPath, this.ChromeOptions);

                case WebDriverType.Firefox:
                    return new FirefoxDriver(this.FirefoxDriverPath);

                case WebDriverType.BrowserStack:
                    if(this.BrowserStackSetting == null)
                    {
                        throw new NullReferenceException("Unable to obtain the browserstack settings. This should not have happened and requires investigation.");
                    }

                    if (this.EnvironmentConfig == null)
                    {
                        throw new NullReferenceException("Unable to obtain the environment settings. This should not have happened and requires investigation.");
                    }

                    return BrowserStackSetup.Init(this.BrowserStackSetting, this.EnvironmentConfig);

                case WebDriverType.InternetExplorer:
                    return new InternetExplorerDriver(this.InternetExplorerDriverPath);

                default:
                    throw new ArgumentOutOfRangeException($"The WebDriverConfigurator class has not been updated to handle the web driver type '{BrowserIndex[BrowserName]}'. An update is required.");
            }
        }
    }
}
