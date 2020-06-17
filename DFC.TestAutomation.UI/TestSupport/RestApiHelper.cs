using DFC.TestAutomation.UI.Utilities.RestApiFactory;
using RestSharp;
using System.Threading.Tasks;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class RestApiHelper
    {
        private IRestClientFactory RestClientFactory { get; set; }
        private IRestRequestFactory RestRequestFactory { get; set; }

        public RestApiHelper(IRestClientFactory restClientFactory, IRestRequestFactory restRequestFactory)
        {
            this.RestClientFactory = restClientFactory;
            this.RestRequestFactory = restRequestFactory;
        }

        public async Task<IRestResponse<T>> ExecuteAsync<T>()
        {
            return await this.RestClientFactory.Create().ExecuteAsync<T>(this.RestRequestFactory.Create());
        }
    }
}
