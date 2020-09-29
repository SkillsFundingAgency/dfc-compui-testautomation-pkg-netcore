using System.Collections.Generic;

namespace DFC.TestAutomation.UI.Config
{
    public class BrowserConfiguration
    {
        public string BrowserName { get; set; }

        public string BrowserVersion { get; set; }

        public List<string> BrowserArguements { get; set; }

        public bool UseProxy { get; set; }

        public string Proxy { get; set; }
    }
}
