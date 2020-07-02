using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.TestAutomation.UI.Config
{
    public class BrowserStackSetting
    {
        public string BrowserStackUser { get; set; }

        public string BrowserStackKey { get; set; }

        public string Browser { get; set; }

        public string ServerName => "http://hub-cloud.browserstack.com/wd/hub/";

        public string AutomateSessions => "https://www.browserstack.com/automate/sessions/";

        public string BuildNumber { get; set; }

        public string Project { get; set; }

        public string Os { get; set; }

        public string Osversion { get; set; }

        public string BrowserVersion { get; set; }

        public string Resolution { get; set; }

        public string Name { get; set; }

        public bool EnableNetworkLogs { get; set; }

        internal string TimeZone => "London";
    }
}
