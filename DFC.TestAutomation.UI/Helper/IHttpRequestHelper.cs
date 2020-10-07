// <copyright file="IHttpRequestHelper.cs" company="National Careers Service">
// Copyright (c) National Careers Service. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
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
