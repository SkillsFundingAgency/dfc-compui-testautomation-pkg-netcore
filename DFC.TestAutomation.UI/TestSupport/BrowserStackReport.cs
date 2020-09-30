using DFC.TestAutomation.UI.Config;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Net;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class BrowserStackReport : IBrowserStackReport
    {
        public IRestRequest RestRequest { get; set; }
        public IRestClient RestClient { get; set; }

        public BrowserStackReport(BrowserStackConfiguration browserStackConfiguration, string remoteWebDriverSessionId)
        {
            this.RestClient = new RestClient(browserStackConfiguration.AutomateSessions)
            {
                Authenticator = new HttpBasicAuthenticator(browserStackConfiguration.BrowserStackUser, browserStackConfiguration.BrowserStackKey)
            };

            this.RestRequest = new RestRequest($"{remoteWebDriverSessionId}.json", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };
        }

        public void MarkTestAsFailed(string message)
        {
            var body = JsonConvert.SerializeObject(new { status = "failed", reason = message });
            this.RestRequest.AddJsonBody(body);
            this.RestClient.Put(this.RestRequest);
        }
    }
}
