using System;

namespace DFC.TestAutomation.UI.Config
{
    public class BrowserStackConfiguration
    {
        public string BrowserStackUser { get; set; }

        public string BrowserStackKey { get; set; }

        public Uri ServerName { get; set; }
        
        public Uri AutomateSessions { get; set; }

        public bool EnableNetworkLogs { get; set; }

        internal string TimeZone { get; set; }

        internal string Name { get; set; }
    }
}
