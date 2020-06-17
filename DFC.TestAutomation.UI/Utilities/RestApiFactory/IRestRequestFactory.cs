using RestSharp;

namespace DFC.TestAutomation.UI.Utilities.RestApiFactory
{
    public interface IRestRequestFactory
    {
        IRestRequest Create();
    }
}
