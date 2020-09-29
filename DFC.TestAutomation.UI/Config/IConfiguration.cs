namespace DFC.TestAutomation.UI.Config
{
    public interface IConfiguration
    {
        ProjectConfiguration ProjectConfiguration { get; set; }

        BuildConfiguration BuildConfiguration { get; set; }

        BrowserConfiguration BrowserConfiguration { get; set; }

        TimeoutConfiguration TimeoutConfiguration { get; set; }

        BrowserStackConfiguration BrowserStackConfiguration { get; set; }

        EnvironmentConfiguration EnvironmentConfiguration { get; set; }

        MongoDatabaseConfiguration MongoDatabaseConfiguration { get; set; }
    }
}
