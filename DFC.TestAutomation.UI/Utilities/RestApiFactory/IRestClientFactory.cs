using RestSharp;

namespace DFC.TestAutomation.UI.Utilities.RestApiFactory
{
    public interface IRestClientFactory
    {
        IRestClient Create();
    }
}
