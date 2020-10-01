using DFC.TestAutomation.UI.Settings;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Net;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class BrowserStackReporter : IBrowserStackReporter
    {
        public IRestRequest RestRequest { get; set; }
        public IRestClient RestClient { get; set; }

        public BrowserStackReporter(BrowserStackSettings browserStackConfiguration, string remoteWebDriverSessionId)
        {
            this.RestClient = new RestClient(browserStackConfiguration.BaseUri)
            {
                Authenticator = new HttpBasicAuthenticator(browserStackConfiguration.BrowserStackUsername, browserStackConfiguration.BrowserStackPassword)
            };

            this.RestRequest = new RestRequest($"{remoteWebDriverSessionId}.json", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };
        }

        public void SendMessage(string status, string message)
        {
            var body = JsonConvert.SerializeObject(new { status, reason = message });
            this.RestRequest.AddJsonBody(body);
            this.RestClient.Put(this.RestRequest);
        }
    }
}
