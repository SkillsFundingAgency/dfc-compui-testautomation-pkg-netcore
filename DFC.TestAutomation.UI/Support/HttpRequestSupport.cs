// <copyright file="HttpRequestSupport.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DFC.TestAutomation.UI.Support
{
    /// <summary>
    /// Provides support functions for all HTTP request related operations.
    /// </summary>
    public class HttpRequestSupport<T> : IHttpRequestSupport, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestSupport{T}"/> class.
        /// </summary>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="requestUrl">The HTTP request url.</param>
        public HttpRequestSupport(HttpMethod httpMethod, Uri requestUrl)
        {
            this.Client = new HttpClient();
            this.RequestMessage = CreateRequestMessage(httpMethod, requestUrl);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestSupport{T}"/> class.
        /// </summary>
        /// <param name="networkCredentials">The network credentials.</param>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="requestUrl">The HTTP request url.</param>
        public HttpRequestSupport(NetworkCredential networkCredentials, HttpMethod httpMethod, Uri requestUrl)
        {
            this.Client = new HttpClient();
            this.RequestMessage = CreateRequestMessage(httpMethod, requestUrl);
            this.AddNetworkCredentials(networkCredentials);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestSupport{T}"/> class.
        /// </summary>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="requestUrl">The HTTP request url.</param>
        /// <param name="content">The HTTP request message content.</param>
        public HttpRequestSupport(HttpMethod httpMethod, Uri requestUrl, T content)
        {
            this.Client = new HttpClient();
            this.CreateHttpMessageContentFromObject(content);
            this.CreateHttpRequestMessage(httpMethod, requestUrl, this.MessageContent);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestSupport{T}"/> class.
        /// </summary>
        /// <param name="networkCredentials">The network credentials.</param>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="requestUrl">The HTTP request url.</param>
        /// <param name="content">The HTTP request message content.</param>
        public HttpRequestSupport(NetworkCredential networkCredentials, HttpMethod httpMethod, Uri requestUrl, T content)
        {
            this.Client = new HttpClient();
            this.CreateHttpMessageContentFromObject(content);
            this.CreateHttpRequestMessage(httpMethod, requestUrl, this.MessageContent);
            this.AddNetworkCredentials(networkCredentials);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestSupport{T}"/> class.
        /// </summary>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="requestUrl">The HTTP request url.</param>
        /// <param name="content">The HTTP message content.</param>
        /// <param name="headers">The HTTP message headers.</param>
        public HttpRequestSupport(HttpMethod httpMethod, Uri requestUrl, T content, IEnumerable<KeyValuePair<string, string>> headers)
        {
            this.Client = new HttpClient();
            this.CreateHttpMessageContentFromObject(content);
            this.CreateHttpRequestMessage(httpMethod, requestUrl, this.MessageContent);

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    this.RequestMessage.Headers.Add(header.Key, header.Value);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestSupport{T}"/> class.
        /// </summary>
        /// <param name="networkCredentials">The network credentials.</param>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="requestUrl">The HTTP request url.</param>
        /// <param name="content">The HTTP message content.</param>
        /// <param name="headers">The HTTP message headers.</param>
        public HttpRequestSupport(NetworkCredential networkCredentials, HttpMethod httpMethod, Uri requestUrl, T content, IEnumerable<KeyValuePair<string, string>> headers)
        {
            this.Client = new HttpClient();
            this.CreateHttpMessageContentFromObject(content);
            this.CreateHttpRequestMessage(httpMethod, requestUrl, this.MessageContent);

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    this.RequestMessage.Headers.Add(header.Key, header.Value);
                }
            }

            this.AddNetworkCredentials(networkCredentials);
        }

        private bool Disposed { get; set; }

        private HttpClient Client { get; set; }

        private HttpRequestMessage RequestMessage { get; set; }

        private ByteArrayContent MessageContent { get; set; }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Send a request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <returns>An HTTP response message.</returns>
        public async Task<HttpResponseMessage> Execute()
        {
            return await this.Client.SendAsync(this.RequestMessage).ConfigureAwait(false);
        }

        /// <summary>
        /// Protected implementation of the Dispose pattern.
        /// </summary>
        /// <param name="disposing">Boolean to indicate whether to dispose of managed objects.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.Disposed)
            {
                return;
            }

            if (disposing)
            {
                this.RequestMessage.Dispose();
            }

            this.Disposed = true;
        }

        private static HttpRequestMessage CreateRequestMessage(HttpMethod httpMethod, Uri requestUrl)
        {
            return new HttpRequestMessage(httpMethod, requestUrl);
        }

        private void CreateHttpRequestMessage(HttpMethod httpMethod, Uri requestUrl, HttpContent httpContent)
        {
            var requestMessage = CreateRequestMessage(httpMethod, requestUrl);
            requestMessage.Content = httpContent;
            this.RequestMessage = requestMessage;
        }

        private void CreateHttpMessageContentFromObject(T content)
        {
            var jsonContent = JsonConvert.SerializeObject(content);
            var byteContent = Encoding.UTF8.GetBytes(jsonContent);
            this.MessageContent = new ByteArrayContent(byteContent);
            this.MessageContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
        }

        private void AddNetworkCredentials(NetworkCredential networkCredential)
        {
            var byteArray = Encoding.ASCII.GetBytes(networkCredential?.UserName + ":" + networkCredential?.Password);
            this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }
    }
}
