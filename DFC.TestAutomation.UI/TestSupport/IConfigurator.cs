using Microsoft.Extensions.Configuration;

namespace DFC.TestAutomation.UI.TestSupport
{
    public interface IConfigurator
    {
        IConfigurationRoot configurationRoot { get; }

        bool IsExecutingInVSTS { get; }

        string EnvironmentName { get; }

        string ProjectName { get; }
    }
}
