// <copyright file="BrowserStackReporter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using DFC.TestAutomation.UI.Settings;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class BrowserStackReporter : IBrowserStackReporter
    {
        public BrowserStackReporter(BrowserStackSettings browserStackConfiguration, string remoteWebDriverSessionId)
        {
            this.RestClient = new RestClient(browserStackConfiguration?.BaseUri)
            {
                Authenticator = new HttpBasicAuthenticator(browserStackConfiguration.BrowserStackUsername, browserStackConfiguration.BrowserStackPassword),
            };

            this.RestRequest = new RestRequest($"{remoteWebDriverSessionId}.json", Method.PUT)
            {
                RequestFormat = DataFormat.Json,
            };
        }

        public IRestRequest RestRequest { get; set; }

        public IRestClient RestClient { get; set; }

        public void SendMessage(string status, string message)
        {
            var body = JsonConvert.SerializeObject(new { status, reason = message });
            this.RestRequest.AddJsonBody(body);
            this.RestClient.Put(this.RestRequest);
        }
    }
}
