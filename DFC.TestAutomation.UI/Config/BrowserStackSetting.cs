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

        public bool EnableNetworkLogs { get; set; }

        internal string TimeZone { get; set; }
    }
}
