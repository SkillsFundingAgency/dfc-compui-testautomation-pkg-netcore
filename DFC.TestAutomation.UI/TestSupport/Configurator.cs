using Microsoft.Extensions.Configuration;
using System.IO;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class Configurator<T> : IConfigurator<T> where T : Config.IConfiguration
    {
        public T Configuration { get; private set; }

        public Configurator()
        {
            var configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            configurationBuilder.AddEnvironmentVariables();
            var configurationRoot = configurationBuilder.Build();
            Configuration = configurationRoot.Get<T>();
        }
    }
}
