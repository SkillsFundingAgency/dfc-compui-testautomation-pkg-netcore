using Microsoft.Extensions.Configuration;
using System.IO;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class Configurator : IConfigurator
    {
        public IConfigurationRoot configurationRoot { get; private set; }

        public bool IsExecutingInVSTS
        {
            get
            {
                return !string.IsNullOrEmpty(configurationRoot.GetSection("AGENT_MACHINENAME")?.Value);
            }
        }

        public string EnvironmentName
        {
            get
            {
                return IsExecutingInVSTS ? configurationRoot.GetSection("RELEASE_ENVIRONMENTNAME")?.Value : configurationRoot.GetSection("EnvironmentName")?.Value;
            }
        }

        public string ProjectName
        {
            get
            {
                return configurationRoot.GetSection("ProjectName").Value;
            }
        }

        public Configurator()
        {
            var configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            configurationBuilder.AddEnvironmentVariables();
            configurationRoot = configurationBuilder.Build();
        }
    }
}
