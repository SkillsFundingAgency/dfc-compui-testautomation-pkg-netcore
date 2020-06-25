using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DFC.TestAutomation.UI.TestSupport
{
    public  class Configurator
    {
        private  IConfigurationBuilder _builder;
        
        private  IConfigurationRoot _config;

        private  IConfigurationRoot _hostingConfig;

        public  bool IsVstsExecution { get; set; }

        public  string EnvironmentName { get; set; }

        public  string ProjectName { get; set; }

        public Configurator()
        {
            _builder = ConfigurationBuilder();
        }

        public  IConfigurationRoot GetConfig() => _config;

        /// <summary>
        /// Add an appsetting json file to configuration before build it
        /// </summary>
        /// <param name="fileName">Name of an appsettings file that is located in the project (relative to the base path) eg "appsettings.json"</param>
        /// <returns></returns>
        public Configurator AddSettingsFile(string fileName)
        {
            _builder.AddJsonFile(fileName, true);
            return this;
        }

        /// <summary>
        /// Build the configuration once app settings files have been added
        /// </summary>
        /// <returns></returns>
        public IConfigurationRoot BuildConfig()
        {
            _config = _builder.AddEnvironmentVariables()
                              .Build();
            return _config;
        }

        /// <summary>
        /// Supply a hosting appsettings file and build the hosting configuration
        /// </summary>
        /// <param name="fileName">Name of an appsettings file that is located in the project (relative to the base path) eg "environmentSettings.json"</param>
        /// <returns></returns>
        public IConfigurationRoot BuildHostingConfig(string fileName)
        {
            _hostingConfig = ConfigurationBuilder()
                 .AddJsonFile(fileName, true)
                .AddEnvironmentVariables()
                .Build();
            IsVstsExecution = TestsExecutionInVsts();
            EnvironmentName = GetEnvironmentName();
            ProjectName = GetProjectName();
            return _hostingConfig;
        }


        private  IConfigurationBuilder ConfigurationBuilder() => new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());

        private  bool TestsExecutionInVsts() => !string.IsNullOrEmpty(GetAgentMachineName());

        private  string GetAgentMachineName() => GetHostingConfigSection("AGENT_MACHINENAME");

        private  string GetEnvironmentName() => IsVstsExecution ? GetHostingConfigSection("RELEASE_ENVIRONMENTNAME") : GetHostingConfigSection("EnvironmentName");

        private  string GetProjectName() => GetHostingConfigSection("ProjectName");

        private  string GetHostingConfigSection(string name) => _hostingConfig.GetSection(name)?.Value;
    }
}
