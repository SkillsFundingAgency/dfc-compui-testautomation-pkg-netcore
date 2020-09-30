using DFC.TestAutomation.UI.Config;
using DFC.TestAutomation.UI.Extension;
using DFC.TestAutomation.UI.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class WebDriverConfigurator<T> : IWebDriverConfigurator where T : IConfiguration
    {
        private string ChromeDriverPath => GetWebDriverPathForExecutable("chromedriver.exe");
        private string FirefoxDriverPath => GetWebDriverPathForExecutable("geckodriver.exe");
        private string InternetExplorerDriverPath => GetWebDriverPathForExecutable("IEDriverServer");

        private ScenarioContext Context { get; set; }
        private ChromeOptions ChromeOptions { get; set; } = new ChromeOptions();
        private BrowserHelper BrowserHelper { get; set; }

        public WebDriverConfigurator(ScenarioContext scenarioContext)
        {
            this.Context = scenarioContext;

            var config = this.Context.GetConfiguration<T>();
            this.BrowserHelper = new BrowserHelper(this.Context.GetConfiguration<T>().Data.BrowserConfiguration.BrowserName);
            this.ChromeOptions = new ChromeOptions();
            ChromeOptions.AddArguments(this.Context.GetConfiguration<T>().Data.BrowserConfiguration.BrowserArguements);
        }

        private string GetWebDriverPathForExecutable(string executableName)
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
            switch(this.BrowserHelper.GetBrowserType())
            {
                case BrowserType.Chrome:
                    this.ChromeOptions.AddArguments(this.Context.GetConfiguration<T>().Data.BrowserConfiguration.BrowserArguements);

                    if (this.Context.GetConfiguration<T>().Data.BrowserConfiguration.UseProxy)
                    {
                        var proxy = this.Context.GetConfiguration<T>().Data.BrowserConfiguration.Proxy;

                        this.ChromeOptions.Proxy = new Proxy
                        {
                            HttpProxy = proxy,
                            SslProxy = proxy,
                            FtpProxy = proxy,
                        };
                    }

                    return new ChromeDriver(this.ChromeDriverPath, this.ChromeOptions);

                case BrowserType.Firefox:
                    return new FirefoxDriver(this.FirefoxDriverPath);

                case BrowserType.BrowserStack:
                    return new BrowserStackSetup<T>(this.Context.GetConfiguration<T>()).CreateRemoteWebDriver();

                case BrowserType.InternetExplorer:
                    return new InternetExplorerDriver(this.InternetExplorerDriverPath);

                default:
                    throw new ArgumentOutOfRangeException($"The WebDriverConfigurator class has not been updated to handle the web driver type '{this.BrowserHelper.GetBrowserType()}'. An update is required.");
            }
        }
    }
}
