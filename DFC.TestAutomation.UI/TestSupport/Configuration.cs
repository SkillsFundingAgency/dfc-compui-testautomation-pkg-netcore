using DFC.TestAutomation.UI.Settings;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class Configuration<T> : IConfiguration<T> where T : IAppSettings
    {
        public T AppSettings { get; private set; }

        public BrowserSettings BrowserSettings { get; set; }

        public BrowserStackSettings BrowserStackSettings { get; set; }
        
        public BuildSettings BuildSettings { get; set; }
        
        public EnvironmentSettings EnvironmentSettings { get; set; }
        
        public MongoDatabaseSettings MongoDatabaseSettings { get; set; }
        
        public TimeoutSettings TimeoutSettings { get; set; }

        public Configuration()
        {
            var configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            configurationBuilder.AddEnvironmentVariables();
            var configurationRoot = configurationBuilder.Build();
            this.AppSettings = configurationRoot.Get<T>();
            this.BrowserSettings = configurationRoot.Get<BrowserSettings>();
            this.BrowserStackSettings = configurationRoot.Get<BrowserStackSettings>();
            this.BuildSettings = configurationRoot.Get<BuildSettings>();
            this.EnvironmentSettings = configurationRoot.Get<EnvironmentSettings>();
            this.MongoDatabaseSettings = configurationRoot.Get<MongoDatabaseSettings>();
            this.TimeoutSettings = configurationRoot.Get<TimeoutSettings>();
        }
    }
}
