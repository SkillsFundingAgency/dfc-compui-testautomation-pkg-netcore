// <copyright file="IHttpRequestHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Net.Http;
using System.Threading.Tasks;

namespace DFC.TestAutomation.UI.Helper
{
    public interface IHttpRequestHelper
    {
        Task<HttpResponseMessage> Execute();
    }
}
