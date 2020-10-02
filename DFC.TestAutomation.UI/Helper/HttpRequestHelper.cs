﻿// <copyright file="HttpRequestHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// Provides helper functions for all HTTP request related operations.
    /// </summary>
    public class HttpRequestHelper<T> : IHttpRequestHelper, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestHelper{T}"/> class.
        /// </summary>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="requestUrl">The HTTP request url.</param>
        public HttpRequestHelper(HttpMethod httpMethod, Uri requestUrl)
        {
            this.Client = new HttpClient();
            this.RequestMessage = CreateRequestMessage(httpMethod, requestUrl);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestHelper{T}"/> class.
        /// </summary>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="requestUrl">The HTTP request url.</param>
        /// <param name="content">The HTTP request message content.</param>
        public HttpRequestHelper(HttpMethod httpMethod, Uri requestUrl, T content)
        {
            this.Client = new HttpClient();
            var messageContent = GetHttpContentFromObject(content);
            this.RequestMessage = CreateRequestMessage(httpMethod, requestUrl, messageContent);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestHelper{T}"/> class.
        /// </summary>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="requestUrl">The HTTP request url.</param>
        /// <param name="content">The HTTP message content.</param>
        /// <param name="headers">The HTTP message headers.</param>
        public HttpRequestHelper(HttpMethod httpMethod, Uri requestUrl, T content, IEnumerable<KeyValuePair<string, string>> headers)
        {
            this.Client = new HttpClient();
            var messageContent = GetHttpContentFromObject(content);
            this.RequestMessage = CreateRequestMessage(httpMethod, requestUrl, messageContent);

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    this.RequestMessage.Headers.Add(header.Key, header.Value);
                }
            }
        }

        private bool Disposed { get; set; }

        private HttpClient Client { get; set; }

        private HttpRequestMessage RequestMessage { get; set; }

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

        private static HttpRequestMessage CreateRequestMessage(HttpMethod httpMethod, Uri requestUrl, HttpContent httpContent)
        {
            var requestMessage = CreateRequestMessage(httpMethod, requestUrl);
            requestMessage.Content = httpContent;
            return requestMessage;
        }

        private static HttpContent GetHttpContentFromObject(T content)
        {
            var jsonContent = JsonConvert.SerializeObject(content);
            var byteContent = Encoding.UTF8.GetBytes(jsonContent);

            using (var messageContent = new ByteArrayContent(byteContent))
            {
                messageContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return messageContent;
            }
        }
    }
}