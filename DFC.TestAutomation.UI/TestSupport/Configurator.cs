using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DFC.TestAutomation.UI.TestSupport
{
    internal static class Configurator
    {
        private readonly static IConfigurationRoot _config;

        private readonly static IConfigurationRoot _hostingConfig;

        internal readonly static bool IsVstsExecution;

        internal readonly static string EnvironmentName;

        internal readonly static string ProjectName;

        static Configurator()
        {
            _hostingConfig = InitializeHostingConfig();
            IsVstsExecution = TestsExecutionInVsts();
            EnvironmentName = GetEnvironmentName();
            ProjectName = GetProjectName();
            _config = InitializeConfig();
        }

        internal static IConfigurationRoot GetConfig() => _config;

        private static IConfigurationRoot InitializeConfig()
        {
            //var EnvironmentName = _hostingConfig.GetSection("Release_EnvironmentName").Value;
            //var ProjectName = _hostingConfig.GetSection("ProjectName").Value;

            return ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true)
            .AddJsonFile("appsettings.Project.json", true)
            .AddJsonFile("appsettings.local.Project.json", true)
            .AddJsonFile("appsettings.local.json", true)
            .AddJsonFile("appsettings.RestApi.json", true)
            .AddEnvironmentVariables()
            //.AddUserSecrets("BrowserStackSecrets")
            //.AddUserSecrets($"{ProjectName}_{EnvironmentName}_Secrets")
            //.AddUserSecrets("MongoDbSecrets")
            .Build();
        }

        private static IConfigurationRoot InitializeHostingConfig() => ConfigurationBuilder()
                .AddJsonFile("appsettings.Environment.json", true)
                .AddEnvironmentVariables()
                .Build();

        private static IConfigurationBuilder ConfigurationBuilder() => new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());

        private static bool TestsExecutionInVsts() => !string.IsNullOrEmpty(GetAgentMachineName());

        private static string GetAgentMachineName() => GetHostingConfigSection("AGENT_MACHINENAME");

        private static string GetEnvironmentName() => IsVstsExecution ? GetHostingConfigSection("RELEASE_ENVIRONMENTNAME") : GetHostingConfigSection("EnvironmentName");

        private static string GetProjectName() => GetHostingConfigSection("ProjectName");

        private static string GetHostingConfigSection(string name) => _hostingConfig.GetSection(name)?.Value;
    }
}
