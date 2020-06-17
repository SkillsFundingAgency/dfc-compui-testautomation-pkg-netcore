using RestSharp;
using System;

namespace DFC.TestAutomation.UI.Utilities.RestApiFactory
{
    public class RestClientFactory : IRestClientFactory
    {
        public Uri BaseUrl { get; set; }

        public RestClientFactory(Uri baseUrl)
        {
            this.BaseUrl = baseUrl;
        }

        public RestClientFactory(string baseUrl)
        {
            this.BaseUrl = new Uri(baseUrl);
        }

        public IRestClient Create()
        {
            return new RestClient(this.BaseUrl);
        }
    }
}
