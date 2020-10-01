using DFC.TestAutomation.UI.Settings;

namespace DFC.TestAutomation.UI.TestSupport
{
    public interface IConfiguration<T>
    {
        public T AppSettings { get; }

        public BrowserSettings BrowserSettings { get; }

        public BrowserStackSettings BrowserStackSettings { get; }

        public BuildSettings BuildSettings { get; }

        public EnvironmentSettings EnvironmentSettings { get; }

        public MongoDatabaseSettings MongoDatabaseSettings { get; }

        public TimeoutSettings TimeoutSettings { get; }
    }
}
