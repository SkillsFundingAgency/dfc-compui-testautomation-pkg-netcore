using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DFC.TestAutomation.UI.Helper
{
    public class HttpClientRequestHelper : IHttpClientRequestHelper
    {
        private HttpClient Client { get; set; }

        private string RequestUri { get; set; }

        private string AccessToken { get; set; }

        public HttpClientRequestHelper(string requestUri)
        {
            this.Client = new HttpClient();
            this.RequestUri = requestUri;
            this.AccessToken = string.Empty;
        }

        public HttpClientRequestHelper(string requestUri, string accessToken)
        {
            this.Client = new HttpClient();
            this.RequestUri = requestUri;
            this.AccessToken = accessToken;
        }

        public async Task<string> ExecuteHttpPostRequest(string postData)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, this.RequestUri)
            {
                Content = new StringContent(postData, Encoding.UTF8, "application/json")
            };

            this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.AccessToken);

            var postRequestResponse = await Client.SendAsync(requestMessage);
            var content = await postRequestResponse.Content.ReadAsStringAsync();
            postRequestResponse.EnsureSuccessStatusCode();
            return content;
        }

        public async Task<string> ExecuteHttpGetRequest()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, this.RequestUri);
            this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.AccessToken);
            var getRequestResponse = await Client.SendAsync(requestMessage);
            var content = await getRequestResponse.Content.ReadAsStringAsync();
            getRequestResponse.EnsureSuccessStatusCode();
            return content;
        }

        public async Task<string> ExecuteHttpPutRequest(string putData)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, this.RequestUri)
            {
                Content = new StringContent(putData, Encoding.UTF8, "application/json")
            };

            this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.AccessToken);

            var putRequestResponse = await Client.SendAsync(requestMessage);
            var content = await putRequestResponse.Content.ReadAsStringAsync();
            putRequestResponse.EnsureSuccessStatusCode();
            return content;
        }

        public async Task ExecuteHttpDeleteRequest(string deleteData)
        {
            HttpRequestMessage requestMessage;
            if (string.IsNullOrEmpty(deleteData))
            {
                requestMessage = new HttpRequestMessage(HttpMethod.Delete, this.RequestUri);
            }
            else
            {
                requestMessage = new HttpRequestMessage(HttpMethod.Delete, this.RequestUri)
                {
                    Content = new StringContent(deleteData, Encoding.UTF8, "application/json")
                };

                this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.AccessToken);
                var deleteRequestResponse = await Client.SendAsync(requestMessage);
                deleteRequestResponse.EnsureSuccessStatusCode();
            }
        }

        public async Task<string> ExecuteHttpPatchRequest(string patchData)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("PATCH"), this.RequestUri)
            {
                Content = new StringContent(patchData, Encoding.UTF8, "application/json")
            };

            this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.AccessToken);

            HttpResponseMessage patchRequestResponse = await Client.SendAsync(requestMessage);
            string content = await patchRequestResponse.Content.ReadAsStringAsync();
            patchRequestResponse.EnsureSuccessStatusCode();
            return content;
        }
    }
}
