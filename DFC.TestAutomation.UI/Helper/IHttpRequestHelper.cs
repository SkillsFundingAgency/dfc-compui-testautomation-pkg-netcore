// <copyright file="IHttpRequestHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Net.Http;
using System.Threading.Tasks;

namespace DFC.TestAutomation.UI.Helper
{
    /// <summary>
    /// An interface containing definitions for all HTTP request related operations.
    /// </summary>
    public interface IHttpRequestHelper
    {
        /// <summary>
        /// Send a request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <returns>An HTTP response message.</returns>
        Task<HttpResponseMessage> Execute();
    }
}
