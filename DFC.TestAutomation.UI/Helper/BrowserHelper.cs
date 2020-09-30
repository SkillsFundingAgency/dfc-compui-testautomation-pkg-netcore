using System;
using System.Collections.Generic;
using DFC.TestAutomation.UI.Extension;

namespace DFC.TestAutomation.UI.Helper
{
    public class BrowserHelper : IBrowserHelper
    {
        private string BrowserName { get; set; }

        private Dictionary<string, BrowserType> BrowserIndex = new Dictionary<string, BrowserType>()
        {
            { "browserstack", BrowserType.BrowserStack },
            { "cloud", BrowserType.BrowserStack },
            { "zapProxyChrome", BrowserType.Chrome },
            { "ie", BrowserType.InternetExplorer },
            { "internetexplorer", BrowserType.InternetExplorer },
            { "firefox", BrowserType.Firefox },
            { "mozillafirefox", BrowserType.Firefox },
            { "chrome", BrowserType.Chrome },
            { "googlechrome", BrowserType.Chrome },
            { "local", BrowserType.Chrome },
            { "chromeheadless", BrowserType.Chrome },
            { "headlessbrowser", BrowserType.Chrome },
            { "headless", BrowserType.Chrome }
        };

        public BrowserHelper(string browserName)
        {
            this.BrowserName = browserName.ToLower().Trim();

            if (!this.BrowserIndex.ContainsKey(this.BrowserName))
            {
                throw new InvalidOperationException($"Unable to initialise the BrowserHelper class as the browser '{this.BrowserName}' was not recognised.");
            }
        }

        public BrowserType GetBrowserType()
        {
            return this.BrowserIndex[this.BrowserName];
        }

        public bool IsExecutingInTheCloud()
        {
            return this.BrowserName.CompareToIgnoreCase("browserstack") || this.BrowserName.CompareToIgnoreCase("cloud");
        }
    }
}
