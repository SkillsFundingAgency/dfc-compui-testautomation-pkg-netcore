using DFC.TestAutomation.UI.Config;
using DFC.TestAutomation.UI.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class WebDriverConfigurator
    {
        private string BrowserName { get; set; }

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

        public WebDriverConfigurator(string browserName)
        {
            BrowserName = browserName.ToLower().Trim();

            if(!BrowserIndex.ContainsKey(BrowserName))
            {
                throw new InvalidOperationException($"Unable to initialise the WebDriverConfigurator class as the browser '{browserName}' was not recognised.");
            }
        }

        public WebDriverConfigurator(string browserName, ChromeOptions chromeOptions)
        {
            
        }

        public WebDriverConfigurator(string browserName, ChromeOptions chromeOptions)
        {

        }

        public IWebDriver Create<T>(ChromeOptions options = null, BrowserStackSetting browserStackSetting = null, EnvironmentConfig environmentConfig = null)
        {
            switch(BrowserIndex[BrowserName])
            {
                case WebDriverType.Chrome:
                    return new ChromeDriver();

                case WebDriverType.Firefox:
                    return new FirefoxDriver();

                case WebDriverType.BrowserStack:
                    return BrowserStackSetup.Init(browserStackSetting, environmentConfig);

                case WebDriverType.InternetExplorer:
                    break;

                default:
                    throw new ArgumentOutOfRangeException($"The WebDriverConfigurator class has not been updated to handle the web driver type '{BrowserIndex[BrowserName]}'. An update is required.");
            }

            return new ChromeDriver();
        }
    }
}
