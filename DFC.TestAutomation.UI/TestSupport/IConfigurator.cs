using Microsoft.Extensions.Configuration;

namespace DFC.TestAutomation.UI.TestSupport
{
    public interface IConfigurator<T>
    {
        T Data { get; }

        bool IsExecutingInVSTS { get; }

        string EnvironmentName { get; }

        string ProjectName { get; }
    }
}
