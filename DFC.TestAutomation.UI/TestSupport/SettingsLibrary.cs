using DFC.TestAutomation.UI.Settings;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class SettingsLibrary<T> : ISettingsLibrary<T>
        where T : IAppSettings
    {
        public SettingsLibrary()
        {
            var configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            configurationBuilder.AddEnvironmentVariables();
            var configurationRoot = configurationBuilder.Build();
            this.AppSettings = configurationRoot.GetSection("AppSettings").Get<T>();
            this.BrowserSettings = configurationRoot.GetSection("BrowserSettings").Get<BrowserSettings>();
            this.BrowserStackSettings = configurationRoot.GetSection("BrowserStackSettings").Get<BrowserStackSettings>();
            this.BuildSettings = configurationRoot.GetSection("BuildSettings").Get<BuildSettings>();
            this.EnvironmentSettings = configurationRoot.GetSection("EnvironmentSettings").Get<EnvironmentSettings>();
            this.MongoDatabaseSettings = configurationRoot.GetSection("MongoDatabaseSettings").Get<MongoDatabaseSettings>();
            this.TimeoutSettings = configurationRoot.GetSection("TimeoutSettings").Get<TimeoutSettings>();
        }

        public T AppSettings { get; private set; }

        public BrowserSettings BrowserSettings { get; set; }

        public BrowserStackSettings BrowserStackSettings { get; set; }

        public BuildSettings BuildSettings { get; set; }

        public EnvironmentSettings EnvironmentSettings { get; set; }

        public MongoDatabaseSettings MongoDatabaseSettings { get; set; }

        public TimeoutSettings TimeoutSettings { get; set; }
    }
}
