using Microsoft.Extensions.Configuration;

namespace DFC.TestAutomation.UI.TestSupport
{
    public interface IConfigurator<T>
    {
        T Configuration { get; }
    }
}
