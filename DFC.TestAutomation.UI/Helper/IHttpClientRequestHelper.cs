// <copyright file="IHttpClientRequestHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;

namespace DFC.TestAutomation.UI.Helper
{
    public interface IHttpClientRequestHelper
    {
        Task<string> ExecuteHttpPostRequest(Uri requestUri, string postData);

        Task<string> ExecuteHttpGetRequest(Uri requestUri);

        Task<string> ExecuteHttpPutRequest(Uri requestUri, string putData);

        Task ExecuteHttpDeleteRequest(Uri requestUri, string deleteData);

        Task<string> ExecuteHttpPatchRequest(Uri requestUri, string patchData);
    }
}
