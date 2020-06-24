using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DFC.TestAutomation.UI.TestSupport
{
    public static class Configurator
    {
        private static IConfigurationRoot _config;

        private static IConfigurationRoot _hostingConfig;

        public static bool IsVstsExecution { get; set; }

        public static string EnvironmentName { get; set; }

        public static string ProjectName { get; set; }

        public static IConfigurationRoot GetConfig() => _config;

        public static IConfigurationRoot InitializeConfig(string[] settingsFiles)
        {
            var config = ConfigurationBuilder();
            foreach (var file in settingsFiles)
            {
                config.AddJsonFile(file, true);
            }
            config.AddEnvironmentVariables();
            _config = config.Build();
            return _config;
        }

        public static void InitializeHostingConfig(string settingsFile)
        {
            _hostingConfig = ConfigurationBuilder()
                 .AddJsonFile(settingsFile, true)
                .AddEnvironmentVariables()
                .Build();
            IsVstsExecution = TestsExecutionInVsts();
            EnvironmentName = GetEnvironmentName();
            ProjectName = GetProjectName();
        }


        private static IConfigurationBuilder ConfigurationBuilder() => new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());

        private static bool TestsExecutionInVsts() => !string.IsNullOrEmpty(GetAgentMachineName());

        private static string GetAgentMachineName() => GetHostingConfigSection("AGENT_MACHINENAME");

        private static string GetEnvironmentName() => IsVstsExecution ? GetHostingConfigSection("RELEASE_ENVIRONMENTNAME") : GetHostingConfigSection("EnvironmentName");

        private static string GetProjectName() => GetHostingConfigSection("ProjectName");

        private static string GetHostingConfigSection(string name) => _hostingConfig.GetSection(name)?.Value;
    }
}
