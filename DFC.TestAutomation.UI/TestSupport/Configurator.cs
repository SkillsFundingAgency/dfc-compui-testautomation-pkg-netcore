using Microsoft.Extensions.Configuration;
using System.IO;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class Configurator<T> : IConfigurator<T>
    {
        public T Data { get; private set; }

        private IConfigurationRoot ConfigurationRoot { get; set; }

        public bool IsExecutingInVSTS
        {
            get
            {
                return !string.IsNullOrEmpty(ConfigurationRoot.GetSection("AGENT_MACHINENAME")?.Value);
            }
        }

        public string EnvironmentName
        {
            get
            {
                return IsExecutingInVSTS ? ConfigurationRoot.GetSection("RELEASE_ENVIRONMENTNAME")?.Value : ConfigurationRoot.GetSection("EnvironmentName")?.Value;
            }
        }

        public string ProjectName
        {
            get
            {
                return ConfigurationRoot.GetSection("ProjectName").Value;
            }
        }

        public Configurator()
        {
            var configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            configurationBuilder.AddEnvironmentVariables();
            ConfigurationRoot = configurationBuilder.Build();
            Data = ConfigurationRoot.Get<T>();
        }
    }
}
