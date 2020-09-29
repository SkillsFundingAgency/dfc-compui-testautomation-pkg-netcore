using System;

namespace DFC.TestAutomation.UI.Config
{
    public class ProjectConfig
    {
        public string Browser { get; set; }

        public Uri BaseUrl { get; set; }

        public string BuildNumber { get; set; }

        public string EnvironmentName { get; set; }

        public string ProjectName { get; set; }
    }
}
