using System;

namespace DFC.TestAutomation.UI.Config
{
    public class BrowserStackConfiguration
    {
        public string BrowserStackUsername { get; set; }

        public string BrowserStackPassword { get; set; }

        public Uri RemoteAddressUri { get; set; }
        
        public Uri BaseUri { get; set; }

        public bool EnableNetworkLogs { get; set; }

        public string Timezone { get; set; }

        public string Name { get; set; }
    }
}
