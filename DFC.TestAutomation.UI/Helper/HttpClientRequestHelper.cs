// <copyright file="HttpClientRequestHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DFC.TestAutomation.UI.Helper
{
    public class HttpClientRequestHelper : IHttpClientRequestHelper
    {
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

        private HttpClient Client { get; set; }

        private string AccessToken { get; set; }

        public async Task<string> ExecuteHttpPostRequest(Uri requestUri, string postData)
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri) { Content = new StringContent(postData, Encoding.UTF8, "application/json") })
            {
                this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.AccessToken);
                var postRequestResponse = await this.Client.SendAsync(requestMessage).ConfigureAwait(false);
                var content = await postRequestResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                postRequestResponse.EnsureSuccessStatusCode();
                return content;
            }
        }

        public async Task<string> ExecuteHttpGetRequest(Uri requestUri)
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri))
            {
                this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.AccessToken);
                var getRequestResponse = await this.Client.SendAsync(requestMessage).ConfigureAwait(false);
                var content = await getRequestResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                getRequestResponse.EnsureSuccessStatusCode();
                return content;
            }
        }

        public async Task<string> ExecuteHttpPutRequest(Uri requestUri, string putData)
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Put, requestUri) { Content = new StringContent(putData, Encoding.UTF8, "application/json") })
            {
                this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.AccessToken);
                var putRequestResponse = await this.Client.SendAsync(requestMessage).ConfigureAwait(false);
                var content = await putRequestResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                putRequestResponse.EnsureSuccessStatusCode();
                return content;
            }
        }

        public async Task ExecuteHttpDeleteRequest(Uri requestUri, string deleteData)
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Delete, requestUri) { Content = new StringContent(deleteData, Encoding.UTF8, "application/json") })
            {
                this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.AccessToken);
                var deleteRequestResponse = await this.Client.SendAsync(requestMessage).ConfigureAwait(false);
                requestMessage.Dispose();
                deleteRequestResponse.EnsureSuccessStatusCode();
            }
        }

        public async Task<string> ExecuteHttpPatchRequest(Uri requestUri, string patchData)
        {
            using (var requestMessage = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri) { Content = new StringContent(patchData, Encoding.UTF8, "application/json") })
            {
                this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.AccessToken);

                HttpResponseMessage patchRequestResponse = await this.Client.SendAsync(requestMessage).ConfigureAwait(false);
                string content = await patchRequestResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                patchRequestResponse.EnsureSuccessStatusCode();
                return content;
            }
        }
    }
}
