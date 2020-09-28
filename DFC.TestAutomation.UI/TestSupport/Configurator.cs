using Microsoft.Extensions.Configuration;
using System.IO;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class Configurator
    {
        public IConfigurationRoot configurationRoot { get; private set; }

        public bool IsExecutingInVSTS => !string.IsNullOrEmpty(configurationRoot.GetSection("AGENT_MACHINENAME")?.Value);

        public string EnvironmentName => IsExecutingInVSTS ? configurationRoot.GetSection("RELEASE_ENVIRONMENTNAME")?.Value : configurationRoot.GetSection("EnvironmentName")?.Value;

        public string ProjectName => configurationRoot.GetSection("ProjectName").Value;

        public Configurator()
        {
            var configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            configurationBuilder.AddEnvironmentVariables();
            configurationRoot = configurationBuilder.Build();
        }
    }
}
