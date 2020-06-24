using DFC.TestAutomation.UI.Config;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Net;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class BrowserStackReport
    {
        public static void MarkTestAsFailed(BrowserStackSetting options, string sessionId, string message)
        {
            var client = Client(options);

            var request = Request(sessionId);

            request.AddJsonBody(JSonBody(message));

            var response = client.Put(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                NUnit.Framework.TestContext.Progress.WriteLine($"{response.StatusCode} - {response.Content}");

                throw new Exception(response.Content, response.ErrorException);
            }
        }

        private static RestClient Client(BrowserStackSetting options)
        {
            return new RestClient(options.AutomateSessions)
            {
                Authenticator = new HttpBasicAuthenticator(options.BrowserStackUser, options.BrowserStackKey)
            };
        }

        private static RestRequest Request(string sessionId)
        {
            return new RestRequest($"{sessionId}.json", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };
        }

        private static string JSonBody(string exceptionmessage)
        {
            return JsonConvert.SerializeObject(new { status = "failed", reason = exceptionmessage });
        }
    }
}
