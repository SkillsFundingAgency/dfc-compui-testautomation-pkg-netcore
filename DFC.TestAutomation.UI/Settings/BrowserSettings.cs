using System;

namespace DFC.TestAutomation.UI.Settings
{
    public class BrowserSettings
    {
        public string BrowserName { get; set; }

        public string BrowserVersion { get; set; }

        public BrowserArguements BrowserArguements { get; set; }

        public bool UseProxy { get; set; }

        public Uri Proxy { get; set; }
    }
}
