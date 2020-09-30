using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DFC.TestAutomation.UI.Helper
{
    public class HttpClientRequestHelper : IHttpClientRequestHelper
    {
        private HttpClient Client { get; set; }

        private string AccessToken { get; set; }

        public HttpClientRequestHelper()
        {
            this.Client = new HttpClient();
            this.AccessToken = string.Empty;
        }

        public HttpClientRequestHelper(string accessToken)
        {
            this.Client = new HttpClient();
            this.AccessToken = accessToken;
        }

        public async Task<string> ExecuteHttpPostRequest(string requestUri, string postData)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = new StringContent(postData, Encoding.UTF8, "application/json")
            };

            this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.AccessToken);

            var postRequestResponse = await Client.SendAsync(requestMessage);
            var content = await postRequestResponse.Content.ReadAsStringAsync();
            postRequestResponse.EnsureSuccessStatusCode();
            return content;
        }

        public async Task<string> ExecuteHttpGetRequest(string requestUri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.AccessToken);
            var getRequestResponse = await Client.SendAsync(requestMessage);
            var content = await getRequestResponse.Content.ReadAsStringAsync();
            getRequestResponse.EnsureSuccessStatusCode();
            return content;
        }

        public async Task<string> ExecuteHttpPutRequest(string requestUri, string putData)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, requestUri)
            {
                Content = new StringContent(putData, Encoding.UTF8, "application/json")
            };

            this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.AccessToken);

            var putRequestResponse = await Client.SendAsync(requestMessage);
            var content = await putRequestResponse.Content.ReadAsStringAsync();
            putRequestResponse.EnsureSuccessStatusCode();
            return content;
        }

        public async Task ExecuteHttpDeleteRequest(string requestUri, string deleteData)
        {
            HttpRequestMessage requestMessage;
            if (string.IsNullOrEmpty(deleteData))
            {
                requestMessage = new HttpRequestMessage(HttpMethod.Delete, requestUri);
            }
            else
            {
                requestMessage = new HttpRequestMessage(HttpMethod.Delete, requestUri)
                {
                    Content = new StringContent(deleteData, Encoding.UTF8, "application/json")
                };

                this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.AccessToken);
                var deleteRequestResponse = await Client.SendAsync(requestMessage);
                deleteRequestResponse.EnsureSuccessStatusCode();
            }
        }

        public async Task<string> ExecuteHttpPatchRequest(string requestUri, string patchData)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri)
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
