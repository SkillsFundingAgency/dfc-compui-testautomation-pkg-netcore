using RestSharp;
using System.Collections.Generic;

namespace DFC.TestAutomation.UI.Utilities.RestApiFactory
{
    public class RestRequestFactory : IRestRequestFactory
    {
        private string Resource { get; set; }
        private Method? Method { get; set; }
        private Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        private object RequestBody { get; set; }

        public RestRequestFactory(string resource, Method method)
        {
            this.Resource = resource;
            this.Method = method;
        }

        public RestRequestFactory(string resource)
        {
            this.Resource = resource;
        }

        public IRestRequest Create()
        {
            RestRequest restRequest;

            if(this.Method == null)
            {
                restRequest = new RestRequest(this.Resource);
            } else
            {
                restRequest = new RestRequest(this.Resource, (Method)this.Method);
            }

            foreach(KeyValuePair<string, string> header in this.Headers)
            {
                restRequest.AddHeader(header.Key, header.Value);
            }

            if(this.RequestBody != null)
            {
                restRequest.AddJsonBody(this.RequestBody);
            }

            return restRequest;
        }

        public void SetHeaders(Dictionary<string, string> headers)
        {
            foreach(KeyValuePair<string, string> header in headers)
            {
                SetHeader(header.Key, header.Value);
            }
        }

        public void SetHeader(string key, string value)
        {
            if(this.Headers.ContainsKey(key))
            {
                this.Headers[key] = value;
            } else
            {
                this.Headers.Add(key, value);
            }
        }

        public void AddBody(object bodyContent)
        {
            this.RequestBody = bodyContent;
        }
    }
}
